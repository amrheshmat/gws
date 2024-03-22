using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class DriverDetailsValidation : AbstractValidator<DriverDetails>
    {
        #region Constructors
        public DriverDetailsValidation()
        {
            applyDriverDetailsValidation();
        }
        #endregion
        #region Actions
        public void applyDriverDetailsValidation()
        {
            RuleFor(x => x.DriverID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DriverFullName).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.ArabicFirstName).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            // ArabicMiddleName must be not null if EnglishMiddleName ...
            RuleFor(x => x.ArabicMiddleName).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.EnglishMiddleName == null);
            RuleFor(x => x.EnglishFirstName).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            // EnglishMiddleName must be not null if ArabicMiddleName ...
            RuleFor(x => x.EnglishMiddleName).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.ArabicMiddleName == null);
            RuleFor(x => x.DriverNationalityID).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString()!.StartsWith("2"));
            RuleFor(x => x.VehicleUsagePercentage).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DriverOccupation).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DriverEducation).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DriverChildrenBelow16).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DriverDateOfBirthG).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString()!.StartsWith("2"));
            RuleFor(x => x.DriverDateOfBirthH).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString()!.StartsWith("1"));
            RuleFor(x => x.DriverGender).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString()!.StartsWith("1"));
            RuleFor(x => x.DriverMaritalStatus).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString()!.StartsWith("1"));
            RuleFor(x => x.DriverLicenseType).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString()!.StartsWith("1"));
            RuleFor(x => x.DriverLicenseOwnYears).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.DriverID.ToString()!.StartsWith("1"));
        }
        #endregion
    }
}
