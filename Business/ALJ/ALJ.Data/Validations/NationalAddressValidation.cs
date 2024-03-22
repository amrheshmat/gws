using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class NationalAddressValidation : AbstractValidator<NationalAddress>
    {
        #region Constructors
        public NationalAddressValidation()
        {
            applyNationalAddressValidation();
        }
        #endregion
        #region Actions
        public void applyNationalAddressValidation()
        {
            RuleFor(x => x.BuildingNumber).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.City).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.ZipCode).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.AdditionalNumber).NotNull().WithMessage("required").WithErrorCode("BadRequest");
        }
        #endregion
    }
}
