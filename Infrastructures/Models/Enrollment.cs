using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public int StudyCenterId { get; set; }
        public StudyCenter StudyCenter { get; set; }
    }
}
