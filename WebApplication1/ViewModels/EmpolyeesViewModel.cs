using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class EmpolyeesViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<Branch> BranchName { get; set; }
        
        public string Governate { get; set; }

        public string GroupName { get; set; }

        public int? BranchId { get; set; }

    }
}
