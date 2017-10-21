using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace the_dojo_league.Models
{
    public abstract class BaseEntity {}
    public class Dojo : BaseEntity
    {
        public Dojo(){
            ninjas = new List<Ninja>();
        }
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Dojo Name:")]
        [MinLength(3, ErrorMessage = "Dojo name must be at least 3 characters long")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Dojo location:")]
        [MinLength(2, ErrorMessage = "Dojo location must be at least 2 characters")]
        public string location { get; set; }
        public string information { get; set; }
        public ICollection<Ninja> ninjas { get; set; }
    }
}