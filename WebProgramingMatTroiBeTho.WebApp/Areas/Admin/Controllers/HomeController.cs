using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models;
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
            var hdThang = new OrderDB().HienThiHD_ADMIN_Thang(ref err);
            string soluong = hdThang.Count.ToString();
            ViewBag.TongHDThangNay = soluong;
            // hóa đơn trong ngay

            var hdngay = new OrderDB().HienThiHD_ADMIN_HomNay(ref err);
            double tongtienngay = hdngay.Sum(item => item.TongTien);
            ViewBag.TongTienHomNay = string.Format("{0:#,##}", tongtienngay);

            //Tổng tiền trong tháng
            double tongtien = hdThang.Sum(item => item.TongTien);
            ViewBag.TongTienThangNay = string.Format("{0:#,##}", tongtien);
            // tổng khách hàng
            var khachHang = new UserBD().DSKhachHang(ref err);
            string soluongKH = khachHang.Count.ToString();
            ViewBag.TongKhachHang = soluongKH;

            ///bảng hóa đơn ngày 
            ///
            var hoaDonNow = new OrderDB().HienThiHD_ADMIN_HomNay(ref err);
            return View(hoaDonNow);

           // return View();


        }
    }
}