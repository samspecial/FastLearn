using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.ViewModels
{
    public class AdminIndexViewModel
    {
        public AdminIndexViewModel()
        {
            Admins = new List<ApplicationUser>();
        }
        public List<ApplicationUser> Admins { get; set; } 
    }
}
