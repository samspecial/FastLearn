using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.ViewModels
{
    public class ManageFacultyViewModel
    {
        public IEnumerable<ApplicationUser> AvailableFaculties { get; set; }
    }
}
