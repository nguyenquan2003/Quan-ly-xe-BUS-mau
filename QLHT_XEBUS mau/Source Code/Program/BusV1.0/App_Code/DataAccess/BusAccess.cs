using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BusAccess
/// </summary>
public class BusAccess
{
    // get Bus Stop Data
    public static DataTable getBusStopData()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        ds = SQLDataAccess.GetDataSet("sp_GetBusStop", null);
        dt = ds.Tables[0];
        return dt;
    }

    // get Bus Line Name
    public static DataTable getBusLineName()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        ds = SQLDataAccess.GetDataSet("sp_getBusLineName", null);
        dt = ds.Tables[0];
        return dt;
    }

    // get Bus Line Name
    public static DataSet getBusLineService()
    {
       
        DataSet ds = new DataSet();
        ds = SQLDataAccess.GetDataSet("sp_getBusLineName", null);
        
        return ds;
    }

    // get Direction BusLine Path Go
    public static DataTable getBusLinePathGo(int id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new   SqlParameter("@IDBusLine", id);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.GetDataSet("sp_getBusLinePathGo", param).Tables[0];
 
    }

    // get Direction BusLine Path Back
    public static DataTable getBusLinePathBack(int id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDBusLine", id);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.GetDataSet("sp_getBusLinePathBack", param).Tables[0];

    }
    // get Direction BusLine Path Back by Name
    public static DataSet getPathBack(string nameBus)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Name", nameBus);
        param[0].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.GetDataSet("sp_getPathBack", param);

    }

    // get Direction BusLine Path Go by Name
    public static DataSet getPathGo(string nameBus)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Name", nameBus);
        param[0].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.GetDataSet("sp_getPathGo", param);

    }
    // get Info BusLine by Id
    public static DataTable getInfoBusLineById(int id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDBusLine", id);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.GetDataSet("sp_GetInfoBusLineById", param).Tables[0];

    }

    // get BusPark Name
    public static DataTable getBusParkName()
    {
        return SQLDataAccess.GetDataSet("sp_GetBusParkName",null).Tables[0];
    }


    // get info BusPark
    public static DataTable getInfoBusParkById(int idBusPark)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDBusPark", idBusPark);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.GetDataSet("sp_GetInfoBusParkById", param).Tables[0];
    }

    // get BusLine Name by IdBusPark
    public static DataTable getBusLineNameOfBusPark(int idBusPark)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDBusPark", idBusPark);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.GetDataSet("sp_getInfoBusPark", param).Tables[0];
    }

    // get BusStop of Street
    public static DataTable getBusStopOfStreet(string nameStreet)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@NameStreet", nameStreet);
        param[0].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.GetDataSet("sp_GetBusLineOfStreet", param).Tables[0];
    }

    // get BusStop of Street
    public static DataTable getBusLineOfStreet(string nameStreet)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Name", nameStreet);
        param[0].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.GetDataSet("sp_GetBusLineNameOfStreet", param).Tables[0];
    }

    // get Ticket Park of District
    public static DataTable getTicketPark(string nameDistrict)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@NameDistrict", nameDistrict);
        param[0].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.GetDataSet("sp_GetTicketPark", param).Tables[0];
    }


    // get info of ticketPark
    public static DataTable getInfoTicketPark(string name)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Name", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.GetDataSet("sp_GetInfoTicketPark", param).Tables[0];
    }

    // get info of ticketPark by ID
    public static DataTable getInfoTicketParkByID(int idTicketPark)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDTicketPark", idTicketPark);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.GetDataSet("sp_GetInfoTicketByID", param).Tables[0];
    }

    // get inFo GPS data
    public static DataTable getInfoGPSData(string strBus,DateTime time)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Time", time);
        param[0].SqlDbType = SqlDbType.DateTime;

        param[1] = new SqlParameter("@IDBus", strBus);
        param[1].SqlDbType = SqlDbType.NVarChar;
        return SQLDataAccess.GetDataSet("sp_GetInfoGPSBusRealTime", param).Tables[0];
    }
    
    // get busid GPS
    public static DataTable getBusID(int IDBusLine)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDBusLine ", IDBusLine);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.GetDataSet("sp_GetBusGPS", param).Tables[0];
    }

    // get history GPS
    public static DataTable getGPSHistory(string strBus, DateTime startTime, DateTime endTime)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@IDBus ", strBus);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@StartTime ", startTime);
        param[1].SqlDbType = SqlDbType.DateTime;

        param[2] = new SqlParameter("@EndTime ", endTime);
        param[2].SqlDbType = SqlDbType.DateTime;

        return SQLDataAccess.GetDataSet("sp_GetGPSHistory", param).Tables[0];
    }

    // insert bus park
    public static int insertBusPark(string name, float lat, float longi, string descript, float area, string address, string image)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Name", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@Latitude", lat);
        param[1].SqlDbType = SqlDbType.Float;

        param[2] = new SqlParameter("@Longitude", longi);
        param[2].SqlDbType = SqlDbType.Float;

        param[3] = new SqlParameter("@Description", descript);
        param[3].SqlDbType = SqlDbType.NVarChar;

        param[4] = new SqlParameter("@Area", area);
        param[4].SqlDbType = SqlDbType.Float;

        param[5] = new SqlParameter("@Address", address);
        param[5].SqlDbType = SqlDbType.NVarChar;

        param[6] = new SqlParameter("@Image", image);
        param[6].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.Execute("sp_InsertBusPark", param);
    }

    // update Bus Park 
    public static int updateBusPark(int idBusPark,string name, float lat, float longi, string descript, float area, string address, string image)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Name", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@Latitude", lat);
        param[1].SqlDbType = SqlDbType.Float;

        param[2] = new SqlParameter("@Longitude", longi);
        param[2].SqlDbType = SqlDbType.Float;

        param[3] = new SqlParameter("@Description", descript);
        param[3].SqlDbType = SqlDbType.NVarChar;

        param[4] = new SqlParameter("@Area", area);
        param[4].SqlDbType = SqlDbType.Float;

        param[5] = new SqlParameter("@Address", address);
        param[5].SqlDbType = SqlDbType.NVarChar;

        param[6] = new SqlParameter("@Image", image);
        param[6].SqlDbType = SqlDbType.NVarChar;

        param[7] = new SqlParameter("@IDBusPark", idBusPark);
        param[7].SqlDbType = SqlDbType.Int;
        return SQLDataAccess.Execute("sp_UpdateBusPark", param);
    }

    // Delete bus park
    public static int deleteBusPark(int idBusPark)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDBusPark",idBusPark);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.Execute("sp_DeleteBusPark", param);
    }

    // get Street of District
    public static DataTable getStreetOfDistrict(int idDistrict)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDDistrict", idDistrict);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.GetDataSet("sp_GetStreetOfDistrict", param).Tables[0];
    }

    // get District 
    public static DataTable getDistrict()
    {
        return SQLDataAccess.GetDataSet("sp_GetDistrict", null).Tables[0];
    }

    // insert Ticket Park
    public static int insertTicketPark(string name, int idStreet, float lat, float longi, string address, string time, string descript)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Name", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@IDStreet", idStreet);
        param[1].SqlDbType = SqlDbType.Int;

        param[2] = new SqlParameter("@Address", address);
        param[2].SqlDbType = SqlDbType.NVarChar;

        param[3] = new SqlParameter("@Latitude", lat);
        param[3].SqlDbType = SqlDbType.Float;

        param[4] = new SqlParameter("@Longitude", longi);
        param[4].SqlDbType = SqlDbType.Float;

        param[5] = new SqlParameter("@Time", time);
        param[5].SqlDbType = SqlDbType.NVarChar;

        param[6] = new SqlParameter("@Description", descript);
        param[6].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.Execute("sp_InsertTicketPark", param);
    }

    // get ticket park name
    public static DataTable getTicketParkName()
    {
        return SQLDataAccess.GetDataSet("sp_GetTicketParkName", null).Tables[0];
    }

    // update ticket park 
    public static int updateTicketPark(int idTicketPark, string name, int idStreet, float lat, float longi, string address, string time, string descript)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Name", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@IDStreet", idStreet);
        param[1].SqlDbType = SqlDbType.Int;

        param[2] = new SqlParameter("@Address", address);
        param[2].SqlDbType = SqlDbType.NVarChar;

        param[3] = new SqlParameter("@Latitude", lat);
        param[3].SqlDbType = SqlDbType.Float;

        param[4] = new SqlParameter("@Longitude", longi);
        param[4].SqlDbType = SqlDbType.Float;

        param[5] = new SqlParameter("@Time", time);
        param[5].SqlDbType = SqlDbType.NVarChar;

        param[6] = new SqlParameter("@Description", descript);
        param[6].SqlDbType = SqlDbType.NVarChar;

        param[7] = new SqlParameter("@IDTicketPark", idTicketPark);
        param[7].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.Execute("sp_UpdateTicketPark",param);
    }

    // delete ticket park
    public static int deleteTicketPark(int idTicketPark)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDTicketPark", idTicketPark);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.Execute("sp_DeleteTicketPark",param);
    }

    // delete bus line
    public static int deleteBusLine(int idBusLine)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IDBusLine", idBusLine);
        param[0].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.Execute("sp_DeleteBusLine", param);
    }

    // insert bus line
    public static int insertBusLine(string name, string startTime, string endTime, string pathName,
        string pathGo, string pathBack, float cost, string descript, int frequen)
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@Name", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@StartTime", startTime);
        param[1].SqlDbType = SqlDbType.NVarChar;

        param[2] = new SqlParameter("@EndTime", endTime);
        param[2].SqlDbType = SqlDbType.NVarChar;

        param[3] = new SqlParameter("@PathName", pathName);
        param[3].SqlDbType = SqlDbType.NVarChar;

        param[4] = new SqlParameter("@PathGo", pathGo);
        param[4].SqlDbType = SqlDbType.NVarChar;

        param[5] = new SqlParameter("@PathBack", pathBack);
        param[5].SqlDbType = SqlDbType.NVarChar;

        param[6] = new SqlParameter("@Cost", cost);
        param[6].SqlDbType = SqlDbType.Float;

        param[7] = new SqlParameter("@Description", descript);
        param[7].SqlDbType = SqlDbType.NVarChar;

        param[8] = new SqlParameter("@Frequence", frequen);
        param[8].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.Execute("sp_InsertBusLine", param);
    }

    // update Bus Line by ID
    public static int updateBusLine(int idBusLine, string name, string startTime, string endTime, string pathName,
        string pathGo, string pathBack, float cost, string descript, int frequen)
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Name", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@StartTime", startTime);
        param[1].SqlDbType = SqlDbType.NVarChar;

        param[2] = new SqlParameter("@EndTime", endTime);
        param[2].SqlDbType = SqlDbType.NVarChar;

        param[3] = new SqlParameter("@PathName", pathName);
        param[3].SqlDbType = SqlDbType.NVarChar;

        param[4] = new SqlParameter("@PathGo", pathGo);
        param[4].SqlDbType = SqlDbType.NVarChar;

        param[5] = new SqlParameter("@PathBack", pathBack);
        param[5].SqlDbType = SqlDbType.NVarChar;

        param[6] = new SqlParameter("@Cost", cost);
        param[6].SqlDbType = SqlDbType.Float;

        param[7] = new SqlParameter("@Description", descript);
        param[7].SqlDbType = SqlDbType.NVarChar;

        param[8] = new SqlParameter("@Frequence", frequen);
        param[8].SqlDbType = SqlDbType.Int;

        param[9] = new SqlParameter("@IDBusLine", idBusLine);
        param[9].SqlDbType = SqlDbType.Int;

        return SQLDataAccess.Execute("sp_UpdateBusLine", param);
    }

    // check user
    public static int checkUser(string name)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserName", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.Execute("sp_CheckUser", param);
    }

    // insert user
    public static int insertUser(string name, string pass, string email, string phone, string address)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@UserName", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@Password", pass);
        param[1].SqlDbType = SqlDbType.NVarChar;

        param[2] = new SqlParameter("@Email", email);
        param[2].SqlDbType = SqlDbType.NVarChar;

        param[3] = new SqlParameter("@PhoneNumber", phone);
        param[3].SqlDbType = SqlDbType.VarChar;

        param[4] = new SqlParameter("@Address", address);
        param[4].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.Execute("sp_InsertUser", param);
    }

    // get all user
    public static DataTable getUser()
    {
        return SQLDataAccess.GetDataSet("sp_GetUser", null).Tables[0];
    }

    // update user
    public static int updateUser(string name, string pass, string email, string phone, string address)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@UserName", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@Password", pass);
        param[1].SqlDbType = SqlDbType.NVarChar;

        param[2] = new SqlParameter("@Email", email);
        param[2].SqlDbType = SqlDbType.NVarChar;

        param[3] = new SqlParameter("@PhoneNumber", phone);
        param[3].SqlDbType = SqlDbType.VarChar;

        param[4] = new SqlParameter("@Address", address);
        param[4].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.Execute("sp_UpdateUser", param);
    }

    // delete user
    public static int deleteUser(string name)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserName", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.Execute("sp_DeleteUser", param);
    }


    // check status 
    public static int checkStatus(string name, string password)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserName", name);
        param[0].SqlDbType = SqlDbType.NVarChar;

        param[1] = new SqlParameter("@Password", password);
        param[1].SqlDbType = SqlDbType.NVarChar;

        return SQLDataAccess.Execute("sp_CheckStatus", param);
    }
}