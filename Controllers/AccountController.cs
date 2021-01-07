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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
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

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);
           
            if (result.Succeeded)
            {

                if (returnUrl != null)
                    return LocalRedirect(returnUrl);
                else
                {
                    
                    var user = await _userManager.FindByEmailAsync(login.Email);
                    
                   //var role = _roleManager.Roles;
                    var role = await _userManager.GetRolesAsync(user);
                    

                    if (role.Contains("Student") == true)
                    {
                        return RedirectToAction("Index", "Student", new { Area = "student" });
                    }
                    else if (role.Contains("Administrator") == true)
                    {
                        return RedirectToAction("Index", "Dashboard", new { Area = "admin" });
                    }
                    else if(role.Contains("Faculty") == true)
                    {
                        return RedirectToAction("Index", "Faculty", new { area = "faculty" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
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
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
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

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { Area = "default" });
        }

        //[HttpGet]
        //public IActionResult ListRole()
        //{
        //    var users = roleManager.Roles;
        //}
    }
}
