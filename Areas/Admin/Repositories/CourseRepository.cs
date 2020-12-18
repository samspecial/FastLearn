using FastLearn.Infrastructures;
using FastLearn.Infrastructures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public class CourseRepository : ICourse
    {
        private readonly ELearningDbContext context;

        public CourseRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddCourse(Course course)
        {
            if(course != null)
            {
                await context.Courses.AddAsync(course);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
             
        }

        public async Task<Course> GetCourse(int id)
        {
            return await context.Courses.FindAsync(id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await context.Courses.OrderByDescending(c => c.Name).ToListAsync();
        }



    }
}
