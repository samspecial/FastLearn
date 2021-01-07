using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.ViewModels
{
    public class EnrolStudentViewModel
    {
        public EnrolStudentViewModel()
        {
            AllEnrollments = new List<ApplicationUser>();
        }
        public IEnumerable<ApplicationUser> AllEnrollments { get; set; }
        //public int Id { get; set; }

        //public bool IsComplete { get; set; }

        //public int ApplicationUserId { get; set; }

        //public IEnumerable<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
        //public IEnumerable<Course> CourseList { get; set; } = new List<Course>();
        //public int CourseId { get; set; }
        //public int StudyCenterId { get; set; }
        //public IEnumerable<StudyCenter> StudyCenterList { get; set; } = new List<StudyCenter>();
    }
}
