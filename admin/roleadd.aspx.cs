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
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool tf = false;
        string b = "";
        string s = "";
        if (rbYes.Checked == true)
        {
            b = "true";
        }
        else if (rbNo.Checked == true)
        {
            b = "false";
        }
        if (rbYess.Checked == true)
        {
            s = "true";
        }
        else if (rbNos.Checked == true)
        {
            s = "false";
        }
        roleBLL bs = new roleBLL();

        if (bs.check(txtTen.Text) == true)
        {
            lbRole.Text = "Tên này đã được sử dung.";
        }
        else
        {
            tf = bs.add(txtTen.Text.Trim(), b, s);
            if (tf == true)
            {
                Response.Redirect("role.aspx?add=t");
            }
            else
            {
                lbError.Text = "<div class='error'>"
                                            + "<div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                                + "<p>Thêm bị lỗi !</p>"
                                            + "</div>"
                                            + "<div class='bl'></div><div class='br'></div>"
                                        + "</div>";
            }
        }
    }
}