using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Core.Repositories
{
    public interface IUserRepository : IRepository<userrole>
    {
        IEnumerable<UserViewModel> FindAll();
        IEnumerable<UserViewModel> FindAll(string id);
        UserViewModel Find(String login, String password);
        UserViewModel GetById(string login);

        bool Add(UserViewModel model);
        bool Delete(UserViewModel model);


    }
}