using Microsoft.AspNetCore.Http;

namespace MWS.Data.ViewModels
{
    public class BlogViewModel
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? languageName { get; set; }
        public string? isActive { get; set; }
        public int? blogId { get; set; }
        public int? languageId { get; set; }
        public List<IFormFile>? files { get; set; }

    }
}
