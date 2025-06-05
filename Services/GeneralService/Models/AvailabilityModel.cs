using System.ComponentModel.DataAnnotations;

namespace SampleMVC.Models
{
    public class AvailabilityModel
    {
        [Required(ErrorMessage = "fromHour is required")]
        public string? fromHour { get; set; }
        [Required(ErrorMessage = "toHour is required")]
        public string? toHour { get; set; }
        [Required(ErrorMessage = "fromDay is required")]
        public string? fromDay { get; set; }
        [Required(ErrorMessage = "toDay is required")]
        public string? toDay { get; set; }
        public string? toPeriod { get; set; } // "AM" or "PM"
        public string? fromPeriod { get; set; } // "AM" or "PM"
    }
}
