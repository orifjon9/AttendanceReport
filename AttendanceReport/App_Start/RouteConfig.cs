﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AttendanceReport
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Attendance",
                url: "{controller}/{action}/{studentId}/{courseId}",
                defaults: new { controller = "Attendance", action = "Details", studentId = UrlParameter.Optional, courseId = UrlParameter.Optional }
            );
        }
    }
}
