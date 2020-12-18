using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public interface IAdminRepository
    {
        Task<bool> SignUpAdmin(ApplicationUser faculty);
        Task<IEnumerable<ApplicationUser>> GetAdmins();
        Task<ApplicationUser> GetAdmin(int id);
        Task UpdateAdmin(ApplicationUser faculty);
        Task RemoveAdmin(int id);
    }
}
