using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebProgramingMatTroiBeTho.Models.Models
{
    public class BaiVietDB:BasicDB
    {
        public List<BaiViet> GetBaiViet(ref string err)
        {
            List<BaiViet> lsBV = null;
            SqlDataReader dataReader = data.MyExecuteReader(ref err, "PSH_HienThiBaiViet", CommandType.StoredProcedure, null);
            if (dataReader != null)
            {
                lsBV = new List<BaiViet>();

                while (dataReader.Read())
                {
                    lsBV.Add(new BaiViet()
                    {
                        IDBaiViet = Convert.ToInt32(dataReader["IDBaiViet"].ToString()),
                        TieuDe = dataReader["TenNoiDung"].ToString(),
                        NoiDung = dataReader["NoiDung"].ToString(),
                        TinhTrang = Convert.ToBoolean(dataReader["TinhTrang"].ToString())
                    });
                }
            }
            return lsBV;
        }

        public bool ThemHoacSuaBaiViet(ref string err, ref int rows, BaiViet baiviet)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("IDBaiViet",baiviet.IDBaiViet),
                new SqlParameter("TenNoiDung",baiviet.TieuDe),
                new SqlParameter("NoiDung", baiviet.NoiDung),
                new SqlParameter("TinhTrang", baiviet.TinhTrang)
            };

            return data.MyExecteNonQuery(ref err, ref rows, "PSH_ThemBaiVietHoacSua", CommandType.StoredProcedure, param);
        }

        public bool XoaBaiViet(ref string err, ref int rows, BaiViet baiviet)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("IDBaiViet", baiviet.IDBaiViet)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "PSH_XoaBaiViet", CommandType.StoredProcedure, param);
        }
    }
}
