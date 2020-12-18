using FastLearn.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public interface IEnrolStudent
    {
        Task<bool> EnrolStudent(Enrollment enrol);
        Task<IEnumerable<Enrollment>> GetEnrollments();
        Task<Enrollment> GetEnrollment(int id);
        Task Update(Enrollment enrol);
        Task Remove(int id);

    }
}
