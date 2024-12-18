using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class AdminGPSRealTime : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        lbAdmin.Text = "<font color='orange'>Xin chào</font> " + Session["name"].ToString();
        if (!IsPostBack)
        {
            timeGps.Interval = 10000000;
            Label1.Visible = false;
            Label1.Text = "";
            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.
            GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet1.GoogleMapObject.Width = "970px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet1.GoogleMapObject.Height = "745px";

            //Specify initial Zoom level.
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 16;

            //Specify Center Point for map. Map will be centered on this point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("HaNoiPoint", 21.013609, 105.844409);
            GooglePoint gp = new GooglePoint("tracking", 21.013609, 105.844409);
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(gp);
            getData();
            getBusLineName();
            timeGps.Enabled = false;
            Label1.Visible = true;
        }
    }
    protected void btnTracking_Click(object sender, EventArgs e)
    {
        if (drlBus.SelectedValue !=" ")
        {
            timeGps.Interval = 1000;
            //Label1.Visible = true;
            timeGps.Enabled = true;
            lbInfo.Text = "Bạn đang theo dõi, để dừng lại bấm 'Dừng lại'";
        }
        else
        {
            lbInfo.Text = "Chọn xe để theo dõi";
        }
    }
    int i = 0;
    protected void timeGps_Tick(object sender, EventArgs e)
    {
        //Label1.Text = DateTime.Now.ToString();

        string strBus = drlBus.SelectedValue;
        if (strBus != null)
        {
            lblBusID.Text = strBus;
            dt = BusBIZ.getInfoGPS(strBus, DateTime.Now);
            if (dt.Rows.Count != 0)
            {
                lbLatitude.Text = dt.Rows[0]["Latitude"].ToString();
                lbLongitude.Text = dt.Rows[0]["Longitude"].ToString();
                lbTime.Text = DateTime.Now.ToString();
                lbSpeed.Text = dt.Rows[0]["Speed"].ToString();
                GoogleMapForASPNet1.GoogleMapObject.Points["tracking"].Latitude = Convert.ToDouble(lbLatitude.Text);
                GoogleMapForASPNet1.GoogleMapObject.Points["tracking"].Longitude = Convert.ToDouble(lbLongitude.Text);
                //if (i == 0)
                //{
                //    GoogleMapForASPNet1.GoogleMapObject.CenterPoint = GoogleMapForASPNet1.GoogleMapObject.Points["tracking"];
                //    GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;

                //}
                //i++;
            }
            else
            {
                lbLatitude.Text = "";
                lbLongitude.Text = "";
                lbSpeed.Text = "";
            }
        }
        else {
            lblBusID.Text = "";
            lbLatitude.Text = "";
            lbLongitude.Text = "";
            
        }
    }
    // get BusStop
    public void getData()
    {
        DataTable dt = new DataTable();
        dt = BusAccess.getBusStopData();
        int n = dt.Rows.Count;
        //count = n;
        if (n != 0)
        {
            GooglePoint[] gp = new GooglePoint[n];
            for (int i = 0; i < n; i++)
            {
                gp[i] = new GooglePoint();
                gp[i].ID = i.ToString();
                gp[i].ToolTip = dt.Rows[i]["Name"].ToString();
                gp[i].Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"].ToString());
                gp[i].Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"].ToString());
                //string[] str = dt.Rows[i]["BusLineArray"].ToString().Split(',');
                //string textHtml = "";
                //for (int i1 = 0; i1 < str.Length; i1++)
                //{
                //    textHtml += "a h"str[i1];
                //}
                gp[i].InfoHTML = "<center><font color='Orange'>" + dt.Rows[i]["Name"].ToString() + "</font></center>" + "Các tuyến xe Buýt đi qua: <br/>" + "<font  face='verdana' color='blue'>" + dt.Rows[i]["BusLineArray"].ToString() + "</font>" + "<br/>" + dt.Rows[i]["Address"].ToString();
                gp[i].IconImage = "Images/BusIcon/bus16.png";
                //gp[i].IconImage = @"C:\Users\hehe\Pictures\bus20.png";
                gp[i].IconAnchor_posX = gp[i].IconImageWidth / 2;
                gp[i].IconAnchor_posY = gp[i].IconImageWidth / 2;
                if (i % 3 == 0)
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
    }
    // getBusLineName
    private void getBusLineName()
    {
        DataTable dt = BusBIZ.getBusLineName();
        int n = dt.Rows.Count;
        if (n != 0)
        {
            drlBusLine.DataSource = dt;
            drlBusLine.DataTextField = "Name";
            drlBusLine.DataValueField = "IDBusLine";
            drlBusLine.DataBind();
            drlBusLine.Items.Insert(0, " ");
        }
    }
    protected void drlBusLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drlBusLine.SelectedValue!=" ")
        {
            int idBusLine = Convert.ToInt32(drlBusLine.SelectedValue);
            DataTable dt = BusBIZ.getBusIDGPS(idBusLine);
            drlBus.DataSource = dt;
            drlBus.DataTextField = "IDBus";
            drlBus.DataValueField = "IDBus";
            drlBus.DataBind();
            drlBus.Items.Insert(0, " ");
        }
    }
    protected void btnStop_Click(object sender, EventArgs e)
    {
        timeGps.Enabled = false;
        lbInfo.Text = "Bạn đang dừng theo dõi, để theo dõi tiếp bấm 'Theo dõi'";
    }
    protected void drlBus_SelectedIndexChanged(object sender, EventArgs e)
    {
        timeGps.Enabled = false;
    }
}