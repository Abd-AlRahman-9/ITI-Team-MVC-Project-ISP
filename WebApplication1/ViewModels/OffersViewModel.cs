using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class OffersViewModel
    {
        public int Id { get; set; }
        public string offerName { get; set; }

        public string serviceName { get; set; }

        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }

        public int Duration { get; set; }

        public decimal Discount { get; set; }

        // نوع الخصم 
        public string typeDiscount {  get; set; }

        public decimal Cancel { get; set; }


        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public Package? Package { get; set; }


    }
}
