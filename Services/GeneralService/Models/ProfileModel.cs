namespace SampleMVC.Models
{
    public class ProfileModel
    {
        public BasicInfoModel? basicInfo { get; set; }      // To populate the dropdown
        public PackageModel? packageInfo { get; set; }      // To populate the dropdown
    }
}
