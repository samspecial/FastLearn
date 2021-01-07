using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public interface IAdmin
    {
        Task<bool> CreateCenter(StudyCenter center);
        Task<IEnumerable<StudyCenter>> GetCenters();
        Task<StudyCenter> GetCenter(int id);
        Task<bool> UpdateCenter(StudyCenter center);
        Task RemoveCenter(int id);
    }
}
