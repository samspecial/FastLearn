using FastLearn.Infrastructures.Models;
using FastLearn.Infrastructures.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(AccountLoginViewModel login, [FromQuery] string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(login);

            var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
           
            if (result.Succeeded)
            {

                if (returnUrl != null)
                    return LocalRedirect(returnUrl);
                else
                {
                    //var role = roleManager.Roles;
                    var user = await userManager.FindByEmailAsync(login.Email);
                  
                    var role = await userManager.GetRolesAsync(user);


                        if (role.Contains("Student") == true)
                        {
                            return RedirectToAction("Index", "Student", new { Area = "student" });
                        }
                        else if (role.Contains("Administrator") == true)
                        {
                            return RedirectToAction("Index", "Dashboard", new { Area = "admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Faculty", new { area = "faculty" });
                        }

                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login details");
            }
            return View(login);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(AccountRegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);
            var user = new ApplicationUser
            {
                FullName = register.FullName,
                Email = register.Email,
                UserName = register.Email
            };
            var result = await userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                
                TempData["StatusMessage"] = $"{register.FullName} Account successfully created";
                return View("Register");
            }

            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(register);
        }

        //[HttpGet]
        //public IActionResult ListRole()
        //{
        //    var users = roleManager.Roles;
        //}
    }
}
