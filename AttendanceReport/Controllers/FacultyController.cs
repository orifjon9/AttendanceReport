using AttendanceReport.Repositories;
using AttendanceReport.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceReport.Controllers
{
    [AttendanceAuthorizeAttribute(Roles = "Faculty")]
    public class FacultyController : Controller
    {
        UnitOfWork uow = new UnitOfWork();
        public ActionResult Courses()
        {
            if (SessionPersister.Current != null)
                return View(uow.OfferedRepository
                    .GetByFacultyID(SessionPersister.Current.User.Faculty.Id));

            return View("AccessDebied");
        }
    }
}