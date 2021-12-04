using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramingMatTroiBeTho.Models.Models.Account
{
    public class KhachHangDB:BasicDB
    {
        public bool ThemDiaChiKhachHang(ref string err, ref int rows, string diaChi, string username)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DiaChi", diaChi),
                new SqlParameter("@UserName", username),
            };
            return data.MyExecteNonQuery(ref err, ref rows, "PSH_ThemDiaChiKhachHang", CommandType.StoredProcedure, param);
        }
    }
}
