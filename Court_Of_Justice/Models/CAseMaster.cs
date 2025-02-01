using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Court_Of_Justice.Models
{
    public class CaseMaster
    {
        public int ID { get; set; }
        public string CaseNumber { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(formate)]
        [Display(Name = "Case Date ")]
        public DateTime CaseDate { get; set; }
        [ForeignKey("Section")]
        [DisplayName("Section")]
        public int SectionId { get; set; }
        [ForeignKey("Adalot")]
        public int AdalotId { get; set; }
        public Section Section { get; set; }
        public Adalot Adalot { get; set; }
    }
}