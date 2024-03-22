using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class DiscountsValidation : AbstractValidator<Discounts>
    {
        #region Constructors
        public DiscountsValidation()
        {
            applyDiscountsValidation();
        }
        #endregion
        #region Actions
        public void applyDiscountsValidation()
        {
            RuleFor(x => x.DiscountTypeID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DiscountPercentage).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DiscountAmount).NotNull().WithMessage("required").WithErrorCode("BadRequest");
        }
        #endregion
    }
}
