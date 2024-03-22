using Microsoft.Extensions.Configuration;
using MWS.Business.Shared.Data.Models;
using MWS.Business.Shared.IBusiness;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MWS.Business.Shared.Business
{
    public class HttpHelperMethods : IHttpHelper
    {
        private IBaseUriService urlService;
        ICustomCaching customCaching;
        private readonly IConfiguration _config;
        public HttpHelperMethods(IBaseUriService _urlService, ICustomCaching _customCaching, IConfiguration config)
        {
            this.urlService = _urlService;
            this.customCaching = _customCaching;
            _config = config;
        }

        public DownloadFileModel DownloadFile(string url, Dictionary<string, string> headers, ContentObj content, string method)
        {
            string testMode = _config.GetSection("TestMode").Value;

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            DownloadFileModel ret = new DownloadFileModel();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = method;

            if (headers != null && headers.Count > 0)
            {
                foreach (var key in headers.Keys)
                {
                    req.Headers.Add(key, headers[key]);
                }
            }


            if (!string.IsNullOrWhiteSpace(content.content))
            {
                byte[] btContent = UTF8Encoding.UTF8.GetBytes(content.content);
                req.ContentLength = btContent.Length;
                if (string.IsNullOrWhiteSpace(content.contentType))
                {
                    content.contentType = getContentType(content.content);
                }
                req.ContentType = content.contentType;
                using (Stream stream = req.GetRequestStream())
                {

                    stream.Write(btContent, 0, btContent.Length);
                }
            }

            WebResponse resPonse = null;
            Exception foundException = null;
            try
            {
                resPonse = req.GetResponse();
                ret.StatusCode = "200";
                ret.contentType = resPonse.ContentType;
            }
            catch (WebException exception)
            {
                resPonse = exception.Response;
                setStatusFromException(ret, exception);
            }
            catch (Exception ex)
            {
                foundException = ex;
            }

            if (foundException != null)
            {
                throw foundException;
            }
            using (resPonse)
            {
                using (var myStream = resPonse.GetResponseStream())
                {
                    using (var reader = new BinaryReader(myStream))
                    {

                        List<byte> btBytes = new List<byte>();
                        while (true)
                        {
                            byte[] chank = reader.ReadBytes(1024 * 50);
                            if (chank.Length == 0)
                            {
                                break;
                            }
                            btBytes.AddRange(chank);
                        }

                        byte[] btRet = btBytes.ToArray();


                        ret.file = btRet;
                    }
                }
            }

            return ret;

        }


        private static void setStatusFromException(HttpModelRet ret, WebException exception)
        {
            if (exception.Status == WebExceptionStatus.ProtocolError)
            {
                ret.StatusCode = ((int)((HttpWebResponse)exception.Response).StatusCode).ToString();
                ret.StatusDesc = (((HttpWebResponse)exception.Response).StatusCode).ToString();
            }
            else
            {
                ret.StatusCode = ((int)exception.Status).ToString();
                ret.StatusDesc = "WebException: " + exception.Message;
            }
        }
        private string getContentType(string content)
        {
            content = content.Trim();
            try
            {

                JToken token = JToken.Parse(content);
                return "application/json";
            }
            catch
            {
                if (content.ToLower().StartsWith("<"))
                {
                    return "text/xml";
                }
                else
                {
                    return "application/x-www-form-urlencoded";
                }

            }


        }

        public HttpModelRet CreateRequest(HttpModel model, X509Certificate2 cert = null)
        {
            throw new NotImplementedException();
        }

        public HttpModelRet CreateRequest(string url, Dictionary<string, string> headers, ContentObj content, string method, X509Certificate2 cert = null)
        {
            throw new NotImplementedException();
        }

        public string createAuthorizationHeaderValue(string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        public string createAuthorizationBearerValue(string token)
        {
            throw new NotImplementedException();
        }

        public string GetCachedToken(string url, string username, string password, string body, string tokenField = "access_token")
        {
            throw new NotImplementedException();
        }

        public HttpModelRet GetCachedTokenRet(string url, string username, string password, string body, string tokenField = "access_token")
        {
            throw new NotImplementedException();
        }

        public string getAuthUserHeaderValue(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
