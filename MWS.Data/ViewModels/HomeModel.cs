using MWS.Data.Entities;

namespace MWS.Data.ViewModels
{
    public class HomeModel
    {
        public List<Attachment>? attachments { get; set; }
        public SearchModel? searchModel { get; set; }
    }
    public class SearchModel
    {
        public string? category { get; set; }
        public string? city { get; set; }
    }
}
