using Microsoft.EntityFrameworkCore;

namespace Infinite.OnlineAdmission.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>Select):base(Select)
        { 
        }
        public DbSet<Course> Courses { get; set; }

    }
}
