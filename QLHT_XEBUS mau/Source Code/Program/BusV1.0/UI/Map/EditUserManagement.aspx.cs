using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_Map_EditUserManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbAdmin.Text = "<font color='orange'>Xin chào</font> " + Session["name"].ToString();
        if (!IsPostBack)
        {
            getData();
        }
    }

    // getData
    public void getData()
    {
        DataTable dt = BusBIZ.getUser();
        grvUser.DataSource = dt;
        grvUser.DataBind();
    }
    protected void grvUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("style", "background-color: #FFFFFF; color: black;");
                e.Row.Attributes.Add("onmouseover", "style.backgroundColor='#FF6600'");
                e.Row.Attributes.Add("onmouseout", "style.backgroundColor='#FFFFFF'");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grvUser, "Select$" + e.Row.RowIndex);
            }
        }
        catch { }
    }

    protected void grvUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lbKetQua.Visible = false;
            GridViewRow row = grvUser.SelectedRow;
            string name = Server.HtmlDecode(row.Cells[0].Text);
            string pass = Server.HtmlDecode(row.Cells[1].Text);
            string email = Server.HtmlDecode(row.Cells[2].Text);
            string phone = Server.HtmlDecode(row.Cells[3].Text);
            string address = Server.HtmlDecode(row.Cells[4].Text);
            txtName.Text = name;
            txtPass.Text = pass;
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtAddress.Text = address;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridViewRow row = grvUser.SelectedRow;
        string name = txtName.Text;
        string pass = txtPass.Text;
        string email = txtEmail.Text;
        string phone = txtPhone.Text;
        string address = txtAddress.Text;
        //update user
        BusBIZ.updateUser(name, pass, email, phone, address);
        lbKetQua.Text = "Đã cập nhật thông tin của "+ name+" vào cơ sở dữ liệu";
        lbKetQua.Visible = true;
        getData();
    }
    protected void grvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUser.PageIndex = e.NewPageIndex;
        getData();
    }
}