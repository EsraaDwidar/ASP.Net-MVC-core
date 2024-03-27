namespace Lab3_MVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Crs_Name { get; set; }
        public int Duration { get; set; }
        public List<Department> Departments { get; set; }
        public List<StudentCourse> CourseStudent { get; set; }
    }
}
