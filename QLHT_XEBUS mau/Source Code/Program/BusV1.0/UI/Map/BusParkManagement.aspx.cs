using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class UI_Map_BusParkManagement : System.Web.UI.Page
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

        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if ((txtNewAddress.Text.Trim()!="")&(txtNewArea.Text.Trim()!="")&(txtNewLongitude.Text.Trim()!="")&(txtNewLatitude.Text.Trim()!="")&(txtNewName.Text.Trim()!=""))
        {
            float lat = float.Parse(txtNewLatitude.Text);
            float longi = float.Parse(txtNewLongitude.Text);
            if ((lat < 0) || (lat > 180) || (longi > 180) || (longi < 0))
            {
                lbThongBao.Visible = true;
                lbThongBao.Text = "Vĩ độ và kinh độ không thỏa mãn trong giới hạn";
                lbKetQua.Visible = false;
            }
            else
            {    
                lbThongBao.Visible = false;
                string name = txtNewName.Text;
                string description = txtNewDescription.Text;
                string address = txtNewAddress.Text;
                float area = float.Parse(txtNewArea.Text);
                string image = "";
                if (fulImages.HasFile)
                {
                    fulImages.SaveAs(Server.MapPath("~/UI/Map/Images/BusPark/") + fulImages.FileName);
                    image = "Images/BusPark/" + fulImages.FileName;
                }
                // them vao co so du lieu
                BusBIZ.insertBusPark(name, lat, longi, description, area, address, image);
                //Response.Write("<script language = 'javascript'>");
                //Response.Write("alert('Đã lưu trữ vào cơ sở dữ liệu !')");
                //Response.Write("</script>");
                lbKetQua.Text = "Đã thêm mới vào cơ sở dữ liệu";
                lbKetQua.Visible = true;
                //txtNewName.Text = "";
                //txtNewLatitude.Text = "";
                //txtNewLongitude.Text = "";
                //txtNewArea.Text = "";
                //txtNewAddress.Text = "";
                //txtNewDescription.Text = "";
                txtNewName.Focus();
            }
        }
        
    }
    //Add event handler for Map Click event
    void OnMapClicked(double dLat, double dLng)
    {
        //Print clicked map positions
        txtNewLatitude.Text = dLat.ToString();
        txtNewLongitude.Text = dLng.ToString();
        //Generate new id for google point
        //string sID = (GoogleMapForASPNet1.GoogleMapObject.Points.Count + 1).ToString();
        //GooglePoint GP1 = new GooglePoint(sID, dLat, dLng);
        //GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);
    }
}