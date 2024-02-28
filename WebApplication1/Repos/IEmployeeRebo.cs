using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public interface IEmployeeRebo
    {
        public List<Employee> GetAll();
        public Employee GetById(int id);
        public void Create(Employee _Employee);
        public Employee Update(int id, Employee _Employee);
        public void Delete(int id);



    }
}
