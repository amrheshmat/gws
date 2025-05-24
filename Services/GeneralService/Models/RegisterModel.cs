using System.ComponentModel.DataAnnotations;

namespace SampleMVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? userName { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        public string? fullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        public string? mobile { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? gender { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? password { get; set; }

    }
}
