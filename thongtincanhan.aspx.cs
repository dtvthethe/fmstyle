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
        if (!IsPostBack)
        {
            if (Session["userpublic"] != null)
            {
                List<userpublicDAL> list = (List<userpublicDAL>)Session["userpublic"];

                lbTK.Text = list[0].username;
                txtHoTen.Text = list[0].hoten;
                txtSDT.Text = list[0].sdt;
                txtDiaChi.Text = list[0].diachi;
                txtEmail.Text = list[0].email;
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        List<userpublicDAL> list = (List<userpublicDAL>)Session["userpublic"];
        nguoidungBLL bs = new nguoidungBLL();
        bool tf = bs.updateTTcaNhan(list[0].id_user, txtHoTen.Text, txtSDT.Text, txtDiaChi.Text, txtEmail.Text);
        if (tf == true)
        {
            lbError.Text = "Cập nhật thông tin thành công!";
            list[0].hoten = txtHoTen.Text;
            list[0].sdt = txtSDT.Text;
            list[0].diachi = txtDiaChi.Text;
            list[0].email = txtEmail.Text;

        }
        else
        {
            lbError.Text = "Có lỗi xảy ra!";
        }
    }
}