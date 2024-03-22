using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class CompQuotesValidation : AbstractValidator<CompQuotes>
    {
        #region Constructors
        public CompQuotesValidation()
        {
            applyCompQuotesValidation();
        }
        #endregion
        #region Actions
        public void applyCompQuotesValidation()
        {
            RuleFor(x => x.QuoteReferenceNo).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.PolicyTitleID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.Deductibles).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.PolicyPremiumFeatures).NotNull().WithMessage("required").WithErrorCode("BadRequest");
        }
        #endregion
    }
}
