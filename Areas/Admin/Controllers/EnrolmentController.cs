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
    public class EnrolmentController : Controller
    {
        private readonly IEnrolStudent _enrolStudent;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICourse _course;
        private readonly IAdmin _admin;
        public EnrolmentController(IEnrolStudent enrolStudent, UserManager<ApplicationUser> userManager, ICourse course, IAdmin admin)
        {
            _enrolStudent = enrolStudent;
            _userManager = userManager;
            _course = course;
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var allStudents = await _userManager.GetUsersInRoleAsync("Student");
            EnrolStudentViewModel enrolStudent = new EnrolStudentViewModel
            {
                AllEnrollments = allStudents
            };
            return View(enrolStudent);
        }

        //[NonAction]
        //public async Task<PopulateEnrolViewModel> PopulateView(PopulateEnrolViewModel viewModel)
        //{
        //    var allEnrollments = await _userManager.GetUsersInRoleAsync("Student");
        //    var allCourses = await _course.GetCourses();
        //    var allCenters = await _admin.GetCenters();

        //    viewModel.Enrollments = allEnrollments;
        //    viewModel.Courses = allCourses;
        //    viewModel.Centers = allCenters;

        //    return viewModel;
        //}

        //[HttpGet]
        //public async Task<IActionResult> Enroll()
        //{
        //    var enrol = new EnrolStudentViewModel
        //    { 
        //        StudyCenterList = await _studyCenter.GetCenters(),
        //        ApplicationUsers = await _userManager.
        //    };
        //    return View(enrol);
        //}

        //public async Task<IActionResult> Add()
        //{
        //    var model = new InventoryAddViewModel
        //    {
        //        WarehouseList = await store.GetAll(),
        //        UserList = await staff.GetAll()
        //    };

        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Add(InventoryAddViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(viewModel);
        //    var item = new Inventory
        //    {
        //        ItemName = viewModel.ItemName,
        //        ManufacturerName = viewModel.ManufacturerName,
        //        UserId = viewModel.UserId,
        //        WarehouseId = viewModel.WarehouseId,
        //        Price = viewModel.Price,
        //        Description = viewModel.Description,
        //        Quantity = viewModel.Quantity,
        //        ProductImage = GetImageFilePath(viewModel.Image),
        //        ProdDate = viewModel.ProdDate,
        //        ExpDate = viewModel.ExpDate
        //    };
        //    await stock.Add(item);
        //    TempData["StatusMessage"] = $"{viewModel.ItemName} successfully added.";
        //    return RedirectToAction("Index");
        //}
    }
}
