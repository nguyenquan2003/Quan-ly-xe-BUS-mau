using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_Map_LoginAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (checkLogin() == true)
        {
            Response.Redirect("AdminGPSRealTime.aspx");
        }
    }
    public bool checkLogin()
    {
        return (bool)Session["login"];
    }
    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        string name = txtUserName.Text;
        string pass = txtPass.Text;
        int check = 0;
        check = BusBIZ.checkStatus(name, pass);
        if (check != 0)
        {
            Session["login"] = true;
            Session["name"] = txtUserName.Text;
            Response.Redirect("AdminGPSRealTime.aspx");
        }
        else
        {
            Session["login"] = false;
            Response.Write("<script language='javasript' type='text/javascript'> alert('Bạn nhập không đúng');");
            Response.Write("</script>");
            txtUserName.Text = "";
            txtPass.Text = "";
            txtUserName.Focus();
        }
    }
}