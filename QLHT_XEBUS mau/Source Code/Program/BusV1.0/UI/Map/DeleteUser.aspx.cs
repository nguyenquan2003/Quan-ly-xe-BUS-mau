using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class UI_Map_DeleteUser : System.Web.UI.Page
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ArrayList al = new ArrayList();
        try
        {
            for (int i = 0; i < grvUser.Rows.Count; i++)
            {
                GridViewRow row = grvUser.Rows[i];
                CheckBox ck = (CheckBox)row.FindControl("ckDelete");
                if (ck != null && ck.Checked == true)
                {

                    string  name = row.Cells[0].Text;
                    //int strID = Convert.ToInt32(gvSach.Rows[i].Cells[0].Text);
                    al.Add(name);

                }
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        if (al != null)
        {
            foreach (string name in al)
            {
                // delete bus park
                BusBIZ.deleteUser(name);
            }
            lbKetQua.Visible = true;
            lbKetQua.Text = "Đã xóa thành công";
            getData();
        }
    }
    protected void grvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUser.PageIndex = e.NewPageIndex;
        getData();
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
            }
        }
        catch { }
    }
}