using System.ComponentModel.DataAnnotations;

namespace login_registration.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Email name is required")]
        [EmailAddress]
        public string loginEmail {get; set;}
        [DataType(DataType.Password)]
        public string loginPassword {get; set;}
    }
}