using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
    public class RegisterUser
    {
        [Required(ErrorMessage="First name is required")]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters")]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}
        [Required(ErrorMessage="Last Name is required")]
        [MinLength(2, ErrorMessage="Last Name must be at least 2 characters")]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}
        [Required(ErrorMessage="Email is required")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email {get; set;}
        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be 8 characters long")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password {get; set;}
        [Compare("Password", ErrorMessage="Password and password confirmation do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm {get; set;}
    }
    public class LoginUser
    {
        [Required(ErrorMessage="Email is required")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string LogEmail {get; set;}
        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be 8 characters long")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string LogPassword {get; set;}
    }
    public class NewWedding
    {
        [Required]
        [MinLength(2, ErrorMessage="Wedder One name must be at least 2 characters")]
        [Display(Name = "Wedder One")]
        public string Groom {get; set;}
        [Required]
        [MinLength(2, ErrorMessage="Wedder Two name must be at least 2 characters")]
        [Display(Name = "Wedder Two")]
        public string Bride {get; set;}
        [Required]
        [Display(Name = "Date")]
        [CheckDateRange]
        public DateTime Date {get; set;}
        [Required]
        public string Address {get; set;}
    }
    public class DashboardModels
    {
        public List<Wedding> allWeddings {get; set;}
        public User User {get; set;}
        public List<Wedding> JoinedWeddings {get; set;}
        public List<Wedding> NotJoinedWeddings {get; set;}
    }
    public class CheckDateRangeAttribute: ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        DateTime dt = (DateTime)value;
        if (dt >= DateTime.UtcNow) {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Make sure your date is in the future");
        }
    }
}