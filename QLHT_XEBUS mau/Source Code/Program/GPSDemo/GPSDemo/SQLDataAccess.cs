using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using GPSDemo;

/// <summary>
/// Summary description for SQLDataAccess
/// </summary>
public class SQLDataAccess
{
        private static System.Configuration.ConnectionStringSettings sqlconn = ConfigurationManager.ConnectionStrings["DBConnectionString"];
        // khai bao doi tuong ket noi co so du lieu
        private static SqlConnection conn = null;
        //ham open connection
        public static void OpenConnection()
        {
            conn = new SqlConnection(sqlconn.ConnectionString);
            conn.Open();
        }

    // ham close connection
        public static void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        // Ham tra ve dataset
        public static DataSet GetDataSet(string strCommandText, SqlParameter[] param)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandText = strCommandText;
            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (param!=null)
            {
                sqlCommand.Parameters.AddRange(param);
            }
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            try
            {
                objDataAdapter.Fill(ds);
            }
            catch
            {
                
                throw new Exception("Lỗi kết nối đến cơ sở dữ liệu! ");
            }
            CloseConnection();
            return ds;
        }

        public static int Execute(string strCommandText, SqlParameter[] param)
        {
            OpenConnection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = conn;
            sqlcommand.CommandText = strCommandText;
            sqlcommand.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                sqlcommand.Parameters.AddRange(param);
            }
            int result = 0;
            try
            {
                result =Convert.ToInt32(sqlcommand.ExecuteScalar());
            }
            catch
            {
                throw new Exception("Lỗi kết nối đến cơ sở dữ liệu! ");
            }
            CloseConnection();
            return result;

        }


        public static int Insert(string strCommandText, SqlParameter[] param)
        {
            OpenConnection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = conn;
            sqlcommand.CommandText = strCommandText;
            sqlcommand.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                sqlcommand.Parameters.AddRange(param);
            }
            int result = 0;
            try
            {
                result = Convert.ToInt32(sqlcommand.ExecuteScalar());
            }
            catch
            {
                result = 0;
                throw new Exception("Lỗi kết nối đến cơ sở dữ liệu! ");
            }
            CloseConnection();
            return result;

        }

        public static string Status(string strCommandText, SqlParameter[] param)
        {
            OpenConnection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = conn;
            sqlcommand.CommandText = strCommandText;
            sqlcommand.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                sqlcommand.Parameters.AddRange(param);
            }
            string result ="";
            try
            {
                result = sqlcommand.ExecuteScalar().ToString();
            }
            catch
            {
                result = "";
                throw new Exception("Lỗi kết nối đến cơ sở dữ liệu! ");
            }
            CloseConnection();
            return result;
        }

}
