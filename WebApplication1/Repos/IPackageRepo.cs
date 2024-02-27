using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public interface IPackageRepo
    {
        public List<Package> GetAll();
        public Package GetById(int id);
        public void Create(Package package);
        public Package Update(int id, Package package);
        public void Delete(int id);
    }
}
