namespace school_system.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string address { get; set; }



        public ICollection<Course> Courses { get; set; }
    }
}
