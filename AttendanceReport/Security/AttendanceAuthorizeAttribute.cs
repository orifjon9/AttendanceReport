using AttendanceReport.Core.Repositories;
using AttendanceReport.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace AttendanceReport.Security
{
    public class AttendanceAuthorizeAttribute: System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.UserName))
            {
                actionContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { controller = "Account", action = "Login" }));
            }
            else
            {
                AttendancePrincipal principal = new AttendancePrincipal(SessionPersister.UserName);
                if (!principal.IsInRole(Roles)){
                    actionContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { controller = "AccessDenied", action = "Index" }));
                }
            }
        }
    }

}