using System.ComponentModel.DataAnnotations;
using System;

namespace login_registration.Models
{
    public class Message
    {
        [Required]
        [Display(Name="Message")]
        public string message {get; set;}
    }
}