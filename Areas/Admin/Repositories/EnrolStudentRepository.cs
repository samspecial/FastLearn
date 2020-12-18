using FastLearn.Infrastructures;
using FastLearn.Infrastructures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.Repositories
{
    public class EnrolStudentRepository : IEnrolStudent
    {
        private readonly ELearningDbContext _context;

        public EnrolStudentRepository(ELearningDbContext context)
        {
            _context = context;
        }
        public async Task<bool> EnrolStudent(Enrollment enrol)
        {
            await _context.Enrollments.AddAsync(enrol);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Enrollment> GetEnrollment(int id)
        {
            return await _context.Enrollments.Where(e => e.Id == id).Include(e => e.StudyCenter).Include(e => e.Course).Include(e => e.ApplicationUser).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollments()
        {
            return await _context.Enrollments.OrderByDescending(e => e.Id).Include(e => e.StudyCenter).Include(e => e.Course).Include(e => e.ApplicationUser).ToListAsync();
        }

        public async Task Remove(int id)
        {
            var enrol = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrol);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Enrollment enrol)
        {
            _context.Enrollments.Update(enrol);
            await _context.SaveChangesAsync();
        }
    }
}
