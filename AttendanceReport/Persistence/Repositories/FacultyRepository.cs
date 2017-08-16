using AttendanceReport.Core.Repositories;
using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Persistence.Repositories
{
    public class FacultyRepository : Repository<faculty>, IFacultyRepository
    {
        private AttendanceDBEntities context;

        public FacultyRepository(AttendanceDBEntities context): base(context)
        {
            this.context = context;
        }
    }
}