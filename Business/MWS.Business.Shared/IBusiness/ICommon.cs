using Microsoft.AspNetCore.Http;
using MWS.Business.Shared.Data.Models;

namespace MWS.Business.Shared.IBusiness
{
    public interface ICommon
    {
        #region general method
        public UserDTO? Getuser(HttpContext context);
        Task<string> GetTrxNo();
        public Task<RequestBody<T>> getModelAndBody<T>(HttpRequest request);
        Task<LogResponse> logRequestService(LogRequest logRequest);
        RequestBody<T> getJsonString<T>(T obj);
        public Task<long?> getBranch(string lesseeID);
        #endregion

    }
}
