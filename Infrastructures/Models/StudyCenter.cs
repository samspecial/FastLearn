using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.Models
{
    public class StudyCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
