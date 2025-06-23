namespace SampleMVC.Models
{
    public class BlogsModel
    {
        public List<BlogModel>? blogs { get; set; }
        public int? totalCount { get; set; }
        public int? totalPages { get; set; }
    }
    public class BlogModel
    {
        public int blogId { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? BlogImage { get; set; }
        public string? isActive { get; set; }
        public DateTime? creationDate { get; set; }
    }
}
