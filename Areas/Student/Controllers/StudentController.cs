using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Student.Controllers
{
    [Area("student")]
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        //TemiJonny!@#123 TemiJay@gmail.com
        public IActionResult Index()
        {
            return View();
        }
    }
}
