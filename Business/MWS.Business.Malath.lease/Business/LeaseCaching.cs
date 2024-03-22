using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MWS.Business.Malath.lease.IBusiness;
using MWS.Business.Shared.IBusiness;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using Newtonsoft.Json.Linq;

namespace MWS.Business.Malath.lease.Business
{
    public class LeaseCaching : ILeaseCaching
    {
        #region fields
        private readonly IConfiguration _config;
        private readonly IRepository _repo;
        public object Sync { get; set; }
        private List<PARTNER_BR_PLAN_TARIFF> cachedPartnerPlanTraffic = null!;
        private List<GEN_PLAN_SCHEME_COV_CONDITIONS> cachedGenPlan = null!;
        private List<PARTNER_PLANS> cachedPartnerPlan = null!;
        private List<GEN_PROD_PLANS> cachedGenProdPlan = null!;
        private List<MODEL_BODY_TYPE> cachedModelBodyType = null!;
        private List<ELM_EXCEPTION_MAKE_MODEL> cachedElmExceptionMakeModel = null!;
        private ICustomCaching _customCache;
        #endregion
        #region constrcutor(s)
        public LeaseCaching(IConfiguration config, IRepositoryFactory repo, ICustomCaching customCache)
        {
            this.Sync = new object();
            _config = config;
            _repo = repo.Create("AGGRDB");
            _customCache = customCache;
        }
        #endregion

        #region custom methods
        public async Task<List<LOOKUP_DETAILS>> GetCachedLookupDetails()
        {
            var cachedLookup = _customCache.Get<List<LOOKUP_DETAILS>>("LOOKUP_DETAILS");
            if (cachedLookup != null)
            {
                return cachedLookup;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedLookup = await _repo.GetAll<LOOKUP_DETAILS>().ToListAsync();
            _customCache.Set("LOOKUP_DETAILS", cachedLookup, expiration);
            return cachedLookup;
        }
        public async Task<List<AGGR_CODES>> GetCachedAggrCodeByBranchAndPartner(decimal partnerCode, string partnerBranch)
        {
            var cachedAggrCodes = _customCache.Get<List<AGGR_CODES>>("AGGR_CODES_BRANCH_PARTNER");
            if (cachedAggrCodes != null && cachedAggrCodes.Count > 0)
            {
                if (cachedAggrCodes[0].PARTNER_CODE == partnerCode && (cachedAggrCodes[0].BRANCH_CODE == partnerBranch || cachedAggrCodes[0].BRANCH_CODE == "[DEFAULT]"))
                {//if cached for this branch and partner berfore ...
                    return cachedAggrCodes;
                }
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedAggrCodes = await _repo.Filter<AGGR_CODES>(X => (X.BRANCH_CODE == partnerBranch || X.BRANCH_CODE == "[DEFAULT]") && X.PARTNER_CODE == partnerCode).ToListAsync();
            _customCache.Set("AGGR_CODES_BRANCH_PARTNER", cachedAggrCodes, expiration);
            return cachedAggrCodes;
        }
        public async Task<List<PARTNER_BR_PLAN_TARIFF>> partnerBrPlanTariff()
        {
            var cachedPartnerPlanTraffic = _customCache.Get<List<PARTNER_BR_PLAN_TARIFF>>("PARTNER_BR_PLAN_TARIFF");
            if (cachedPartnerPlanTraffic != null)
            {
                return cachedPartnerPlanTraffic;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedPartnerPlanTraffic = await _repo.GetAll<PARTNER_BR_PLAN_TARIFF>().ToListAsync();
            _customCache.Set("PARTNER_BR_PLAN_TARIFF", cachedPartnerPlanTraffic, expiration);
            return cachedPartnerPlanTraffic;
        }
        public async Task<List<GEN_PLAN_SCHEME_COV_CONDITIONS>> covConditionsTypeFiltered()
        {

            List<string> lstTypes = new List<string>() { "COV_CONFLICT", "COV_ATTACHED", "DRIVER_AGE", "VEH_VALUE" };
            string cacheKey = typeof(List<GEN_PLAN_SCHEME_COV_CONDITIONS>).FullName + "_" + JToken.FromObject(lstTypes).ToString();
            var cachedGenPlan = _customCache.Get<List<GEN_PLAN_SCHEME_COV_CONDITIONS>>(cacheKey);
            if (cachedGenPlan != null)
            {
                return cachedGenPlan;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedGenPlan = await _repo.GetAll<GEN_PLAN_SCHEME_COV_CONDITIONS>().ToListAsync();
            _customCache.Set("GEN_PLAN_SCHEME_COV_CONDITIONS", cachedGenPlan, expiration);
            return cachedGenPlan;
        }
        public async Task<List<PARTNER_PLANS>> partnerPlansLease()
        {
            var cachedPartnerPlan = _customCache.Get<List<PARTNER_PLANS>>("PARTNER_PLANS");
            if (cachedPartnerPlan != null)
            {
                return cachedPartnerPlan;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedPartnerPlan = await _repo.GetAll<PARTNER_PLANS>().ToListAsync();
            _customCache.Set("PARTNER_PLANS", cachedPartnerPlan, expiration);
            return cachedPartnerPlan;
        }
        public async Task<List<GEN_PROD_PLANS>> genProdPlansLease()
        {
            var cachedGenProdPlan = _customCache.Get<List<GEN_PROD_PLANS>>("GEN_PROD_PLANS");
            if (cachedGenProdPlan != null)
            {
                return cachedGenProdPlan;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedGenProdPlan = await _repo.GetAll<GEN_PROD_PLANS>().ToListAsync();
            _customCache.Set("GEN_PROD_PLANS", cachedGenProdPlan, expiration);
            return cachedGenProdPlan;
        }
        public async Task<List<MODEL_BODY_TYPE>> modelBodyTypes()
        {
            var cachedModelBodyType = _customCache.Get<List<MODEL_BODY_TYPE>>("MODEL_BODY_TYPE");
            if (cachedModelBodyType != null)
            {
                return cachedModelBodyType;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedModelBodyType = await _repo.GetAll<MODEL_BODY_TYPE>().ToListAsync();
            _customCache.Set("MODEL_BODY_TYPE", cachedModelBodyType, expiration);
            return cachedModelBodyType;
        }
        public async Task<List<ELM_EXCEPTION_MAKE_MODEL>> elmExceptionMakeModel()
        {
            var cachedElmExceptionMakeModel = _customCache.Get<List<ELM_EXCEPTION_MAKE_MODEL>>("ELM_EXCEPTION_MAKE_MODEL");
            if (cachedElmExceptionMakeModel != null)
            {
                return cachedElmExceptionMakeModel;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedElmExceptionMakeModel = await _repo.GetAll<ELM_EXCEPTION_MAKE_MODEL>().ToListAsync();
            _customCache.Set("ELM_EXCEPTION_MAKE_MODEL", cachedElmExceptionMakeModel, expiration);
            return cachedElmExceptionMakeModel;
        }
        public async Task<List<CCHI_OCCUPATIONS>> cchiOcc()
        {
            var cachedCchiOccupations = _customCache.Get<List<CCHI_OCCUPATIONS>>("CCHI_OCCUPATIONS");
            if (cachedCchiOccupations != null)
            {
                return cachedCchiOccupations;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedCchiOccupations = await _repo.GetAll<CCHI_OCCUPATIONS>().ToListAsync();
            _customCache.Set("CCHI_OCCUPATIONS", cachedCchiOccupations, expiration);
            return cachedCchiOccupations;
        }
        #endregion
    }
}
