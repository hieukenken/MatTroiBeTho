using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models.SanPham;

namespace WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Controllers
{
    public class ChiTietHoaDonController : Controller
    {
        // GET: Admin/ChiTietHoaDon
        string err = string.Empty;
        int rows = 0;
        public ActionResult Index()
        {
            var hoaDon = new OrderDB().HienThiHD_ADMIN(ref err);
            return View(hoaDon);
        }
        public ActionResult HoaDonThangNay()
        {
            var hoaDonThang = new OrderDB().HienThiHD_ADMIN_Thang(ref err);
            return View(hoaDonThang);
        }
        public ActionResult HoaDonHomNay()
        {
            var hoaDonNow = new OrderDB().HienThiHD_ADMIN_HomNay(ref err);
            return View(hoaDonNow);
        }
        // GET: Admin/ChiTietHoaDon/Details/5
        public ActionResult Details(int id)
        {
            var cthd = new OrderDetailDB().ADMIN_CTHD(ref err, id);
            if (cthd != null)
            {
                return View(cthd);
            }
            else
            {
                if (!string.IsNullOrEmpty(err))
                    ViewBag.Err = string.Format("Lỗi: {0}", err);
                else
                    ViewBag.Err = "Ko xem đc";
            }
            return View();
        }

        // GET: Admin/ChiTietHoaDon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChiTietHoaDon/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ChiTietHoaDon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ChiTietHoaDon/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ChiTietHoaDon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ChiTietHoaDon/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
