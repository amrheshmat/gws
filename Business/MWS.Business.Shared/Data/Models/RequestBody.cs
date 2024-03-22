namespace MWS.Business.Shared.Data.Models
{
    public class RequestBody<T>
    {
        //return body as string and mdel from any hhtp request ...
        public string? BodyStr { get; set; }
        public T model { get; set; }

    }
}
