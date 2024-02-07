using Microsoft.AspNetCore.Mvc;
using school_system.Models;
using school_system.Repositories.Interfaces;

namespace school_system.Controllers
{
    public class StudentController : Controller
    {
        private IStudent _student;

        public StudentController(IStudent st)
        {
            _student = st;
        }
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAll()
        {
            var a = _student.GetAllStudents();
            if (a == null)
            {
                return NotFound();
            }

            return Ok(a);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetStudentById(int id)
        {
            Student student = _student.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        [Route("CreatingStudent")]
        public IActionResult CreateStudent(Student student)
        {
            int st = _student.CreateStudent(student);
            if (st <= 0)
            {
                return BadRequest("Failed to create student");
            }
            else
                return Ok("Added student");
        }
        [HttpPut]
        [Route("EditDeleteStudent")]
        public IActionResult UpdateStudent(Student student)
        {
            int st = _student.UpdateStudent(student);
            if (st <= 0)
            {
                return BadRequest("Failed to edit student");
            }
            else
                return Ok("Updated student");
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            int st = _student.DeleteStudent(id);
            if (st <= 0)
            {
                return BadRequest("Failed to Delete student");
            }
            else
                return Ok("Deleted student");
        }

    }

}
