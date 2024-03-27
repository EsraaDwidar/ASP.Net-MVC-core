using Lab3_MVC.Interfaces;
using Lab3_MVC.Models;
using Lab3_MVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_MVC.Controllers
{
    [Authorize(Roles = "Admins")]

    public class DepartmentController : Controller
    {
        ITIContext db = new ITIContext();
        IDeptRepo departmentRepo;//= new DepartmentRepo();

        public DepartmentController(IDeptRepo _deptRepo)
        {
            departmentRepo = _deptRepo;
        }
        public IActionResult Index()
        {
            var model = db.Departments.ToList();//departmentRepo.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                departmentRepo.Add(model);
                return RedirectToAction("index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = departmentRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = departmentRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Department dept, int id)
        {
            dept.DeptId = id;
            departmentRepo.Update(dept);
            return RedirectToAction("index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            departmentRepo.Delete(id.Value);
            return RedirectToAction("index");
        }
    } 
}
