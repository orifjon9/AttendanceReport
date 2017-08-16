using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class PersonViewModel
    {
        public PersonViewModel() { }
        public PersonViewModel(person p)
        {
            if (p != null)
            {
                this.ID = p.PersonId;
                this.EmailAddress = p.EmailAddress;
                this.Firstname = p.Firstname;
                this.Lastname = p.Lastname;
            }
        }
        public Object ID { get; set; }
        public string EmailAddress { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}