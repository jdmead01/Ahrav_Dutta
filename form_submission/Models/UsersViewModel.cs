using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name="First Name")]
        [MinLength(4, ErrorMessage = "First Name must be at least 4 characters long")]
        public string First_name { get; set; }
        [Required]
        [Display(Name="Last Name")]
        [MinLength(4, ErrorMessage = "Last name must be at least 4 characters long")]
        public string Last_name { get; set; }
        [Required]
        [Display(Name="Age")]
        [Range(0,125, ErrorMessage = "Age must be between 0-125")]
        public int Age { get; set; }
        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name="Password")]
        [MinLength(8, ErrorMessage = "Password must be 8 characters long"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}