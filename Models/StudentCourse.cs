using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_MVC.Models
{
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CrstId { get; set; }
        public int Degree { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
