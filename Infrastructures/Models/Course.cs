using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        [Column(TypeName="decimal(18, 2)")]
        public decimal Fee { get; set; }
        public ICollection<Enrollment>  Enrollments{ get; set; }
        public string Duration { get; set; }
        public string CourseMaterial { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
