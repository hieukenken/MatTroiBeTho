using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models;
using WebProgramingMatTroiBeTho.Models.Models.SanPham;
using WebProgramingMatTroiBeTho.WebApp.Commons;

namespace WebProgramingMatTroiBeTho.WebApp.Controllers
{
    public class HomeController : Controller
    {

      
        string err = string.Empty;
        int rows = 0;
        // GET: Home
        public ActionResult Index()
        {
            if (SessionHelperLogin.GetSession() != null && SessionHelperLogin.GetSession().Type =="US") {
                var sanPham = new SanPhamDB().GetSanPhamList(ref err);
                return View(sanPham);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
    }
}