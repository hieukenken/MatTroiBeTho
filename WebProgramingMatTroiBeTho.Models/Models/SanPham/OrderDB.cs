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
                new SqlParameter("@NgayLap", order.ThoiGianDatHang)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "PSH_ThemOrder", CommandType.StoredProcedure, param);
        
    }
    }
}
