using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramingMatTroiBeTho.Models.Models
{
    public class UserBD : BasicDB
    {
        public List<User> DSKhachHang(ref string err)
        {
            List<User> listKH = new List<User>();
            var dataReader = data.MyExecuteReader(ref err, "NHP_DSKHACHHANG", CommandType.StoredProcedure, null);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    listKH.Add(
                    new User()
                    {
                        MaKH = int.Parse(dataReader["MaKH"].ToString()),
                        TenKH = (dataReader["TenKH"].ToString()),
                        GioiTinh = (dataReader["GioiTinh"].ToString()),
                        SDT = int.Parse(dataReader["SDT"].ToString()),
                        DiaChi = dataReader["DiaChi"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        TinhTrang = bool.Parse(dataReader["TinhTrang"].ToString())
                    });

                }
            }
            return listKH;
        }
        public List<User> KhachHang_TongHDdamua(ref string er, int id)
        {
            List<User> khDetails = new List<User>();
            var dataReader = data.MyExecuteReader(ref er, "NHP_KhachHang_TongHD", CommandType.StoredProcedure, new SqlParameter("@id", id));
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    khDetails.Add(new User()
                    {
                        TenKH = (dataReader["TenKH"].ToString()),
                        SDT = int.Parse(dataReader["SDT"].ToString()),
                        DiaChiNhan = dataReader["DiaChiNhanHang"].ToString(),
                        TongTien = int.Parse(dataReader["TongTien"].ToString()),
                        NgayLap = DateTime.Parse(dataReader["NgayLap"].ToString()),
                    });
                }
            }
            return khDetails;
        }
    }
}
