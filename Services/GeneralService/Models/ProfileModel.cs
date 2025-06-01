namespace SampleMVC.Models
{
    public class ProfileModel
    {
        public string? userId { get; set; }
        public BasicInfoModel? basicInfo { get; set; }      // To populate the dropdown
        public AvailabilityModel? availability { get; set; }      // To populate the dropdown
        public PackageModel? packageInfo { get; set; }      // To populate the dropdown
    }
}
