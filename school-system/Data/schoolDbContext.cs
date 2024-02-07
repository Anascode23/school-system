
using Microsoft.EntityFrameworkCore;
using school_system.Models;

namespace school_system.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
