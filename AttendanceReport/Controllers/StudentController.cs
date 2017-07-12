using AttendanceReport.Models;
using AttendanceReport.Repositories;
using AttendanceReport.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceReport.Controllers
{

    [AttendanceAuthorizeAttribute(Roles = "Student, Administrator")]
    public class StudentController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Find(string Id)
        {
            if(Id != null)
                return View(uow.StudentRepository.GetById(Id));

            return View();
        }

        [AttendanceAuthorizeAttribute(Roles = "Student")]
        public ActionResult Courses()
        {
            if(SessionPersister.Current != null)
                return View(uow.EnrollmentRepository
                    .GetByStudentID(SessionPersister.Current.User.Student.StudentId));

            return View("AccessDebied");
        }

        public ActionResult Attendance(string studentId)
        {
            return View();
        }
    }
}