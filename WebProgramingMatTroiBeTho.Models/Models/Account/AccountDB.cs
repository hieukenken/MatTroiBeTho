using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WebProgramingMatTroiBeTho.Models.Models.Account
{
    public class AccountDB:BasicDB
    {
        public bool LoginAdmin(ref string err, string UserName, string PassWord)
        {
            bool result = false;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@PassWord", PassWord)
            };
            try
            {
                result = (bool)data.MyExecuteScalar(ref err, "SPH_Account_Login_Admin", CommandType.StoredProcedure, param);
            }catch(Exception ex)
            {
                err = ex.Message;
            }
            return result;
        }
        // lấy thông tin khách hàng, Hiện tại chỉ lấy địa chỉ và tên 
        public KhachHang GetKhachHang(ref string err, string UserName)
        {
            KhachHang khachHang = new KhachHang();
            var dataReader = data.MyExecuteReader(ref err, "PSH_LayDiaChiKhachHang", CommandType.StoredProcedure, new SqlParameter("@UserName", UserName));
            if(dataReader != null)
            {
                while (dataReader.Read())
                {
                    khachHang.DiaChiKH = dataReader["DiaChiNhan"].ToString();
                    khachHang.TenKH = dataReader["TenKH"].ToString();
                }
            }
            return khachHang;
        }

        public bool CheckAccount(ref string err, string UserName)
        {
            bool result = false;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserName", UserName)
            };
            try
            {
                result = (bool)data.MyExecuteScalar(ref err, "SPH_Account_Check", CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return result;
        }

        public bool LoginUser(ref string err, string UserName, string PassWord)
        {
            bool result = false;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@PassWord", PassWord)
            };
            try
            {
                result = (bool)data.MyExecuteScalar(ref err, "SPH_Account_Login_User", CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return result;
        }
        public bool SingUpUser(ref string err, ref int rows, Account account)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Username", account.UserName),
                new SqlParameter("@PassWord", account.PassWord),
                new SqlParameter("@NameKH", account.NameUser),
                new SqlParameter("@LoaiTK", 2)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "SPH_Account_Singup_User_Basic", CommandType.StoredProcedure, param);
        }


    }
}
