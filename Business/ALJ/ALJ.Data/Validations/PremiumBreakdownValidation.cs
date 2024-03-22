using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class PremiumBreakdownValidation : AbstractValidator<PremiumBreakdown>
    {
        #region Constructors
        public PremiumBreakdownValidation()
        {
            applyPremiumBreakdownValidation();
        }
        #endregion
        #region Actions
        public void applyPremiumBreakdownValidation()
        {
            RuleFor(x => x.BreakdownTypeID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.BreakdownAmount).NotNull().WithMessage("required").WithErrorCode("BadRequest");
        }
        #endregion
    }
}
