using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramingMatTroiBeTho.Models.Models.SanPham;

namespace WebProgramingMatTroiBeTho.WebApp.Models
{
    
        public class CartItem
        {
            public SanPham shopping_SanPham { get; set; }
            public int shopping_quantity { get; set; }
        }
      
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public void Add(SanPham sp , int quantity = 1)
        {
            var item = items.FirstOrDefault(i => i.shopping_SanPham.MaSP == sp.MaSP);
            if(item == null)
            {
                items.Add(new CartItem
                {
                    shopping_SanPham = sp,
                    shopping_quantity = quantity
                });
            }
            else
            {
                item.shopping_quantity += quantity;
            }
        }
        public void Update_Quantity_Shoping(string id, int soluong)
        {
            var item = Items.First(s => s.shopping_SanPham.MaSP == id);
            if(item!= null)
            {
                item.shopping_quantity = soluong;
            }
        }
        public double TongTien()
        {
            var tong = items.Sum(s => s.shopping_SanPham.DonGia * s.shopping_quantity);
            return (double)tong;
        }
        public void Xoa_SanPham(string id)
        {
            items.RemoveAll(s => s.shopping_SanPham.MaSP == id);
        }

        public int TongSoHangTrongCart()
        {
            return items.Sum(s => s.shopping_quantity);
        }
        public void XoaCart()
        {
            items.Clear();
        }
    }
}