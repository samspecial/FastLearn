using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.ViewModels
{
    public class ManageCourseViewModel
    {
        public IEnumerable<Course> AvailableCourses { get; set; }
    }
}
