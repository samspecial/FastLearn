using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string FeedBackText { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now.ToUniversalTime();
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
