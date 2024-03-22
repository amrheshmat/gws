using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class ErrorsValidation : AbstractValidator<ErrorResponse>
    {
        #region Constructors
        public ErrorsValidation()
        {
            applyErrorsValidation();
        }
        #endregion
        #region Actions
        public void applyErrorsValidation()
        {
            RuleFor(x => x.Field).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.Message).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.Code).NotNull().WithMessage("required").WithErrorCode("BadRequest");
        }
        #endregion
    }
}
