namespace school_system.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public string school { get; set; }
        public DateTime startdate { get; set; }
        public int StudentId { get; set; }
    }
}
