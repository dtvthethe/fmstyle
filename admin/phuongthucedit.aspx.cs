using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default3 : System.Web.UI.Page
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
            this.loadphuongThuc();
        }
    }

    // hien thi du lieu
    private void loadphuongThuc()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        phuongthucthanhtoanBLL bs = new phuongthucthanhtoanBLL();
        List<phuongthucthanhtoanDAL> ds = bs.getPhuongThucById(id);
        txtTen.Text = ds[0].ten_phuongthuc;
        txtTT.Text = ds[0].chitiet;
    }


    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool tf = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        phuongthucthanhtoanBLL bs = new phuongthucthanhtoanBLL();

        if (bs.check(id, txtTen.Text) == false)
        {
            tf = bs.edit(id, txtTen.Text.Trim(), txtTT.Text);
            if (tf == true)
            {
                Response.Redirect("phuongthuc.aspx?edit=t");
            }
            else
            {
                lbError.Text = "<div class='error'>"
                                                + "<div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                    + "<p>Sửa phương thức bị lỗi!</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
            }
        }
        else
        {
            lbTen.Text = "Tên phương thức này đã được sử dụng.";
        }
        
        
    }
}