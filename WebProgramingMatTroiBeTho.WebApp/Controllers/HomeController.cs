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
        public ActionResult Index(string searchString)
        {
           // if (SessionHelperLogin.GetSession() != null && SessionHelperLogin.GetSession().Type =="US") {
                var sanPham = new SanPhamDB().GetSanPhamList(ref err,searchString);
                string soluong = sanPham.Count.ToString();
            ViewBag.TongSanPham = soluong;
                return View(sanPham);
          //  }
          //  else
         //   {
         //       return RedirectToAction("Index", "Login");
         //   }
           
        }
        // add to cart
        public ActionResult DanhMuc(string id)
        {
            var sanPhamDanhmuc = new SanPhamDB().GetSanPhamDanhMuc(ref err, id.Trim());
            string soluong = sanPhamDanhmuc.Count.ToString();
            if (id.Equals("PhaChe"))
            {
                ViewBag.SoSanPham = "Sản Phẩm pha chế | "+ soluong +" Sản phẩm";
            }
            else if (id.Equals("DongChai"))
            {
                ViewBag.SoSanPham = "Sản phẩm đóng chai | " + soluong + " Sản phẩm";
            }
            else if (id.Equals("DoAnNhanh")){
                ViewBag.SoSanPham = "Đồ ăn nhanh | " + soluong + " Sản phẩm";
            }
            else
            {
                ViewBag.SoSanPham = "Tất cả sản phẩm | " + soluong + " Sản phẩm";
            }
                return View(sanPhamDanhmuc);
        }

        public ActionResult HienThiHoaDon(FormCollection form)
        {
             if (SessionHelperLogin.GetSession() != null && SessionHelperLogin.GetSession().Type =="US") {
                string MaKH = form["MaKH"];
                var hoaDons = new OrderDB().HienThiHD(ref err, MaKH);
                return View(hoaDons);
              }
              else
               {
                   return RedirectToAction("Index", "Login");
               }
        }

        public ActionResult HienThiChiTiet(string MaHD)
        {
            if (SessionHelperLogin.GetSession() != null && SessionHelperLogin.GetSession().Type == "US")
            {
                var ctHoaDons = new OrderDetailDB().HienThiChiTiet (ref err, MaHD);
                return View(ctHoaDons);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}