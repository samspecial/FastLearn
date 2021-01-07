using FastLearn.Areas.Admin.ViewModels;
using FastLearn.Infrastructures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController( UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
       
        public async Task<IActionResult> ManageUser()
        {
            var faculty = new ManageUserViewModel();
            var getFaculties =  await _userManager.GetUsersInRoleAsync("Faculty");
            var getStudent =  await _userManager.GetUsersInRoleAsync("Student");
            foreach (var user in getFaculties)
            {
                    faculty.AvailableFaculties.Add(user);
            }
            foreach (var user in getStudent)
            {
                faculty.AvailableStudents.Add(user);
            }
            return View(faculty);
           
        }

        [HttpGet]
        
        public IActionResult AddUser()
        {
            var result = new UserAddViewModel { 
            UserRoles = GetRolesDropDown()
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserAddViewModel user)
        {
           
            user.UserRoles = GetRolesDropDown();
            if (!ModelState.IsValid)
                return View(user);
            var newUser = new ApplicationUser
            {
                FullName = user.FullName,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                LockoutEnabled = true,
                UserName = user.Email
            };
            //TemiJonny!@#123
           var result = await _userManager.CreateAsync(newUser, user.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, user.Role);
                TempData["StatusMessage"] = $"{user.FullName} successfully added";
                return RedirectToAction("AddUser");
            }   
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(user);
        }

        [NonAction]
        public ICollection<SelectListItem> GetRolesDropDown()
        {
            return _roleManager.Roles.Select(u => new SelectListItem { Text = u.Name, Value = u.Name }).ToList();
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(string Id)
        {
            if (Id == null)
                return View();
            var getUser = await _userManager.FindByIdAsync(Id);
            var setUser = new UserDetailsViewModel
            {
               FullName = getUser.FullName,
               Email = getUser.Email,
               PhoneNumber = getUser.PhoneNumber,
               Address = getUser.Address,
               UserName = getUser.UserName,
               LockedOut = getUser.LockoutEnabled,
               Id = getUser.Id,
               TwoFactor = getUser.TwoFactorEnabled             
            };
            return View(setUser);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
                return NotFound();

            var faculty = await _userManager.FindByIdAsync(Id);

            if (faculty == null)
                return NotFound();

            var facultyView = new UserDeleteViewModel
            {
                FullName = faculty.FullName,             
                Id = faculty.Id
            };
            return View(facultyView);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string Id)
        {
            var getUser = await _userManager.FindByIdAsync(Id);
            await _userManager.DeleteAsync(getUser);
            return RedirectToAction("ManageUser");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string Id)
        {
            if (Id == null)
                return NotFound();
            var user =  await _userManager.FindByIdAsync(Id);
            var editUser = new UserEditViewModel
            {
                FullName = user.FullName,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return View(editUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserEditViewModel user)
        {
            if (!ModelState.IsValid)
                return View(user);
            
            ApplicationUser editUser = await _userManager.FindByIdAsync(user.Id);

            editUser.FullName = user.FullName;
            editUser.Address = user.Address;
            editUser.Email = user.Email;
            editUser.PhoneNumber = user.PhoneNumber;
           
            var result = await _userManager.UpdateAsync(editUser);
            if (result.Succeeded)
            {
                TempData["StatusMessage"] = $"{user.FullName} updated Successfully";
                return View();
            }
            else
            {
                foreach (var error in result.Errors)
                {

                ModelState.AddModelError("", error.Description);
                }
                return View(user);
            }


        }

        
    }
}
