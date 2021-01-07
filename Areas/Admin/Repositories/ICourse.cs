using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public interface ICourse
    {
        Task<bool> AddCourse(Course course);
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
        Task RemoveCourse(int id);
        Task<bool> EditCourse(Course course);

    }
}
