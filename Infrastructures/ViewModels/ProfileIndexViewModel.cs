using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.ViewModels
{
    public class ProfileIndexViewModel
    {
        public ProfileIndexViewModel()
        {
            RegUsers = new List<ApplicationUser>();
        }
        public List<ApplicationUser> RegUsers { get; set; }
        
       
    }
}
