using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace Court_Of_Justice.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Adalot> Adalot { get; set; }
        public DbSet<CaseDetails> CaseDetails { get; set; }
        public DbSet<CaseMaster> CaseMasters { get; set; }
        public DbSet<CaseSource> CaseSources { get; set; }
        public DbSet<Section> Sections { get; set; }

    }
}
