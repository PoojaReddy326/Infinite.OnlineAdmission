using Microsoft.EntityFrameworkCore;

namespace Infinite.OnlineAdmission.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>Select):base(Select)
        { 
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ApplicationStatus> Status { get; set; }
        public DbSet<Documents> Uploads { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ApplicationForm> forms { get; set; }
        public DbSet<RegUser> Regdusers { get; set; }
        public DbSet<Admin> admins { get; set; }



    }
}
