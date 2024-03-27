using Lab3_MVC.Models;

namespace Lab3_MVC.Interfaces
{
    public interface IDeptRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Add(Department department);

        void Update(Department department);
        void Delete(int id);
    }
}
