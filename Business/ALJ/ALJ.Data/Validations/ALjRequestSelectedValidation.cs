using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class ALjRequestSelectedValidation : AbstractValidator<AljuQuotationSelected>
    {
        #region Constructors
        public ALjRequestSelectedValidation()
        {
            applyLogquestValidation();
        }
        #endregion
        #region Actions
        public void applyLogquestValidation()
        {
            RuleFor(x => x.PolicyRequestReferenceNo).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.InsuranceCompanyCode).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.RequestReferenceNo).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.QuoteReferenceNo).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DeductibleAmount).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleForEach(x => x.PolicyPremiumFeatures).SetValidator(new DynamicPremiumFeaturesValidation());
            RuleForEach(x => x.DynamicPremiumFeatures).SetValidator(new DynamicPremiumFeaturesValidation()).When(x => x.DynamicPremiumFeatures != null);
            RuleForEach(x => x.CustomizedParameter).SetValidator(new CustomizedParameterValidation()).When(x => x.CustomizedParameter != null);

        }
        #endregion
    }
}
