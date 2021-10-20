using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramingMatTroiBeTho.Models.Models.Cart
{
    public class ItemSP
    {
        string IDSP { get; set; }
        string TenSP { get; set; }
        int SoLuong { get; set; }
        string LoaiSP { get; set; }
        string HinhAnh { get; set; }
        double DonGia { get; set; }
    }

    public class XuLyCat
    {
        List<ItemSP> lsSP = new List<ItemSP>();
        public IEnumerable<ItemSP> itemSPs
        {
            get { return itemSPs; }
        }
    }
}
