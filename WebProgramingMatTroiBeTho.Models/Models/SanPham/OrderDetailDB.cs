using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebProgramingMatTroiBeTho.Models.Models.SanPham
{
    public class OrderDetailDB:BasicDB
    {
        public bool ThemOrderDetail(ref string err, ref int rows, OrderDetail orderDetail)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaHoaDon", orderDetail.MaHD),
                new SqlParameter("@MaSanPham", orderDetail.IDSP),
                new SqlParameter("@SoLuong", orderDetail.SoLuong),
                new SqlParameter("@DonGia", orderDetail.GiaTien),
                new SqlParameter("@LoaiHang", orderDetail.LoaiHang)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "PSH_ThemChiTietOrder", CommandType.StoredProcedure, param);
        }
        public List<OrderDetail> HienThiChiTiet(ref string er,string MaHD)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            var dataReader = data.MyExecuteReader(ref er, "PSH_ShowChiTiet", CommandType.StoredProcedure, new SqlParameter("@MaHD",MaHD));
            if(dataReader != null)
            {
                while (dataReader.Read())
                {
                    orderDetails.Add(new OrderDetail()
                    {
                        MaHD = int.Parse(dataReader["MaHD"].ToString()),
                        HinhAnh = dataReader["HinhAnh"].ToString(),
                        TenSP = dataReader["TenSP"].ToString(),
                        SoLuong = int.Parse(dataReader["SoLuong"].ToString()),
                        GiaTien = double.Parse(dataReader["DonGia"].ToString()),
                        LoaiHang = dataReader["LoaiHang"].ToString()
                    });
                }
            }
            return orderDetails;
        }
    }
}
