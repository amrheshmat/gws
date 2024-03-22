namespace ALJ.Data.Models
{

    public class DynamicPremiumFeatures
    {
        public long? FeatureID { get; set; }
        public long? FeatureTypeID { get; set; }
        public decimal? FeatureAmount { get; set; }
        public decimal? FeatureTaxableAmount { get; set; }
    }
}
