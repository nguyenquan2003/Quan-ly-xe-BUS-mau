using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class UI_Map_TicketManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbAdmin.Text = "<font color='orange'>Xin chào</font> " + Session["name"].ToString();
        //Add event handler for PushpinMoved event
        GoogleMapForASPNet1.MapClicked += new GoogleMapForASPNet.MapClickedHandler(OnMapClicked);
        if (!IsPostBack)
        {
            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.
            GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet1.GoogleMapObject.Width = "700px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet1.GoogleMapObject.Height = "750px";

            //Specify initial Zoom level.
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 13;

            //Specify Center Point for map. Map will be centered on this point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("HaNoiPoint", 21.013609, 105.844409);
            getDistrict();
            GetStreetOfDistrict();
        }
    }

    // get District
    public void getDistrict()
    {
        DataTable dt = BusBIZ.getDistrict();
        drlDistrict.DataSource = dt;
        drlDistrict.DataTextField = "Name";
        drlDistrict.DataValueField = "IDDistrict";
        drlDistrict.DataBind();
    }

    // get Street Of District()
    public void GetStreetOfDistrict()
    {
        int idDistrict = Convert.ToInt32(drlDistrict.SelectedValue);
        DataTable dt = BusBIZ.getStreetOfDistrict(idDistrict);
        drlStreet.DataSource = dt;
        drlStreet.DataTextField = "Name";
        drlStreet.DataValueField = "IDStreet";
        drlStreet.DataBind();
    }
    protected void drlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetStreetOfDistrict();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        float lat = float.Parse(txtLatitude.Text);
        float longi = float.Parse(txtLongitude.Text);
        if ((lat < 0) || (lat > 180) || (longi > 180) || (longi < 0))
        {
            lbThongBao.Visible = true;
            lbThongBao.Text = "Vĩ độ và kinh độ không thỏa mãn trong giới hạn";
            lbKetQua.Visible = false;
        }
        else
        {
            lbThongBao.Visible = false;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string time = txtTime.Text;
            string descript = txtDescription.Text;
            int idStreet = Convert.ToInt32(drlStreet.SelectedValue);
            BusBIZ.insertTicketPark(name, idStreet, lat, longi, address, time, descript);
            lbKetQua.Visible = true;
            lbKetQua.Text = "Đã thêm điểm bán vé <b>"+ name + "</b> vào cơ sở dữ liệu";
        }
    }
    //Add event handler for Map Click event
    void OnMapClicked(double dLat, double dLng)
    {
        //Print clicked map positions
        txtLatitude.Text = dLat.ToString();
        txtLongitude.Text = dLng.ToString();
        //Generate new id for google point
        //string sID = (GoogleMapForASPNet1.GoogleMapObject.Points.Count + 1).ToString();
        //GooglePoint GP1 = new GooglePoint(sID, dLat, dLng);
        //GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);
    }
}