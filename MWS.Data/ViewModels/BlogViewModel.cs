namespace MWS.Data.ViewModels
{
    public class BlogViewModel
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? languageName { get; set; }
        public string? isActive { get; set; }
        public decimal? blogId { get; set; }
        public decimal? languageId { get; set; }
        public FileModel attachments { get; set; } = new FileModel();
    }
}
