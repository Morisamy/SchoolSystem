using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
namespace SchoolSystem.Models.HR
{
    public class HRDatabaseContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\SQLExpress; initial catalog=SchoolSystemDb; integrated security=SSPI;");
        }
    }
}
