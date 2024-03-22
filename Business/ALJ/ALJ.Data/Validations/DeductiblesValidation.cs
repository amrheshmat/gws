using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class DeductiblesValidation : AbstractValidator<Deductibles>
    {
        #region Constructors
        public DeductiblesValidation()
        {
            applyDeductiblesValidation();
        }
        #endregion
        #region Actions
        public void applyDeductiblesValidation()
        {
            RuleFor(x => x.DeductibleAmount).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.PolicyPremium).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.TaxableAmount).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.BasePremium).NotNull().WithMessage("required").WithErrorCode("BadRequest");
        }
        #endregion
    }
}
