using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AttendanceReport.Models;
using AttendanceReport.Repositories;
using AttendanceReport.Security;
using AttendanceReport.Persistence.Repositories;

namespace AttendanceReport.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IUnitOfWork uow = new UnitOfWork();

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if(SessionPersister.Current != null)
                return RedirectToAction("index", "home");

            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userViewModel = uow.UserRepository.Find(model.UserName, model.Password);
            if (userViewModel == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
            SessionPersister.UserName = userViewModel.UserName;
           
            return RedirectToAction("index", "home");
        }

        
        [AllowAnonymous]
        public ActionResult Logout()
        {
            SessionPersister.UserName = null;
            SessionPersister.Current = null;
            return RedirectToAction("index", "home");
        }
        
    }
}