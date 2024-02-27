using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class EmpolyeesViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // list of string 
        public string Governate { get; set; }
        // list of string
        public string BranchName { get; set; }
        public string GroupName { get; set; }
    }
}
