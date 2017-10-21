using System.ComponentModel.DataAnnotations;
using System;
namespace the_dojo_league.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Ninja Name:")]
        [MinLength(4, ErrorMessage = "Ninja name must be at least 4 characters long")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Ninjaing Level (1-10")]
        [Range(1,10, ErrorMessage = "Ninjaing level must be between 1 and 10")]
        public int level { get; set; }
        [Display(Name = "Optional description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Dojo location")]
        public Dojo dojo { get; set; }
    }
}