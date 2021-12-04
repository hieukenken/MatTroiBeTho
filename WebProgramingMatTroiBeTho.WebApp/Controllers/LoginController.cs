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
        int rows = 0;
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
            var getKhachHang = new AccountDB().GetKhachHang(ref err, accountModel.UserName);

            if (resultAD && ModelState.IsValid)
            {
                SessionHelperLogin.SetSession(new UserSessionLogin() { UserName = accountModel.UserName, Type = "AD" });
                return RedirectToAction("Index", "Home", new { Area = "Admin"});
            }
            else if (resultUS && ModelState.IsValid)
            {
                SessionHelperLogin.SetSession(new UserSessionLogin() { UserName = accountModel.UserName, Type = "US" , Address = getKhachHang.DiaChiKH});
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
            }
            return View(accountModel);
        }

        public ActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SingUp(Account account)
        {
            var checkUser = new AccountDB().CheckAccount(ref err, account.UserName);

            if (!checkUser)
            {
                if(account.PassWord == account.CheckPassword)
                {
                    var result = new AccountDB().SingUpUser(ref err, ref rows, account);
                    if (result && ModelState.IsValid)
                    {
                        ModelState.AddModelError("", "Tạo tài khoản thành công");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lỗi cú pháp yêu cầu gõ chính xác");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không trùng nhau");
                }

            }
            else
            {
                ModelState.AddModelError("", "Đã có người sử dụng");
            }
            return View(account);

        }


        public ActionResult Logout()
        {
            SessionHelperLogin.SetSession(null);
            return RedirectToAction("Index", "Home");
        }


    }
}