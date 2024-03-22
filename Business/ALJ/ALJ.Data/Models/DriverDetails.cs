namespace ALJ.Data.Models
{

    public class DriverDetails
    {

        public long? DriverID { get; set; }
        public string DriverFullName { get; set; }
        public string ArabicFirstName { get; set; }
        public string ArabicMiddleName { get; set; }
        public string ArabicLastName { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishMiddleName { get; set; }
        public string EnglishLastName { get; set; }
        public long? DriverRelation { get; set; }
        public long? DriverNationalityID { get; set; }
        public long? VehicleUsagePercentage { get; set; }
        public string DriverOccupation { get; set; }
        public string DriverEducation { get; set; }
        public long? DriverChildrenBelow16 { get; set; }
        public string DriverWorkCompanyName { get; set; }
        public long? DriverWorkCityID { get; set; }
        public List<CountriesValidDrivingLicense> CountriesValidDrivingLicense { get; set; }
        public long? DriverNoOfClaims { get; set; }
        public string DriverTrafficViolationsCode { get; set; }
        public string DriverHealthConditionsCode { get; set; }
        public string DriverDateOfBirthG { get; set; }
        public string DriverDateOfBirthH { get; set; }
        public long? DriverGender { get; set; }
        public long? DriverMaritalStatus { get; set; }
        public string DriverHomeAddressCity { get; set; }
        public string DriverHomeAddress { get; set; }
        public long? DriverLicenseType { get; set; }
        public long? DriverLicenseOwnYears { get; set; }
        public long? DriverNoOfAccidents { get; set; }


    }
}
