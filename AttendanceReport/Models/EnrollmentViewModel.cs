using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class EnrollmentViewModel
    {
        public EnrollmentViewModel() { }
        public EnrollmentViewModel(enrollment en)
        {
            if (en != null)
            {
                this.Id = en.Id;
                this.Date = en.Date;
                this.Status = en.Status;
                this.OfferId = en.OfferId;
                this.StudentId = en.StudentId;
                this.Offered = new OfferedViewModel(en.offered);
            }
        }
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Status { get; set; }
        public Nullable<int> OfferId { get; set; }
        public string StudentId { get; set; }
        public OfferedViewModel Offered { get; set; }
    }
}