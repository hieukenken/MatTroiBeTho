using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebProgramingMatTroiBeTho.Models.Models.SanPham
{
    public class SanPhamDB:BasicDB
    {
        public SanPhamDB() : base() { }

        public List<SanPham> GetSanPhamList(ref string err, string searchString)
        {
            List<SanPham> list = new List<SanPham>();
            if(searchString == null)
            {
                searchString = "";
            }
            var dataReader = data.MyExecuteReader(ref err, "PSH_Select_SanPham", CommandType.StoredProcedure, new SqlParameter("@searchString", searchString));
            if(dataReader != null)
            {
                while (dataReader.Read())
                {
                    list.Add(
                        new SanPham()
                        {
                            MaSP = dataReader["MaSP"].ToString(),
                            TenSP = dataReader["TenSP"].ToString(),
                            DonGia = double.Parse(dataReader["DonGia"].ToString()),
                            SoLuong = int.Parse(dataReader["SoLuong"].ToString()),
                            ChiTietSanPham = dataReader["ChiTietSanPham"].ToString(),
                            LoaiSP = dataReader["LoaiSP"].ToString(),
                            TinhTrang = bool.Parse(dataReader["TinhTrang"].ToString()),
                            HinhAnh = dataReader["HinhAnh"].ToString()
                        });
                }
            }
            

            return list;
        }
    }
}
