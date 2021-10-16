using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models.Account;
using WebProgramingMatTroiBeTho.WebApp.Commons;
using WebProgramingMatTroiBeTho.WebApp.Models;

namespace WebProgramingMatTroiBeTho.WebApp.Controllers
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
        public ActionResult Index(AccountModelLogin accountModel)
        {
            var resultAD = new AccountDB().LoginAdmin(ref err, accountModel.UserName, accountModel.PassWord);
            var resultUS = new AccountDB().LoginUser(ref err, accountModel.UserName, accountModel.PassWord);

            if (resultAD && ModelState.IsValid)
            {
                SessionHelperLogin.SetSession(new UserSessionLogin() { UserName = accountModel.UserName, Type = "AD" });
                return RedirectToAction("Index", "Home", new { Area = "Admin"});
            }
            else if (resultUS && ModelState.IsValid)
            {
                SessionHelperLogin.SetSession(new UserSessionLogin() { UserName = accountModel.UserName, Type = "US" });
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
            SessionHelperLogin.SetSession(null);
            return RedirectToAction("Index", "Home");
        }
    }
}