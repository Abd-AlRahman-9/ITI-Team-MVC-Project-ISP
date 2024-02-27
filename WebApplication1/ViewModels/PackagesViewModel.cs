using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class PackagesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Limited { get; set; } = true;
        public int? ProviderId { get; set; }
        public List<InternetServiceProvider> ProviderName { get; set; } = [];
        public decimal Price { get; set; }
    }
}
