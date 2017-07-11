using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class StudentViewModel
    {
        public StudentViewModel() { }
        public StudentViewModel(student st)
        {
            if (st != null) {
                this.StudentId = st.StudentId;
                this.Barcode = st.Barcode;
                this.DateEntry = st.Entry;
                this.Status = st.Status;
                this.VisaStatus = st.VisaStatus;
                this.Enrollments = st.enrollments
                    .Select(s=>new EnrollmentViewModel(s))
                    .ToList();

                this.Person = new PersonViewModel(st.person);
            }
        }
        public String StudentId { get; set; }
        public string Barcode { get; set; }
        public Nullable<System.DateTime> DateEntry { get; set; }
        public string Status { get; set; }
        public string VisaStatus { get; set; }
        public virtual List<EnrollmentViewModel> Enrollments { get; set; }
        public virtual PersonViewModel Person { get; set; }

        public static explicit operator StudentViewModel(student st)
        {
            return new StudentViewModel(st);
        }
    }
}