using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class QuoteSelectedResponseValidation : AbstractValidator<ResponseQuoteSelected>
    {
        #region Constructors
        public QuoteSelectedResponseValidation()
        {
            applyQuoteSelectedResponseValidation();
        }
        #endregion
        #region Actions
        public void applyQuoteSelectedResponseValidation()
        {
            RuleFor(x => x.Status).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleForEach(x => x.errors).SetValidator(new ErrorsValidation()).When(x => x.errors != null);

        }
        #endregion
    }
}
