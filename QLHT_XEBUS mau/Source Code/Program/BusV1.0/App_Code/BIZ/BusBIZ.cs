using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BusBIZ
/// </summary>
public class BusBIZ
{
	public BusBIZ()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    // get Bus Stop Data
    public static DataTable getBusStopData()
    {
        return BusAccess.getBusStopData();
    }

    // get Bus Line Name
    public static DataTable getBusLineName()
    {
        return BusAccess.getBusLineName();
    }

    // getBusLinePathGo
    public static DataTable getBusLinePathGo(int idBusLine)
    {
        return BusAccess.getBusLinePathGo(idBusLine);
    }

    // getBusLinePathBack
    public static DataTable getBusLinePathBack(int idBusLine)
    {
        return BusAccess.getBusLinePathBack(idBusLine);
    }

    // getBusLinePathBack by name
    public static DataSet getPathBack(string nameBus)
    {
        return BusAccess.getPathBack(nameBus);
    }

    // getBusLinePathGo by name
    public static DataSet getPathGo(string nameBus)
    {
        return BusAccess.getPathGo(nameBus);
    }
    // get Info BusLine by Id
    public static DataTable getInfoBusLineById(int idBusLine)
    {
        return BusAccess.getInfoBusLineById(idBusLine);
    }

    // get Bus Park Name
    public static DataTable getBusParkName()
    {
        return BusAccess.getBusParkName();
    }

    // get Info BusPark
    public static DataTable getInfoBusParkById(int idBusPark)
    {
        return BusAccess.getInfoBusParkById(idBusPark);
    }

    // get BusLine of BusPark
    public static DataTable getBusLineOfBusPark(int idBusPark)
    {
        return BusAccess.getBusLineNameOfBusPark(idBusPark);
    }

    // get BusStop of Street
    public static DataTable getBusStopOfStreet(string nameStreet)
    {
        return BusAccess.getBusStopOfStreet(nameStreet);
    }

    // get Bus Line of Street
    public static DataTable getBusLineOfStreet(string nameStreet)
    {
        return BusAccess.getBusLineOfStreet(nameStreet);
    }

    // get Ticket Of District
    public static DataTable getTicketPark(string nameDistrict)
    {
        return BusAccess.getTicketPark(nameDistrict);
    }

    // get info of ticketPark
    public static DataTable getInfoTicketPark(string name)
    {
        return BusAccess.getInfoTicketPark(name);
    }

    // get info of ticketPark by Id
    public static DataTable getInfoTicketParkByID(int idTicket)
    {
        return BusAccess.getInfoTicketParkByID(idTicket);
    }

    // get info GPS
    public static DataTable getInfoGPS(string strBus,DateTime time)
    {
        return BusAccess.getInfoGPSData(strBus,time);
    }

    // get BusID
    public static DataTable getBusIDGPS(int idBusLine)
    {
        return BusAccess.getBusID(idBusLine);
    }

    // get GPS History
    public static DataTable getGPSHistory(string strBus, DateTime startTime, DateTime endTime)
    {
        return BusAccess.getGPSHistory(strBus, startTime, endTime);
    }

    // insert bus park
    public static int insertBusPark(string name, float lat, float longi, string descript, float area, string address, string image)
    {
        return BusAccess.insertBusPark(name, lat, longi, descript, area, address, image);
    }

    // update bus park
    public static int updateBusPark(int idBusPark,string name, float lat, float longi, string descript, float area, string address, string image)
    {
        return BusAccess.updateBusPark(idBusPark, name, lat, longi, descript, area, address, image);
    }

    // Delete  Bus Park
    public static int deleteBusPark(int idBusPark)
    {
        return BusAccess.deleteBusPark(idBusPark);
    }

    // get Street of District
    public static DataTable getStreetOfDistrict(int idDistrict)
    {
        return BusAccess.getStreetOfDistrict(idDistrict);
    }

    // get District
    public static DataTable getDistrict()
    {
        return BusAccess.getDistrict();
    }

    // insert ticket park
    public static int insertTicketPark(string name, int idStreet, float lat, float longi, string address, string time, string descript)
    {
        return BusAccess.insertTicketPark(name, idStreet, lat, longi, address, time, descript);
    }

    // get ticket park name
    public static DataTable getTicketParkName()
    {
        return BusAccess.getTicketParkName();
    }

    // update ticket park
    public static int updateTicketPark(int idTicketPark, string name, int idStreet, float lat, float longi, string address, string time, string descript)
    {
        return BusAccess.updateTicketPark(idTicketPark, name, idStreet, lat, longi, address, time, descript);
    }

    // delete ticket park
    public static int deleteTicketPark(int idTicketPark)
    {
        return BusAccess.deleteTicketPark(idTicketPark);
    }

    // delete bus line
    public static int deleteBusLine(int idBusLine)
    {
        return BusAccess.deleteBusLine(idBusLine);
    }

    // insert bus line
    public static int insertBusLine(string name, string startTime, string endTime, string pathName,
        string pathGo, string pathBack, float cost, string descript, int frequen)
    {
        return BusAccess.insertBusLine(name, startTime, endTime, pathName, pathGo, pathBack, cost, descript, frequen);
    }

    // update bus line by id
    public static int updateBusLine(int idBusLine, string name, string startTime, string endTime, string pathName,
        string pathGo, string pathBack, float cost, string descript, int frequen)
    {
        return BusAccess.updateBusLine(idBusLine,name, startTime, endTime, pathName, pathGo, pathBack, cost, descript, frequen);
    }

    // check User
    public static int checkUser(string name)
    {
        return BusAccess.checkUser(name);
    }

    // insert user
    public static int insertUser(string name, string pass, string email, string phone, string address)
    {
        return BusAccess.insertUser(name, pass, email, phone, address);
    }

    // get user
    public static DataTable getUser()
    {
        return BusAccess.getUser();
    }

    // update user
    public static int updateUser(string name, string pass, string email, string phone, string address)
    {
        return BusAccess.updateUser(name, pass, email, phone, address);
    }

    // delete user
    public static int deleteUser(string name)
    {
        return BusAccess.deleteUser(name);
    }

    // check status
    public static int checkStatus(string name, string password)
    {
        return BusAccess.checkStatus(name, password);
    }
}