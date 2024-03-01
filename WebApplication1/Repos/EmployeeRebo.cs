using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;

namespace WebApplication1.Repos
{ 
    public class EmployeeRebo : IEmployeeRebo
    {
     
         ISPContext context;

        public EmployeeRebo(ISPContext _context)
        {

            this.context = _context;

        }


      
        public List<Employee> GetAll()
        {


            return context.Employees.Include(e=>e.Branch).ToList();

        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

      
        public void Create(Employee _Employee)
        {
            context.Add(_Employee);
            Save();
           

        }

        public Employee Update(int id, Employee _Employee)
        {
             context.Update(_Employee);
              Save();
            return _Employee;

           

        }

        public void Delete(int id)
        {
            context.Remove(GetById(id));
            Save();
        }

        public void Save()
        {
            context.SaveChanges();  

        }

       

       
    }
   
}
