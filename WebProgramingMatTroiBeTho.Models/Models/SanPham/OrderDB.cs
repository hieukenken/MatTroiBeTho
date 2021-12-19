using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramingMatTroiBeTho.Models.Models.SanPham
{
    public class OrderDB:BasicDB
    {
        public int CheckMaHDInOrder(ref string err)
        {
            return (int)data.MyExecuteScalar(ref err, "SPH_CheckSoHoaDon", System.Data.CommandType.StoredProcedure, null);
        }
        public bool AddOrder(ref string err, ref int rows, Order order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaHD", order.MaHD),
                new SqlParameter("@SDTDN", order.SDTDangNhap),
                new SqlParameter("@SDTNhanHang", order.SoDienThoaiNhanHang),
                new SqlParameter("@DiaChiNhan", order.DiaChiNhanHang),
                new SqlParameter("@TongTien", order.TongTien),
                new SqlParameter("@NgayLap", order.ThoiGianDatHang),
                new SqlParameter("@GiaoHang", order.GiaoHang)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "PSH_ThemOrder", CommandType.StoredProcedure, param);
        
    }
        public List<Order> HienThiHD(ref string err, string MaKH)
        {
            List<Order> lisHD = new List<Order>();
            var dataReader = data.MyExecuteReader(ref err, "PSH_InHoaDon", CommandType.StoredProcedure, new SqlParameter("@MaKH", MaKH));
            if(dataReader != null)
            {
                while (dataReader.Read())
                {
                    lisHD.Add(
                    new Order()
                    {
                        MaHD = int.Parse(dataReader["MaHD"].ToString()),
                        ThoiGianDatHang = DateTime.Parse(dataReader["NgayLap"].ToString()),
                        SoDienThoaiNhanHang = dataReader["SDTdathang"].ToString(),
                        DiaChiNhanHang = dataReader["DiaChiNhanHang"].ToString(),
                        TongTien = double.Parse(dataReader["TongTien"].ToString()),
                        GiaoHang = bool.Parse(dataReader["GiaoHang"].ToString())
                    });

                }
            }
            return lisHD;
        }
        //Phuc Hóa đơn
        public List<Order> HienThiHD_ADMIN(ref string err)
        {
            List<Order> lisHD = new List<Order>();
            var dataReader = data.MyExecuteReader(ref err, "NHP_Admin_XemHoaDon", CommandType.StoredProcedure, null);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    lisHD.Add(
                    new Order()
                    {
                        MaHD = int.Parse(dataReader["MaHD"].ToString()),
                        ThoiGianDatHang = DateTime.Parse(dataReader["NgayLap"].ToString()),
                        SoDienThoaiNhanHang = dataReader["SDTdathang"].ToString(),
                        DiaChiNhanHang = dataReader["DiaChiNhanHang"].ToString(),
                        TongTien = double.Parse(dataReader["TongTien"].ToString()),
                        GiaoHang = bool.Parse(dataReader["GiaoHang"].ToString())
                    });

                }
            }
            return lisHD;
        }
        public List<Order> HienThiHD_ADMIN_Thang(ref string err)
        {
            List<Order> lisHD = new List<Order>();
            var dataReader = data.MyExecuteReader(ref err, "NHP_ADMIN_HD_THang", CommandType.StoredProcedure, null);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    lisHD.Add(
                    new Order()
                    {
                        MaHD = int.Parse(dataReader["MaHD"].ToString()),
                        ThoiGianDatHang = DateTime.Parse(dataReader["NgayLap"].ToString()),
                        SoDienThoaiNhanHang = dataReader["SDTdathang"].ToString(),
                        DiaChiNhanHang = dataReader["DiaChiNhanHang"].ToString(),
                        TongTien = double.Parse(dataReader["TongTien"].ToString()),
                        GiaoHang = bool.Parse(dataReader["GiaoHang"].ToString())
                    });

                }
            }
            return lisHD;
        }

        public List<Order> HienThiHD_ADMIN_HomNay(ref string err)
        {
            List<Order> lisHD = new List<Order>();
            var dataReader = data.MyExecuteReader(ref err, "NHP_ADMIN_HD_HomNay", CommandType.StoredProcedure, null);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    lisHD.Add(
                    new Order()
                    {
                        MaHD = int.Parse(dataReader["MaHD"].ToString()),
                        ThoiGianDatHang = DateTime.Parse(dataReader["NgayLap"].ToString()),
                        SoDienThoaiNhanHang = dataReader["SDTdathang"].ToString(),
                        DiaChiNhanHang = dataReader["DiaChiNhanHang"].ToString(),
                        TongTien = double.Parse(dataReader["TongTien"].ToString()),
                        GiaoHang = bool.Parse(dataReader["GiaoHang"].ToString())
                    });

                }
            }
            return lisHD;
        }
        public List<Order> ThuNhap_ADMIN_Thang(ref string err)
        {
            List<Order> lisHD = new List<Order>();
            var dataReader = data.MyExecuteReader(ref err, "NHP_ADMIN_HD_THang", CommandType.StoredProcedure, null);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    lisHD.Add(
                    new Order()
                    {
                        TongTien = double.Parse(dataReader["TongTien"].ToString()),
                    });

                }
            }
            return lisHD;
        }

    }
}
