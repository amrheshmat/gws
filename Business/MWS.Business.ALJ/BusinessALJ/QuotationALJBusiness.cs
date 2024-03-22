using ALJ.Data.Models;
using ALJ.Data.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MWS.Business.ALJ.IBusinessALJ;
using MWS.Business.Malath.lease.IBusiness;
using MWS.Business.Shared.Business;
using MWS.Business.Shared.Business.Business;
using MWS.Business.Shared.Data.Models;
using MWS.Business.Shared.IBusiness;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using DataEntities = MWS.Data.Entities;
namespace MWS.Business.ALJ.BusinessALJ
{
    public class QuotationALJBusiness : ControllerBase, IQuotationALJBusiness
    {
        #region fields
        private readonly IConfiguration _config;
        private IValueHelper _valHelp;
        private readonly IRepository _repo;
        private readonly ICommon _common;
        private IQuotationBusiness _leaseBusiness;
        private ILoggerHandler<QuotationALJBusiness> _logger;
        private IDateConverter _dateConverter;
        #endregion
        #region constructor
        public QuotationALJBusiness(IDateConverter dateConverter, IConfiguration config, IRepositoryFactory repoFacory, ICommon common, IValueHelper valHelp, IQuotationBusiness leaseBusiness, ILoggerHandler<QuotationALJBusiness> logger)

