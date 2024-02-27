using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class OffersViewModel
    {
        public string OfferName { get; set; }
        //list of string
        public string ProviderName { get; set; }
        // list of string
        public string PackageName { get; set; }
        public DateOnly StartDate { get; set; }
        public int Duration { get; set; }
        public bool Percentage { get; set; } 
        public decimal Discount { get; set; }
        public decimal Cancel { get; set; }
    }
}
