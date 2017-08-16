using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Core.Repositories
{
    public interface IOfferedRepository : IRepository<offered>
    {
        OfferedViewModel GetById(int id);
        IEnumerable<OfferedViewModel> GetByFacultyID(int facultyID);
        IEnumerable<OfferedViewModel> GetByStudentID(string studentID);
    }
}