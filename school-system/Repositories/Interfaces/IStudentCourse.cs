using school_system.Models;

namespace school_system.Repositories.Interfaces
{
    public interface IStudentCourse
    {
        void EnrollStudentToCourse(int studentId, int courseId);
        List<Student> GetStudentsEnrolledInCourse(int courseId);
        List<Course> GetCoursesEnrolledByStudents(int studentId);

        int DeleteCourse(int id);

        bool DoesCourseHaveStudents(int courseid);
    }
}
