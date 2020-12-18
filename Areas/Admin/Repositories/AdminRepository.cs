using FastLearn.Infrastructures;
using FastLearn.Infrastructures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public class AdminRepository:IAdminRepository
    {
       
        private readonly ELearningDbContext _dbContext;

        public AdminRepository(ELearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAdmins()
        {
            return await _dbContext.ApplicationUsers.OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<ApplicationUser> GetAdmin(int id)
        {
            return await _dbContext.ApplicationUsers.FindAsync(id);
        }

        public async Task RemoveAdmin(int id)
        {
            var faculty = await _dbContext.ApplicationUsers.FindAsync(id);
            _dbContext.ApplicationUsers.Remove(faculty);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> SignUpAdmin(ApplicationUser faculty)
        {
            await _dbContext.ApplicationUsers.AddAsync(faculty);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAdmin(ApplicationUser faculty)
        {
            _dbContext.ApplicationUsers.Update(faculty);
            await _dbContext.SaveChangesAsync();
        }
    }

    
}
