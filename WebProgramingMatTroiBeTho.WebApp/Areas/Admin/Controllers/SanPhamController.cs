using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models.SanPham;

namespace WebProgramingMatTroiBeTho.WebApp.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        string err = string.Empty;
        int rows = 0;
        public ActionResult Index(string  searchString)
        {
            var sanPham = new SanPhamDB().GetSanPhamList(ref err, searchString);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Details/5
        
        public ActionResult Details(string id )
        {                      
            return View();
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPham collection)
        {          
            return View();          
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(string id)
        {          
            return View();
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, SanPham collection)
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

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(string id)
        {           
            return View();
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, SanPham collection)
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
