
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_MVC.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="department id")]
        public int DeptId { get; set; }
        [Display(Name = "department Name")]
        public string DeptName { get; set; }
        public bool Status { get; set; }
        public ICollection<Student> students { get; set; } = new HashSet<Student>();
        public List<Course> Courses { get; set; }
    }
}
