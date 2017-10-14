using System.ComponentModel.DataAnnotations;
namespace lost_in_woods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Key]
        public long id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Trail Name must be at least 2 characters")]
        public string name { get; set; }
        [MinLength(10, ErrorMessage = "Trail description must be at least 10 characters long")]
        public string description { get; set; }
        [Range(0,500, ErrorMessage = "Please enter trail length between 0 and 500")]
        public int length { get; set; }
        [Range(-200,200, ErrorMessage = "Please enter elevation change between -200 and 200")]
        public int elevationChange { get; set; }
        [Range(-180, 180, ErrorMessage = "Please enter logitute between -180 and 180 degrees")]
        public double longitude { get; set; }
        [Range(-90,90, ErrorMessage = "Please enter latitude between -90 and 90 degrees")]
        public double latitude { get; set; }

    }
}