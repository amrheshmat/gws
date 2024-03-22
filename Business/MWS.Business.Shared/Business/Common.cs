using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MWS.Business.Shared.Data.Models;
using MWS.Business.Shared.IBusiness;
using MWS.Data.ViewModels;
using MWS.Infrustructure.Repositories;
using MWS.Repository;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MWS.Business.Shared.Business
{
    public class Common : ICommon
    {
        #region fields
        private readonly IConfiguration _config;
        private IRepository _repo;
        private ILoggerHandler<Common> _logger;
        private readonly ICustomCaching _cache;
        private IClearString _clearString;
        #endregion
        #region constructor(s)
        public Common(ILoggerHandler<Common> logger, IConfiguration config, IRepositoryFactory repository, IClearString clearString, ICustomCaching cache)
        {
            _config = config;
            _repo = repository.Create("AGGRDB");
            this._logger = logger;
            _clearString = clearString;
            _cache = cache;
        }
        #endregion
        #region general method
        public UserDTO? Getuser(HttpContext context)
        {
            UserDTO? user = null;
            //Get user regiterd by jwt token ...
            user = (UserDTO?)context.Items["User"];
            return user;

        }
        public async Task<string> GetTrxNo()
        {
            Exception foundEx = null;
            try
            {

                HttpClient client = new HttpClient();

                var baseUrl = _config.GetSection("ServiceSettings:SequenceServiceKey").Value!.ToString();

                var url = baseUrl + "api/Sequence/UPLOAD_TRX_NO";

                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(

                new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                TrxNoVM TrxNo = JsonSerializer.Deserialize<TrxNoVM>(result)!;
                return TrxNo.NewVal.ToString();
            }
            catch (Exception ex)
            {
                this._logger.logError(ex);
                foundEx = ex;
            }
            if (foundEx != null)
            {
                throw foundEx;
            }
            return null;

        }
        public RequestBody<T> getJsonString<T>(T obj)
        {
            RequestBody<T> requestModelBody = new RequestBody<T>();
            string ret = JsonSerializer.Serialize(obj)!;
            requestModelBody.BodyStr = ret;
            requestModelBody.model = obj;
            return requestModelBody;
        }
        public async Task<RequestBody<T>> getModelAndBody<T>(HttpRequest request)
        {
            RequestBody<T> requestModelBody = new RequestBody<T>();
            var bodyStr = "";
            // read body from request ...
            using (var reader = new StreamReader(request.Body, Encoding.UTF8))
            {
                bodyStr = await reader.ReadToEndAsync();
            }
            T model = JsonSerializer.Deserialize<T>(bodyStr)!;
            requestModelBody.BodyStr = bodyStr;
            requestModelBody.model = model;
            return requestModelBody;
        }
        public async Task<LogResponse> logRequestService(LogRequest logRequest)
        {
            //call log services ....
            HttpClient client = new HttpClient();
            //get log base url from setting ...
            var url = _config.GetSection("ServiceSettings:LogServiceKey").Value!.ToString();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //send post request to log api ...
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Log/logRequest", logRequest);
            //read response from log service ...
            var result = await response.Content.ReadAsStringAsync();
            //deserialize result to log response ...
            LogResponse logResponse = JsonSerializer.Deserialize<LogResponse>(result)!;
            //add log to motor aggr log table ...
            return logResponse;
        }
        public async Task<long?> getBranch(string lesseeID)
        {
            ObjectParameter P_CR_IQAMA_NO = new ObjectParameter("P_CR_IQAMA_NO", long.Parse(lesseeID));
            ObjectParameter P_PARTNER_CODE = new ObjectParameter("P_PARTNER_CODE", typeof(long));
            try
            {
                await this._repo.ExecuteProcedureAsync("NONMED.MOTOR_LEASE_PKG.GET_PARTNER_CODE_BY_CR", P_CR_IQAMA_NO, P_PARTNER_CODE);
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
            }
            if (P_PARTNER_CODE.Value == null || string.IsNullOrWhiteSpace(P_PARTNER_CODE.Value.ToString()))
            {
                return null;
            }
            else
            {
                return long.Parse(P_PARTNER_CODE.Value.ToString()!);
            }
        }
        #endregion
    }


}
