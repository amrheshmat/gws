namespace ALJ.Data.Models
{
    public partial class AljuQuotationRequest
    {

        public AljuQuotationRequest()
        {
            CountriesValidDrivingLicense = new List<CountriesValidDrivingLicense>();
            LessorNationalAddress = new List<NationalAddress>();
            NajmCaseDetails = new List<NajmCaseDetails>();
            DriverDetails = new List<DriverDetails>();
            CustomizedParameter = new List<CustomizedParameter>();
            LesseeNationalAddress = new List<NationalAddress>();
        }



        public string? RequestReferenceNo { get; set; }

        public int? InsuranceCompanyCode { get; set; }

        public string? LessorNameEN { get; set; }

        public decimal? LessorID { get; set; }

        public int? LessorBranch { get; set; }

        public bool? IsRenewal { get; set; }

        public string? PolicyNumber { get; set; }

        public int? PurposeofVehicleUseID { get; set; }

        public int? Cylinders { get; set; }

        public int? VehicleMileage { get; set; }

        public int? VehicleExpectedMileageYear { get; set; }

        public float? VehicleEngineSizeCC { get; set; }

        public int? VehicleTransmission { get; set; }

        public int? VehicleNightParking { get; set; }

        public int? VehicleCapacity { get; set; }

        public int? VehicleBodyCode { get; set; }

        public int? VehicleMakeCodeNIC { get; set; }

        public string? VehicleMakeTextNIC { get; set; }
        public int? VehicleMakeCodeIHC { get; set; }

        public int? VehicleModelCodeNIC { get; set; }

        public string? VehicleModelTextNIC { get; set; }

        public int? VehicleModelCodeIHC { get; set; }

        public int? ManufactureYear { get; set; }

        public int? VehicleColorCode { get; set; }

        public string? VehicleModifications { get; set; }

        public int? VehicleSumInsured { get; set; }

        public float? DepreciationratePercentage { get; set; }

        public int? RepairMethod { get; set; }

        public int? LesseeID { get; set; }
        public int? VehicleUsagePercentage { get; set; }


        public string? FullName { get; set; }

        public string? ArabicFirstName { get; set; }

        public string? ArabicMiddleName { get; set; }

        public string? ArabicLastName { get; set; }

        public string? EnglishFirstName { get; set; }

        public string? EnglishMiddleName { get; set; }

        public string? EnglishLastName { get; set; }

        public int? LesseeNationalityID { get; set; }


        public string? LesseeOccupation { get; set; }

        public string? LesseeEducation { get; set; }

        public int? LesseeChildrenBelow16 { get; set; }

        public string? LesseeWorkCompanyName { get; set; }

        //TODO alj mapping
        public int? LesseeWorkCityID { get; set; }

        public int? LesseeNoOfClaims { get; set; }

        public string? LesseeTrafficViolationsCode { get; set; }

        public string? LesseeHealthConditionsCode { get; set; }

        public string? LesseeDateOfBirthG { get; set; }

        public string? LesseeDateOfBirthH { get; set; }

        public int? LesseeGender { get; set; }

        public int? LesseeMaritalStatus { get; set; }

        public int? LesseeLicenseType { get; set; }

        public int? LesseeLicenseOwnYears { get; set; }

        public string? LesseeNCDCode { get; set; }

        public string? LesseeNCDReference { get; set; }

        public int? LesseeNoOfAccidents { get; set; }

        public List<NationalAddress> LessorNationalAddress { get; set; }

        public List<CountriesValidDrivingLicense> CountriesValidDrivingLicense { get; set; }

        public List<NajmCaseDetails> NajmCaseDetails { get; set; }

        public List<DriverDetails> DriverDetails { get; set; }
        public List<CustomizedParameter> CustomizedParameter { get; set; }
        public List<NationalAddress> LesseeNationalAddress { get; set; }

    }
}
