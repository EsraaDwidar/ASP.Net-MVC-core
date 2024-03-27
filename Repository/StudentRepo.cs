using Lab3_MVC.Interfaces;
using Lab3_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3_MVC.Repository
{
    public class StudentRepo : IStudentRepo
    {
        ITIContext db;// = new ITIContext();
        public StudentRepo(ITIContext _db)
        {
            db = _db;
        }
        public List<Student> GetAll()
        {
            return db.Students.Include(s => s.Department).ToList();
        }
        public Student GetById(int id)
        {
            return db.Students.Include(s => s.Department).SingleOrDefault(x => x.Id == id);
        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var s = db.Students.SingleOrDefault(a => a.Id == id);
            db.Students.Remove(s);
            db.SaveChanges();
        }
    }
}
