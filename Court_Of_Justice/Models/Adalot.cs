using System.ComponentModel.DataAnnotations;

namespace Court_Of_Justice.Models
{
    public class Adalot
    {
        [Key]//pk
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Provide Court name within 50 characters")]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}