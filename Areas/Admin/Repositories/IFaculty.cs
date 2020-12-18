using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public interface IFaculty
    {
        Task<bool> SignUpFaculty(ApplicationUser faculty);
        Task<IEnumerable<ApplicationUser>> GetFaculties();
        Task<ApplicationUser> GetFaculty(int id);
        Task<bool> UpdateFaculty(ApplicationUser faculty);
        Task RemoveFaculty(int id);
    }
}
