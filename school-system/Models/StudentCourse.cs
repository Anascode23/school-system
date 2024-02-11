namespace school_system.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student student { get; set; }
        public Course course { get; set; }
    }
}
