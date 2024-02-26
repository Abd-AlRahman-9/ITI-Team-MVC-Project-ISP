using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountsController : Controller
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        public AccountsController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = registerViewModel.UserName;
                applicationUser.Email = registerViewModel.Email;
                applicationUser.PasswordHash = registerViewModel.Password;

              var user=  await _userManager.CreateAsync(applicationUser,registerViewModel.Password);
                if(user.Succeeded)
                {
                    //create cookies==> username,password,email,role
                 //var mohammed=  await _userManager.AddToRoleAsync(applicationUser, "User");
                await _signInManager.SignInAsync(applicationUser, false);
                }
                else
                {
                    foreach (var error in user.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                   
                }
            }
            return View(registerViewModel);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInViewModel logInViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? userName = await _userManager.FindByNameAsync(logInViewModel.UserName);
                if (userName is not null)
                {
                    bool isExist = await _userManager.CheckPasswordAsync(userName, logInViewModel.Password);
                    if (isExist)
                    {
                        // if user check remember me box(true),then will save cookie
                        await _signInManager.SignInAsync(userName, logInViewModel.RememberMe);
                        return RedirectToAction("Register");
                    }
                }
                 ModelState.AddModelError("", "Invalid user name or password");
            }
             return View(logInViewModel);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }
    }
}
