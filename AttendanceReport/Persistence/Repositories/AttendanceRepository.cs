using AttendanceReport.Core.Repositories;
using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Persistence.Repositories
{
    public class AttendanceRepository : Repository<attendance_record>, IAttendanceRepository
    {
        private AttendanceDBEntities context;

        public AttendanceRepository(AttendanceDBEntities context): base(context)
        {
            this.context = context;
        }
                
        public IEnumerable<AttendanceRecordViewModel> FindAll()
        {
            return GetAll().ToList()
                .Select(s => new AttendanceRecordViewModel(s));
        }
    }
}