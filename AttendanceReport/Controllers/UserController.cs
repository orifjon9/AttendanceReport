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
    [AttendanceAuthorizeAttribute(Roles ="Administrator")]
    public class UserController : Controller
    {

        UnitOfWork uow = new UnitOfWork();
        // GET: User
        public ActionResult Find(string Id)
        {
            return View(uow.UserRepository.FindAll(Id ?? "").ToList());
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


            //@ViewBag.Error

            return View();
        }

        public ActionResult Edit(string id)
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            return View("Find");
        }
    }
}