using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="User name is required.")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public String Password { get; set; }
    }
}