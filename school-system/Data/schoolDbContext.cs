
using Microsoft.EntityFrameworkCore;
using school_system.Models;

namespace school_system.Data
{
    public class schoolDbContext : DbContext
    {
        public schoolDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}
