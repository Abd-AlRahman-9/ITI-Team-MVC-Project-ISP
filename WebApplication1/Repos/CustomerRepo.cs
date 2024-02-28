using NuGet.Protocol;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repos
{
    public class CustomerRepo : ICustomerRepo
    {

        readonly ISPContext context;

        public CustomerRepo(ISPContext _context)
        {
            this.context = _context;
        }

        public List<Customer> GetAll() => context.Customers.Where(C=>C.IsDeleted==false).ToList();

        public Customer GetById(int id) => context.Customers.FirstOrDefault(B => B.Id == id);
        public void Create(CustomerViewModel _Customer)
        {
            Customer C = new Customer
            {
                Address = _Customer.Adress,
                Phone = _Customer.Phone,
                PackageId = context.Packages.Where(P=>P.Name == _Customer.Package).ToList()[0].Id,
                IsDeleted = false,
                Name = _Customer.Name
            };

            context.Customers.Add(C);
            context.SaveChanges();
        }

        public Customer Update(int Id, CustomerViewModel _Customer)
        {
            Customer customer = context.Customers.Find(Id);
            customer.Name = _Customer.Name;
            customer.Address = _Customer.Adress;
            customer.IsDeleted = false;
            customer.Phone = _Customer.Phone;
            customer.PackageId = context.Packages.Where(P=>P.Name == _Customer.Package).ToList()[0].Id;
            context.Customers.Update(customer);
            context.SaveChanges();
            return customer;
        }

        public void Delete(int id)
        {
            Customer C = context.Customers.Find( id);
            C.IsDeleted = true;
            context.Customers.Update(C);
            context.SaveChanges();
        }
    }
}
