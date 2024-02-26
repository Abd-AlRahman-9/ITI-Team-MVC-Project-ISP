using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class EmpolyeesViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string BranchName { get; set; }
        // FK
        public string Governate { get; set; }

        public string GroupName { get; set; }
    }
}
