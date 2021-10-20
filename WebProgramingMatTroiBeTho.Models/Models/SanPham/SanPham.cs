using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramingMatTroiBeTho.Models.Models.SanPham
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DinhDanhSP { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public string ChiTietSanPham { get; set; }
        public string DonViTinh { get; set; }
        public string LoaiSP { get; set; }
        public bool TinhTrang { get; set; }
        public string HinhAnh { get; set; }
    }
}
