using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Security
{
    public static class SessionPersister
    {
        private static String usernameSession = "username";
        static AttendancePrincipal principal = null;
        public static String UserName
        {
            get {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sesion = HttpContext.Current.Session[usernameSession];
                if (sesion != null)
                    return sesion as string;

                return null;
            }
            set {
                HttpContext.Current.Session[usernameSession] = value;
            }
        }

        public static AttendancePrincipal Current
        {
            get
            {
                if (principal == null && IsAuthorized())
                {
                    principal = new AttendancePrincipal(UserName);
                }

                return principal;
            }
            set {
                principal = value;
            }
        }

        public static bool IsAuthorized()
        {
            return UserName != null && UserName.Length > 0;

        }
    }
}