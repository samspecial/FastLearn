using FastLearn.Areas.Admin.Repositories;
using FastLearn.Infrastructures.Models;
using FastLearn.Infrastructures.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize (Roles = "Administrator")]
    public class CourseController : Controller
    {
        private readonly ICourse _course;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CourseController(ICourse course, IWebHostEnvironment webHostEnvironment)
        {
            _course = course;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> ManageCourse()
        {

            var courses = new ManageCourseViewModel
            {
                AvailableCourses = await _course.GetCourses()
            };
            return View(courses);
        }
        [HttpGet]
        public  IActionResult AddCourse()
        {
            var result = new CourseAddViewModel();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseAddViewModel course)
        {
            if (!ModelState.IsValid)
                return View(course);
            var newCourse = new Course
            {
                Name=course.Name,
                Fee = course.Fee,
                Duration = course.Duration,
                Prerequisite = course.Prerequisite,
                DisplayImage = GetImageFilePath(course.DisplayImage)
            };
            await _course.AddCourse(newCourse);
            TempData["StatusMessage"] = $"{course.Name} successfully added";
            return View();
        }

        [NonAction]
        public string GetImageFilePath(IFormFile imageUpload)
        {
            string filePath = null;
            if (imageUpload != null)
            {
                var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                //Create a unique file name
                filePath = Guid.NewGuid().ToString() + "_" + imageUpload.FileName;
                //Add the unique file name to the original upload filename
                string absolutePath = Path.Combine(uploadsFolder, filePath);
                using (var fileStream = new FileStream(absolutePath, FileMode.Create))
                {
                    imageUpload.CopyTo(fileStream);
                }

            }
            return filePath;
        }


    }
}
