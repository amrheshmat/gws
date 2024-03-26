namespace MWS.Business.Shared.Data.Models
{
    public class Response
    {
        public Response()
        {

        }
        public Response(string Message, bool Status)
        {
            this.Status = Status;
            this.Message = Message;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}
