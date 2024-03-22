namespace ALJ.Data.Models
{

    public partial class AljuQuotationSelected
    {


        public string? PolicyRequestReferenceNo { get; set; }

        public int? InsuranceCompanyCode { get; set; }
        public string? RequestReferenceNo { get; set; }

        public int? QuoteReferenceNo { get; set; }

        public string? DeductibleReferenceNo { get; set; }

        public int? DeductibleAmount { get; set; }

        public List<DynamicPremiumFeatures> PolicyPremiumFeatures { get; set; }
        public List<DynamicPremiumFeatures> DynamicPremiumFeatures { get; set; }
        public List<CustomizedParameter> CustomizedParameter { get; set; }
    }
}
