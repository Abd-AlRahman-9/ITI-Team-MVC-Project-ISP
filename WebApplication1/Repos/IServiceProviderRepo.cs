using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public interface IServiceProviderRepo
    {
        public List<InternetServiceProvider> GetAll();
        public InternetServiceProvider GetById(int id);
        public void Create(InternetServiceProvider serviceProvider);
        public InternetServiceProvider Update(int id, InternetServiceProvider serviceProvider);
        public void Delete(int id);
    }
}