using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }

        public int Duration { get; set; }

        public decimal Discount { get; set; }

        public decimal Cancel { get; set; }


        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public Package? Package { get; set; }    
    }
}
