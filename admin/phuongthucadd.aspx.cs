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
    }
    // them
    private void them()
    {
        bool tf = false;
        phuongthucthanhtoanBLL bs = new phuongthucthanhtoanBLL();
        if (bs.check(txtTen.Text) == false)
        {
            tf = bs.add(txtTen.Text.Trim(), txtTT.Text);

            if (tf == true)
            {
                Response.Redirect("phuongthuc.aspx?add=t");
            }
            else
            {
                lbError.Text = "<div class='error'>"
                                            + "<div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                                + "<p>Thêm phương thức bị lỗi !</p>"
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
    protected void btnThem_Click(object sender, EventArgs e)
    {
        this.them();
    }
}