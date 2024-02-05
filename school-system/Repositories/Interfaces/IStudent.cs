using school_system.Models;

namespace school_system.Repositories.Interfaces
{
    public interface IStudent : IDisposable
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        int CreateStudent(Student student);
        int UpdateStudent(Student student);
        int DeleteStudent(int id);
    }
}
