using FastLearn.Infrastructures.Models;
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

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<StudyCenter> StudyCenters { get; set; }
    }
}
