using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramingMatTroiBeTho.Models.Models.SanPham
{
    public class Order
    {
        public int MaHD { get; set; }
        public int IDOrder { get; set; }
        public SanPham SanPham { get; set; }
        public string SDTDangNhap { get; set; }
        public string SoDienThoaiNhanHang { get; set; }
        public DateTime ThoiGianDatHang { get; set; }
        public double TongTien { get; set; }
        public int SoLuong { get; set; }
        public string DiaChiNhanHang { get; set; }
    }
}

