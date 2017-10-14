using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Restauranter.Models
{
    public class Reviews
    {
        public int Id {get; set;}
        public string ReviewerName {get; set;}
        public string RestaurantName {get; set;}
        public string Review {get; set;}
        public DateTime DateOfVisit {get; set;}
        public int Rating {get; set;}
    }
    public class newReview 
    {
        [Required(ErrorMessage="Reviewer name is required")]
        public string ReviewerName {get; set;}
        [Required(ErrorMessage="Restaurant name is required")]
        public string RestaurantName {get; set;}
        [Required]
        [MinLength(10)]
        public string Review {get; set;}
        [Required]
        [CheckDateRange]
        public DateTime DateOfVisit {get; set;}
        [Required]
        [Range(0,9)]
        public int Rating {get; set;}
    }
    public class CheckDateRangeAttribute: ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        DateTime dt = (DateTime)value;
        if (dt <= DateTime.UtcNow) {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Make sure your date is <= than today");
    }

}
}