using AttendanceReport.Core.Repositories;
using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Persistence.Repositories
{
    public class EnrollmentRepository : Repository<enrollment>, IEnrollmentRepository
    {
        private AttendanceDBEntities context;
        public EnrollmentRepository(AttendanceDBEntities context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<EnrollmentViewModel> GetByStudentID(string studentID)
        {
            return this.Find(w => w.StudentId == studentID).ToArray()
                .Select(s => (EnrollmentViewModel)s);
        }
    }
}