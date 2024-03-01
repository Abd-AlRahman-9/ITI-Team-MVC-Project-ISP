using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        //list of string

        public int? PackageId { get; set; }
        public int? OfferId { get; set; }
        public int? ProviderId { get; set; }
        public List<InternetServiceProvider> ServiceProvider { get; set; }
        // list of string
        public List<Package> Package { get; set; }
        //list of string
        public List<Offer> Offer { get; set; }

    }
}
