using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class OffersViewModel
    {
        public string OfferName { get; set; }
        public int PackageId { get; set; }
        public List<string> Packages { get; set; } = new List<string>();
        public DateOnly StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Discount { get; set; }
        public bool Percentage { get; set; } = false;
        public decimal Cancel { get; set; }
    }
}
