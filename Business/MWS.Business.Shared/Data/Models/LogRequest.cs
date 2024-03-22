namespace MWS.Business.Shared.Data.Models
{
    public class LogRequest
    {
        public string? DocCode { get; set; }



        public string? Doc { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public string? Key1 { get; set; }

        public string? Value1 { get; set; }

        public string? Key2 { get; set; }

        public string? Value2 { get; set; }

        public string? Key3 { get; set; }

        public string? Value3 { get; set; }



    }

    public class LogResponse
    {
        public long? DocId { get; set; }

    }

    public class GetDocVM
    {
        public System.String? DocType { get; set; }

        public long? DocId { get; set; }
    }

    public class GetDocResponse
    {
        public System.String? DocType { get; set; }

        public long? DocId { get; set; }

        public string Doc { get; set; }
    }

    public class GetDocDB
    {
        public string DOC { get; set; }
    }
}
