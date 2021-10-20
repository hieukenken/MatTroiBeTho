using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models.SanPham;
using WebProgramingMatTroiBeTho.WebApp.Models;

namespace WebProgramingMatTroiBeTho.WebApp.Controllers
{
    public class MuaHangController : Controller
    {
        string err;
        List<SanPham> lsSp()
        {
            var list = new SanPhamDB().GetSanPhamList(ref err);
            return list;
        }

        // GET: MuaHang
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult ThemVaoGioHang(string id)
        {
            var sp = lsSp().SingleOrDefault(s => s.MaSP == id);
          if(sp != null)
            {
                GetCart().Add(sp);
            }
           return RedirectToAction("HienThiCart", "MuaHang");
        }

        public ActionResult HienThiCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("HienThiCart", "MuaHang");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult Update_Quatity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string id_sp = form["MaSanPham"];
            int quantity = int.Parse(form["soSanPham"]);
            cart.Update_Quantity_Shoping(id_sp, quantity);
            return RedirectToAction("HienThiCart", "MuaHang");
        }
        public ActionResult Xoa_SanPham (string id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Xoa_SanPham(id);
            return RedirectToAction("HienThiCart", "MuaHang");
        }
    }
}