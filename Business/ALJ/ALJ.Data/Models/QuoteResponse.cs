namespace ALJ.Data.Models
{

    public class QuoteResponse
    {
        public string RequestReferenceNo { get; set; }
        public long? InsuranceCompanyCode { get; set; }
        public long? LesseeID { get; set; }
        public long? VehicleUsagePercentage { get; set; }
        public string LesseeDateOfBirthG { get; set; }
        public string LesseeDateOfBirthH { get; set; }
        public long? LesseeGender { get; set; }
        public long? NCDEligibility { get; set; }
        public List<NajmCaseDetails> NajmCaseDetails { get; set; }
        public List<ResponseDriverDetails> DriverDetails { get; set; }
        public List<CompQuotes> CompQuotes { get; set; }

        public string QuotaionExpiryDate { get; set; }

        public bool Status { get; set; }

        public List<ErrorResponse> errors { get; set; }

    }
}
