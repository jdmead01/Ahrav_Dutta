using System.ComponentModel.DataAnnotations;

namespace login_registration.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="First name is required")]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string first_name {get; set;}
        [Required(ErrorMessage="Last name is required")]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string last_name {get; set;}
        [Required(ErrorMessage="Email name is required")]
        [EmailAddress]
        public string email {get; set;}
        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be 8 characters long")]
        [DataType(DataType.Password)]
        public string password {get; set;}
        [Compare("password", ErrorMessage="Password and password confirmation do not match")]
        [DataType(DataType.Password)]
        public string password_confirm {get; set;}
    }
}