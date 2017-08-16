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
    [AttendanceAuthorizeAttribute(Roles ="Administrator")]
    public class UserController : Controller
    {

        IUnitOfWork uow = new UnitOfWork();
        // GET: User
        public ActionResult Find(string Id)
        {
            return View(uow.UserRepository.FindAll(Id ?? string.Empty).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserRoleViewModel userRole)
        {
            if (!ModelState.IsValid)
            {
                return View(userRole);
            }

            UserViewModel user = new UserViewModel()
            {
                UserName = userRole.UserName,
                Password = userRole.Password,
                Role = (Helpers.UserRole)userRole.TypeId,
                Student = ((Helpers.UserRole)userRole.TypeId) == Helpers.UserRole.Student ? new StudentViewModel() { StudentId = userRole.ObjectId } : null,
                Faculty = ((Helpers.UserRole)userRole.TypeId) == Helpers.UserRole.Faculty ? new FacultyViewModel() { Id = Convert.ToInt32(userRole.ObjectId) } : null
            };

            if (uow.UserRepository.GetById(user.UserName) != null) {
                ViewBag.Error = "This user exist in the database. Please, choose another name";
                return View(userRole);
            }

            uow.UserRepository.Add(user);
            uow.Complete();

            return RedirectToAction("Find");
        }

        public ActionResult Edit(string id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                uow.UserRepository.Delete(new UserViewModel() { UserName = id });
                uow.Complete();
            }

            return RedirectToAction("Find");
        }
    }
}