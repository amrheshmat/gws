using Microsoft.AspNetCore.Mvc.Rendering;
using MWS.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SampleMVC.Models
{
    public class BasicInfoModel
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Mobile is required")]
        public string? Phone { get; set; }
        public int? experience_years { get; set; }
        public string? bio { get; set; }
        public string? City { get; set; }  // For binding selected values
        public string? ProfilePicPath { get; set; }
        public List<City>? Cities { get; set; }
        public List<string>? SelectedCategories { get; set; }      // To populate the dropdown
        public List<SelectListItem>? AvailableCategories { get; set; }      // To populate the dropdown
    }
}
