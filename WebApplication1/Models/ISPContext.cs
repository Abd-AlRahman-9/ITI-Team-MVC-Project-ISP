using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApplication1.Models
{
    public class ISPContext: IdentityDbContext<ApplicationUser>
    {
        public ISPContext (DbContextOptions dbContextOptions):base(dbContextOptions){} 
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Employee>  Employees {  get; set; }
        public DbSet<InternetServiceProvider> ServiceProviders { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
