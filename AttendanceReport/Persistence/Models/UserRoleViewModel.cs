using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceReport.Models
{
    public class UserRoleViewModel
    {
        
        [Required(ErrorMessage = "User name is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Type is required!")]
        public int TypeId { get; set; }
        public string ObjectId { get; set; }
    }
}