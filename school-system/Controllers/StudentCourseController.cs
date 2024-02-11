using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_system.Data;
using school_system.Models;
using school_system.Repositories.Implementations;
using school_system.Repositories.Interfaces;

namespace school_system.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourse _studentCourse;
       

        public StudentCourseController(IStudentCourse studentCourse)
        {
            _studentCourse = studentCourse;
        }

        [HttpPost]
        [Route("Enrollment")]
        public IActionResult EnrollStudentInCourse(int studentId, int courseId)
        {
            _studentCourse.EnrollStudentToCourse(studentId, courseId);
            return Ok("Student enrolled in course successfully");


        }

        [HttpGet]
        [Route("GetCoursesEnrolledByStudent")]
        public IActionResult GetCoursesEnrolledByStudent(int courseId)
        {
            var course   = _studentCourse.GetStudentsEnrolledInCourse(courseId);

            if (course == null)
                return NotFound();



            return Ok(course);
        }
        [HttpGet]
        [Route("GetCoursesEnrolledByStudents")]
        public IActionResult GetCoursesEnrolledByStudents(int studentId)
        {
            var student = _studentCourse.GetCoursesEnrolledByStudents(studentId);

            if (student == null)
                return NotFound();



            return Ok(student);
        }

    }
}
