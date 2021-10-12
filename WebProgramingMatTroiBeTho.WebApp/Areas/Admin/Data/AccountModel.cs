using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Data
{
    public class AccountModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}