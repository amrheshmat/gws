namespace MWS.Business.Shared.Data.Models
{
    public class AggrError
    {
        public AggrError()
        {

        }
        public AggrError(string Message, string Field)
        {
            this.Field = Field;
            this.Message = Message;
        }

        public string Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
