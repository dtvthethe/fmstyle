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
      
        if (Session["admindoimk"] == null)
        {
            Response.Redirect("error.aspx");
        }
    }
    private bool doimatkhau(int id)
    {
        bool t = false;
        nguoidungBLL bs = new nguoidungBLL();

        if (txtMK1.Text == txtMK2.Text)
        {
            bool tf = bs.qenMatKhau_doiMatKhau(txtMK2.Text, id);
            t = tf;
        }
        else
        {
            lbError.Text = "<div class='error'>"
                                    + "<div class='tl'></div><div class='tr'></div>"
                                    + "<div class='desc'>"
                                        + "<p>Mật khẩu mới không chính xác !</p>"
                                    + "</div>"
                                    + "<div class='bl'></div><div class='br'></div>"
                                + "</div>";
        }


        return t;
    }
    protected void btnDoiMK_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["admindoimk"]);
        bool tf = doimatkhau(id);
        if (tf == true)
        {
            Response.Redirect("nguoidungedit.aspx?id=" + id + "&edit=t");
        }
    }
}