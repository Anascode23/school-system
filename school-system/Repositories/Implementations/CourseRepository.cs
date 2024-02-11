using Microsoft.EntityFrameworkCore;
using school_system.Data;
using school_system.Models;
using school_system.Repositories.Interfaces;

namespace school_system.Repositories.Implementations
{
    public class CourseRepository : ICourse
    {
        private readonly SchoolDbContext _context;
        public CourseRepository(SchoolDbContext dbContext)
        {

            _context = dbContext;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public int CreateCourse(Course course)
        {
            int result = -1;
            if (course == null)
            {
                result = 0;
            }
            else
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                result = course.Id;
            }
            return result;
        }


        public void Dispose()
        {
            _context?.Dispose();
        }


        public IEnumerable<Course> GetAllCourses()
        {
            var x = _context.Courses.ToList();
            return x;
        }

        public Course GetCourseById(int id)
        {
            var y = _context.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == id);
            return y;
        }

        public int UpdateCourse(Course course)
        {
            var z = _context.Courses.Where(x => x.Id == course.Id).FirstOrDefault() ?? null;
            if (z != null)
            {
                z.name = course.name;
                z.startdate = course.startdate;
                _context.SaveChanges();
                return z.Id;
            }
            return -1;
        }
    }
}
