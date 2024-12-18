using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// Summary description for MobileService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MobileService : System.Web.Services.WebService {

    public MobileService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataTable getBusLinePathGo(int idBusLine)
    {
        return BusBIZ.getBusLinePathGo(idBusLine);
    }
    [WebMethod]
    public string Hello()
    {
        return "Chao ban Tien";
    }
    [WebMethod]
    public int Add(int a, int b)
    {
        return a + b;
    }
    [WebMethod]
    public DataSet getString()
    {
        return BusAccess.getBusLineService();
    }

    // lay chieu ve cua tuyen xe bus: dau vao la ten xe bus
    [WebMethod]
    public DataSet getPathBack(string nameBus)
    {
        return BusAccess.getPathBack(nameBus);
    }

    // lay chieu di cua tuyen xe bus: dau vao la ten xe bus
    [WebMethod]
    public DataSet getPathGo(string nameBus)
    {
        return BusAccess.getPathGo(nameBus);
    }

    // lay tat ca cac tuyen xe bus
    [WebMethod]
    public DataTable getAllBusLine()
    {
        return BusAccess.getBusLineName();
    }

    // lay tat ca cac tram ban ve
    [WebMethod]
    public DataTable getAllTicketPark()
    {
        return BusAccess.getTicketParkName();
    }

    // lay tat ca cac tram ban ve
    [WebMethod]
    public DataTable getAllStreet()
    {
        return BusAccess.getTicketParkName();
    }
}
