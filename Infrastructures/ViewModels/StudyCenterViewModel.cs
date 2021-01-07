using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.ViewModels
{
    public class StudyCenterViewModel
    {
        public StudyCenterViewModel()
        {
            Studies = new List<StudyCenter>();
        }
        [Required(ErrorMessage = "Please enter name of Study center")]
        [Display(Name = "Study center")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the location")]
        [Display(Name = "Location name")]
        public string Location { get; set; }
       
        public int Id { get; set; }
        public IEnumerable<StudyCenter> Studies { get; set; }
    }
}
