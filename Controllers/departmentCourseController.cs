using Lab3_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_MVC.Controllers
{
    public class departmentCourseController : Controller
    {
        ITIContext db = new ITIContext();

        public IActionResult ShowCourses(int id)
        {
            var model = db.Departments.Include(a => a.Courses).FirstOrDefault(a => a.DeptId == id);
            return View(model);
        }
        public IActionResult ManageCourses(int id)
        {

            var model = db.Departments.Include(a => a.Courses).FirstOrDefault(a => a.DeptId == id);
            var allCourses = db.Courses.ToList();
            var courseInDept = model.Courses;
            var courseNotInDept = allCourses.Except(courseInDept).ToList();
            ViewBag.courseNotInDept = courseNotInDept;
            return View(model);
        }
        [HttpPost]
        public IActionResult ManageCourses(int id, List<int> coursesToRemove, List<int> coursesToAdd)
        {
            Department dept = db.Departments.Include(a => a.Courses).FirstOrDefault(a => a.DeptId == id);
            foreach (var item in coursesToRemove)
            {
                Course c = db.Courses.FirstOrDefault(a => a.Id == item);
                dept.Courses.Remove(c);
            }
            db.SaveChanges();
            foreach (var item in coursesToAdd)
            {
                Course c = db.Courses.FirstOrDefault(a => a.Id == item);
                dept.Courses.Add(c);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
        //

        public IActionResult AddStudentDegree(int deptid, int crsid)
        {
            Department? dept = db.Departments.Include(a => a.students).FirstOrDefault(a => a.DeptId == deptid);
            Course? course = db.Courses.FirstOrDefault(a => a.Id == crsid);
            ViewBag.Course = course;
            return View(dept);
        }

        [HttpPost]
        public IActionResult AddStudentDegree(int deptid, int crsid, Dictionary<int, int> degree)
        {
            foreach (var item in degree)
            {
                var stdcrs = db.StudentCourses.FirstOrDefault(a => a.StudentId == item.Key && a.CrstId == crsid);
                if (stdcrs == null)
                {
                    StudentCourse stdudentcrs = new StudentCourse()
                    {
                        StudentId = item.Key,
                        CrstId = crsid,
                        Degree = item.Value

                    };
                    db.StudentCourses.Add(stdudentcrs);

                }
                else

                    stdcrs.Degree = item.Value;

            }

            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
    }
}
