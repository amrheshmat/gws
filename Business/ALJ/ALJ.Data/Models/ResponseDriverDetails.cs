namespace ALJ.Data.Models
{

    public class ResponseDriverDetails
    {
        public long? DriverID { get; set; }
        public string DriverName { get; set; }
        public long? VehicleUsagePercentage { get; set; }
        public string DriverDateOfBirthG { get; set; }
        public string DriverDateOfBirthH { get; set; }
        public long? DriverGender { get; set; }

        public long? NCDEligibility { get; set; }
    }
}
