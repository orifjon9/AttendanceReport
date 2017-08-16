using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class SessionViewModel
    {
        public SessionViewModel(attendance_session session)
        {
            this.Id = session.Id;
            this.Date = session.Date;
            this.BlockId = session.BlockId;
            this.TimeslotId = session.TimeslotId;
        }
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string BlockId { get; set; }
        public string TimeslotId { get; set; }
    }
}