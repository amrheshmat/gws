using MWS.Business.Malath.lease.Models;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;

namespace MWS.Business.Malath.lease.IBusiness
{
    public interface IQuotationBusiness
    {
        #region malath codes
        //public List<AljuQuotationRequest> GetQuotationRequest();
        public Task<AggrError> MapPartnerData(QuoteRequest quotesRequest, USERS appUser);
        public Task<AGGR_CODES> getAggrCodeObjByMalath(string key, string malathCode, int partnerCode, string branch);
        public Task<string> getNotElmMalathCode(string key, string aggrCode, decimal partnerCode, string partnerBranch);
        public Task<int?> getMalathCountryCode(string key, int partnerCode, string branch);
        public Task<List<AGGR_CODES>> getAggrCodeLookup(string key, int partnerCode, string branch);
        public Task<string> getMalathMaritalStatus(string elmMaritalStatus, int partnerCode, string branch);
        public Task<List<AggrError>> insertMappedDataAndReturnPartnerError(QuoteRequest quoteRequest, USERS appUser);
        #endregion
        //public Task<AljuQuotationRequest> AddQuotationRequest(AljuQuotationRequest aljuQuotationRequest);
    }
}
