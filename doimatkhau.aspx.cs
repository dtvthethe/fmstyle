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
        if (Session["userpublic"] == null)
        {
            Response.Redirect("/");
        }
    }
    protected void btndoimatkhau_Click(object sender, EventArgs e)
    {
        nguoidungBLL bs = new nguoidungBLL();
        List<userpublicDAL> ds = (List<userpublicDAL>)Session["userpublic"];

        if (bs.xacthuc(txtmk.Text, ds[0].id_user) == true)
        {
            bool tf = bs.qenMatKhau_doiMatKhau(txtmk2.Text, ds[0].id_user);

            if (tf == true)
            {
                lbError.Text = "Đổi mật khẩu thành công !";
                txtmk.Text = "";
                txtmk1.Text = "";
                txtmk2.Text = "";
            }
            else
            {
                lbError.Text = "Đổi mật khẩu thất bại !";
            }
        }
        else
        {
            lbError.Text = "Mật khẩu cũ không chính xác !";
        }
        
        
    }
}