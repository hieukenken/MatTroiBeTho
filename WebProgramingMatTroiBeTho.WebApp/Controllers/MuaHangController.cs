using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramingMatTroiBeTho.Models.Models.Account;
using WebProgramingMatTroiBeTho.Models.Models.SanPham;
using WebProgramingMatTroiBeTho.WebApp.Commons;
using WebProgramingMatTroiBeTho.WebApp.Models;

namespace WebProgramingMatTroiBeTho.WebApp.Controllers
{
    public class MuaHangController : Controller
    {
        string err;
        int rows;
        List<SanPham> lsSp()
        {
            var list = new SanPhamDB().GetSanPhamList(ref err,"");
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
            if(SessionHelperLogin.GetSession() != null)
            {
                var sp = lsSp().SingleOrDefault(s => s.MaSP == id);
                if (sp != null)
                {
                    GetCart().Add(sp);
                }
                return RedirectToAction("Index", "Home"); // RedirectToAction("HienThiCart", "MuaHang");
            }
            else
            {
                SetAlert("Bạn cần đăng nhập để mua hàng", 2);
                return RedirectToAction("Index", "Login");
            }
               
        }

        public ActionResult HienThiCart()
        {
            if (SessionHelperLogin.GetSession() != null && SessionHelperLogin.GetSession().Type == "US")
            {
                TempData["Number"] = SessionHelperLogin.GetSession().UserName;
                if (Session["Cart"] == null)
                    return RedirectToAction("HienThiCart", "MuaHang");
                Cart cart = Session["Cart"] as Cart;
                return View(cart);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            
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

        public PartialViewResult GioHang()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
                total_item = cart.TongSoHangTrongCart();
                ViewBag.SoSanPham = total_item;
                return PartialView("GioHang");
        }
        public ActionResult MuaSamThanhCong()
        {
            return View();
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                if(SessionHelperLogin.GetSession() != null)
                {
                    Order order = new Order();
                    OrderDB orderDB = new OrderDB();
                    KhachHangDB khachHangDB = new KhachHangDB();
                    int MaHD = orderDB.CheckMaHDInOrder(ref err);
                    MaHD = MaHD + 1;
                    foreach (var item in cart.Items)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.MaHD = MaHD;
                        orderDetail.IDSP = item.shopping_SanPham.MaSP;
                        orderDetail.SoLuong = item.shopping_quantity;
                        orderDetail.GiaTien = item.shopping_SanPham.DonGia * item.shopping_quantity;
                        orderDetail.LoaiHang = item.shopping_SanPham.LoaiSP;
                        var add = new OrderDetailDB().ThemOrderDetail(ref err, ref rows, orderDetail);
                        if (add == false)
                        {
                            return Content("Lỗi Không add được, Thông báo với admin để có thưởng ádasdasdasd:V");
                        }
                        // bỏ vào bảng chi tiết order
                    }
                    order.MaHD = MaHD;
                    order.ThoiGianDatHang = DateTime.Now;
                    order.SDTDangNhap = SessionHelperLogin.GetSession().UserName;
                    order.DiaChiNhanHang = form["DiaChiNhanHang"];
                    order.SoDienThoaiNhanHang = form["SDTNhanHang"];
                    order.TongTien = double.Parse(form["TongTienThanhToan"]);
                    order.GiaoHang = false;
                    // tạo cập nhật order vào database orderDB
                    var add_order = orderDB.AddOrder(ref err, ref rows, order);

                    // Cập nhật địa chỉ nhận của khách hàng
                    var add_DiaChi = khachHangDB.ThemDiaChiKhachHang(ref err, ref rows, order.DiaChiNhanHang, order.SDTDangNhap);
                    if (!add_DiaChi)
                    {
                        return Content("Lỗi Không add được địa chỉ, Thông báo với admin để có thưởng :V");
                    }
                    if(!add_order)
                        return Content("Lỗi Không add được, Thông báo với admin để có thưởng :V");
                    // lấy item vào giỏ hàng

                    cart.XoaCart();
                    return RedirectToAction("MuaSamThanhCong", "MuaHang");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch
            {
                return Content("Lỗi mua hàng, xem lại thông tin...");
            }
        }
        protected void SetAlert(string message, int type)
        {
            TempData["AlertMessage"] = message;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == 3)
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }
    }
}