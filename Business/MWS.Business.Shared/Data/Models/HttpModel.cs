using System.Net;

namespace MWS.Business.Shared.Data.Models
{
    public class HttpModel
    {
        public HttpModel(string url, string method, object data = null)
        {
            Headers = new Dictionary<string, string>();
            QueryString = new Dictionary<string, string>();
            Data = data;
            Url = url;
            Method = method;
            Timeout = 10 * 60 * 1000;
            ContentType = "application/json;charset=UTF-8";

            AdditionalData = new Dictionary<string, object>();
            this.SecurityProtocol = SecurityProtocolType.Tls12;
            this.IsJsonBody = true;
        }

        public SecurityProtocolType SecurityProtocol { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string, string> QueryString { get; set; }



        public Dictionary<string, object> AdditionalData { get; set; }
        public object Data { get; set; }

        public string Url { get; set; }

        public string Method { get; set; }

        public long Timeout { get; set; }


        public string ContentType { get; set; }

        public bool IsJsonBody { get; set; }
    }
}
