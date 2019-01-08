using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuser"] != null)
        {
            Response.Redirect("/admin/");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        roleBLL ro = new roleBLL();
        nguoidungBLL bs = new nguoidungBLL();
        List<nguoidungDAL> list = bs.dangNhap(txtTK.Text, txtMK.Text);
        List<userpublicDAL> user = new List<userpublicDAL>();
        userpublicDAL u = new userpublicDAL();
        
        if (list.Count == 1)
        {
            List<roleDAL> r = ro.getRolebyId(list[0].role);
            if (r[0].truycap_cms == true && r[0].special == false)
            {
                u.id_user = list[0].id_user;
                u.hoten = list[0].hoten;
                u.special = false;
                user.Add(u);
                Session["adminuser"] = user;
                Response.Redirect("/admin/");
            }
            else if (r[0].truycap_cms == true && r[0].special == true)
            {
                u.id_user = list[0].id_user;
                u.hoten = list[0].hoten;
                u.special = true;
                user.Add(u);
                Session["adminuser"] = user;
                Response.Redirect("/admin/");
            }
            else
            {
                lbError.Text = "<div class='notice'>"
                                            + "<div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                                + "<p>Bạn bị giới hạn quyền truy cập !</p>"
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
                                                    + "<p>Sai mật khẩu hoặc tài khoản !</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
        }
    }
}