using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramingMatTroiBeTho.Models.Models
{
    public class User
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public int SDT { get; set; }
        public string Email { get; set; }
        public bool TinhTrang { get; set; }


        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int TongTien { get; set; }

        public string DiaChiNhan { get; set; }
    }
}
