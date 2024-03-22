using ALJ.Data.Models;
using FluentValidation;
using MWS.Business.Shared.Data.Models;



namespace ALJ.Data.Validations
{
    public class AljRequestValidation : AbstractValidator<AljuQuotationRequest>
    {
        #region Constructors
        public AljRequestValidation()
        {
            applyAljRequestValidation();
        }
        #endregion
        #region Actions
        public void applyAljRequestValidation()
        {
            RuleFor(x => x.RequestReferenceNo).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.InsuranceCompanyCode).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LessorNameEN).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LessorID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LessorBranch).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            //validate national address mandtory fields ...
            RuleForEach(x => x.LessorNationalAddress).NotNull().WithMessage("required").WithErrorCode("BadRequest").SetValidator(new NationalAddressValidation());
            RuleFor(x => x.PurposeofVehicleUseID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleTransmission).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleNightParking).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleMakeCodeNIC).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleMakeTextNIC).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleMakeCodeIHC).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleModelCodeNIC).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleModelTextNIC).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleModelCodeIHC).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.ManufactureYear).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleColorCode).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleSumInsured).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.DepreciationratePercentage).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.RepairMethod).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.FullName).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.VehicleUsagePercentage).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeOccupation).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeEducation).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeChildrenBelow16).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeGender).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeMaritalStatus).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeLicenseType).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeLicenseOwnYears).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeNCDCode).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleForEach(x => x.LesseeNationalAddress).NotNull().WithMessage("required").WithErrorCode("BadRequest")
                .SetValidator(new NationalAddressValidation());
            RuleFor(x => x.IsRenewal).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            // The PolicyNumber will be mandtory If IsRenewal: true else, NO ... 
            RuleFor(x => x.PolicyNumber).NotNull().WithErrorCode("BadRequest").WithMessage("required").When(x => x.IsRenewal == true);
            RuleFor(x => x.ArabicFirstName).NotNull().WithErrorCode("BadRequest").WithMessage("required").When(x => x.EnglishFirstName == null);
            RuleFor(x => x.EnglishFirstName).NotNull().WithErrorCode("BadRequest").WithMessage("required").When(x => x.ArabicFirstName == null);
            RuleFor(x => x.LesseeNationalityID).NotNull().WithErrorCode("BadRequest").WithMessage("required").When(x => x.LesseeID.ToString()!.StartsWith("2"));
            RuleFor(x => x.LesseeDateOfBirthG).NotNull().WithErrorCode("BadRequest").WithMessage("required").When(x => x.LesseeID.ToString()!.StartsWith("2"));
            RuleFor(x => x.LesseeDateOfBirthH).NotNull().WithErrorCode("BadRequest").WithMessage("required").When(x => x.LesseeID.ToString()!.StartsWith("1"));
            //if CustomizedParameter not null then validate mandtory field in it ...
            RuleForEach(x => x.CustomizedParameter).SetValidator(new CustomizedParameterValidation()).When(x => x.CustomizedParameter != null);
            //if DriverDetails not null then validate mandtory field in it ...
            RuleForEach(x => x.DriverDetails).SetValidator(new DriverDetailsValidation()).When(x => x.DriverDetails != null);
        }
        public List<AggrError> getValidationErrors(AljuQuotationRequest model)
        {
            AljRequestValidation validationRules = new AljRequestValidation();
            var validateResult = validationRules.Validate(model);
            List<AggrError> invalidErrors = new List<AggrError>();
            if (!validateResult.IsValid)
            {
                foreach (var error in validateResult.Errors)
                {
                    AggrError invalidError = new AggrError();
                    invalidError.Message = error.ErrorMessage;
                    invalidError.Code = error.ErrorCode;
                    invalidError.Field = error.PropertyName;
                    invalidErrors.Add(invalidError);
                }
            }
            return invalidErrors;
        }
        #endregion
    }
}
