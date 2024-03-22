namespace ALJ.Data.Models
{

    public class CompQuotes
    {
        public long? QuoteReferenceNo { get; set; }
        public string QuoteExpiryDate { get; set; }
        public long? PolicyTitleID { get; set; }
        public List<Deductibles> Deductibles { get; set; }
        public List<DynamicPremiumFeatures> PolicyPremiumFeatures { get; set; }
        public List<CustomizedParameter> CustomizedParameter { get; set; }
    }
}
