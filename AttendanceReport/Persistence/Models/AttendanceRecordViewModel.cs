using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class AttendanceRecordViewModel
    {
        public AttendanceRecordViewModel(attendance_record record)
        {
            this.Id = record.Id;
            this.Barcode = record.Barcode;
            this.Date = record.Date;
            this.Time = record.Time;
            this.Location = record.LocationId;
            this.Timeslot = record.TimeslotId;
        }
        public long Id { get; set; }
        public string Barcode { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public string Location { get; set; }
        public string Timeslot { get; set; }

    }
}