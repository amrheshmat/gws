using Microsoft.Extensions.Configuration;
using MWS.Business.Malath.lease.IBusiness;
using MWS.Business.Malath.lease.Models;
using MWS.Business.Shared.Business;
using MWS.Business.Shared.Data.Models;
using MWS.Business.Shared.IBusiness;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using MWS.Repository;

namespace MWS.Business.Malath.lease.Business
{
    public delegate void inputFunction();
    public class QuotationBusiness : IQuotationBusiness
    {
        #region fields
        private readonly IConfiguration _config;
        private IDateConverter _dateConverter;
        private ILeaseCaching _cache;
        private ILoggerHandler<QuotationBusiness> _logger;
        private ICommon _common;
        private IRepository _repo;
        private IClearString _clearString;
        #endregion
        #region Constructor(s)
        public QuotationBusiness(IConfiguration config, IRepositoryFactory repository, IDateConverter dateConverter, ILeaseCaching cache, ILoggerHandler<QuotationBusiness> logger, ICommon common, IClearString clearString)
        {
            _dateConverter = dateConverter;
            _cache = cache;
            _logger = logger;
            _common = common;
            _repo = repository.Create("AGGRDB");
            _clearString = clearString;
            _config = config;
        }
        #endregion
        #region methods
        public async Task<AggrError> MapPartnerData(QuoteRequest quotesRequest, USERS appUser)
        {
            #region validate upload date and lessee id
            //upload date ...
            if (!string.IsNullOrWhiteSpace(quotesRequest.UploadDate))
            {
                var t = _dateConverter.DateToString(DateTime.Now.Date);
                DateTime dtSentDate = _dateConverter.ToDateTime(_dateConverter.HijriToGreg(t));
                DateTime startDate = DateTime.Now.Date;
                if (dtSentDate < startDate)
                {
                    return new AggrError("invalid", "UploadDate");
                }
            }
            var lookupDetails = await _cache.GetCachedLookupDetails();
            // lessee id 
            var aggrCrTypeCode = await getNotElmMalathCode("ID_TYPE_CODE", quotesRequest.DriverDetails[0].DriverID!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
            if (!new List<string>() { "1", "2", "3" }.Contains(aggrCrTypeCode))
            {
                return new AggrError("invalid", "lesseeID");
            }
            #endregion
            #region get setup
            lookupsOneValueModel lockData = null!;
            //get setup ...
            try
            {
                lockData = await GetNotListValues(appUser);
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new AggrError("Malath Setup is not complete for CR Number " + quotesRequest.LessorID + " Partner " + appUser.PARTNER_CODE + " CR Branch " + appUser.PARTNER_BRANCH, "CR_IQAMA_NO");
            }
            #endregion
            #region vehicle sum insured
            if (long.Parse(quotesRequest.VehicleSumInsured!) < lockData.VehMinValue)
            {
                return new AggrError("invalid", "VehicleSumInsured");
            }
            if (long.Parse(quotesRequest.VehicleSumInsured!) > lockData.VehMaxValue)
            {
                return new AggrError("invalid", "VehicleSumInsured");
            }
            #endregion
            #region manufacture year
            if (int.Parse(quotesRequest.ManufactureYear!) > (DateTime.Now.Year + 1))
            {
                return new AggrError("invalid", "ManufactureYear");
            }
            #endregion
            //TODO ...
            //VEH_DEFN_TYPE(custom or sequence) ,VEH_REG_EXP_DT
            #region mile age , engin , transmission and parking
            if (quotesRequest.VehicleMileage != null && (int.Parse(quotesRequest.VehicleMileage!) < 0 || quotesRequest.VehicleMileage.ToString()!.Length > 6))
            {
                return new AggrError("invalid", "VehicleMileage");
            }
            var expectedmileAge = await getNotElmMalathCode("MILEAGE", quotesRequest.VehicleExpectedMileageYear!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
            if (quotesRequest.VehicleExpectedMileageYear != null && expectedmileAge == null)
            {
                return new AggrError("invalid", "VehicleExpectedMileageYear");
            }
            quotesRequest.VehicleMileage = expectedmileAge;
            var engin = await getNotElmMalathCode("ENGINE", quotesRequest.VehicleEngineSizeCC!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
            if (!string.IsNullOrWhiteSpace(quotesRequest.VehicleEngineSizeCC.ToString()) && engin == null)
            {
                return new AggrError("invalid", "VehicleEngineSizeCC");
            }
            quotesRequest.VehicleEngineSizeCC = engin;//set mapped value ...
            var transmission = await getNotElmMalathCode("VEH_TRANS", quotesRequest.VehicleTransmission!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
            if (!string.IsNullOrWhiteSpace(quotesRequest.VehicleTransmission.ToString()) && string.IsNullOrWhiteSpace(transmission))
            {
                return new AggrError("invalid", "VehicleTransmission");
            }
            quotesRequest.VehicleTransmission = transmission;//set mapped value ...
            var parking = await getNotElmMalathCode("VEH_PARKING", quotesRequest.VehicleNightParking!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);

            if (!string.IsNullOrWhiteSpace(quotesRequest.VehicleNightParking.ToString()) && string.IsNullOrWhiteSpace(parking))
            {
                return new AggrError("invalid", "VehicleNightParking");
            }
            quotesRequest.VehicleNightParking = parking;//set mapped value ...
            #endregion
            #region Lessor city

            if (!string.IsNullOrWhiteSpace(quotesRequest.LessorCity))
            {
                string mappedCity = await getInsuredCityByElm(quotesRequest.LessorCity!.ToString()!);

                if (string.IsNullOrWhiteSpace(mappedCity) || mappedCity == "-1")
                {
                    new AggrError("invalid", "CITY");
                }
                else
                {
                    quotesRequest.LessorCity = mappedCity;// set mapped value ...
                }
            }

            #endregion
            #region make model bodytype

            int elmBodyType = 0;
            int.TryParse(quotesRequest.MalathVehicleBodyCode, out elmBodyType);

            ///try to map partner codes first
            var isMakeAggrCodes = await getAggrCodeLookup("MAKE", appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH);
            string elmVehicleMakeTextNIC = quotesRequest.VehicleMakeTextNIC!;
            if (isMakeAggrCodes.Any())
            {
                elmVehicleMakeTextNIC = await getNotElmMalathCode("MAKE", elmVehicleMakeTextNIC, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH);
                quotesRequest.MalathVehicleMake = elmVehicleMakeTextNIC;//set mapped value ...
            }

            var isModelAggrCodes = await getAggrCodeLookup("MODEL", appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH);
            string elmModelCode = quotesRequest.VehicleModelTextNIC!;
            if (isModelAggrCodes.Any())
            {
                elmModelCode = await getNotElmMalathCode("MODEL", elmModelCode, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH);
                quotesRequest.MalathVehicleModel = elmModelCode;//set mapped value ...
            }

            mapVehicle(quotesRequest
                , elmVehicleMakeTextNIC!
                , elmModelCode!
                , elmBodyType
                );

            #endregion make model bodytype
            #region Color
            var vehColor = await getNotElmMalathCode("CLR", quotesRequest.VehicleColorCode!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH);
            if (vehColor != null)
            {
                quotesRequest.MalathVehicleColor = vehColor;//set mapped value ...
            }

            if (string.IsNullOrWhiteSpace(quotesRequest.VehicleColorCode!.ToString()))
            {
                new AggrError("invalid", "COLOR");
            }
            #endregion Color
            #region DeriverMinAge
            //mappedQuoteModel.DeriverMinAge = "17";
            #endregion
            #region InsuredNationalityCode
            if (aggrCrTypeCode == "2")
            {
                var countryCode = await getMalathCountryCode(quotesRequest.DriverDetails[0].DriverNationalityID!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH);
                if (countryCode != null)
                {
                    quotesRequest.DriverDetails[0].DriverNationalityID = countryCode.ToString();
                }
            }
            else if (aggrCrTypeCode == "1")
            {
                var countryCode = await getMalathCountryCode("0", appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH);
                quotesRequest.DriverDetails[0].DriverNationalityID = countryCode.ToString();

            }
            #endregion
            #region driverDetails
            for (int i = 0; i < quotesRequest.DriverDetails.Count; i++)
            {
                var driver = quotesRequest.DriverDetails[0];
                #region VehUsageCode
                var vehUsage = lookupDetails.Where(x => x.MASTER_CODE == "ELM_VEH_USG" && x.DETAIL_CODE == driver.VehicleUsagePercentage && !string.IsNullOrWhiteSpace(x.MAPPED_CODE)).FirstOrDefault();
                if (vehUsage == null)
                {
                    return new AggrError("invalid", "VEHICLE_USAGE");
                }
                else
                {
                    driver.VehicleUsagePercentage = vehUsage.MAPPED_CODE;
                }
                #endregion
                #region Occupation
                var occupation = await getMalathOccupation(driver.DriverOccupation!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH);
                if (!string.IsNullOrWhiteSpace(driver.DriverOccupation) && string.IsNullOrWhiteSpace(occupation))
                {
                    return new AggrError("invalid", "DriverOccupation");
                }
                driver.DriverOccupation = occupation;//set mapped value ...
                #endregion
                #region birth date
                if (!string.IsNullOrWhiteSpace(driver.DriverDateOfBirthG))
                {
                    var birthDate = _dateConverter.GregToHijri(driver.DriverDateOfBirthG, "dd-MM-yyyy");
                    if (string.IsNullOrWhiteSpace(birthDate))
                    {
                        return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverDateOfBirthG");
                    }
                    driver.DriverDateOfBirthH = birthDate;
                }
                else if (!string.IsNullOrWhiteSpace(driver.DriverDateOfBirthH))
                {
                    var birthDate = _dateConverter.HijriToGreg(driver.DriverDateOfBirthH, "dd-MM-yyyy");
                    if (string.IsNullOrWhiteSpace(birthDate))
                    {
                        return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverDateOfBirthH");
                    }
                    driver.DriverDateOfBirthG = birthDate;
                }
                #endregion
                #region gender and education
                var gender = await getNotElmMalathCode("GENDER", driver.DriverGender!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
                if (!string.IsNullOrWhiteSpace(driver.DriverGender!.ToString()) && string.IsNullOrWhiteSpace(gender))
                {
                    return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverGender");
                }
                driver.DriverGender = gender;// set  mapped value ...
                var education = await getNotElmMalathCode("EDUCATION", driver.DriverEducation!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
                if (!string.IsNullOrWhiteSpace(driver.DriverEducation) && string.IsNullOrWhiteSpace(education))
                {
                    new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverEducation");
                }
                driver.DriverEducation = education;// set  mapped value ...
                #endregion
                #region marital status
                var martialStatus = await getMalathMaritalStatus(driver.DriverMaritalStatus, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
                if (!string.IsNullOrWhiteSpace(driver.DriverMaritalStatus!.ToString()) && string.IsNullOrWhiteSpace(martialStatus))
                {
                    return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverMaritalStatus");
                }
                driver.DriverMaritalStatus = martialStatus; // set  mapped value ...
                #endregion
                #region license and owners
                var licenseType = await getNotElmMalathCode("MOT_LICEN_TY", driver.DriverLicenseType!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
                if (!string.IsNullOrWhiteSpace(driver.DriverLicenseType!.ToString()) && string.IsNullOrWhiteSpace(licenseType))
                {
                    return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverLicenseType");
                }
                driver.DriverLicenseType = licenseType; // set  mapped value ...
                if (driver.DriverLicenseOwnYears != null && (int.Parse(driver.DriverLicenseOwnYears!) < 0 || int.Parse(driver.DriverLicenseOwnYears!) > 99))
                {
                    return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverLicenseOwnYears");
                }
                #endregion
                #region license countries
                var otherCountriesLicense = driver.CountriesValidDrivingLicense;
                if (otherCountriesLicense != null && otherCountriesLicense.Count > 0)
                {
                    foreach (var count in otherCountriesLicense)
                    {
                        var countryID = await getMalathCountryCode(count.DrivingLicenseCountryID!.ToString()!, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
                        if (countryID == null)
                        {
                            return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "COUNTRY_CODE");
                        }

                        if (count.DriverLicenseYears != null && (int.Parse(count.DriverLicenseYears!) < 0 || int.Parse(count.DriverLicenseYears!) > 99))
                        {
                            return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "LICENSE_YEARS");
                        }
                        count.DrivingLicenseCountryID = countryID.ToString();// set  mapped value ...
                    }
                }
                #endregion
                #region number of claims and accidents
                if (driver.DriverNoOfClaims != null && (int.Parse(driver.DriverNoOfClaims!) < 0 || int.Parse(driver.DriverNoOfClaims!) > 99))
                {
                    new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverNoOfClaims");
                }

                if (driver.DriverNoOfAccidents != null && (int.Parse(driver.DriverNoOfAccidents!) < 0 || int.Parse(driver.DriverNoOfAccidents!) > 99))
                {
                    new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverNoOfAccidents");
                }
                #endregion
                #region traffic violatios
                if (driver.DriverTrafficViolationsCode != null && driver.DriverTrafficViolationsCode.Count > 0)
                {
                    foreach (var viol in driver.DriverTrafficViolationsCode)
                    {
                        if (viol != null && !string.IsNullOrWhiteSpace(viol.DriverTrafficViolationsCode))
                        {
                            var val = await getNotElmMalathCode("NCD_TRAFFIC", viol.DriverTrafficViolationsCode, appUser.PARTNER_CODE.GetValueOrDefault(), appUser.PARTNER_BRANCH!);
                            if (string.IsNullOrWhiteSpace(val))
                            {
                                return new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverTrafficViolationsCode");
                            }
                            viol.DriverTrafficViolationsCode = val;// set  mapped value ...
                        }
                    }
                }
                #endregion
                #region childern
                if (driver.DriverChildrenBelow16 != null && (int.Parse(driver.DriverChildrenBelow16!) < 0 || int.Parse(driver.DriverChildrenBelow16!) > 99))
                {
                    new AggrError(string.Format("Driver {0} invalid", driver.DriverID), "DriverChildrenBelow16");
                }
                #endregion
                #region InsuredCityCode
                if (!string.IsNullOrWhiteSpace(driver.DriverWorkCity!.ToString()))
                {
                    string mappedCity = await getInsuredCityByElm(driver.DriverWorkCity!.ToString()!);

                    if (string.IsNullOrWhiteSpace(mappedCity) || mappedCity == "-1")
                    {
                        new AggrError("invalid", "CITY");
                    }
                    else
                    {
                        driver.DriverWorkCity = mappedCity;// set  mapped value ...
                    }
                }
                #endregion
            }
            #endregion
            return new AggrError();
        }
        public async Task<lookupsOneValueModel> GetNotListValues(USERS appUser)
        {
            lookupsOneValueModel ret = new lookupsOneValueModel();

            DateTime current = DateTime.Now;
            System.Globalization.UmAlQuraCalendar hijriCal = new System.Globalization.UmAlQuraCalendar();
            ret.MinDriverAge = int.Parse(_config.GetSection("TplDriverAge").Value!);
            DateTime maxDriverBirth = current.AddYears(-1 * (ret.MinDriverAge!.Value));
            var planCom = await GetCompPlan(appUser);
            ret.MaxDriverBirthG = maxDriverBirth.ToString("yyyy'-'MM'-'dd");
            ret.MaxDriverBirthH = hijriCal.GetYear(maxDriverBirth).ToString("d4")
                + "-" + hijriCal.GetMonth(maxDriverBirth).ToString("d2")
                 + "-" + hijriCal.GetDayOfMonth(maxDriverBirth).ToString("d2");

            ret.LookupsDate = DateTime.Now;
            ret.MinManYear = int.Parse(_config.GetSection("MinManfYear").Value!);
            ret.VehMaxValue = await getVehicleMaxValue(appUser, planCom.PLAN_CODE!.Value.ToString());
            ret.VehMinValue = await getVehicleMinValue(appUser, planCom.PLAN_CODE.Value.ToString());

            return ret;

        }
        public async Task<GEN_PROD_PLANS> GetCompPlan(USERS user)
        {
            var plans = await GetProPlans(user);
            return plans.FirstOrDefault()!;
        }
        public async Task<List<GEN_PROD_PLANS>> GetProPlans(USERS CurrentEmployee)
        {
            var branchCode = CurrentEmployee.PARTNER_BRANCH;
            var cachedPlans = await _cache.partnerPlansLease();
            var palns = cachedPlans.Where(e => e.PARTNER_CODE ==
            CurrentEmployee.PARTNER_CODE && e.PRODUCT_CODE == "LAS-RTL").Select(e => e.PLAN_CODE).ToList();
            var cachedBranchPlans = await _cache.partnerBrPlanTariff();
            var branchPlans = cachedBranchPlans.Where(e => e.PARTNER_CODE == CurrentEmployee.PARTNER_CODE && e.BRANCH_CODE == branchCode).Select(x => x.PLAN_CODE).Distinct().ToList();
            var cachedValue = await _cache.genProdPlansLease();
            var value = cachedValue.Where(e => e.PROD_CODE ==
                "LAS-RTL" && palns.Contains(e.PLAN_CODE) && branchPlans.Contains(e.PLAN_CODE) && (e.USER_AUTHORITY == null || e.USER_AUTHORITY != "Y")).ToList();
            return value;
        }
        protected async Task<long> getVehicleMaxValue(USERS CurrentEmployee, string PLAN_CODE)
        {

            long max = 0;

            int? PARTNER_CODEInt = CurrentEmployee.PARTNER_CODE;
            int PLAN_CODEInt = 0;

            if (int.TryParse(PLAN_CODE, out PLAN_CODEInt))
            {
                if (PLAN_CODEInt > 0)
                {
                    var tareef = await getTareefCode(CurrentEmployee, PLAN_CODEInt);
                    var cachedItems = await _cache.covConditionsTypeFiltered();
                    var items = cachedItems.Where(i => i.PARTNER_CODE == PARTNER_CODEInt && i.PLAN_CODE == PLAN_CODEInt && i.COND_DEF_TYPE == "VEH_VALUE" && i.TARIFF_CODE == tareef).ToList();
                    if (items.Count == 0 || (items.Max(i => Convert.ToInt64(i.COND_VALUE_TO) <= 0)))
                    {
                        throw new Exception(string.Format("There is no setup record for this partner"));
                    }
                    else
                    {
                        max = items.Max(i => Convert.ToInt64(i.COND_VALUE_TO));
                    }
                }
            }
            return max;
        }
        protected async Task<long> getVehicleMinValue(USERS CurrentEmployee, string PLAN_CODE)
        {
            long min = 0;

            int? PARTNER_CODEInt = CurrentEmployee.PARTNER_CODE;
            int PLAN_CODEInt = 0;

            if (int.TryParse(PLAN_CODE, out PLAN_CODEInt))
            {
                if (PLAN_CODEInt > 0)
                {
                    var tareef = await getTareefCode(CurrentEmployee, PLAN_CODEInt);
                    var cachedItems = await _cache.covConditionsTypeFiltered();
                    var items = cachedItems.Where(i => i.PARTNER_CODE == PARTNER_CODEInt && i.PLAN_CODE == PLAN_CODEInt && i.COND_DEF_TYPE == "VEH_VALUE" && i.TARIFF_CODE == tareef).ToList();
                    if (items.Count == 0 || (items.Min(i => Convert.ToInt64(i.COND_VALUE_TO) <= 0)))
                    {
                        throw new Exception(string.Format("There is no setup record for this partner"));
                    }
                    else
                    {
                        min = items.Min(i => Convert.ToInt64(i.COND_VALUE_FROM));
                    }
                }
            }
            return min;
        }
        public async Task<string> getTareefCode(USERS CurrentEmployee, int pc)
        {

            var cachedItems = await _cache.partnerBrPlanTariff();
            return cachedItems.Where(e => e.PARTNER_CODE == CurrentEmployee.PARTNER_CODE && e.BRANCH_CODE == CurrentEmployee.PARTNER_BRANCH && e.PLAN_CODE == pc).FirstOrDefault().TARIFF_CODE;
        }
        public async Task<AggrError> mapVehicle(QuoteRequest mappedQuoteModel, string elmMake, string elmModel, int? elmBodyType)
        {
            List<string> ret = new List<string>();


            checkFallbackTable(mappedQuoteModel, elmMake, elmModel);

            if (string.IsNullOrWhiteSpace(mappedQuoteModel.MalathVehicleModel))
            {
                #region Make
                var vehMakeCache = await _cache.GetCachedLookupDetails();
                var vehMake = vehMakeCache.Where(x => x.MASTER_CODE == "ELM_VEH_MAKE" && _clearString.clearAll(x.DETAIL_DESC_AR) == _clearString.clearAll(elmMake)).FirstOrDefault();

                if (vehMake != null)
                {
                    mappedQuoteModel.MalathVehicleMake = vehMake.MAPPED_CODE;//set mapped value ...
                }

                if (string.IsNullOrWhiteSpace(mappedQuoteModel.MalathVehicleMake))
                {
                    return new AggrError("invalid", "MAKE");
                }

                #endregion

                #region Model
                if (!string.IsNullOrWhiteSpace(mappedQuoteModel.MalathVehicleMake))
                {
                    var allowableModelsLookupsCache = await _cache.GetCachedLookupDetails();
                    var allowableModelsLookups = allowableModelsLookupsCache.Where(x => x.MASTER_CODE == "MOT_VEH_MOD" && x.DETAIL_CODE.StartsWith(mappedQuoteModel.MalathVehicleMake)).ToList();

                    if (allowableModelsLookups.Count == 1)
                    {
                        mappedQuoteModel.MalathVehicleModel = allowableModelsLookups[0].DETAIL_CODE;//set mapped value ...
                    }
                    else if (allowableModelsLookups.Count > 0)
                    {
                        var vehModelCache = await _cache.GetCachedLookupDetails();
                        var vehModel = vehModelCache.Where(x => x.MASTER_CODE == "ELM_VEH_MOD" && _clearString.clearAll(x.DETAIL_DESC_AR) == _clearString.clearAll(elmModel) && (x.MAPPED_CODE ?? "").StartsWith(vehMake.MAPPED_CODE)).FirstOrDefault();
                        if (vehModel != null && allowableModelsLookups.Any(x => x.DETAIL_CODE == vehModel.MAPPED_CODE))
                        {
                            mappedQuoteModel.MalathVehicleModel = vehModel.MAPPED_CODE;//set mapped value ...
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(mappedQuoteModel.MalathVehicleModel))
                {
                    return new AggrError("invalid", "Model");
                }



                #endregion
            }

            if (!string.IsNullOrWhiteSpace(mappedQuoteModel.MalathVehicleModel))
            {
                //get body type
                var allowableBTypesMapsCache = await _cache.modelBodyTypes();
                var allowableBTypesMaps = allowableBTypesMapsCache.Where(m => m.MODEL_CODE == mappedQuoteModel.MalathVehicleModel).Select(m => m.BODY_TYPE_CODE).ToList();
                var allowableBTypeLookupsCache = await _cache.GetCachedLookupDetails();
                var allowableBTypeLookups = allowableBTypeLookupsCache.Where(x => x.MASTER_CODE == "MOT_BODY_TYP" && allowableBTypesMaps.Contains(x.DETAIL_CODE)).ToList();

                if (allowableBTypeLookups.Count == 1)
                {//set mapped value ...
                    mappedQuoteModel.MalathVehicleBodyCode = allowableBTypeLookups[0].DETAIL_CODE;
                }
                else if (allowableBTypeLookups.Count > 0 && elmBodyType.GetValueOrDefault() > 1)
                {
                    var elmBodyTypeLookupCache = await _cache.GetCachedLookupDetails();
                    var elmBodyTypeLookup = elmBodyTypeLookupCache.Where(x => x.MASTER_CODE == "ELM_BODY_TYP" && x.DETAIL_CODE == elmBodyType.Value.ToString() && !string.IsNullOrWhiteSpace(x.MAPPED_CODE)).FirstOrDefault();

                    if (elmBodyTypeLookup != null && allowableBTypeLookups.Any(x => x.DETAIL_CODE == elmBodyTypeLookup.MAPPED_CODE))
                    {//set mapped value ...
                        mappedQuoteModel.MalathVehicleBodyCode = elmBodyTypeLookup.MAPPED_CODE;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(mappedQuoteModel.MalathVehicleBodyCode))
            {
                return new AggrError("invalid", "body");
            }

            return null;
        }
        private async Task checkFallbackTable(QuoteRequest mappedQuoteModel, string elmMake, string elmModel)
        {
            var foundExceptionalCache = await _cache.elmExceptionMakeModel();
            var foundExceptional = foundExceptionalCache.Where(e =>
                _clearString.clearAll(e.ELM_MAKE_DESC) == _clearString.clearAll(elmMake)
                && _clearString.clearAll(e.ELM_MODEL_DESC) == _clearString.clearAll(elmModel)).FirstOrDefault();

            if (foundExceptional != null)
            {
                mappedQuoteModel.VehicleMakeTextNIC = foundExceptional.MALATH_MAKE_CODE;
                mappedQuoteModel.VehicleModelTextNIC = foundExceptional.MALATH_MODEL_CODE;
            }
        }
        public async Task<AGGR_CODES> getAggrCodeObjByMalath(string key, string malathCode, int partnerCode, string branch)
        {
            if (string.IsNullOrWhiteSpace(malathCode))
            {
                return null!;
            }
            var branchVals = await getAggrCodeLookup(key, partnerCode, branch);


            var same = branchVals.Where(l => _clearString.clearAll(l.AGGR_ADD_DATA!) == _clearString.clearAll("[SAME]")).ToList().FirstOrDefault();
            if (same != null)
            {
                return new AGGR_CODES()
                {
                    MASTER_CODE = key,
                    AGGR_CODE = malathCode,
                    MALATH_CODE = malathCode,
                    PARTNER_CODE = partnerCode,
                    BRANCH_CODE = branch
                };
            }

            var lookup = branchVals.Where(l => _clearString.clearAll(l.MALATH_CODE!) == _clearString.clearAll(malathCode)).ToList().FirstOrDefault();

            return lookup!;
        }
        private async Task<AGGR_CODES> getAggrCodeObj(string key, string aggr_val, int partnerCode, string branch)
        {
            if (string.IsNullOrWhiteSpace(aggr_val))
            {
                return null;
            }
            var branchVals = await getAggrCodeLookup(key, partnerCode, branch);


            var same = branchVals.Where(l => _clearString.clearAll(l.AGGR_ADD_DATA!) == _clearString.clearAll("[SAME]")).ToList().FirstOrDefault();
            if (same != null)
            {
                return new AGGR_CODES()
                {
                    MASTER_CODE = key,
                    AGGR_CODE = aggr_val,
                    MALATH_CODE = aggr_val,
                    PARTNER_CODE = partnerCode,
                    BRANCH_CODE = branch
                };
            }

            var lookup = branchVals.Where(l => _clearString.clearAll(l.AGGR_CODE!) == _clearString.clearAll(aggr_val)).ToList().FirstOrDefault();

            return lookup;
        }
        #endregion
        #region malath codes
        public async Task<string> getNotElmMalathCode(string key, string aggrCode, decimal partnerCode, string partnerBranch)
        {
            if (string.IsNullOrWhiteSpace(aggrCode))
            {
                return "";
            }
            //if (string.IsNullOrWhiteSpace(key))
            //{
            //    return aggrCode;
            //}

            List<AGGR_CODES> aggrCodesCach = await _cache.GetCachedAggrCodeByBranchAndPartner(partnerCode, partnerBranch);
            var mapedAggrCode = aggrCodesCach.Where(l => l.PARTNER_CODE == partnerCode & l.AGGR_CODE == aggrCode && l.MASTER_CODE == key && l.BRANCH_CODE == partnerBranch).ToList();
            if (mapedAggrCode.Count == 0)
            {
                mapedAggrCode = aggrCodesCach.Where(l => l.PARTNER_CODE == partnerCode && l.BRANCH_CODE == "[DEFAULT]" && l.MASTER_CODE == key).ToList();
            }

            if (mapedAggrCode == null)
            {
                return "";
            }
            return mapedAggrCode.FirstOrDefault()!.MALATH_CODE;
        }
        public async Task<int?> getMalathCountryCode(string key, int partnerCode, string branch)
        {

            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            var aggrCodes = await getAggrCodeLookup("COUNTRY", partnerCode, branch);
            string elmCode = key;
            if (aggrCodes.Any())
            {
                elmCode = await getNotElmMalathCode("COUNTRY", elmCode, partnerCode, branch);
            }

            if (string.IsNullOrWhiteSpace(elmCode))
            {
                return null;
            }

            int code = int.Parse(elmCode);
            ObjectParameter P_ELM_NAT_ID = new ObjectParameter("P_ELM_NAT_ID", code);
            ObjectParameter P_MALATH_COUNTRY_ID = new ObjectParameter("P_MALATH_COUNTRY_ID", typeof(int));
            _repo.ExecuteProcedure("NONMED.GET_MALTH_COUNTRY_BY_ELM_NAT", P_ELM_NAT_ID, P_MALATH_COUNTRY_ID);
            if (P_MALATH_COUNTRY_ID.Value == null || string.IsNullOrWhiteSpace(P_MALATH_COUNTRY_ID.Value.ToString()) || ((int)P_MALATH_COUNTRY_ID.Value) < 0)
            {
                return null;
            }
            else
            {
                int parsed = 0;
                if (int.TryParse(P_MALATH_COUNTRY_ID.Value.ToString(), out parsed))
                {
                    return parsed;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<List<AGGR_CODES>> getAggrCodeLookup(string key, int partnerCode, string branch)
        {
            var branchValsCache = await _cache.GetCachedAggrCodeByBranchAndPartner(partnerCode, branch);
            var branchVals = branchValsCache.Where(l => l.PARTNER_CODE == partnerCode && (l.BRANCH_CODE == branch || l.BRANCH_CODE == "[DEFAULT]") && l.MASTER_CODE == key).ToList();
            return branchVals;
        }
        public async Task<string> getInsuredCityByElm(string Elm_City)
        {
            Elm_City = _clearString.trimSave(Elm_City);
            ObjectParameter P_ELM_CITY_NAME = new ObjectParameter("P_ELM_CITY_NAME", Elm_City);
            ObjectParameter P_MALATH_CITY = new ObjectParameter("P_MALATH_CITY", new String(' ', 100));
            await _repo.ExecuteProcedureAsync("TPAUSER.ELM.MALATH_CITY_BY_ELM_CITY", P_ELM_CITY_NAME, P_MALATH_CITY);

            if (P_MALATH_CITY.Value == null || string.IsNullOrWhiteSpace(P_MALATH_CITY.Value.ToString()))
            {
                var cachedCities = await _cache.GetCachedLookupDetails();
                var cities = cachedCities.Where(l => l.MASTER_CODE == "ELM_CITY" && !string.IsNullOrWhiteSpace(l.MAPPED_CODE)).ToList();
                var foundCity = cities.Where(c => _clearString.clearAll(c.DETAIL_DESC_AR!) == _clearString.clearAll(Elm_City) ||
                _clearString.clearAll(c.DETAIL_DESC_EN!) == _clearString.clearAll(Elm_City)
                ).ToList().FirstOrDefault();
                if (foundCity != null)
                {
                    return foundCity.MAPPED_CODE!;
                }
                return "";
            }

            return P_MALATH_CITY.Value.ToString()!;

        }
        public async Task<string> getMalathMaritalStatus(string elmMaritalStatus, int partnerCode, string branch)
        {
            if (string.IsNullOrWhiteSpace(elmMaritalStatus))
            {
                return "";
            }
            var elmCode = await getNotElmMalathCode("SOCIAL", elmMaritalStatus, partnerCode, branch);
            if (string.IsNullOrWhiteSpace(elmCode))
                elmCode = elmMaritalStatus;

            var cahechlookup = await _cache.GetCachedLookupDetails();
            var lookup = cahechlookup.Where(l => l.ACTIVE == "Y" && l.MASTER_CODE == "ELM_SOCIAL" && l.DETAIL_CODE == elmCode).FirstOrDefault();
            if (lookup == null)
            {
                return "";
            }
            return lookup.MAPPED_CODE;
        }
        public async Task<string> getMalathOccupation(string TameeniJob, int partnerCode, string branch)
        {
            var tamMappedOcc = await getMalathFromAggrCode("OCCUPATIONS", TameeniJob, partnerCode, branch);
            if (string.IsNullOrWhiteSpace(tamMappedOcc))
            {
                var occCache = await _cache.cchiOcc();
                var occ = occCache.Where(o => _clearString.clearAll(o.A_NAME) == _clearString.clearAll(TameeniJob)).ToList().FirstOrDefault();
                if (occ != null)
                {
                    return occ.OCCUPATION_CODE.GetValueOrDefault().ToString();
                }
                else
                {
                    occCache = await _cache.cchiOcc();
                    occ = occCache.Where(o => _clearString.clearAll(o.OCCUPATION_CODE.GetValueOrDefault().ToString()) == _clearString.clearAll(TameeniJob)).ToList().FirstOrDefault();
                    if (occ != null)
                    {
                        return occ.OCCUPATION_CODE.GetValueOrDefault().ToString();
                    }
                    else
                    {
                        occCache = await _cache.cchiOcc();
                        occ = occCache.Where(o => _clearString.clearAll(o.E_NAME) == _clearString.clearAll(TameeniJob)).ToList().FirstOrDefault();
                        if (occ != null)
                        {
                            return occ.OCCUPATION_CODE.GetValueOrDefault().ToString();
                        }
                    }
                }
            }

            return tamMappedOcc;

        }
        private async Task<string> getMalathFromAggrCode(string key, string aggr_val, int partnerCode, string branch)
        {
            var lookup = await getAggrCodeObj(key, aggr_val, partnerCode, branch);

            if (lookup == null)
                return "";

            return lookup.MALATH_CODE;

        }
        private async Task<List<AggrError>> convertToPartnerError(List<AggrError> lstErrors, int? partnerCode, string branch)
        {
            if (lstErrors == null)
            {
                return null!;
            }
            List<AggrError> ret = new List<AggrError>();
            foreach (var error in lstErrors)
            {
                var mapObj = await getAggrCodeObjByMalath("ERROR_FIELDS", error.Field, partnerCode.GetValueOrDefault(), branch);
                var aggrError = new AggrError();
                aggrError.Code = error.Code;
                aggrError.Field = error.Field;
                if (mapObj != null)
                    aggrError.Field = mapObj.AGGR_CODE!;
                aggrError.Message = error.Message;
                ret.Add(aggrError);
            }
            return ret;
        }
        public async Task<List<AggrError>> insertMappedDataAndReturnPartnerError(QuoteRequest quoteRequest, USERS appUser)
        {
            AggrError aggrError = await MapPartnerData(quoteRequest, appUser);
            //insert mapped data 
            /*
             * 
             * 
             */
            //convert to partner error 
            List<AggrError> errorList = null!;
            if (aggrError != null && !string.IsNullOrEmpty(aggrError.Code))
            {
                List<AggrError> aggrErrorList = new List<AggrError>();
                aggrErrorList.Add(aggrError);
                errorList = await convertToPartnerError(aggrErrorList, appUser.PARTNER_CODE, appUser.PARTNER_BRANCH!);
            }
            return errorList;
        }
        #endregion
        //public async Task<AljuQuotationRequest> AddQuotationRequest(AljuQuotationRequest aljuQuotationRequest)
        //{
        //    await _dbContext.ALJU_QUOTATION_REQUEST.AddAsync(aljuQuotationRequest);
        //    await _dbContext.SaveChangesAsync();

        //    return aljuQuotationRequest;
        //}
    }
}
