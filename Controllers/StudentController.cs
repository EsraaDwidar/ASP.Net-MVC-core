using Lab3_MVC.Interfaces;
using Lab3_MVC.Models;
using Lab3_MVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_MVC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {

        ITIContext db = new ITIContext();

        IDeptRepo departmentRepo;//= new DepartmentRepo();
        IStudentRepo studentRepo;//= new StudentRepo();
        public StudentController(IStudentRepo _stdRepo, IDeptRepo _deptRepo)
        {
            studentRepo = _stdRepo;
            departmentRepo = _deptRepo;
        }
        public IActionResult Index()
        {
            var model = studentRepo.GetAll();
            return View(model);
        }
        
        public IActionResult Create()
        {
            ViewBag.deptlist = departmentRepo.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std, IFormFile stdimg)
        {
            if (ModelState.IsValid)
            {
                if (stdimg != null && stdimg.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await stdimg.CopyToAsync(ms);
                        std.Img = ms.ToArray();
                    }
                }
                studentRepo.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Name or Dept is not valid");
                ViewBag.deptlist = departmentRepo.GetAll();
                return View(std);
            }
        }
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var model = studentRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = studentRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            ViewBag.deptlist = departmentRepo.GetAll();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student std, IFormFile stdimg)
        {
            if (ModelState.IsValid)
            {
                if (stdimg != null && stdimg.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await stdimg.CopyToAsync(ms);
                        std.Img = ms.ToArray();
                    }
                }
                db.Students.Update(std);

                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Name or Dept is not valid");
                ViewBag.deptlist = departmentRepo.GetAll();
                return View(std);
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = db.Students.SingleOrDefault(a => a.Id == id);
            if (model == null)
                return NotFound();
            db.Students.Remove(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Details2(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var model = db.Students.Include(a => a.Department).SingleOrDefault(a => a.Id == id);
            if (model == null)
                return NotFound();
            return PartialView(model);
        }
        public IActionResult CheckEmail(string Email, string Name, int Age)
        {
            var model = db.Students.FirstOrDefault(a => a.Email == Email);
            if (model != null)
                return Json($"{Name}{Age}@iti.com");
            else
                return Json(true);
        }
    }
}
