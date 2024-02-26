using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using System.IdentityModel;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        readonly ISPContext context;
        readonly RoleManager<IdentityRole> roleManager;
        readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public RolesController(ISPContext _context, RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager)
        {
            this.context = _context;
            this.roleManager = _roleManager;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }
        public IActionResult Index()
        {
           var rolesList= context.Roles.ToList();
            return View(rolesList);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = roleViewModel.RoleName;
              var role= await roleManager.CreateAsync(identityRole);
                if(role.Succeeded)
                return RedirectToAction("Index");
                foreach (var error in role.Errors)
                {
                    ModelState.AddModelError("RoleName", error.Description);
                }
            }
         return View(roleViewModel);
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmi(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = registerViewModel.UserName;
                applicationUser.PasswordHash = registerViewModel.Password;
                applicationUser.Email = registerViewModel.Email;
             var user = await userManager.CreateAsync(applicationUser, registerViewModel.Password);
                if (user.Succeeded)
                {
                 var role=  await userManager.AddToRoleAsync(applicationUser, "Admin");
                   await signInManager.SignInAsync(applicationUser, true);
                    return RedirectToAction();
                }
                else
                {
                    foreach (var error in user.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
         return View(registerViewModel);
        }
    }
}
