using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_Map_UserManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbAdmin.Text = "<font color='orange'>Xin chào</font> " + Session["name"].ToString();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        int result = BusBIZ.checkUser(txtName.Text.Trim());
        if (result > 0)
        {
            lbThongBao.Text = "Đã tồn tại tên đăng nhập trong cơ sở dữ liệu";
            lbThongBao.Visible = true;
            lbKetQua.Visible = false;
        }
        else
        {
            lbThongBao.Visible = false;
            string name = txtName.Text;
            string pass = txtPass.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            //insert into database
            BusBIZ.insertUser(name, pass, email, phone, address);
            lbKetQua.Text = "Đã thêm mới vào cơ sở dữ liệu";
            lbKetQua.Visible = true;
            
        }
    }
}