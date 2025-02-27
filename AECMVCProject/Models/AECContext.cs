using Microsoft.EntityFrameworkCore;

namespace AECMVCProject.Models
{
    public class AECContext :DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        //ConnectionString
        //Data Source=.;Initial Catalog=Amazon;Integrated Security=True;Encrypt=False

        public AECContext():base()
        {
            
        }

        public AECContext(DbContextOptions<AECContext> options) : base(options)//ask ioc 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AEC2025;Integrated Security=True;Encrypt=False");
        }
    }
}
