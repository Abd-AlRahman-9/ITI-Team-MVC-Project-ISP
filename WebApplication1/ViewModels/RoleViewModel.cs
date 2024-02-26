using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
