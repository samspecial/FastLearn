using FastLearn.Infrastructures;
using FastLearn.Infrastructures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public class AdminRepository : IAdmin
    {
        private readonly ELearningDbContext _eLearningDb;

        public AdminRepository(ELearningDbContext eLearningDb)
        {
            _eLearningDb = eLearningDb;
        }
        public async Task<bool> CreateCenter(StudyCenter center)
        {
          await  _eLearningDb.StudyCenters.AddAsync(center);
            await _eLearningDb.SaveChangesAsync();
            return true;
        }

        public async Task<StudyCenter> GetCenter(int id)
        {
            return await _eLearningDb.StudyCenters.FindAsync(id);
        }

        public async Task<IEnumerable<StudyCenter>> GetCenters()
        {
            return await _eLearningDb.StudyCenters.OrderByDescending(s => s.Location).ToListAsync();
        }

        public async Task RemoveCenter(int id)
        {
            var result = await _eLearningDb.StudyCenters.FindAsync(id);
            _eLearningDb.StudyCenters.Remove(result);
            await _eLearningDb.SaveChangesAsync();
        }

        public async Task<bool> UpdateCenter(StudyCenter center)
        {
            _eLearningDb.StudyCenters.Update(center);
            await _eLearningDb.SaveChangesAsync();
            return true;
        }
    }
}
