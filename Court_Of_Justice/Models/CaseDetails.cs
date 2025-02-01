using System.ComponentModel.DataAnnotations.Schema;

namespace Court_Of_Justice.Models
{
    public class CaseDetails
    {
        public int Id { get; set; }
        public DateTime HieringDate { get; set; }
        public DateTime NextHieringDate { get; set; }
        public string Hiering { get; set; }
        public string Comments { get; set; }
        [ForeignKey("CaseMaster")]
        public int CaseId { get; set; }
        public CaseMaster CAseMaster { get; set; }
    }
}