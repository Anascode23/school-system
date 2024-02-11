namespace school_system.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string school { get; set; }
        public DateTime startdate { get; set; }


        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
