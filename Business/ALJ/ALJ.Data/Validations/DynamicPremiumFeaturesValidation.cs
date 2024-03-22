using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class DynamicPremiumFeaturesValidation : AbstractValidator<DynamicPremiumFeatures>
    {
        #region Constructors
        public DynamicPremiumFeaturesValidation()
        {
            applyDynamicPremiumFeaturesValidation();
        }
        #endregion
        #region Actions
        public void applyDynamicPremiumFeaturesValidation()
        {
            RuleFor(x => x.FeatureID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.FeatureTypeID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.FeatureAmount).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.FeatureTypeID == 1);
            RuleFor(x => x.FeatureTaxableAmount).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.FeatureTypeID == 1);
        }
        #endregion
    }
}
