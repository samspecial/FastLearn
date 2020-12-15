using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.Models
{
    public class Query
    {
        public int Id { get; set; }
        public string QueryMessage { get; set; }
        public string DateCreated { get; set; } = DateTime.Now.ToLongDateString();
        public string ResponseMessage { get; set; }
        public DateTimeOffset? ResponseDate { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }

    }
}
