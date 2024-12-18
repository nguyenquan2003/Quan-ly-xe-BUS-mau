using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class UI_Map_EditBusParkManagement : System.Web.UI.Page
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
          
            getBusParkName();
            hpImage.Text = "";
        }
    }

    // get BusPark Name
    public void getBusParkName()
    {
        DataTable dt = BusBIZ.getBusParkName();
        int n = dt.Rows.Count;
        if (n != 0)
        {
            drlBusPark.DataSource = dt;
            drlBusPark.DataTextField = "Name";
            drlBusPark.DataValueField = "IDBusPark";
            drlBusPark.DataBind();
            drlBusPark.Items.Insert(0, " ");
        }
    }
    protected void drlBusPark_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbKetQua.Visible = false;
        lbThongBao.Visible = false;
        if (drlBusPark.SelectedValue.Trim()!="")
        {
            int idBusPark = Convert.ToInt32(drlBusPark.SelectedValue);
            getInfo(idBusPark);
        }
    }

    // get Info of BusPark
    public void getInfo(int idBusPark)
    {
        DataTable dt = BusBIZ.getInfoBusParkById(idBusPark);
        txtNewName.Text = dt.Rows[0]["Name"].ToString();
        txtNewLatitude.Text = dt.Rows[0]["Latitude"].ToString();
        txtNewLongitude.Text = dt.Rows[0]["Longitude"].ToString();
        txtNewDescription.Text = dt.Rows[0]["Description"].ToString();
        txtNewArea.Text = dt.Rows[0]["Area"].ToString();
        txtNewAddress.Text = dt.Rows[0]["Address"].ToString();
        hpImage.ImageUrl = dt.Rows[0]["Image"].ToString();
        if (hpImage.ImageUrl.Trim() == "")
        {
            hpImage.Text = "Chưa có hình ảnh";
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // cap nhat vao co so du lieu
        if (drlBusPark.SelectedValue.Trim() != "")
        {
            int idBusPark = Convert.ToInt32(drlBusPark.SelectedValue);
            if ((txtNewAddress.Text.Trim() != "") & (txtNewArea.Text.Trim() != "") & (txtNewLongitude.Text.Trim() != "") & (txtNewLatitude.Text.Trim() != "") & (txtNewName.Text.Trim() != ""))
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
                    string image = hpImage.ImageUrl;
                    if (fulImages.HasFile)
                    {
                        fulImages.SaveAs(Server.MapPath("~/UI/Map/Images/BusPark/") + fulImages.FileName);
                        image = "Images/BusPark/" + fulImages.FileName;
                        hpImage.ImageUrl = image;
                    }

                    BusBIZ.updateBusPark(idBusPark, name, lat, longi, description, area, address, image);
                    txtNewName.Focus();
                    lbKetQua.Text = "Đã cập nhật vào cơ sở dữ liệu";
                    lbKetQua.Visible = true;
                    getBusParkName();
                    drlBusPark.SelectedValue = idBusPark.ToString();

                }
            }
        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (drlBusPark.SelectedValue.Trim()!="")
        {
            getInfo(Convert.ToInt32(drlBusPark.SelectedValue));
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