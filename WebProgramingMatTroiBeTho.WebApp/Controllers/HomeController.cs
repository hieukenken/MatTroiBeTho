using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models;
using WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Commons;

namespace WebProgramingMatTroiBeTho.WebApp.Controllers
{
    public class HomeController : Controller
    {

      
        string err = string.Empty;
        int rows = 0;
        // GET: Home
        public ActionResult Index()
        {
            if (SessionHelper.GetSession() != null) {
                var baiviet = new BaiVietDB().GetBaiViet(ref err);
                return View(baiviet);
            }
            else
            {
               return RedirectToAction("Index", "Login", new { Area = "Admin" });
            }
            
        }
    }
}