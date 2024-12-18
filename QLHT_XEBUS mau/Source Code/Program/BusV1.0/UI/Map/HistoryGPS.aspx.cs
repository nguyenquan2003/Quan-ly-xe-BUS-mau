using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;

public partial class UI_Map_HistoryGPS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lbAdmin.Text = "<font color='orange'>Xin chào</font> " + Session["name"].ToString();
        if (!IsPostBack)
        {
            for (int i = 1; i <= 31; i++)
            {
                drlStartDate.Items.Add(i.ToString());
                drlEndDate.Items.Add(i.ToString());
            }
            for (int i = 1; i <=12; i++)
            {
                drlStartMonth.Items.Add(i.ToString());
                drlEndMonth.Items.Add(i.ToString());
            }
            for (int i = 2010; i <= 2015; i++)
            {
                drlStartYear.Items.Add(i.ToString());
                drlEndYear.Items.Add(i.ToString());
            }

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
    public int SoNgay(int thang)
    {
        int songay = 0;
        switch (thang)
        {

            case 4:
            case 6:
            case 9:
            case 11:
                songay = 30;
                break;
            case 2:
                songay = 28;
                break;
            default:
                songay = 31;
                break;

        }
        return songay;
    }
    protected bool KiemTra(int nam, int thang, int ngay)
    {
        int songay;
        if ((nam % 4) == 0)
        {
            if (((nam % 100) == 0) && ((nam % 400) != 0))
                songay = SoNgay(thang);
            else
            {
                if (thang == 2)
                    songay = 29;
                else
                    songay = SoNgay(thang);

            }
        }
        else
            songay = SoNgay(thang);
        if (songay < ngay)
            return false;
        else
            return true;
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
        if (drlBusLine.SelectedValue != " ")
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
    protected void btnHistory_Click(object sender, EventArgs e)
    {
        int startYear = Convert.ToInt32(drlStartYear.SelectedItem.Value.ToString());
        int startMonth = Convert.ToInt32(drlStartMonth.SelectedItem.Value.ToString());
        int startDate = Convert.ToInt32(drlStartDate.SelectedItem.Value.ToString());
        int endYear = Convert.ToInt32(drlEndYear.SelectedItem.Value.ToString());
        int endMonth = Convert.ToInt32(drlEndMonth.SelectedItem.Value.ToString());
        int endDate = Convert.ToInt32(drlEndDate.SelectedItem.Value.ToString());
        if (txtEndHour.Text.Trim()=="")
        {
            txtEndHour.Text = "0";
            
        }
        if (txtEndMinute.Text.Trim()=="")
        {
            txtEndMinute.Text = "0";
        }
        if (txtEndSecond.Text.Trim()=="")
        {
            txtEndSecond.Text = "0";
        }
        if (txtStartHour.Text.Trim()=="")
	    {
		    txtStartHour.Text = "0";
	    }
        if (txtStartMinute.Text.Trim()=="")
	    {
		    txtStartMinute.Text="0";
	    }
        if (txtStartSecond.Text.Trim()=="")
	    {
		     txtStartSecond.Text="0";
	    }

        int startHour = Convert.ToInt32(txtStartHour.Text);
        int startMinute = Convert.ToInt32(txtStartMinute.Text);
        int startSecond = Convert.ToInt32(txtStartSecond.Text);
        int endHour = Convert.ToInt32(txtEndHour.Text);
        int endMinute = Convert.ToInt32(txtEndMinute.Text);
        int endSecond = Convert.ToInt32(txtEndSecond.Text);
        if (startHour >= 24)
        {
            lbStarHour.Visible = true;
        }
        else
        {
            lbStarHour.Visible = false;
            if (startMinute >= 60)
            {
                lbStartMinute.Visible = true;
            }
            else
            {
                lbStartMinute.Visible = false;

                if (startSecond >= 60)
                {
                    lbStartSecond.Visible = true;
                }
                else
                {
                    lbStartSecond.Visible = false;
                    if (endHour >= 24)
                    {
                        lbEndHour.Visible = true;
                    }
                    else
                    {
                        lbEndHour.Visible = false;
                        if (endMinute >= 60)
                        {
                            lbEndMinute.Visible = true;
                        }
                        else
                        {
                            lbEndMinute.Visible = false;
                            if (endSecond >= 60)
                            {
                                lbEndsecond.Visible = true;
                            }
                            else {
                                lbEndsecond.Visible = false;

                            }
                        }
                    }
                }
            }
        }
        if ((startHour <24)&&(startMinute<60)&&(startSecond<60)&&(endHour<24)&&(endMinute<60)&&(endSecond<60))
        {
            lbStarHour.Visible = false;
            lbStartMinute.Visible = false;
            lbStartSecond.Visible = false;
            lbEndHour.Visible = false;
            lbEndMinute.Visible = false;
            lbEndsecond.Visible = false;

            if (KiemTra(startYear, startMonth, startDate) != true)
            {
                lbHienThiStart.Visible = true;
            }
            else
            {
                if (KiemTra(endYear, endMonth, endDate) != true)
                {
                    lbHienThiEnd.Visible = false;
                }
                else
                {
                    lbHienThiEnd.Visible = false;
                    lbHienThiStart.Visible = false;
                    DateTime dt1 = new DateTime(startYear, startMonth, startDate, startHour, startMinute, startSecond);
                    DateTime dt2 = new DateTime(endYear, endMonth, endDate, endHour, endMinute, endSecond);
                    if (dt2 <= dt1)
                    {
                        lbDate.Text = "Ngay ket thuc truoc ngay bat dau, de nghi chon lai";
                        lbDate.Visible = true;
                    }
                    else
                    {
                        lbDate.Text = drlBus.SelectedValue+"%"+dt1.ToString()+"%"+dt2.ToString();
                        lbDate.Visible = false;
                        if (drlBus.SelectedValue.Trim() != "")
                        {
                            string idBus = drlBus.SelectedValue;
                            getGPSHistory(idBus, dt1, dt2);
                            for (int i = 0; i < 1000; i++)
                            {
                                GoogleMapForASPNet1.GoogleMapObject.Points.Remove("GPS"+i.ToString());
                            }
                        }
                    }

                    //Label1.Text = dt1.ToString() + DateTime.Now.ToString();
                }
            }
       
        }
    }
 
    protected void grvGPSHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("style", "background-color: #FFFFFF; color: black;");
                e.Row.Attributes.Add("onmouseover", "style.backgroundColor='#FF6600'");
                e.Row.Attributes.Add("onmouseout", "style.backgroundColor='#FFFFFF'");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grvGPSHistory, "Select$" + e.Row.RowIndex);
            }
        }
        catch { }
    }
    protected void grvGPSHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGPSHistory.PageIndex = e.NewPageIndex;
        getGPSHistory(lbDate.Text.Split('%')[0], Convert.ToDateTime(lbDate.Text.Split('%')[1]), Convert.ToDateTime(lbDate.Text.Split('%')[2]));
    }

    // get gps History
    public void getGPSHistory(string strBus, DateTime dt1, DateTime dt2)
    {
        DataTable dt = new DataTable();
        dt = BusBIZ.getGPSHistory(strBus, dt1, dt2);
        grvGPSHistory.DataSource = dt;
        grvGPSHistory.DataBind();
        if (dt.Rows.Count != 0)
        {
            lbCount.Text = dt.Rows.Count.ToString();
            btnAllHistory.Visible = true;
        }
        else
        {
            lbCount.Text = "0";
            btnAllHistory.Visible = false;
        }
    }

    public DataTable getTB(string strBus, DateTime dt1, DateTime dt2)
    {
         DataTable dt = new DataTable();
         dt = BusBIZ.getGPSHistory(strBus, dt1, dt2);
         return dt;
    }
    protected void grvGPSHistory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = grvGPSHistory.SelectedRow;
            //txtStreet.Text = row.Cells[1].Text;
            string strName = row.Cells[0].Text;
            double strLatitude = Convert.ToDouble(row.Cells[1].Text);
            double strLongitude = Convert.ToDouble(row.Cells[2].Text);
            string strSpeed = row.Cells[3].Text;
            GoogleMapForASPNet1.GoogleMapObject.Points.Remove("GPS");
            GooglePoint gp = new GooglePoint("GPS", strLatitude, strLongitude);
            gp.InfoHTML = "Vĩ độ: <b>" + strLatitude + "</b><br/>Kinh độ: <b>"+strLongitude+"</b>" + "<br/> Tốc độ: " + "<i>" + strSpeed + "</i> km/h <br/> Thời gian: "+strName;
            gp.IconImage = "Images/BusIcon/icong.png";
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
    protected void btnAllHistory_click(object sender, EventArgs e)
    {
        int n = grvGPSHistory.Rows.Count;
        for (int i = 0; i < n; i++)
        {
            string strTime = grvGPSHistory.Rows[i].Cells[0].Text;
            double strLatitude = Convert.ToDouble(grvGPSHistory.Rows[i].Cells[1].Text);
            double strLongitude = Convert.ToDouble(grvGPSHistory.Rows[i].Cells[2].Text);
            string strSpeed = grvGPSHistory.Rows[i].Cells[3].Text;
            GoogleMapForASPNet1.GoogleMapObject.Points.Remove("GPS");
            GooglePoint gp = new GooglePoint("GPS"+i.ToString(), strLatitude, strLongitude);
            gp.InfoHTML = "Vĩ độ: <b>" + strLatitude + "</b><br/>Kinh độ: <b>"+strLongitude+"</b>" + "<br/> Tốc độ: " + "<i>" + strSpeed + "</i> km/h <br/> Thời gian: "+strTime;
            
            gp.MinZoom = 16;
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(gp);
        }
    }
}