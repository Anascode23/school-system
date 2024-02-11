using Microsoft.EntityFrameworkCore;
using school_system.Data;
using school_system.Models;
using school_system.Repositories.Interfaces;

namespace school_system.Repositories.Implementations
{
    public class StudentCourseRepository : IStudentCourse
    {
        private readonly SchoolDbContext _schoolDbContext;
        private readonly IStudent _student;
        private readonly ICourse _course;

        public StudentCourseRepository(SchoolDbContext schoolDbContext, IStudent student, ICourse course)
        {
            _schoolDbContext = schoolDbContext;
            _student = student;
            _course = course;
        }

        public void EnrollStudentToCourse(int studentId, int courseId)
        {
            var student = _student.GetStudentById(studentId);
            var course = _course.GetCourseById(courseId);
            var enrollment = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };
        
            _schoolDbContext.StudentCourses.Add(enrollment);
            _schoolDbContext.SaveChanges();
        }

        public List<Student> GetStudentsEnrolledInCourse(int courseId)
        {
            return _schoolDbContext.StudentCourses
            .Where(e => e.CourseId == courseId)
            .Select(e => e.student)
            .ToList();
        }

        public List<Course> GetCoursesEnrolledByStudents(int studentId)
        {
            return _schoolDbContext.StudentCourses
            .Where(e => e.StudentId == studentId)
            .Select(e => e.course)
            .ToList();
        }

        public int DeleteCourse(int courseid)
        {
            if (courseid == 0)
            {
                return -1;
            }
            var y = _schoolDbContext.Courses.Where(x => x.Id == courseid).FirstOrDefault() ?? null;
            if (y != null)
            {
                _schoolDbContext.Courses.Remove(y);
                _schoolDbContext.SaveChanges();
                return courseid;
            }
            return 0;
        }

        public bool DoesCourseHaveStudents(int courseId)
        {
            return _schoolDbContext.StudentCourses.Any(e => e.CourseId == courseId);
        }


    }
}
