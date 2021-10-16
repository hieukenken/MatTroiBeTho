﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Commons
{
    public class SessionHelper
    {
        public static void SetSession(UserSession session)
        {
            HttpContext.Current.Session["sessionLogin"] = session;
        }

        public static UserSession GetSession()
        {
            return HttpContext.Current.Session["sessionLogin"] as UserSession;
        }
    }
}