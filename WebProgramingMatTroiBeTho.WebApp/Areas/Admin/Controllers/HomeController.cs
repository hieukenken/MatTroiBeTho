using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models.SanPham;
using WebProgramingMatTroiBeTho.WebApp.Commons;

namespace WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        string err = string.Empty;
        string searchString = string.Empty;
        int rows = 0;
        public ActionResult Index()
        {
            if (SessionHelperLogin.GetSession() != null && SessionHelperLogin.GetSession().Type == "AD")
            {
                
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
            return View();
        }
    }
}