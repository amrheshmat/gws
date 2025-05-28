using System.ComponentModel.DataAnnotations;

namespace SampleMVC.Models
{
    public class PackageModel
    {
        [Required(ErrorMessage = "title is required")]
        public string? title { get; set; }
        [Required(ErrorMessage = "description is required")]
        public string? description { get; set; }
        [Required(ErrorMessage = "price is required")]
        public decimal? price { get; set; }
        [Required(ErrorMessage = "duration is required")]
        public string? duration { get; set; }
        [Required(ErrorMessage = "deliverables is required")]
        public string? deliverables { get; set; }
    }
}
