﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_system.Data;
using school_system.Models;
using school_system.Repositories.Interfaces;

namespace school_system.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _course;
        private readonly IStudent _student;
        private readonly SchoolDbContext _context;

        public CourseController(ICourse course, IStudent student, SchoolDbContext dbContext)
        {
            _course = course;
            _student = student;
            _context = dbContext;
        }
        [HttpGet]
        [Route("GetAllCourses")]
        public IActionResult GetAll()
        {
            var a = _course.GetAllCourses();
            if (a == null)
            {
                return NotFound();
            }

            return Ok(a);
        }
        [HttpGet]
        [Route("GetCourseById")]
        public IActionResult GetCourseById(int id)
        {
            Course course = _course.GetCourseById(id);
            if (course == null)
            {
                return NotFound("Course not found");
            }
            return Ok(course);
        }

        [HttpGet]
        [Route("GetStudentsEnrolledInCourse")]
        public IActionResult GetStudentsEnrolledInCourse(int courseId)
        {
            var course = _context.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == courseId);

            if (course == null)
                return NotFound();


            var studentsEnrolled = course.Students;


            return Ok(studentsEnrolled);
        }

       /* [HttpGet]
        [Route("GetCoursesEnrolledByStudent")]
        public IActionResult GetCoursesEnrolledByStudent(int studentId)
        {
            var student = _context.Students.Include(s => s.Courses).FirstOrDefault(s => s.Id == studentId);

            if (student == null)
                return NotFound();


            var CoursesEnrolled = student.Courses;


            return Ok(CoursesEnrolled);
        }*/
        [HttpPost]
        [Route("CreatingCourse")]
        public IActionResult CreateCourse(Course course)
        {
            int cr = _course.CreateCourse(course);
            if (cr <= 0)
            {
                return BadRequest("Failed to create course");
            }
            else
                return Ok("Added course");
        }
        [HttpPost]
        [Route("EnrollStudentInCourse")]
        public IActionResult EnrollStudentInCourse(int studentId, int courseId)
        {
            var student = _student.GetStudentById(studentId);
            var course = _course.GetCourseById(courseId);

            if (student == null || course == null)
            {
                return BadRequest("StudentId or CourseId was not found");
            }
            course.Students.Add(student);
            _course.Complete();
            return Ok("Added student to course");
        }

        [HttpPut]
        [Route("EditCourse")]
        public IActionResult UpdateCourse(Course course)
        {
            int cr = _course.UpdateCourse(course);
            if (cr <= 0)
            {
                return BadRequest("Failed to edit course");
            }
            else
                return Ok("Updated course");
        }
        [HttpDelete]
        [Route("DeleteCourse")]
        public IActionResult DeleteCourse(int id)
        {
            int cr = _course.DeleteCourse(id);
            if (cr <= 0)
            {
                return BadRequest("Failed to Delete course");
            }
            else
                return Ok("Deleted course");
        }
    }

}
