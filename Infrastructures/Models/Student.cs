using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.Models
{
    public class Student
    {
        public int StudyCenterId { get; set; }
        public StudyCenter StudyCenter { get; set; }
        public Course Course { get; set; }
    }
}
