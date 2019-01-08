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
    protected void btnDangKy_Click(object sender, EventArgs e)
    {

        nguoidungBLL bs = new nguoidungBLL();

        if (bs.uniqueTK(txtTK.Text) == true)
        {
            lbError.Text = "Tài khoản này đã có người sử dụng !";
        }
        else if (bs.uniqueEmail(txtEmail.Text) == true)
        {
            lbError.Text = "Email này đã có người sử dụng !";
        }
        else
        {

            bool tf = bs.dangKy(txtTK.Text, txtMK2.Text, txtHoTen.Text, txtDT.Text, txtDiaChi.Text, txtEmail.Text);
            if (tf == true)
            {
                lbError.Text = "Đăng ký thành công !";
                Response.Redirect("dkthanhcong.aspx");
            }
            else
            {
                lbError.Text = "Đăng ký thất bại !";
            }
        }
    }
}