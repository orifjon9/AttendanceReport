using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Core.Repositories
{
    public interface IEnrollmentRepository : IRepository<enrollment>
    {
        IEnumerable<EnrollmentViewModel> GetByStudentID(string studentID);
    }
}