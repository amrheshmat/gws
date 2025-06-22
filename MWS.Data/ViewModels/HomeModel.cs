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
        public string? fullName { get; set; }
        public string? category { get; set; }
        public string? city { get; set; }
        public string? gender { get; set; }
        public decimal? Price { get; set; }
        public string? Sort { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
