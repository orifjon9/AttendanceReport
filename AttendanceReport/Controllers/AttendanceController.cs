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
    public class AttendanceController : Controller
    {
        IUnitOfWork uow = new UnitOfWork();

        [AttendanceAuthorizeAttribute(Roles = "Faculty")]
        public ActionResult Course(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();

            OfferedViewModel offered = uow.OfferedRepository.GetById(Convert.ToInt32(id));
            var attendanceRecords = uow.GetByCourse(offered);

            return View(attendanceRecords);
        }

        [AttendanceAuthorizeAttribute(Roles = "Student")]
        public ActionResult Student()
        {
            if (SessionPersister.Current == null && SessionPersister.Current.User == null)
                return View();

            var attendanceRecords = uow.GetByStudent(SessionPersister.Current.User.Student);
            return View(attendanceRecords);
        }

        [AttendanceAuthorizeAttribute(Roles = "Faculty, Student, Staff")]
        public ActionResult Details(string studentId, string courseId)
        {
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(courseId))
                return View();

            var student = uow.StudentRepository.GetById(studentId);
            var offered = uow.OfferedRepository.GetById(Convert.ToInt32(courseId));

            var attendanceRecord = uow.GetByStudentCourse(student, offered);
            return View(attendanceRecord);
        }
    }
}