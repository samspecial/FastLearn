using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.ViewModels
{
    public class CourseAddViewModel
    {
       [Required]
       [Display(Name="Course name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Prerequisite for course")]
        public string Prerequisite { get; set; }
        [Required]
        [Display(Name = "Course fee")]
        public decimal Fee { get; set; }
        [Required]
        [Display(Name = "Course duration")]
        public string Duration { get; set; }
        [Required]
        [Display(Name = "Course cover image")]
        public IFormFile DisplayImage { get; set; }

    }
}
