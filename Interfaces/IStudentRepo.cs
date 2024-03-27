using Lab3_MVC.Models;

namespace Lab3_MVC.Interfaces
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);

        void Update(Student student);
        void Delete(int id);
    }
}
