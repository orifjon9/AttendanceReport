using AttendanceReport.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class UserViewModel
    {
        public String UserName { get; set; }
        public UserRole Role { get; set; }

        public String Password { get; set; }

        public StudentViewModel Student { get; set; }
        public FacultyViewModel Faculty { get; set; }

        public static explicit operator UserViewModel(userrole userRole) {

            if (userRole == null) return null;

            var userViewModel = new UserViewModel() {
                UserName = userRole.UserName,
                Role = (UserRole)userRole.TypeId
            };
            
            return userViewModel;
        }

    }
}