using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuser"] != null)
        {
            List<userpublicDAL> us = (List<userpublicDAL>)Session["adminuser"];
            if (us[0].special == false)
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            this.ttChitiet();
            this.view();
        }


    }
    // load thong tin
    private void ttChitiet()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        lienheBLL bs = new lienheBLL();
        List<lienheDAL> ds = bs.getLienHebyId(id);
        lbEmail.Text = ds[0].email;
        lbHoTen.Text = ds[0].hoten;
        lbNgayGui.Text = ds[0].ngaygui.ToString();
        lbNoidung.Text = ds[0].noidung;
        lbSDT.Text = ds[0].sdt;

    }

    // 
    private void view()
    {
        lienheviewBLL bs = new lienheviewBLL();
        int id = Convert.ToInt32(Request.QueryString["id"]);
        List<userpublicDAL> list = (List<userpublicDAL>)Session["adminuser"];
        if (bs.checkView(id, list[0].id_user) == true)
        {
            bs.lienheadd(id, list[0].id_user);
        }
    }
}