using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for AutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService 
{
    [WebMethod]
    public string[] GetCountriesList(string prefixText) 
    {
        DataSet dtst = new DataSet();
        //SqlParameter[] param = new SqlParameter[0];
        //param[0] = new SqlParameter("@Name", prefixText);
        //param[0].SqlDbType = SqlDbType.NVarChar;
        //dtst = SQLDataAccess.GetDataSet("sp_GetNameSearch", param);
        ConnectionStringSettings sqlconn = ConfigurationManager.ConnectionStrings["DBConnectionString"];

        SqlConnection sqlCon = new SqlConnection(sqlconn.ConnectionString);
        string strSql = "SELECT Name FROM Street WHERE Name LIKE N'%" + prefixText + "%' ";
        SqlCommand sqlComd = new SqlCommand(strSql, sqlCon);
        sqlCon.Open();
        SqlDataAdapter sqlAdpt = new SqlDataAdapter();
        sqlAdpt.SelectCommand = sqlComd;
        sqlAdpt.Fill(dtst);
        string[] cntName = new string[dtst.Tables[0].Rows.Count];
        int i = 0;
        try
        {
            foreach (DataRow rdr in dtst.Tables[0].Rows)
            {
                cntName.SetValue(rdr["Name"].ToString(), i);
                i++;
            }
        }
        catch { }
        finally
        {
            //sqlCon.Close();
        }
        return cntName;
    }

    [WebMethod]
    public string[] GetDistrictList(string prefixText)
    {
        DataSet dtst = new DataSet();
        //SqlParameter[] param = new SqlParameter[0];
        //param[0] = new SqlParameter("@Name", prefixText);
        //param[0].SqlDbType = SqlDbType.NVarChar;
        //dtst = SQLDataAccess.GetDataSet("sp_GetNameSearch", param);
        ConnectionStringSettings sqlconn = ConfigurationManager.ConnectionStrings["DBConnectionString"];

        SqlConnection sqlCon = new SqlConnection(sqlconn.ConnectionString);
        string strSql = "SELECT Name FROM District WHERE Name LIKE N'%" + prefixText + "%' ";
        SqlCommand sqlComd = new SqlCommand(strSql, sqlCon);
        sqlCon.Open();
        SqlDataAdapter sqlAdpt = new SqlDataAdapter();
        sqlAdpt.SelectCommand = sqlComd;
        sqlAdpt.Fill(dtst);
        string[] cntName = new string[dtst.Tables[0].Rows.Count];
        int i = 0;
        try
        {
            foreach (DataRow rdr in dtst.Tables[0].Rows)
            {
                cntName.SetValue(rdr["Name"].ToString(), i);
                i++;
            }
        }
        catch { }
        finally
        {
            //sqlCon.Close();
        }
        return cntName;
    } 
}