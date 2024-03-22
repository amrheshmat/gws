using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class CustomizedParameterValidation : AbstractValidator<CustomizedParameter>
    {
        #region Constructors
        public CustomizedParameterValidation()
        {
            applyCustomizedParameterValidation();
        }
        #endregion
        #region Actions
        public void applyCustomizedParameterValidation()
        {
            RuleFor(x => x.Key).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.Value1).NotNull().WithMessage("required").WithErrorCode("BadRequest");
        }
        #endregion
    }
}
