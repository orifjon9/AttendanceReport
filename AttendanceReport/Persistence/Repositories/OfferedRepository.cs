using AttendanceReport.Core.Repositories;
using AttendanceReport.Models;
using AttendanceReport.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Persistence.Repositories
{
    public class OfferedRepository : Repository<offered>, IOfferedRepository
    {
        private AttendanceDBEntities context;

        public OfferedRepository(AttendanceDBEntities context) : base(context)
        {
            this.context = context;
        }

        public OfferedViewModel GetById(int id)
        {
            return (OfferedViewModel)this.Get(Convert.ToInt32(id));
        }

        public IEnumerable<OfferedViewModel> GetByFacultyID(int facultyID)
        {
            return this.Find(w => w.FacultyId == facultyID)
                  .GroupBy(g => new { g.CourseNumber, g.StartDate })
                  .Select(s => s.FirstOrDefault())
                  .OrderByDescending(o => o.StartDate).ToArray()
                  .Select(s => new OfferedViewModel(s));
        }

        public IEnumerable<OfferedViewModel> GetByStudentID(string studentID)
        {
            return context.enrollments
                    .Where(w => w.StudentId == studentID).ToList()
                    .Select(s => new OfferedViewModel(s.offered));
        }
    }
}