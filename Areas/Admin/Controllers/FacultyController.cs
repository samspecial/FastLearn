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
    //[Authorize(Roles = "Administrator")]
    public class FacultyController : Controller
    {
        private readonly IFaculty _faculty;
        private readonly UserManager<ApplicationUser> _userManager;

        public FacultyController(IFaculty faculty, UserManager<ApplicationUser> userManager )
        {
            _faculty = faculty;
            _userManager = userManager;
           
        }
       
        public async Task<IActionResult> ManageFaculty()
        {

            var faculty = new ManageFacultyViewModel
            {
                AvailableFaculties = await _faculty.GetFaculties()
            };
            return View(faculty);
        }
        [HttpGet]
        
        public IActionResult AddFaculty()
        {
            var result = new FacultyAddViewModel();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFaculty(FacultyAddViewModel faculty)
        {
            if (!ModelState.IsValid)
                return View(faculty);
            var newFaculty = new ApplicationUser
            {
                FullName = faculty.FullName,
                Address = faculty.Address,
                Email = faculty.Email,
                PhoneNumber = faculty.PhoneNumber,
                LockoutEnabled = true
            };
            await _faculty.SignUpFaculty(newFaculty);
            await _userManager.AddToRoleAsync(newFaculty, "Faculty");
            TempData["StatusMessage"] = $"{faculty.FullName} successfully added";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetFaculty(int Id)
        {
            if (Id != 0)
                return View();
            var getFaculty = await _faculty.GetFaculty(Id);
            var setFaculty = new FacultyDetailsViewModel
            {
               FullName = getFaculty.FullName,
               Email = getFaculty.Email,
               PhoneNumber = getFaculty.PhoneNumber,
               Address = getFaculty.Address,
               UserName = getFaculty.UserName,
               LockedOut = getFaculty.LockoutEnabled,
               Id = getFaculty.Id,
               TwoFactor = getFaculty.TwoFactorEnabled

               
            };
            return View(setFaculty);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
                return NotFound();

            var faculty = await _faculty.GetFaculty(Id);

            if (faculty == null)
                return NotFound();

            var facultyView = new FacultyDeleteViewModel
            {
                FullName = faculty.FullName,
              
                Id = faculty.Id
            };
            return View(facultyView);

        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int Id)
        {
            await _faculty.RemoveFaculty(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditFaculty(int Id)
        {
            if (Id == 0)
                return NotFound();
            var faculty = await _faculty.GetFaculty(Id);
            var editFaculty = new FacultyAddViewModel
            {
                FullName = faculty.FullName,
                Address = faculty.Address,
                Email = faculty.Email,
                PhoneNumber = faculty.PhoneNumber
            };
            return View(editFaculty);
        }
        [HttpPost]
        public async Task<IActionResult> EditFaculty(FacultyAddViewModel faculty)
        {
            if (!ModelState.IsValid)
                return View(faculty);
            var editFaculty = new ApplicationUser
            {
                FullName = faculty.FullName,
                Address = faculty.Address,
                PhoneNumber = faculty.PhoneNumber,
                Email = faculty.Email
            };
            var result = await _faculty.UpdateFaculty(editFaculty);
            if (result == true)
                TempData["StatusMessage"] = "Faculty details updated Successfully";
            else
                ModelState.AddModelError(string.Empty, "Sorry, something went wrong!");
            return View(faculty);
        }

        
    }
}
