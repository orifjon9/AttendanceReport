using AttendanceReport.Helpers;
using AttendanceReport.Models;
using AttendanceReport.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AttendanceReport.Security
{
    public class AttendancePrincipal : IPrincipal
    {
        private UserViewModel user;
        private UserRepository userRepository;

        public AttendancePrincipal(string userName) {
            userRepository = new UserRepository(new AttendanceDBEntities());

            this.user = userRepository.GetById(userName);
            this.Identity = new GenericIdentity(user.UserName);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            return role.ToLower().Contains(user.Role.ToString().ToLower());
        }

        public UserRole Role { get { return this.user.Role; } }
    }
}