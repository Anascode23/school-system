
using Microsoft.EntityFrameworkCore;
using school_system.Models;
using System.Reflection.Emit;


namespace school_system.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.student)
                .WithMany(sc => sc.studentCourses)
                .HasForeignKey(sc => sc.CourseId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.course)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
