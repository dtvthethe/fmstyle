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

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        nguoidungBLL bs = new nguoidungBLL();
        int id = bs.quenMatKhau(txtTK.Text,txtEmail.Text);
        if (id > 0)
        {
            Session["quenmatkhau"] = id;
            Response.Redirect("quenmatkhau-matkhaumoi.aspx");

        }
        else {
            lbError.Text = "Tài khoản hoặc email không đúng!";
        }
    }
}