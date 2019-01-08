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
            this.loadtt();
        }
    }

    // load thong tin :

    private void loadtt()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        roleBLL bs = new roleBLL();
        List<roleDAL> list = bs.getRolebyId(id);
        txtTen.Text = list[0].role;
        if (list[0].truycap_cms == true)
        {
            rbYes.Checked = true;
        }
        else if (list[0].truycap_cms == false)
        {
            rbNo.Checked = true;
        }

        if (list[0].special == true)
        {
            rbYess.Checked = true;
        }
        else if (list[0].special == false)
        {
            rbNos.Checked = true;
        }

    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        string b = "";
        string s = "";
        bool tf = false;
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
        int id = Convert.ToInt32(Request.QueryString["id"]);
        roleBLL bs = new roleBLL();
        if (bs.check(txtTen.Text, id) == true)
        {
            lbRole.Text = "Tên này đã được sử dụng.";
        }
        else
        {
            tf = bs.edit(id, txtTen.Text.Trim(), b, s);
            if (tf == true)
            {
                Response.Redirect("role.aspx?edit=t");
            }
            else
            {
                lbError.Text = "<div class='error'>"
                                                + "<div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                    + "<p>Sửa  bị lỗi!</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
            }
        }
    }
}