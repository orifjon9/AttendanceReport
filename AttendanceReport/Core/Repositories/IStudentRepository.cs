using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Core.Repositories
{
    public interface IStudentRepository : IRepository<student>
    {
        StudentViewModel GetById(String id);
        IEnumerable<StudentViewModel> GetByOfferedId(int offerId);
        
    }
}