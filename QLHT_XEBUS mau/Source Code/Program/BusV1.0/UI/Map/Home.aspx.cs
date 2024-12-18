using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Home : System.Web.UI.Page
{
    string[] sIcons = { "Images/BusIcon/sun.png", "Images/BusIcon/rain.png", "Images/BusIcon/bus16.png", "Images/BusIcon/snow.png" };
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.
            GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet1.GoogleMapObject.Width = "714px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet1.GoogleMapObject.Height = "500px";

            //Specify initial Zoom level.
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;

            //Specify Center Point for map. Map will be centered on this point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("HaNoiPoint", 21.013609, 105.844409);
            getData();
            getBusLineName();

           
        

        GoogleMapForASPNet1.ZoomChanged += new GoogleMapForASPNet.ZoomChangedHandler(OnZoomChanged);
    }

    public void getData()
    {
        DataTable dt = new DataTable();
        dt = BusAccess.getBusStopData();
        int n = dt.Rows.Count;
        count = n;
        GooglePoint [] gp = new GooglePoint[n];
        for (int i = 0; i < n; i++)
        {
            gp[i] = new GooglePoint();
            gp[i].ID = i.ToString();
            gp[i].ToolTip = dt.Rows[i]["Name"].ToString();
            gp[i].Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"].ToString());
            gp[i].Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"].ToString());
            gp[i].InfoHTML =  dt.Rows[i]["Name"].ToString() + "<br/>" + dt.Rows[i]["Longitude"];
            gp[i].IconImage = "Images/BusIcon/bus8.png";
            gp[i].IconAnchor_posX = gp[i].IconImageWidth / 2;
            gp[i].IconAnchor_posY = gp[i].IconImageWidth / 2;
            if (i%3==0)
            {
                gp[i].MinZoom = 14;
            }
            if (i % 3 == 1)
            {
                gp[i].MinZoom = 15;
            }
            if (i % 3 == 2)
            {
                gp[i].MinZoom = 16;
            }

            GoogleMapForASPNet1.GoogleMapObject.Points.Add(gp[i]);
        }
    }

    // Tuyen xe bus
    public void getBusLineName() {

        drlBusLine.DataSource = BusAccess.getBusLineName();
        drlBusLine.DataValueField = "IDBusLine";
        drlBusLine.DataTextField = "Name";
        drlBusLine.DataBind();
    }
    //Add event handler for PushpinDrag event
    void OnZoomChanged(int pZoomLevel)
    {
        if ((pZoomLevel >= 16) && (pZoomLevel < 20))
        {
            for (int i = 0; i < count; i++)
            {
                //GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].PointStatus = "C";
                GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].IconImage = "Images/BusIcon/bus16.png";
                //GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].IconImage = "Images/BusIcon/bus16.png";
            }
        }

        if ((pZoomLevel < 16))
        {
            for (int i = 0; i < count; i++)
            {
                //GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].PointStatus = "C";
                GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].IconImage = "Images/BusIcon/bus8.png";
                //GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].IconImage = "Images/BusIcon/bus16.png";
            }
        }
        //else
        //    if (pZoomLevel == 20)   
        //    {
        //        for (int i = 0; i < 10; i++)
        //    {
        //        GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].IconImage = "Images/BusIcon/busTest.png";
        //    }
        //    }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int idBusLine = Convert.ToInt32(drlBusLine.SelectedValue);

        DataTable dt = BusAccess.getBusLinePathGo(idBusLine);
        int n = dt.Rows.Count;

        for (int i = 2; i < 28; i++)
        {
            GooglePoint gp = new GooglePoint(i.ToString() + "Moi", Convert.ToDouble(dt.Rows[i]["Latitude"].ToString()), Convert.ToDouble(dt.Rows[i]["Longitude"].ToString()));
            gp.IconImage = "Images/BusIcon/DirectionOrder/iconr1.png";
            gp.MinZoom = 14;

            GoogleMapForASPNet1.GoogleMapObject.Points.Add(gp);
        }

        GooglePoint gp1 = new GooglePoint("q", 21.04873, 105.879124);
        gp1.IconImage = "Images/BusIcon/snow.png";
        gp1.MinZoom = 14;
        gp1.InfoHTML = "Bến xe Gia Lâm";
        gp1.IconAnchor_posX = gp1.IconImageWidth / 2;
        gp1.IconAnchor_posY = gp1.IconImageWidth / 2;
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(gp1);
        GoogleMapForASPNet1.GoogleMapObject.CenterPoint= gp1;
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 18;
    }
}