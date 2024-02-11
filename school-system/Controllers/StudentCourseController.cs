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

        [HttpDelete]
        [Route("DeleteCourse")]
        public IActionResult DeleteCourse(int id)
        {
            int cr = _studentCourse.DeleteCourse(id);
            if (cr <= 0 || _studentCourse.DoesCourseHaveStudents(id))
            {

                return BadRequest("Course has students enrolled in it");
            }
            else
                return Ok("Deleted course");
        }

    }
}
