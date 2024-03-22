using MWS.Business.Shared.Business;
using MWS.Business.Shared.Data.Models;
using System.Security.Cryptography.X509Certificates;

namespace MWS.Business.Shared.IBusiness
{
    public interface IHttpHelper
    {
        HttpModelRet CreateRequest(HttpModel model, X509Certificate2 cert = null);
        HttpModelRet CreateRequest(string url, Dictionary<string, string> headers, ContentObj content, string method, X509Certificate2 cert = null);

        DownloadFileModel DownloadFile(string url, Dictionary<string, string> headers, ContentObj content, string method);

        string createAuthorizationHeaderValue(string userName, string passWord);

        string createAuthorizationBearerValue(string token);

        string GetCachedToken(string url, string username, string password, string body, string tokenField = "access_token");

        HttpModelRet GetCachedTokenRet(string url, string username, string password, string body, string tokenField = "access_token");

        string getAuthUserHeaderValue(string username, string password);
    }
}
