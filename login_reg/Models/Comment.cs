using System.ComponentModel.DataAnnotations;
using System;

namespace login_registration.Models
{
    public class Comment
    {
        [Required]
        [Display(Name="Comment")]
        public string comment {get; set;}
    }
}