using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public class ServiseProviderRepo : IServiceProviderRepo
    {
        readonly ISPContext context;

        public ServiseProviderRepo(ISPContext _context)
        {
            this.context = _context;
        }

        public List<InternetServiceProvider> GetAll() => context.ServiceProviders.Where(s => s.IsDeleted).ToList();

        public InternetServiceProvider GetById(int id) => context.ServiceProviders.FirstOrDefault(s => s.Id == id);

        public void Create(InternetServiceProvider serviceProvider)
        {
            context.ServiceProviders.Add(serviceProvider);
            context.SaveChanges();
        }

        public InternetServiceProvider Update(int id, InternetServiceProvider serviceProvider)
        {
            InternetServiceProvider provider = context.ServiceProviders.Find(id);
            provider.Name = serviceProvider.Name;
            provider.IsDeleted = serviceProvider.IsDeleted;
            context.SaveChanges();
            return provider;
        }

        public void Delete(int id)
        {
            InternetServiceProvider provider = context.ServiceProviders.Find(id);
            provider.IsDeleted = true;
            context.SaveChanges();
        }

    }
}