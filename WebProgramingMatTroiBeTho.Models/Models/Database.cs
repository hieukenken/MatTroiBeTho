using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebProgramingMatTroiBeTho.Models.Models
{
    public class Database
    {
        private SqlConnection connect;
        private SqlCommand command;

        public Database()
        {
            connect = new SqlConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString };
        }

        public SqlDataReader MyExecuteReader(ref string err, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            SqlDataReader dataReader = null;
            try
            {
                //mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                dataReader = command.ExecuteReader();
            }
            catch (Exception ex) { err = ex.Message; }
            return dataReader;
        }

        public bool MyExecteNonQuery(ref string err, ref int rows, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            bool result = false;
            try
            {
                //mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                rows = command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex) { err = ex.Message; }
            return result;
        }

        public object MyExecuteScalar(ref string err, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            object result = null;
            try
            {
                //Mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khoi tao command
                command = new SqlCommand()
                {
                    Connection = connect,
                    CommandText = commandText,
                    CommandType = commandType,
                    CommandTimeout = 600
                };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                result = command.ExecuteScalar();

            }
            catch (Exception ex) { err = ex.Message; }
            finally { connect.Close(); }// dung dong ket noi
            return result;

        }
    }
}
