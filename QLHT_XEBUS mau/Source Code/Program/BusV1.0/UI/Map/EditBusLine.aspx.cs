using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_Map_EditBusLine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbAdmin.Text = "<font color='orange'>Xin chào</font> " + Session["name"].ToString();
        if (!IsPostBack)
        {
            getData();
        }
    }

    // get bus line
    public void getData()
    {
        DataTable dt = new DataTable();
        dt = BusBIZ.getBusLineName();
        drlBusLine.DataSource = dt;
        drlBusLine.DataTextField = "Name";
        drlBusLine.DataValueField = "IDBusLine";
        drlBusLine.DataBind();
        drlBusLine.Items.Insert(0," ");
    }
    protected void drlBusLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drlBusLine.SelectedValue.Trim()!="")
        {
            int idBusLine = Convert.ToInt32(drlBusLine.SelectedValue);
            DataTable dt = BusBIZ.getInfoBusLineById(idBusLine);
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtStartTime.Text = dt.Rows[0]["StartTime"].ToString();
            txtEndTime.Text = dt.Rows[0]["EndTime"].ToString();
            txtPathName.Text = dt.Rows[0]["PathName"].ToString();
            txtPathGo.Text = dt.Rows[0]["PathGo"].ToString();
            txtPathBack.Text = dt.Rows[0]["PathBack"].ToString();
            txtCost.Text = dt.Rows[0]["Cost"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            txtFrequence.Text = dt.Rows[0]["Frequence"].ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (drlBusLine.SelectedValue.Trim() != "")
        {
            int idBusLine = Convert.ToInt32(drlBusLine.SelectedValue);
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
            BusBIZ.updateBusLine(idBusLine, name, startTime, endTime, pathName, pathGo, pathBack, cost, descript, frequen);
            lbKetQua.Text = "Đã cập nhật tuyến " + name + " vào cơ sở dữ liệu";
            lbKetQua.Visible = true;
            getData();
            drlBusLine.SelectedValue = idBusLine.ToString();
        }
        else
            lbKetQua.Visible = false;
    }
}