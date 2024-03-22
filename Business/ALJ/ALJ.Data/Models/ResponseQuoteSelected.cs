namespace ALJ.Data.Models
{

    public class ResponseQuoteSelected
    {
        public bool Status { get; set; }

        public List<ErrorResponse> errors { get; set; }
    }
}
