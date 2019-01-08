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
            this.loadRole();
        }
    }

    // load role:
    private void loadRole()
    {
        roleBLL bs = new roleBLL();
        ddlRole.DataSource = bs.getRole();
        ddlRole.DataTextField = "role";
        ddlRole.DataValueField = "id_role";
        ddlRole.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        nguoidungBLL bs = new nguoidungBLL();
        if (bs.uniqueTK(txtTK.Text) == true)
        {
            lbTK.Text = "Tài khoản này đã có người sử dụng.";
        }
        else if (bs.uniqueEmail(txtEmail.Text) == true)
        {
            lbEmail.Text = "Email này đã có người sử dụng.";
        }
        else if (txtMK1.Text == txtMK2.Text)
        {
            bool tf = bs.add(txtTK.Text.Trim(), txtMK2.Text, txtHoTen.Text, txtSDT.Text, txtDiaChi.Text, txtEmail.Text, Convert.ToInt32(ddlRole.SelectedValue));
            if (tf == true)
            {
                Response.Redirect("nguoidung.aspx?add=t");
            }
            else
            {
                lbError.Text = "<div class='error'>"
                                                + "<div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                    + "<p>Thêm người dùng bị lỗi !</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
            }
        }
        else
        {
            lbError.Text = "<div class='error'>"
                                            + "<div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                                + "<p>Mật khẩu không chính xác !</p>"
                                            + "</div>"
                                            + "<div class='bl'></div><div class='br'></div>"
                                        + "</div>";
        }
    }
}