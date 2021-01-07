using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.ViewModels
{
    public class ManageUserViewModel
    {
        public ManageUserViewModel()
        {
            AvailableFaculties = new List<ApplicationUser>();
            AvailableStudents = new List<ApplicationUser>();
        }
        public List<ApplicationUser> AvailableFaculties { get; set; }
        public List<ApplicationUser> AvailableStudents { get; set; }
    }
}
