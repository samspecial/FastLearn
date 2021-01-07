using FastLearn.Infrastructures.Models;
using FastLearn.Infrastructures.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    public class DashboardController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DashboardController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(string searchWord)
        {
            ViewData["searchBy"] = searchWord;
            var dashboard = _userManager.Users.OrderByDescending(u => u.FullName).AsEnumerable();

            if (!String.IsNullOrEmpty(searchWord))
                dashboard = dashboard.Where(u => u.FullName.Contains(searchWord));

            return View(dashboard);
        }

        [HttpGet]
        public IActionResult PostMessage(string message)
        {
            ViewData["messageBody"] = message;
              
            return View();
        }
    }
}
