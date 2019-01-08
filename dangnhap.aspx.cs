using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userpublic"] != null)
        {
            Response.Redirect("/");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string tk = txtUserName.Text;
        string mk = txtPassWord.Text;
        nguoidungBLL dn = new nguoidungBLL();
        List<nguoidungDAL> ds = dn.dangNhap(tk, mk);
        List<userpublicDAL> usp = new List<userpublicDAL>();
        if (ds.Count == 1)
        {
            userpublicDAL us = new userpublicDAL();
            us.id_user = ds[0].id_user;
            us.username = ds[0].username;
            us.hoten = ds[0].hoten;
            us.sdt = ds[0].sdt;
            us.diachi = ds[0].diachi;
            us.role = ds[0].role;
            us.email = ds[0].email;

            usp.Add(us);
            Session["userpublic"] = usp;
            Response.Redirect("/");
        }
        else
        {
            lbResult.Text = "Sai tài khoản hoặc mật khẩu!";
        }
    }
}