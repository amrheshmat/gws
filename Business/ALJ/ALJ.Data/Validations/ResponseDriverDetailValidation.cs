using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class ResponseDriverDetailValidation : AbstractValidator<ResponseDriverDetails>
    {
        #region Constructors
        public ResponseDriverDetailValidation()
        {
            applyResponseDriverDetailValidation();
        }
        #endregion
        #region Actions
        public void applyResponseDriverDetailValidation()
        {
            RuleFor(x => x.DriverID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DriverName).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleUsagePercentage).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DriverDateOfBirthG).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString().StartsWith("2"));
            RuleFor(x => x.DriverDateOfBirthH).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString().StartsWith("1"));
            RuleFor(x => x.DriverGender).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.NCDEligibility).NotNull().WithMessage("required").WithErrorCode("BadRequest");
        }
        #endregion
    }
}
