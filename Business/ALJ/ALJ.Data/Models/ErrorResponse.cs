namespace ALJ.Data.Models
{

    public class ErrorResponse
    {
        public long? Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
