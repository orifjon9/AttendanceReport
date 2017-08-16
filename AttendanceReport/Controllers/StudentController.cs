using AttendanceReport.Models;
using AttendanceReport.Persistence.Repositories;
using AttendanceReport.Repositories;
using AttendanceReport.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceReport.Controllers
{
    public class StudentController : Controller
    {
        private IUnitOfWork uow = new UnitOfWork();
        
        public ActionResult Index()
        {
            return View();
        }

        [AttendanceAuthorizeAttribute(Roles = "Staff")]
        public ActionResult Find(string id)
        {
            if(!string.IsNullOrEmpty(id))
                return View(uow.StudentRepository.GetById(id));

            return View();
        }

        [AttendanceAuthorizeAttribute(Roles = "Student")]
        public ActionResult Courses()
        {
            if(SessionPersister.Current != null)
                return View(uow.EnrollmentRepository.GetByStudentID(SessionPersister.Current.User.Student.StudentId));

            return View("AccessDebied");
        }

        [AttendanceAuthorizeAttribute(Roles = "Staff")]
        public ActionResult Attendance(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();

            var student = uow.StudentRepository.GetById(id);
            var attendanceRecords = uow.GetByStudent(student);
            return View(attendanceRecords);
        }
    }
}