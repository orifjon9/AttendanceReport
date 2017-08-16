using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class StudentAttendanceViewModel
    {
        public StudentViewModel Student { get; set; }
        public OfferedViewModel CourseOffered { get; set; }
        public IEnumerable<AttendanceRecordViewModel> AttendanceRecords { get; set; }
        public IEnumerable<SessionViewModel> Sessions { get; set; }

        public double GetMeditaionPercentage()
        {
            if (AttendanceRecords.Count() == 0)
                return 0;
            return 100.0 * (AttendanceRecords.Count() > Sessions.Count() ? Sessions.Count() : AttendanceRecords.Count()) / Sessions.Count();
        }
        

        public double GetMeditationGrade()
        {
            double percentage = GetMeditaionPercentage();

            if (percentage >= 90.0)
            {
                return 1.5;
            }
            if (percentage >= 80.0)
            {
                return 1.0;
            }
            if (percentage >= 70.0)
            {
                return 0.5;
            }

            return 0.0;
        }

        public List<int> GetMonths() {
            if (Sessions != null) {
               return Sessions.Select(s => s.Date.Month).Distinct().ToList();
            }

            return null;
        }
        public int? GetYear() {
            if (Sessions != null)
            {
                return Sessions.Select(s => s.Date.Year).Distinct().FirstOrDefault();
            }

            return (int?)null;
        }

        public bool CheckSessionDate(int year, int month, int day) {
            if (this.Sessions == null)
                return false;

            return this.Sessions.Where(w => w.Date == new DateTime(year, month, day)).FirstOrDefault() != null;
        }

        public bool CheckAttendanceDate(int year, int month, int day)
        {
            if (this.Sessions == null)
                return false;

            return this.AttendanceRecords.Where(w => w.Date == new DateTime(year, month, day)).FirstOrDefault() != null;
        }

        public bool CheckAttendanceDate(DateTime date)
        {
            if (this.Sessions == null)
                return false;

            return this.AttendanceRecords.Where(w => w.Date == date).FirstOrDefault() != null;
        }
    }
}