using WebApplication1.Models;

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

        public void Create(Branch _Branch)
        {
            context.Branches.Add(_Branch);
            context.SaveChanges();
        }

        public Branch Update(int Id, Branch _Branch)
        {
            Branch branch = context.Branches.Find(Id);
            branch.Name = _Branch.Name;
            branch.Governate =_Branch.Governate;
            branch.Address = _Branch.Address;
            branch.ManagerName = _Branch.ManagerName;
            branch.Fax = _Branch.Fax;
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
