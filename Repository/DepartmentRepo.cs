using Lab3_MVC.Interfaces;
using Lab3_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3_MVC.Repository
{
    public class DepartmentRepo : IDeptRepo
    {
        ITIContext db ;//= new ITIContext();
        public DepartmentRepo(ITIContext _db)
        {
            db = _db;
        }
        public List<Department> GetAll()
        {
            Console.WriteLine("Department List Required");
            return db.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.SingleOrDefault(a => a.DeptId == id);
        }
        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var dept = GetById(id);
            dept.Status = false;
            db.SaveChanges();
        }
    }
}
