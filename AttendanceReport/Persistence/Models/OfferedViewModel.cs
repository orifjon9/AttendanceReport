using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class OfferedViewModel
    {
        public OfferedViewModel() { }
        public OfferedViewModel(offered off)
        {
            if (off != null)
            {
                this.Id = off.Id;
                this.Active = off.Active;
                this.Capacity = off.Capacity;
                this.DistanceEducation = off.DE;
                this.Enrolled = off.Enrolled;
                this.StartDate = off.StartDate;
                this.Period = off.Period;
                this.CourseNumber = off.CourseNumber;
            }
        }
        public int Id { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Capacity { get; set; }
        public Nullable<bool> DistanceEducation { get; set; }
        public Nullable<int> Enrolled { get; set; }
        public string Period { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string CourseNumber { get; set; }
        public Nullable<int> FacultyId { get; set; }

        public static explicit operator OfferedViewModel(offered off)
        {
            if (off == null) return null;

            return new OfferedViewModel(off);
        }
    }
}