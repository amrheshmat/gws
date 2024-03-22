using ALJ.Data.Models;
using FluentValidation;


namespace ALJ.Data.Validations
{
    public class QuoteResponseValidation : AbstractValidator<QuoteResponse>
    {
        #region Constructors
        public QuoteResponseValidation()
        {
            applyQuoteResponseValidation();
        }
        #endregion
        #region Actions
        public void applyQuoteResponseValidation()
        {
            RuleFor(x => x.RequestReferenceNo).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.InsuranceCompanyCode).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeID).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.LesseeDateOfBirthG).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.LesseeID.ToString()!.StartsWith("2"));
            RuleFor(x => x.LesseeDateOfBirthH).NotNull().WithMessage("required").WithErrorCode("BadRequest").When(x => x.LesseeID.ToString()!.StartsWith("1"));

            RuleFor(x => x.LesseeGender).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.NCDEligibility).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.CompQuotes).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleFor(x => x.Status).NotNull().WithMessage("required").WithErrorCode("BadRequest");
            RuleForEach(x => x.CompQuotes).NotNull().WithMessage("required").WithErrorCode("BadRequest").SetValidator(new CompQuotesValidation());
            RuleForEach(x => x.DriverDetails).SetValidator(new ResponseDriverDetailValidation()).When(x => x.DriverDetails != null);
            RuleForEach(x => x.errors).SetValidator(new ErrorsValidation()).When(x => x.errors != null);

        }
        #endregion
    }
}
