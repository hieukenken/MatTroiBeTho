using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProgramingMatTroiBeTho.Models.Models.Account;
using WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Commons;
using WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Data;

namespace WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        string err = string.Empty;
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //kieemr tra token, tranhs request lien tuc
        public ActionResult Index(AccountModel accountModel)
        {
            var result = new AccountDB().Login(ref err, accountModel.UserName, accountModel.PassWord);
            if(result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName = accountModel.UserName });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
            }
            return View(accountModel);
        }

        public ActionResult Logout()
        {
            SessionHelper.SetSession(null);
            return RedirectToAction("Index", "Home");
        }
    }
}