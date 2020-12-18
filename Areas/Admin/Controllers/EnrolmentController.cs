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

        public EnrolmentController(IEnrolStudent enrolStudent, UserManager<ApplicationUser> userManager)
        {
            _enrolStudent = enrolStudent;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _enrolStudent.GetEnrollments());
        }

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
