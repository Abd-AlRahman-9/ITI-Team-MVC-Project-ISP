using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class OffersViewModel
    {
        public string OfferName { get; set; }
<<<<<<< HEAD
        public int PackageId { get; set; }
        public List<string> Packages { get; set; } = new List<string>();
=======
        //list of string
        public string ProviderName { get; set; }
        // list of string
        public string PackageName { get; set; }
>>>>>>> c3cb6b49b871d781751a5d6c5d01a27d2e634d17
        public DateOnly StartDate { get; set; }
        public int Duration { get; set; }
        public bool Percentage { get; set; } 
        public decimal Discount { get; set; }
<<<<<<< HEAD
        public bool Percentage { get; set; } = false;
=======
>>>>>>> c3cb6b49b871d781751a5d6c5d01a27d2e634d17
        public decimal Cancel { get; set; }
    }
}
