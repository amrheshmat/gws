namespace SampleMVC.Models
{
    public class FileModel
    {
        public int? tourId { get; set; }
        public List<IFormFile>? files { get; set; }
    }
}
