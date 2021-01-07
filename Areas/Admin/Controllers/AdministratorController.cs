using FastLearn.Areas.Admin.Repositories;
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
    [Authorize(Roles ="Administrator")]
    public class AdministratorController : Controller
    {

        private readonly IAdmin _admin;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministratorController(IAdmin admin, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _admin = admin;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        public async Task<IActionResult> Index()
        {
            var admin = new AdminIndexViewModel();
            //var getUsers = _userManager.Users;
           var getUsers = await _userManager.GetUsersInRoleAsync("Administrator");
            
            foreach (var user in getUsers)
            {
                    admin.Admins.Add(user);
            }   
            return View(admin);
        }
        
        [HttpGet]
        public IActionResult AddAdmin()
        {
            var result = new AdminAddViewModel();
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(AdminAddViewModel admin)
        {
            if (!ModelState.IsValid)
                return View(admin);
            var newAdmin = new ApplicationUser
            {
                FullName = admin.FullName,
                Address = admin.Address,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                UserName = admin.Email,
            };
           var result = await _userManager.CreateAsync(newAdmin, admin.Password);
            if(result.Succeeded)
            {
            await _userManager.AddToRoleAsync(newAdmin, "Administrator");
            TempData["StatusMessage"] = $"{admin.FullName} successfully added";
            return View("index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(admin);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingleAdmin(string Id)
        {
            if (Id == null)
                return View();
            var getAdmin = await _userManager.FindByIdAsync(Id);
            var setAdmin = new AdminDetailsViewModel
            {
                FullName = getAdmin.FullName,
                Email = getAdmin.Email,
                PhoneNumber = getAdmin.PhoneNumber,
                Address = getAdmin.Address,
                UserName = getAdmin.UserName,
                LockedOut = getAdmin.LockoutEnabled,
                Id = getAdmin.Id,
                TwoFactor = getAdmin.TwoFactorEnabled
            };
            return View(setAdmin);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
                return NotFound();

            var admin = await _userManager.FindByIdAsync(Id);

            if (admin == null)
                return NotFound();

            var adminView = new AdminDeleteViewModel
            {
                FullName = admin.FullName,
                Id = admin.Id
            };
            return View(adminView);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string Id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }

        //Ikum23!73.@sh9

        [HttpGet]
        public async Task<IActionResult> EditAdmin(string Id)
        {
            if (Id == null)
                return NotFound();
            var admin = await _userManager.FindByIdAsync(Id);
            var editAdmin = new AdminEditViewModel
            {
                FullName =admin.FullName,
                Address = admin.Address,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber
            };
            return View(editAdmin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdmin(AdminEditViewModel admin)
        {
            if (!ModelState.IsValid)
                return View(admin);
            ApplicationUser editAdmin = await _userManager.FindByIdAsync(admin.Id);

            editAdmin.FullName = admin.FullName;
            editAdmin.Address = admin.Address;
            editAdmin.Email = admin.Email;
            editAdmin.PhoneNumber = admin.PhoneNumber;
          
            var result = await _userManager.UpdateAsync(editAdmin);
            if (result.Succeeded)
            {
                TempData["StatusMessage"] = "Administrator details updated Successfully";
                return View();
            }
            else
            {
                foreach (var error in result.Errors)
                {

                ModelState.AddModelError("", error.Description);
                }
                return View(admin);
            }


        }

        [HttpGet]
        public  IActionResult CreateRole()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };
            var result = await  _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                TempData["Title"] = $"{model.RoleName} added successfully";
                return RedirectToAction("createrole");
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpGet]
        
        public async Task<IActionResult> CreateStudyCenter()
        {
            var model = new StudyCenterViewModel
            {
                Studies = await _admin.GetCenters()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudyCenter(StudyCenterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            StudyCenter studyCenter = new StudyCenter
            {
                Name = model.Name,
                Location = model.Location
            };
            var result = await _admin.CreateCenter(studyCenter);
            if (result)
            {

                TempData["StatusMessage"] = $"{model.Name} added successfully";
                return RedirectToAction("createstudycenter");
            }
            else
            {
                TempData["StatusMessage"] = "Something went wrong";
                return View(model);
            }
           
        }

        [HttpGet]
        
        public async Task<IActionResult> EditStudyCenter(int Id)
        {
            if (Id == 0)
                return NotFound();
            var model = await _admin.GetCenter(Id);

            EditStudyCenterViewModel studyCenter = new EditStudyCenterViewModel
            {
                Id = model.Id,
                Location = model.Location,
                Name = model.Name,
            };
            return View(studyCenter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudyCenter(EditStudyCenterViewModel model)
        {
            
            var studyCenter = await _admin.GetCenter(model.Id);
            if (!ModelState.IsValid)
                return View(model);
            studyCenter.Name = model.Name;
            studyCenter.Location = model.Location;
            
            var result = await _admin.UpdateCenter(studyCenter);
            if (result)
            {

               TempData["StatusMessage"] = $"{model.Name} updated successfully";
                return View();
            }
            else
            {
                TempData["StatusMessage"] = "Something went wrong";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStudyCenter(int Id)
        {
            if (Id == 0)
                return NotFound();
            var center = await _admin.GetCenter(Id);
            if (center == null)
                return NotFound();
            var delete = new DeleteStudyViewModel
            {
                Id = center.Id,
                Name = center.Name,
                Location = center.Location
            };
            return View(delete);
        }

        [HttpPost]
        [ActionName("DeleteCenter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCenter(int Id)
        {
            await _admin.RemoveCenter(Id);
            return RedirectToAction("createstudycenter");
        }

        //End of Study Center Feature

        //Beginning of Student Enrollment
    }
}

