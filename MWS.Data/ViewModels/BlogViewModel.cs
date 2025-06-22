using Microsoft.AspNetCore.Http;
using MWS.Data.Entities;

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
        public List<Attachment>? attachments { get; set; }
        public Blog? blog { get; set; }

    }
}
