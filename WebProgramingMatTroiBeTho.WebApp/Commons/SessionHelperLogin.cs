using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProgramingMatTroiBeTho.WebApp.Commons
{
    public class SessionHelperLogin
    {
        public static void SetSession(UserSessionLogin session)
        {
            HttpContext.Current.Session["sessionLogin"] = session;
        }

        public static UserSessionLogin GetSession()
        {
            return HttpContext.Current.Session["sessionLogin"] as UserSessionLogin;
        }
    }
}