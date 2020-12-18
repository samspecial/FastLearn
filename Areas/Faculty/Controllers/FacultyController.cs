using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Faculty.Controllers
{
    [Area("faculty")]
    //[Authorize(Roles = "Faculty")]
    public class FacultyController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
