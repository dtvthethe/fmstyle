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
       
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "")
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                this.loadRole();
                this.loadNguoiDung(id);
            }
            if (Request.QueryString["edit"] == "t")
            {
                lbError.Text = "<div class='success'> " +
                                             " <div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                            + "	<p>Đổi mật khẩu thành công!</p>"
                                            + "</div>"
                                            + "<div class='bl'></div><div class='br'></div>"
                                        + "</div>";
            }
            Session.Remove("admindoimk");
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
    // load thoong tin nguoi dung:

    private void loadNguoiDung(int id)
    {
        nguoidungBLL bs = new nguoidungBLL();
        List<nguoidungDAL> ds = bs.getNguoiDungbyId(id);
        if (ds.Count == 1)
        {
            txtDiaChi.Text = ds[0].diachi;
            txtEmail.Text = ds[0].email;
            txtHoTen.Text = ds[0].hoten;
            txtSDT.Text = ds[0].sdt;
            ddlRole.SelectedValue = ds[0].role.ToString();
            lbTK.Text = ds[0].username;
        }
        else
        {
            Response.Redirect("error.aspx");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        nguoidungBLL bs = new nguoidungBLL();
        bool tf = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        if (bs.uniqueEmailtt(txtEmail.Text, id) == true)
        {
            lbEmail.Text = "Địa chỉ email này đã có người sử dụng.";
        }
        else
        {
            tf = bs.suanguoidung(id, txtHoTen.Text.Trim(), txtSDT.Text, txtDiaChi.Text, Convert.ToInt32(ddlRole.SelectedValue), txtEmail.Text);
            if (tf == true)
            {
                Response.Redirect("nguoidung.aspx?edit=t");
            }
            else
            {
                lbError.Text = "<div class='error'> " +
                                                 " <div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                + "	<p>Sửa người dùng không thành công!</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
            }
        }
    }
    protected void btnDoiMK_Click(object sender, EventArgs e)
    {
        Session["admindoimk"] = Request.QueryString["id"];
        Response.Redirect("nguoidungdoimk.aspx");
    }
}