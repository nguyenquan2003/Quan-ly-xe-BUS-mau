using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Data;

public partial class UI_Map_BusLine : System.Web.UI.Page
{
    private enum TabIndex
    {

        DEFAULT = 0,

        ONE = 1,

        TWO = 2,

        // you can as many as you want here
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "selecttab", "$('#tabs').tabs({ selected: " + hidLastTab.Value + " });", true);
        if (!IsPostBack)
        {

            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.
            GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet1.GoogleMapObject.Width = "970px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet1.GoogleMapObject.Height = "745px";

            //Specify initial Zoom level.
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;

            //Specify Center Point for map. Map will be centered on this point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("HaNoiPoint", 21.013609, 105.844409);
            getData();
            getBusLineName();
            getBusParkName();
            pnBusLine.Visible = false;
            pnBusPark.Visible = false;
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
    protected void btnChieuDi_Click(object sender, EventArgs e)
    {
        hidLastTab.Value = "0";
        if (drlBusLine.SelectedValue != " ")
        {
            int idBusLine = Convert.ToInt32(drlBusLine.SelectedValue);
            getDirect(idBusLine, "r",true);
            getInfoBusLine(idBusLine);
        }
        else
        {
            for (int i = 0; i < 50; i++)
            {
                GoogleMapForASPNet1.GoogleMapObject.Points.Remove(i.ToString() + "Moi");
            }
            pnBusLine.Visible = false;
        }
    }

    protected void btnChieuVe_Click(object sender, EventArgs e)
    {
        hidLastTab.Value = "0";
        if (drlBusLine.SelectedValue != " ")
        {
            int idBusLine = Convert.ToInt32(drlBusLine.SelectedValue);
            getDirect(idBusLine, "g",false);
            getInfoBusLine(idBusLine);
        }
        else
        {
            for (int i = 0; i < 50; i++)
            {
                GoogleMapForASPNet1.GoogleMapObject.Points.Remove(i.ToString() + "Moi");
            }
            pnBusLine.Visible = false;
        }
    }
    // Add onZoomChangeMap
    //void OnZoomChanged(int pZoomLevel)
    //{
    //    if ((pZoomLevel>=14)&&(pZoomLevel<=16))
    //    {
    //        for (int i = 0; i < count; i++)
    //        {
    //            GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].PointStatus = "C";
    //            GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].IconImage = "Images/BusIcon/bus8.png";
    //        }
    //    }
    //    if ((pZoomLevel>16)&&(pZoomLevel<=18))
    //    {
    //        for (int i = 0; i < count; i++)
    //        {
    //            GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].PointStatus = "C";
    //            GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].IconImage = "Images/BusIcon/bus16.png";
    //        }
    //    }

    //    if ((pZoomLevel>18)&&(pZoomLevel<=20))
    //    {
    //        for (int i = 0; i < count; i++)
    //        {
    //            GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].PointStatus = "C";
    //            GoogleMapForASPNet1.GoogleMapObject.Points[i.ToString()].IconImage = "Images/BusIcon/bus20.png";
    //        }
    //    }
    //}

    public string GetAbsFolderCurrent()
    {
        FileInfo fileInfo = new FileInfo(HttpContext.Current.Request.PhysicalApplicationPath);
        return fileInfo.Directory.FullName;
    }

    // thong tin cua tung tuyen xe Bus 
    public void getInfoBusLine(int idBusLine)
    {
        DataTable dtBusLineInfo = BusBIZ.getInfoBusLineById(idBusLine);
        lbDescription.Text = dtBusLineInfo.Rows[0]["Description"].ToString();
        lbCost.Text = dtBusLineInfo.Rows[0]["Cost"].ToString() + " đ/lượt";
        lbFrequence.Text = dtBusLineInfo.Rows[0]["Frequence"].ToString() + " phút/chuyến";
        lbTime.Text = dtBusLineInfo.Rows[0]["StartTime"].ToString() + " - " + dtBusLineInfo.Rows[0]["EndTime"].ToString();
        lbPathGo.Text = dtBusLineInfo.Rows[0]["PathGo"].ToString();
        lbPathBack.Text = dtBusLineInfo.Rows[0]["PathBack"].ToString();
        pnBusLine.Visible = true;
    }

    // bieu dien duong di cua tuyen xe Bus
    public void getDirect(int idBusLine, string strIcon, bool direct)
    {
        GoogleMapForASPNet1.GoogleMapObject.Points.Remove("Street");
        for (int i = 0; i < 50; i++)
        {
            GoogleMapForASPNet1.GoogleMapObject.Points.Remove(i.ToString() + "Moi");
        }
        DataTable dt = new DataTable();
        if (direct == true)
        {
           dt = BusBIZ.getBusLinePathGo(idBusLine);
        }
        else
           dt = BusBIZ.getBusLinePathBack(idBusLine);
        
        int n = dt.Rows.Count;
        if (n != 0)
        {
            for (int i = 0; i < n; i++)
            {
                GooglePoint gp = new GooglePoint(i.ToString() + "Moi", Convert.ToDouble(dt.Rows[i]["Latitude"].ToString()), Convert.ToDouble(dt.Rows[i]["Longitude"].ToString()));
                gp.InfoHTML = dt.Rows[i]["Name"].ToString();
                gp.MinZoom = 14;
                gp.Higtlight = true;
                if ((i != 0) && (i != n - 1))
                {
                    gp.IconImage = "Images/BusIcon/DirectionOrder/" + strIcon + i.ToString() + ".png";
                }
                else
                {
                    if (i == n - 1)
                    {
                        gp.IconImage = "Images/BusIcon/DirectionOrder/" + strIcon + "B.png";
                        gp.InfoHTML = "Điểm cuối: " + dt.Rows[i]["Name"].ToString();
                    }
                    else
                    {
                        gp.IconImage = "Images/BusIcon/DirectionOrder/" + strIcon + "A.png";
                        gp.InfoHTML = "Điểm đầu: " + dt.Rows[i]["Name"].ToString();
                        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;
                        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = gp;
                        GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;
                    }
                }
                GoogleMapForASPNet1.GoogleMapObject.Points.Add(gp);
            }
        }
    }

    // thong tin ben do xe Buyt
    public void getInfoBusPark(int idBusPark)
    {
        DataTable dtBusPark = BusBIZ.getInfoBusParkById(idBusPark);
        DataTable dtBusLine = BusBIZ.getBusLineOfBusPark(idBusPark);
        if (dtBusPark != null)
        {
            pnBusPark.Visible = true;
            GoogleMapForASPNet1.GoogleMapObject.Points.Remove("BusPark");
            lbName.Text = dtBusPark.Rows[0]["Name"].ToString();
            lbCoordinate.Text = dtBusPark.Rows[0]["Latitude"].ToString() + " - " + dtBusPark.Rows[0]["Longitude"].ToString();
            lbArea.Text = dtBusPark.Rows[0]["Area"].ToString() + " m2";
            lbDescription.Text = dtBusPark.Rows[0]["Description"].ToString();
            lbAddress.Text = dtBusPark.Rows[0]["Address"].ToString();
            lbBusLine.Text = "";

            if (dtBusLine != null)
            {
                int countBL = dtBusLine.Rows.Count;
                if (countBL != 0)
                {
                    for (int i = 0; i < countBL; i++)
                    {
                        lbBusLine.Text += dtBusLine.Rows[i]["Name"].ToString() + "<br/>";
                    }
                }
            }

            GooglePoint gpBusPark = new GooglePoint("BusPark", Convert.ToDouble(dtBusPark.Rows[0]["Latitude"].ToString()), Convert.ToDouble(dtBusPark.Rows[0]["Longitude"].ToString()));
            gpBusPark.MinZoom = 14;
            gpBusPark.InfoHTML = "<div style='width:300px'><font size='5' color ='Orange'><b><center>" + lbName.Text + "</center></b></font>";
            if (dtBusPark.Rows[0]["Image"].ToString() != "")
            {
                gpBusPark.InfoHTML += "<center><div style='with:300px;height:245px'><img src ='" + dtBusPark.Rows[0]["Image"].ToString() + "'/></div></center>"; ;
            }

            gpBusPark.InfoHTML += "</font> Địa chỉ: " + lbAddress.Text + "</div>"; ;
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(gpBusPark);
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = gpBusPark;
            GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hidLastTab.Value = "1";
        if (drlBusPark.SelectedValue != " ")
        {
            int idBusPark = Convert.ToInt32(drlBusPark.SelectedValue);
            getInfoBusPark(idBusPark);
        }
    }

    protected void btnSearchDirection_Click(object sender, EventArgs e)
    {
        GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Clear();
        GoogleMapForASPNet1.GoogleMapObject.Directions.HideMarkers = false;
        GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(txtStartPoint.Text+", Hà Nội, Việt Nam");
        GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(txtEndPoint.Text+", Hà Nội, Việt Nam");
        GoogleMapForASPNet1.GoogleMapObject.Directions.Locale = "vi_VN";
        GoogleMapForASPNet1.GoogleMapObject.Directions.ShowDirectionInstructions = true;
        hidLastTab.Value = "2";
    }

    protected void btnSearchStreet_Click(object sender, EventArgs e)
    {
        lbBusLineOfStreet.Text = " ";
        DataTable dt = BusBIZ.getBusLineOfStreet(txtStreet.Text.Trim());
        int countBusLine = dt.Rows.Count;
        if (countBusLine != 0)
        {
            lbKetQuaStreet.Visible = false;
            pnlStreet.Visible = true;
            for (int i = 0; i < countBusLine; i++)
            {
                lbBusLineOfStreet.Text += dt.Rows[i]["Name"].ToString() + "<br/>";
            }
        }
        else
        {
            lbKetQuaStreet.Text = "Không có tuyến xe Buýt nào đi qua " + txtStreet.Text;
            pnlStreet.Visible = false;
            lbKetQuaStreet.Visible = true;
        }
        lbStreet.Text = txtStreet.Text.Trim();
        getBusStopOfStreet(txtStreet.Text.Trim());
        hidLastTab.Value = "3";
    }
    
    // lay du lieu ve cac busstop 
    public void getBusStopOfStreet(string nameStreet)
    {
        grvBusList.DataSource = BusBIZ.getBusStopOfStreet(nameStreet);
        grvBusList.DataBind();
    }

    protected void grvBusList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("style", "background-color: #FFFFFF; color: black;");
                e.Row.Attributes.Add("onmouseover", "style.backgroundColor='#FF6600'");
                e.Row.Attributes.Add("onmouseout", "style.backgroundColor='#FFFFFF'");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grvBusList, "Select$" + e.Row.RowIndex);
            }
        }
        catch { }
    }
    protected void grvBusList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = grvBusList.SelectedRow;
            //txtStreet.Text = row.Cells[1].Text;
            string strName = row.Cells[0].Text;
            double strLatitude = Convert.ToDouble(row.Cells[1].Text);
            double strLongitude = Convert.ToDouble(row.Cells[2].Text);
            string strAddress = row.Cells[3].Text;
            GoogleMapForASPNet1.GoogleMapObject.Points.Remove("Street");
            GooglePoint gp = new GooglePoint("Street", strLatitude, strLongitude);
            gp.InfoHTML = "<center><b>" + strName + "</b></center>" + "<br/> Địa chỉ: " + "<i>" + strAddress + "</i>";
            gp.Higtlight = true;
            gp.MinZoom = 14;
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(gp);
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 20;
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = gp;
            GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;
        }
        catch
        {
            Response.Write("<script  type='text/javascript'>alert('Xảy ra lỗi trong thao tác');</script>");
        }
    }
    protected void grvBusList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvBusList.PageIndex = e.NewPageIndex;
        getBusStopOfStreet(lbStreet.Text);
    }
 
    protected void btnSearchTicketPark_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = BusBIZ.getTicketPark(txtDistrict.Text.Trim());
        if (dt.Rows.Count != 0)
        {
            lsTicketPark.DataSource = dt;
            lsTicketPark.DataTextField = "Name";
            lsTicketPark.DataValueField = "IDTicketPark";
            lsTicketPark.DataBind();
            pnlTicket.Visible = true;
            pnlInfoTicket.Visible = false;
            lblKetQua.Visible = false;
        }
        else {
            lblKetQua.Text = "Không có điểm bán vé tháng tại quận này!";
            pnlTicket.Visible = false;
            lblKetQua.Visible = true;
        }
    }
    protected void btnInfoTicket_Click(object sender, EventArgs e)
    {
        try
        {
            //GridViewRow row = grvTicketPark.SelectedRow;
            txtDistrict.Text = lsTicketPark.SelectedItem.Text;
            string strName = lsTicketPark.SelectedItem.Text;
            DataTable dt = BusBIZ.getInfoTicketPark(strName);
            double latitude = Convert.ToDouble(dt.Rows[0]["Latitude"].ToString());
            double longitude = Convert.ToDouble(dt.Rows[0]["Longitude"].ToString());
            string strDescription = dt.Rows[0]["Description"].ToString();
            string strAddress = dt.Rows[0]["Address"].ToString();
            lbTicketName.Text = strName;
            lbLatitudeTicket.Text = latitude.ToString();
            lbLongitudeTicket.Text = longitude.ToString();
            lbDescriptionTicket.Text = strDescription;
            lbAddressTicket.Text = strAddress;
            pnlInfoTicket.Visible = true;
            GoogleMapForASPNet1.GoogleMapObject.Points.Remove("TicketPark");
            GooglePoint gp = new GooglePoint("TicketPark", latitude, longitude);
            gp.InfoHTML = "<center><b>"+strName +"</b></center>"+ "<br/> Địa chỉ: " +"<i>"+ strAddress+"</i>";
            gp.Higtlight = true;
            gp.MinZoom = 14;
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(gp);
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 16;
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = gp;
            GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;
        }
        catch { }
    }

}