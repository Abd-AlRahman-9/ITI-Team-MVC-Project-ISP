using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public interface IBranchRepo
    {
        public List<Branch> GetAll();
        public Branch GetById(int id);
        public void Create(Branch _Branch);
        public Branch Update(int id, Branch _Branch);
        public void Delete(int id);
    }
}
