using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramingMatTroiBeTho.Models.Models.SanPham
{
    public class OrderDetail
    {
        public int MaHD { get; set; }
        public string IDSP { get; set; }
        public double GiamGia { get; set; }
        public double GiaTien { get; set; }
        public int SoLuong { get; set; }
        public string LoaiHang { get; set; }
    }
}
