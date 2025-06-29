namespace SampleMVC.Models
{
    public class ProfileModel
    {
        public string? userId { get; set; }
        public BasicInfoModel? basicInfo { get; set; }
        public AvailabilityModel? availability { get; set; }
        public PackageModel? packageInfo { get; set; }
        public List<string>? attachmentPathes { get; set; }
    }
}
