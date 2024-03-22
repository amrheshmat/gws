using MWS.Data.Entities;

namespace MWS.Business.Malath.lease.IBusiness
{
    public interface ILeaseCaching
    {
        public Task<List<LOOKUP_DETAILS>> GetCachedLookupDetails();
        public Task<List<AGGR_CODES>> GetCachedAggrCodeByBranchAndPartner(decimal partnerCode, string partnerBranch);
        public Task<List<PARTNER_BR_PLAN_TARIFF>> partnerBrPlanTariff();
        public Task<List<GEN_PLAN_SCHEME_COV_CONDITIONS>> covConditionsTypeFiltered();
        public Task<List<PARTNER_PLANS>> partnerPlansLease();
        public Task<List<GEN_PROD_PLANS>> genProdPlansLease();
        public Task<List<MODEL_BODY_TYPE>> modelBodyTypes();
        public Task<List<ELM_EXCEPTION_MAKE_MODEL>> elmExceptionMakeModel();
        public Task<List<CCHI_OCCUPATIONS>> cchiOcc();
    }
}
