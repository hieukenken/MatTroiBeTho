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

    }
}
