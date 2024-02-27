using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repos
{
    public class BranchRepo : IBranchRepo
    {
        readonly ISPContext context;

        public BranchRepo (ISPContext _context)
        {
            this.context = _context;
        }

        public List<Branch> GetAll() => context.Branches.ToList();

        public Branch GetById(int id) => context.Branches.FirstOrDefault(B => B.Id == id);

        public void Create(BranchViewModel _Branch)
        {
            Branch B = new Branch();
            B.Address = _Branch.Address;
            B.Fax = _Branch.Fax;
            B.Name = _Branch.Name;  
            B.ManagerName = _Branch.ManagerName;
            B.Governate = _Branch.Governate;
            context.Branches.Add(B);
            context.SaveChanges();
        }

        public Branch Update(int Id,BranchViewModel _Branch)
        {
            Branch branch = context.Branches.Find(Id);
            branch.Name = _Branch.Name;
            branch.Governate =_Branch.Governate;
            branch.Address = _Branch.Address;
            branch.ManagerName = _Branch.ManagerName;
            branch.Fax = _Branch.Fax;
            context.Branches.Update(branch);
            context.SaveChanges();
            return branch;
        }

        public void Delete(int id)
        {
            Branch branch = context.Branches.Find(id);
            context.Branches.Remove(branch);
            context.SaveChanges();
        }
    }
}
