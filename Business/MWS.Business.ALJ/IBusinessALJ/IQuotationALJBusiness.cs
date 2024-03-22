using ALJ.Data.Models;
using Microsoft.AspNetCore.Http;
using MWS.Data.Entities;

namespace MWS.Business.ALJ.IBusinessALJ
{
    public interface IQuotationALJBusiness
    {
        #region log
        Task LogRequestBody(string bodyStr, string trx);
        Task LogResponseBody(string bodyStr, string trx);
        #endregion
        #region quotaion
        public Task<object> AddQuotationRequest(AljuQuotationRequest aljuQuotationRequest, string trx, HttpContext httpContext);
        Task<QuoteRequest> AddQuotationRequestMapping(AljuQuotationRequest aljuQuotationRequest, string trx);
        #endregion
    }
}
