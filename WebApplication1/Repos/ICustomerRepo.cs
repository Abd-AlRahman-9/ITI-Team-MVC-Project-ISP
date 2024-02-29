using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repos
{
    public interface ICustomerRepo
    {
        public List<Customer> GetAll();
        public Customer GetById(int id);
        public void Create(CustomerViewModel _Customer);
        public Customer Update(int id, CustomerViewModel _Customer);
        public void Delete(int id);
    }
}
