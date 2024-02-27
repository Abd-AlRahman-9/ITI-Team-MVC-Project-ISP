using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public class PackageRepo : IPackageRepo
    {
        readonly ISPContext context;

        public PackageRepo(ISPContext _context)
        {
            this.context = _context;
        }

        public List<Package> GetAll() => context.Packages.Include(p => p.ServiceProvider).ToList();

        public Package GetById(int id) => context.Packages.FirstOrDefault(p => p.Id == id);
        public void Create(Package package)
        {
            context.Packages.Add(package);
            context.SaveChanges();
        }
        public Package Update(int id, Package package)
        {
            Package newPackage = context.Packages.Find(id);
            newPackage.Name = package.Name;
            newPackage.Price = package.Price;
            newPackage.Limited = package.Limited;
            newPackage.ProviderId = package.ProviderId;
            context.SaveChanges();
            return newPackage;
        }
        public void Delete(int id)
        {
            Package package = context.Packages.Find(id);
            if (package != null)
            {
                context.Packages.Remove(package);
                context.SaveChanges();
            }
        }

    }
}
