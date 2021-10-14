using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProgramingMatTroiBeTho.WebApp.Models
{
    public class AccountModelLogin
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}