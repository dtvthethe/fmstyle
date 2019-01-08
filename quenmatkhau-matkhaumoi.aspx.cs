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
        if (Session["quenmatkhau"] == null)
        {
            Response.Redirect("/");
           
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        nguoidungBLL bs = new nguoidungBLL();
        int id = Convert.ToInt32(Session["quenmatkhau"]);
        bool tf = bs.qenMatKhau_doiMatKhau(txtmk1.Text, Convert.ToInt32(txtmk2.Text));
        if (tf == true)
        {
            lbError.Text = "Đổi mật khẩu thành công !";
            Session.Remove("quenmatkhau");
        }
        else
        {
            lbError.Text = "Đổi mật khẩu thất bại !";
            
        }
    }
}