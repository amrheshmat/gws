using MWS.Data.Entities;
using MWS.Data.ViewModels;

namespace SampleMVC.Models
{
    public class ServiceProvidersModel
    {
        public SearchModel? searchModel { get; set; }
        public List<subscriberModel>? subscribers { get; set; }
        public int? totalCount { get; set; }
        public int? totalPages { get; set; }
    }
    public class subscriberModel
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? ProfileImage { get; set; }
        public string? City { get; set; }
        public List<string>? Categories { get; set; }
        public List<Package>? Packages { get; set; }

    }
}
