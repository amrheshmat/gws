using ALJ.Data.Models;
using Microsoft.AspNetCore.Mvc;
using MWS.Business.ALJ.IBusinessALJ;
using MWS.Business.Malath.lease.IBusiness;
using MWS.Business.Shared.Data.Models;
using MWS.Business.Shared.IBusiness;

namespace ALJU.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        IQuotationBusiness _quotationBusiness;
        IQuotationALJBusiness _quotationALJBusiness;
        ICommon _common;
        ILoggerHandler<QuotationController> _loggerHandler;
        public QuotationController(ILoggerHandler<QuotationController> loggerHandler, ICommon common, IQuotationBusiness quotationBusiness, IQuotationALJBusiness quotationALJBusiness)
        {
            _quotationBusiness = quotationBusiness;
            _quotationALJBusiness = quotationALJBusiness;
            _common = common;
            _loggerHandler = loggerHandler;
        }
        //[HttpGet("/GetQuotationRequest")]

        //public List<AljuQuotationRequest> GetQuotationRequest()
        //{

        //    // to set new connection string and send it to dbcontext ...
        //    _dataSourceProvider.CurrentDataSource = DataSource.AGGRDB;
        //    string connectionString = _dataSourceProvider.GetConnectionString();
        //    //send connection string to business and then to dbcontex ...
        //    return _quotationBusiness.GetQuotationRequest();
        //}
        [HttpPost("/AddQuotationRequest")]

        public async Task<object> AddQuotationRequest()
        {
            //get new quote number
            string trx = await _common.GetTrxNo();
            RequestBody<object> ret = null;
            try
            {


                //_loggerHandler.logInformation("error information message...");
                //get body as string and model from request ...
                RequestBody<AljuQuotationRequest> requestModelBody = await _common.getModelAndBody<AljuQuotationRequest>(Request);


                //call log request ...
                _quotationALJBusiness.LogRequestBody(requestModelBody.BodyStr, trx);

                //call ALJ business ...
                var quoteRet = await _quotationALJBusiness.AddQuotationRequest(requestModelBody.model, trx, HttpContext);

                ret = _common.getJsonString((object)quoteRet);

                return quoteRet;
            }
            catch (Exception ex)
            {
                _loggerHandler.logError(ex);


                //TODO return unknown error
                ErrorResponse resp = new ErrorResponse();
                resp.Code = 500;
                resp.Message = ex.ToString();
                ret = _common.getJsonString((object)resp);

                return ret;
            }
            finally
            {
                _quotationALJBusiness.LogResponseBody(ret?.BodyStr, trx);
            }
        }

    }
}