        {
            _config = config;
            _repo = repoFacory.Create("AGGRDB");
            _common = common;
            _valHelp = valHelp;
            _leaseBusiness = leaseBusiness;
            _logger = logger;
            _dateConverter = dateConverter;
        }
        #endregion
        #region log methods
        public async Task LogRequestBody(string bodyStr, string trx)
        {
            //fill log request model ...
            LogRequest logRequest = createLogModel(bodyStr, trx);
            logRequest.DocCode = "MTR_LEASE_REQ";
            var logResponse = await _common.logRequestService(logRequest);
            await this.addDoc(logRequest, logResponse);
        }
        public async Task LogResponseBody(string bodyStr, string trx)
        {
            //fill log request model ...
            LogRequest logRequest = createLogModel(bodyStr, trx);
            logRequest.DocCode = "MTR_LEASE_RES";
            var logResponse = await _common.logRequestService(logRequest);
            await this.addDoc(logRequest, logResponse);
        }
        private LogRequest createLogModel(string bodyStr, string trx)
        {
            LogRequest logRequest = new LogRequest();
            logRequest.Key1 = "QuoteReferenceNo";
            //get trx number ...
            logRequest.Value1 = trx;
            //request body ...
            logRequest.Doc = (bodyStr ?? "");
            //get expiry date from settings ...
            logRequest.ExpiryDate = DateTime.Now.AddDays(double.Parse(_config.GetSection("LogExpiryDate").Value!.ToString()));
            //MTR_LEASE_RES   Motor Lease Response ...
            //Motor Lease Request ...
            return logRequest;
        }
        private async Task addDoc(LogRequest logRequest, LogResponse logResponse)
        {
            MotorAggrLogs aggrLogs = new MotorAggrLogs();
            aggrLogs.docId = logResponse.DocId!.Value;
            aggrLogs.trxNo = long.Parse(logRequest.Value1!);
            aggrLogs.docCode = long.Parse(logRequest.DocCode!);
            aggrLogs.isRead = 'F';
            //var cacheData1 = await _repository.Filter<USERS>(u => u.ACTIVE == "Y" && u.ISWEB_FLAG == "Y" && u.STATUS == "A").ToListAsync();
            var t = await _repo.CreateAsync(aggrLogs);
            await _repo.SaveChangesAsync();

        }
        #endregion
        #region quotation
        public async Task<object> AddQuotationRequest(AljuQuotationRequest aljuQuotationRequest, string trx, HttpContext httpContext)
        {
            #region validation
            //validate request ...
            long.TryParse(trx, out long QuoteReferenceNo);
            AljRequestValidation validationRules = new AljRequestValidation();
            List<AggrError> invalidErrors = validationRules.getValidationErrors(aljuQuotationRequest);
            if (invalidErrors.Count > 0)
            {
                return BadRequest(invalidErrors);
            }
            #endregion
            #region mapping and partner data
            else
            {
                UserDTO user = _common.Getuser(httpContext)!;
                //map alj request to malath model ...
                var Ret = await AddQuotationRequestMapping(aljuQuotationRequest, trx);
                USERS appUser = new USERS
                {
                    PARTNER_BRANCH = user.branch,
                    PARTNER_CODE = user!.partner
                };
                var aggrError = await _leaseBusiness.insertMappedDataAndReturnPartnerError(Ret, appUser);
                return aggrError;
            }
            #endregion
        }
        //mapping AljuQuotationRequest to malathQuoteRequest Model
        public async Task<QuoteRequest> AddQuotationRequestMapping(AljuQuotationRequest AljRequest, string trx)
        {
            QuoteRequest Ret = new QuoteRequest();
            #region main table mapping
            Ret.RequestReferenceNo = _valHelp.toStringSave(AljRequest.RequestReferenceNo!);
            Ret.LessorID = _valHelp.toStringSave(AljRequest.LessorID!);
            Ret.IsRenewal = _valHelp.toStringSave(AljRequest.IsRenewal!);
            Ret.PolicyNumber = _valHelp.toStringSave(AljRequest.PolicyNumber!);
            Ret.PurposeofVehicleUseID = _valHelp.toStringSave(AljRequest.PurposeofVehicleUseID!);
            Ret.Cylinders = _valHelp.toStringSave(AljRequest.Cylinders!);
            Ret.VehicleMileage = _valHelp.toStringSave(AljRequest.VehicleMileage!);
            Ret.VehicleExpectedMileageYear = _valHelp.toStringSave(AljRequest.VehicleExpectedMileageYear!);
            Ret.VehicleEngineSizeCC = _valHelp.toStringSave(AljRequest.VehicleEngineSizeCC! / 1000);
            Ret.VehicleTransmission = _valHelp.toStringSave(AljRequest.VehicleTransmission!);
            Ret.VehicleNightParking = _valHelp.toStringSave(AljRequest.VehicleNightParking!);
            Ret.VehicleCapacity = _valHelp.toStringSave(AljRequest.VehicleCapacity!);
            Ret.VehicleMakeTextNIC = _valHelp.toStringSave(AljRequest.VehicleMakeTextNIC!);
            Ret.VehicleModelTextNIC = _valHelp.toStringSave(AljRequest.VehicleModelTextNIC!);
            Ret.ManufactureYear = _valHelp.toStringSave(AljRequest.ManufactureYear!);
            Ret.VehicleColorCode = _valHelp.toStringSave(AljRequest.VehicleColorCode!);
            Ret.VehicleModifications = _valHelp.toStringSave(AljRequest.VehicleModifications!);
            Ret.VehicleSumInsured = _valHelp.toStringSave(AljRequest.VehicleSumInsured!);
            Ret.DepreciationratePercentage = _valHelp.toStringSave(AljRequest.DepreciationratePercentage!);
            Ret.RepairMethod = _valHelp.toStringSave(AljRequest.RepairMethod!);
            Ret.UploadDate = this._dateConverter.DateToString(DateTime.Now.Date);
            #endregion
            #region LessorNationalAddress mapping
            if (AljRequest.LessorNationalAddress != null && AljRequest.LessorNationalAddress.Count > 0)
            {


                Ret.LessorBuildingNumber = _valHelp.toStringSave(AljRequest.LessorNationalAddress[0].BuildingNumber!);
                Ret.LessorStreet = _valHelp.toStringSave(AljRequest.LessorNationalAddress[0].Street);
                Ret.LessorDistrict = _valHelp.toStringSave(AljRequest.LessorNationalAddress[0].District);
                Ret.LessorCity = _valHelp.toStringSave(AljRequest.LessorNationalAddress[0].City);
                Ret.LessorZipCode = _valHelp.toStringSave(AljRequest.LessorNationalAddress[0].ZipCode!);
                Ret.LessorAdditionalNumber = _valHelp.toStringSave(AljRequest.LessorNationalAddress[0].AdditionalNumber!);


            }
            #endregion
            #region CustomizedParameter mapping
            if (AljRequest.CustomizedParameter != null)
            {
                Ret.CustomizedParameter = new List<DataEntities.CustomizedParameter>();
                foreach (var CustomizedParameter in AljRequest.CustomizedParameter)
                {
                    DataEntities.CustomizedParameter RetCustomizedParameter = new DataEntities.CustomizedParameter();
                    RetCustomizedParameter.Key = _valHelp.toStringSave(CustomizedParameter.Key);
                    RetCustomizedParameter.Value1 = _valHelp.toStringSave(CustomizedParameter.Value1);
                    RetCustomizedParameter.Value2 = _valHelp.toStringSave(CustomizedParameter.Value2);
                    RetCustomizedParameter.Value3 = _valHelp.toStringSave(CustomizedParameter.Value3);
                    RetCustomizedParameter.Value4 = _valHelp.toStringSave(CustomizedParameter.Value4);
                    Ret.CustomizedParameter.Add(RetCustomizedParameter);
                }
            }
            #endregion
            #region MainDriverDetails mapping
            Ret.DriverDetails = new List<DataEntities.DriverDetails>();
            DataEntities.DriverDetails MainDriverDetails = new DataEntities.DriverDetails();
            MainDriverDetails.IsLessee = "Y";
            MainDriverDetails.DriverID = _valHelp.toStringSave(AljRequest.LesseeID!);
            MainDriverDetails.DriverFullName = _valHelp.toStringSave(AljRequest.FullName!);
            MainDriverDetails.ArabicFirstName = _valHelp.toStringSave(AljRequest.ArabicFirstName!);
            MainDriverDetails.ArabicMiddleName = _valHelp.toStringSave(AljRequest.ArabicMiddleName!);
            MainDriverDetails.ArabicLastName = _valHelp.toStringSave(AljRequest.ArabicLastName!);
            MainDriverDetails.EnglishFirstName = _valHelp.toStringSave(AljRequest.EnglishFirstName!);
            MainDriverDetails.EnglishMiddleName = _valHelp.toStringSave(AljRequest.EnglishMiddleName!);
            MainDriverDetails.EnglishLastName = _valHelp.toStringSave(AljRequest.EnglishLastName!);
            //MainDriverDetails.DriverRelation = _valHelp.toStringSave(AljRequest.lesse!);
            MainDriverDetails.DriverNationalityID = _valHelp.toStringSave(AljRequest.LesseeNationalityID!);
            MainDriverDetails.VehicleUsagePercentage = _valHelp.toStringSave(AljRequest.VehicleUsagePercentage!);
            MainDriverDetails.DriverOccupation = _valHelp.toStringSave(AljRequest.LesseeOccupation!);
            MainDriverDetails.DriverEducation = _valHelp.toStringSave(AljRequest.LesseeEducation!);
            MainDriverDetails.DriverChildrenBelow16 = _valHelp.toStringSave(AljRequest.LesseeChildrenBelow16!);
            MainDriverDetails.DriverWorkCompanyName = _valHelp.toStringSave(AljRequest.LesseeWorkCompanyName!);
            MainDriverDetails.DriverWorkCity = _valHelp.toStringSave(AljRequest.LesseeWorkCityID!);
            MainDriverDetails.DriverNoOfClaims = _valHelp.toStringSave(AljRequest.LesseeNoOfClaims!);
            MainDriverDetails.DriverDateOfBirthG = _valHelp.toStringSave(AljRequest.LesseeDateOfBirthG!);
            MainDriverDetails.DriverDateOfBirthH = _valHelp.toStringSave(AljRequest.LesseeDateOfBirthH!);
            MainDriverDetails.DriverGender = _valHelp.toStringSave(AljRequest.LesseeGender!);
            MainDriverDetails.DriverMaritalStatus = _valHelp.toStringSave(AljRequest.LesseeMaritalStatus!);
            //  MainDriverDetails.DriverHomeAddressCity = _valHelp.toStringSave(AljRequest.less);
            // MainDriverDetails.DriverHomeAddress = _valHelp.toStringSave(AljRequest.DriverHomeAddress);
            #region LesseeNationalAddress mapping in MainDriverDetails mapping
            if (AljRequest.LesseeNationalAddress != null && AljRequest.LesseeNationalAddress.Count > 0)
            {
                MainDriverDetails.DriverBuildingNumber = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[0].BuildingNumber!);
                MainDriverDetails.DriverStreet = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[0].Street!);
                MainDriverDetails.DriverDistrict = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[0].District!);
                MainDriverDetails.DriverCity = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[0].City!);
                MainDriverDetails.DriverZipCode = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[0].ZipCode!);
                MainDriverDetails.DriverAdditionalNumber = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[0].AdditionalNumber!);
            }
            #endregion
            MainDriverDetails.DriverLicenseType = _valHelp.toStringSave(AljRequest.LesseeLicenseType!);
            MainDriverDetails.DriverLicenseOwnYears = _valHelp.toStringSave(AljRequest.LesseeLicenseOwnYears!);
            MainDriverDetails.DriverNoOfAccidents = _valHelp.toStringSave(AljRequest.LesseeNoOfAccidents!);
            if (AljRequest.CountriesValidDrivingLicense != null)
            {
                MainDriverDetails.CountriesValidDrivingLicense = new List<DataEntities.CountriesValidDrivingLicense>();
                foreach (var DetailsCountriesDrivingLicense in AljRequest.CountriesValidDrivingLicense)
                {
                    DataEntities.CountriesValidDrivingLicense RetDetailsCountriesDrivingLicense = new DataEntities.CountriesValidDrivingLicense();
                    RetDetailsCountriesDrivingLicense.DrivingLicenseCountryID = _valHelp.toStringSave(DetailsCountriesDrivingLicense.DrivingLicenseCountryID!);
                    RetDetailsCountriesDrivingLicense.DriverLicenseYears = _valHelp.toStringSave(DetailsCountriesDrivingLicense.DriverLicenseYears!);
                    MainDriverDetails.CountriesValidDrivingLicense.Add(RetDetailsCountriesDrivingLicense);
                }
            }
            if (AljRequest.LesseeTrafficViolationsCode != null)
            {
                // Split the string based on the comma
                string[] DriverTrafficArray = AljRequest.LesseeTrafficViolationsCode.Split(',');
                MainDriverDetails.DriverTrafficViolationsCode = new List<DataEntities.DriverTrafficViolations>();
                if (DriverTrafficArray.Count() > 0)
                {
                    foreach (var DetailsDriverTrafficViolationsCode in DriverTrafficArray)
                    {
                        DataEntities.DriverTrafficViolations RetDetailsDriverTrafficViolations = new DataEntities.DriverTrafficViolations();
                        RetDetailsDriverTrafficViolations.DriverID = _valHelp.toStringSave(AljRequest.LesseeID!);
                        RetDetailsDriverTrafficViolations.QuotationReference = long.Parse(trx!);
                        RetDetailsDriverTrafficViolations.DriverTrafficViolationsCode = _valHelp.toStringSave(DetailsDriverTrafficViolationsCode);
                        MainDriverDetails.DriverTrafficViolationsCode.Add(RetDetailsDriverTrafficViolations);
                    }
                }
            }
            if (AljRequest.LesseeHealthConditionsCode != null)
            {
                // Split the string based on the comma
                string[] DriverHealthArray = AljRequest.LesseeHealthConditionsCode.Split(',');
                MainDriverDetails.DriverHealthConditionsCode = new List<DataEntities.DriverHealthConditions>();
                if (DriverHealthArray.Count() > 0)
                {
                    foreach (var DetailsDriverHealthConditionsCode in DriverHealthArray)
                    {
                        DataEntities.DriverHealthConditions RetDetailsDriverHealthConditions = new DataEntities.DriverHealthConditions();
                        RetDetailsDriverHealthConditions.DriverID = _valHelp.toStringSave(AljRequest.LesseeID!);
                        RetDetailsDriverHealthConditions.QuotationReference = long.Parse(trx!);
                        RetDetailsDriverHealthConditions.DriverHealthConditionsCode = _valHelp.toStringSave(DetailsDriverHealthConditionsCode);
                        MainDriverDetails.DriverHealthConditionsCode.Add(RetDetailsDriverHealthConditions);
                    }
                }

            }
            Ret.DriverDetails.Add(MainDriverDetails);
            #endregion
            #region DriverDetails mapping In case DriverDetails.DriverID != AljRequest.LesseeID
            if (AljRequest.DriverDetails != null)
            {
                foreach (var DriverDetails in AljRequest.DriverDetails)
                {
                    DataEntities.DriverDetails RetDriverDetails = new DataEntities.DriverDetails();
                    //
                    if (DriverDetails.DriverID != AljRequest.LesseeID)
                    {
                        RetDriverDetails.DriverID = _valHelp.toStringSave(DriverDetails.DriverID!);
                        RetDriverDetails.DriverFullName = _valHelp.toStringSave(DriverDetails.DriverFullName);
                        RetDriverDetails.ArabicFirstName = _valHelp.toStringSave(DriverDetails.ArabicFirstName);
                        RetDriverDetails.ArabicMiddleName = _valHelp.toStringSave(DriverDetails.ArabicMiddleName);
                        RetDriverDetails.ArabicLastName = _valHelp.toStringSave(DriverDetails.ArabicLastName);
                        RetDriverDetails.EnglishFirstName = _valHelp.toStringSave(DriverDetails.EnglishFirstName);
                        RetDriverDetails.EnglishMiddleName = _valHelp.toStringSave(DriverDetails.EnglishMiddleName);
                        RetDriverDetails.EnglishLastName = _valHelp.toStringSave(DriverDetails.EnglishLastName);
                        RetDriverDetails.DriverRelation = _valHelp.toStringSave(DriverDetails.DriverRelation!);
                        RetDriverDetails.DriverNationalityID = _valHelp.toStringSave(DriverDetails.DriverNationalityID!);
                        RetDriverDetails.VehicleUsagePercentage = _valHelp.toStringSave(DriverDetails.VehicleUsagePercentage!);
                        RetDriverDetails.DriverOccupation = _valHelp.toStringSave(DriverDetails.DriverOccupation);
                        RetDriverDetails.DriverEducation = _valHelp.toStringSave(DriverDetails.DriverEducation);
                        RetDriverDetails.DriverChildrenBelow16 = _valHelp.toStringSave(DriverDetails.DriverChildrenBelow16!);
                        RetDriverDetails.DriverWorkCompanyName = _valHelp.toStringSave(DriverDetails.DriverWorkCompanyName);
                        RetDriverDetails.DriverWorkCity = _valHelp.toStringSave(DriverDetails.DriverWorkCityID!);
                        RetDriverDetails.DriverNoOfClaims = _valHelp.toStringSave(DriverDetails.DriverNoOfClaims!);
                        RetDriverDetails.DriverDateOfBirthG = _valHelp.toStringSave(DriverDetails.DriverDateOfBirthG);
                        RetDriverDetails.DriverDateOfBirthH = _valHelp.toStringSave(DriverDetails.DriverDateOfBirthH);
                        RetDriverDetails.DriverGender = _valHelp.toStringSave(DriverDetails.DriverGender!);
                        RetDriverDetails.DriverMaritalStatus = _valHelp.toStringSave(DriverDetails.DriverMaritalStatus!);
                        RetDriverDetails.DriverHomeAddressCity = _valHelp.toStringSave(DriverDetails.DriverHomeAddressCity);
                        RetDriverDetails.DriverHomeAddress = _valHelp.toStringSave(DriverDetails.DriverHomeAddress);
                        RetDriverDetails.DriverLicenseType = _valHelp.toStringSave(DriverDetails.DriverLicenseType!);
                        RetDriverDetails.DriverLicenseOwnYears = _valHelp.toStringSave(DriverDetails.DriverLicenseOwnYears!);
                        RetDriverDetails.DriverNoOfAccidents = _valHelp.toStringSave(DriverDetails.DriverNoOfAccidents!);
                        #region LesseeNationalAddress mapping in DriverDetails mapping In case DriverDetails.DriverID != AljRequest.LesseeID
                        if (AljRequest.LesseeNationalAddress != null && AljRequest.LesseeNationalAddress.Count > 0)
                        {
                            for (int i = 1; i < AljRequest.LesseeNationalAddress.Count; i++)
                            {
                                RetDriverDetails.DriverBuildingNumber = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[i].BuildingNumber!);
                                RetDriverDetails.DriverStreet = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[i].Street!);
                                RetDriverDetails.DriverDistrict = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[i].District!);
                                RetDriverDetails.DriverCity = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[i].City!);
                                RetDriverDetails.DriverZipCode = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[i].ZipCode!);
                                RetDriverDetails.DriverAdditionalNumber = _valHelp.toStringSave(AljRequest.LesseeNationalAddress[i].AdditionalNumber!);
                            }
                        }
                        #endregion
                        //mapping AljRequest DriverDetails.CountriesValidDrivingLicense list to malath quoteRequest DriverDetails.CountriesValidDrivingLicense list
                        if (DriverDetails.CountriesValidDrivingLicense != null)
                        {
                            RetDriverDetails.CountriesValidDrivingLicense = new List<DataEntities.CountriesValidDrivingLicense>();
                            foreach (var DetailsCountriesDrivingLicense in DriverDetails.CountriesValidDrivingLicense)
                            {
                                DataEntities.CountriesValidDrivingLicense RetDetailsCountriesDrivingLicense = new DataEntities.CountriesValidDrivingLicense();
                                RetDetailsCountriesDrivingLicense.DrivingLicenseCountryID = _valHelp.toStringSave(DetailsCountriesDrivingLicense.DrivingLicenseCountryID!);
                                RetDetailsCountriesDrivingLicense.DriverLicenseYears = _valHelp.toStringSave(DetailsCountriesDrivingLicense.DriverLicenseYears!);
                                RetDriverDetails.CountriesValidDrivingLicense.Add(RetDetailsCountriesDrivingLicense);
                            }
                        }
                        if (DriverDetails.DriverTrafficViolationsCode != null)
                        {
                            // Split the string based on the comma
                            string[] DriverTrafficArray = DriverDetails.DriverTrafficViolationsCode.Split(',');
                            RetDriverDetails.DriverTrafficViolationsCode = new List<DataEntities.DriverTrafficViolations>();
                            if (DriverTrafficArray.Count() > 0)
                            {
                                foreach (var DetailsDriverTrafficViolationsCode in DriverTrafficArray)
                                {
                                    DataEntities.DriverTrafficViolations RetDetailsDriverTrafficViolations = new DataEntities.DriverTrafficViolations();
                                    RetDetailsDriverTrafficViolations.DriverID = _valHelp.toStringSave(DriverDetails.DriverID!);
                                    RetDetailsDriverTrafficViolations.QuotationReference = long.Parse(trx!);
                                    RetDetailsDriverTrafficViolations.DriverTrafficViolationsCode = _valHelp.toStringSave(DetailsDriverTrafficViolationsCode);
                                    RetDriverDetails.DriverTrafficViolationsCode.Add(RetDetailsDriverTrafficViolations);
                                }
                            }
                        }
                        if (DriverDetails.DriverHealthConditionsCode != null)
                        {
                            // Split the string based on the comma
                            string[] DriverHealthArray = DriverDetails.DriverHealthConditionsCode.Split(',');
                            RetDriverDetails.DriverHealthConditionsCode = new List<DataEntities.DriverHealthConditions>();
                            if (DriverHealthArray.Count() > 0)
                            {
                                foreach (var DetailsDriverHealthConditionsCode in DriverHealthArray)
                                {
                                    DataEntities.DriverHealthConditions RetDetailsDriverHealthConditions = new DataEntities.DriverHealthConditions();
                                    RetDetailsDriverHealthConditions.DriverID = _valHelp.toStringSave(DriverDetails.DriverID!);
                                    RetDetailsDriverHealthConditions.QuotationReference = long.Parse(trx!);
                                    RetDetailsDriverHealthConditions.DriverHealthConditionsCode = _valHelp.toStringSave(DetailsDriverHealthConditionsCode);
                                    RetDriverDetails.DriverHealthConditionsCode.Add(RetDetailsDriverHealthConditions);
                                }
                            }
                        }
                        Ret.DriverDetails.Add(RetDriverDetails);
                    }
                }
            }
            #endregion
            return Ret;
        }

        #endregion
    }
}

