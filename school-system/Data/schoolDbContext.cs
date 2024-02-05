
using Microsoft.EntityFrameworkCore;
using school_system.Models;

namespace school_system.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}
