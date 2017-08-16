using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class FacultyViewModel
    {
        public FacultyViewModel() { }
        public FacultyViewModel(faculty f)
        {
            if (f != null)
            {
                this.Id = f.Id;
                this.FirstName = f.Firstname;
                this.LastName = f.Lastname;
                
               /* this.Offered = f.offereds
                    .Select(s => new OfferedViewModel(s))
                    .ToList();*/
            }
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public virtual List<OfferedViewModel> Offered { get; set; }

        public static explicit operator FacultyViewModel(faculty f)
        {
            return new FacultyViewModel(f);
        }
    }
}