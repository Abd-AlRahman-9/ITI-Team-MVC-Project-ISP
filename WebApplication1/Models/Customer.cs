using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Customer
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Package")]
        public int? PackageId { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public Branch? Branch { get; set; }

        public Package? Package { get; set; }
    }
}
