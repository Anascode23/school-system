using school_system.Models;

namespace school_system.Repositories.Interfaces
{
    public interface ICourse : IDisposable
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        int CreateCourse(Course course);
        int UpdateCourse(Course course);
        int DeleteCourse(int id);
        void Complete();
    }
}
