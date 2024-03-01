using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repos
{
    public interface IBranchRepo
    {
        public List<Branch> GetAll();
        public Branch GetById(int id);
        public void Create(BranchViewModel _Branch);
        public List<string> getGovernates();
        public Branch Update(int id,Branch _Branch);
        public void Delete(int id);
    }
}
