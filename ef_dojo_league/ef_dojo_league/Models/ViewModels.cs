using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ef_dojo_league.Models{
    public class RegisterNinja
    {
        [Required(ErrorMessage = "Ninja name is required")]
        [MinLength(2, ErrorMessage = "Ninja name must be at least 2 characters long")]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "Ninja Name")]
        public string Name {get; set;}
        [Required(ErrorMessage = "Ninjaing Level is required")]
        [Range(1,10,ErrorMessage = "Ninjaing level must be between 1 and 10")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Ninjaing level must be an integer between 1 and 10")]
        [Display(Name = "Ninjaing Level (1-10)")]
        public int Level {get; set;}
        [Required(ErrorMessage = "Must select an Assigned Dojo")]
        [Display(Name = "Assigned Dojo?")]
        public int DojoId {get; set;}
        [MinLength(10, ErrorMessage = "Desription if entered must be at least 10 characters long")]
        [Display(Name = "Optional Description")]
        public string Description {get; set;}
    }
    public class RegisterDojo
    {
        [Required(ErrorMessage = "Dojo name is required")]
        [MinLength(2, ErrorMessage = "Dojo name must be at least 2 characters long")]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "Dojo Name")]
        public string Name {get; set;}
        [Required(ErrorMessage = "Dojo Location is required")]
        [MinLength(2, ErrorMessage = "Dojo location must be at least 2 characters long")]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "Dojo Location")]
        public string Location {get; set;}
        [Required(ErrorMessage = "Additional dojo information is required")]
        [MinLength(10, ErrorMessage = "Dojo information must be at least 10 characters long")]
        [Display(Name = "Additional Dojo Information")]
        public string Information {get; set;}
    }
}