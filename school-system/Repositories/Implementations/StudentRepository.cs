using school_system.Data;
using school_system.Models;
using school_system.Repositories.Interfaces;

namespace school_system.Repositories.Implementations
{
    public class StudentRepository : IStudent
    {
        private readonly SchoolDbContext _context;
        public StudentRepository(SchoolDbContext dbContext)
        {

            _context = dbContext;
        }
        public int CreateStudent(Student student)
        {
            int result = -1;
            if (student == null)
            {
                result = 0;
            }
            else
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                result = student.Id;
            }
            return result;
        }

        public int DeleteStudent(int id)
        {
            if (id == 0)
            {
                return -1;
            }
            var y = _context.Students.Where(x => x.Id == id).FirstOrDefault() ?? null;
            if (y != null)
            {
                _context.Students.Remove(y);
                _context.SaveChanges();
                return id;
            }
            return 0;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var x = _context.Students.ToList();
            return x;
        }

        public Student GetStudentById(int id)
        {
            var y = _context.Students.Where(x => x.Id == id).FirstOrDefault() ?? null;
            return y;
        }

        public int UpdateStudent(Student student)
        {
            var z = _context.Students.Where(x => x.Id == student.Id).FirstOrDefault() ?? null;
            if (z != null)
            {
                z.Id = student.Id;
                z.Name = student.Name;
                z.age = student.age;
                z.address = student.address;
                _context.SaveChanges();
                return z.Id;
            }
            return -1;
        }
    }


}
