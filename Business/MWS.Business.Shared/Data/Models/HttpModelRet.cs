
using Newtonsoft.Json.Linq;

namespace MWS.Business.Shared.Data.Models
{
    public class HttpModelRet
    {
        public string Raw { get; set; }

        public JToken Ret { get; set; }

        public string StatusCode { get; set; }

        public string StatusDesc { get; set; }

        public string CachedToken { get; set; }

        public string contentType { get; set; }
    }
}
