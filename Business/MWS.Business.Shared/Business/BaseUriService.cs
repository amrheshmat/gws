using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MWS.Business.Shared.IBusiness;
using System.Web;

namespace MWS.Business.Shared.Business
{


    public class BaseUriService : ControllerBase, IBaseUriService
    {
        #region fields
        private readonly IUrlHelper _urlHelper;
        #endregion
        #region constructor(s)
        public BaseUriService(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        #endregion
        #region methods
        public string addParameterToUrl(string url, string parameterName, string value)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[parameterName] = value;

            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();

        }
        public string getAbsoluteUrl()
        {
            if (HttpContext == null)
                return "";
            return HttpContext.Request.GetEncodedUrl(); ;
        }
        public string getBaseUrl(HttpRequestMessage Request)
        {
            string baseUrl = "";
            if (Request == null)
            {
                if (HttpContext == null)
                    return "";
                return HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + HttpContext.Request.PathBase.ToString().TrimEnd('/') + "/";


            }
            else
            {

                //// baseUrl = Request.GetRequestContext().Url.Content((Request.GetRequestContext().VirtualPathRoot)).Trim();


                baseUrl = HttpContext.Request.PathBase;

                // Get the URL content
                var contentUrl = _urlHelper.Content(baseUrl);

                // Trim any leading or trailing whitespace
                var trimmedContentUrl = contentUrl?.Trim();

                if (!baseUrl.EndsWith("/"))
                {
                    baseUrl = baseUrl + "/";

                }
            }

            return baseUrl;


        }
        #endregion
    }
}
