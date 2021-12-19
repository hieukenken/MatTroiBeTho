using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models;

namespace WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        string err = string.Empty;
        int rows = 0;
        public ActionResult Index()
        {
            var khachHang = new UserBD().DSKhachHang(ref err);
            string soluong = khachHang.Count.ToString();
            ViewBag.TongKhachHang = soluong;
            return View(khachHang);
            
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(int id)
        {
            var ctKH = new UserBD().KhachHang_TongHDdamua(ref err, id);
            if (ctKH != null)
            {
                double tongtien = ctKH.Sum(item => item.TongTien);
                ViewBag.TongTienThangNay = string.Format("{0:#,##}", tongtien);
                string tongHD = ctKH.Count.ToString();
                ViewBag.TongHD = tongHD;
                return View(ctKH);
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

        // GET: Admin/KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHang/Create
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

        // GET: Admin/KhachHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/KhachHang/Edit/5
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

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/KhachHang/Delete/5
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
