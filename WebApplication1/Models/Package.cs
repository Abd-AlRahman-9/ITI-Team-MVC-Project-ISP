using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Limited { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("ServiceProvider")]
        public int ProviderId { get; set; }
        public ServiceProvider? ServiceProvider { get; set; }
        public List<Offer> Packages { get; set; } = new List<Offer>();
    }
}
