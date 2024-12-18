using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_Map_BusLineManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbAdmin.Text = "<font color='orange'>Xin chào</font> " + Session["name"].ToString();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string pathName = txtPathName.Text;
        string startTime = txtStartTime.Text;
        string endTime = txtEndTime.Text;
        string pathGo = txtPathGo.Text;
        string pathBack = txtPathBack.Text;
        string descript = txtDescription.Text;
        float cost = float.Parse(txtCost.Text);
        int frequen = Convert.ToInt32(txtFrequence.Text);
        // insert to database
        BusBIZ.insertBusLine(name, startTime, endTime, pathName, pathGo, pathBack, cost, descript, frequen);
        lbKetQua.Text = "Đã thêm tuyến " + name + " vào cơ sở dữ liệu";
        lbKetQua.Visible = true;
    }
}