using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures
{
    public class ELearningDbContext:IdentityDbContext
    {
        public ELearningDbContext(DbContextOptions<ELearningDbContext> options):base(options)
        {

        }
    }
}
