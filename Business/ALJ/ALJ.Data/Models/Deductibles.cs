namespace ALJ.Data.Models
{

    public class Deductibles
    {
        public long? DeductibleAmount { get; set; }
        public decimal? PolicyPremium { get; set; }
        public decimal? TaxableAmount { get; set; }
        public decimal? BasePremium { get; set; }
        public List<PremiumBreakdown> PremiumBreakdown { get; set; }
        public List<DynamicPremiumFeatures> DynamicPremiumFeatures { get; set; }

        public List<Discounts> Discounts { get; set; }

        public string DeductibleReferenceNo { get; set; }
    }
}
