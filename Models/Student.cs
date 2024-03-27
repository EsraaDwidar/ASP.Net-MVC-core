using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_MVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(10,MinimumLength =3, ErrorMessage ="violate stringlrength ct")]
        [Display(Name = "Full Name")] 
        public string Name { get; set; }
        [Range(20,30, ErrorMessage ="Range validator")]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        [Remote("CheckEmail","Student", AdditionalFields ="Name,Age")]
        public string Email { get; set; }
        [NotMapped]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }
        public byte[] Img { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set; }
        public Department Department { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
