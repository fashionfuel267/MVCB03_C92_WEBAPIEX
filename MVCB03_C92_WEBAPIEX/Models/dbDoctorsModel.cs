using Microsoft.EntityFrameworkCore;

namespace MVCB03_C92_WEBAPIEX.Models
{
    public class dbDoctorsModel:DbContext
    {
        public dbDoctorsModel( DbContextOptions<dbDoctorsModel> options):base(options   )
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<DoctorsDpartment> DoctorsDpartment { get; set; }
    }
}
