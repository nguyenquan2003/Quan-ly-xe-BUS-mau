using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class UI_Map_DeleteTicketPark : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbAdmin.Text = "<font color='orange'>Xin chào</font> " + Session["name"].ToString();
        if (!IsPostBack)
        {
            getTicketPark();
        }
    }

    // get Ticket Park
    public void getTicketPark()
    {
        DataTable dt = BusBIZ.getTicketParkName();
        grvTicketPark.DataSource = dt;
        grvTicketPark.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ArrayList al = new ArrayList();
        try
        {
            for (int i = 0; i < grvTicketPark.Rows.Count; i++)
            {
                GridViewRow row = grvTicketPark.Rows[i];
                CheckBox ck = (CheckBox)row.FindControl("ckDelete");
                if (ck != null && ck.Checked == true)
                {

                    int id = Convert.ToInt32(row.Cells[0].Text);
                    //int strID = Convert.ToInt32(gvSach.Rows[i].Cells[0].Text);
                    al.Add(id);

                }
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        if (al != null)
        {
            foreach (int arridTicketPark in al)
            {
                // delete bus park
                BusBIZ.deleteTicketPark(arridTicketPark);
            }
            lbKetQua.Visible = true;
            lbKetQua.Text = "Đã xóa thành công";
            getTicketPark();
        }
    }
    protected void grvTicketPark_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void grvTicketPark_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTicketPark.PageIndex = e.NewPageIndex;
        getTicketPark();
    }
}