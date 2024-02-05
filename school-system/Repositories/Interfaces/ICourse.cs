using school_system.Models;

namespace school_system.Repositories.Interfaces
{
    public interface ICourse : IDisposable
    {
        IEnumerable<Course> GetAllStudents();
        Course GetCourse(int id);
        int CreateCourse(Course course);
        int UpdateCourse(Course course);
        int DeleteStudent(int id);
    }
}
