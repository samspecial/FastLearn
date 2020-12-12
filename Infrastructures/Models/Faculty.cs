using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.Models
{
    public class Faculty:IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Query> Queries { get; set; }
    }
}
