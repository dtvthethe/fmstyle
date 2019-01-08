using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_templateadmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuser"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {

            List<userpublicDAL> us = (List<userpublicDAL>)Session["adminuser"];
            lbHi.Text = "<a href='nguoidungedit.aspx?id="+us[0].id_user+"'>" + us[0].hoten +"</a>";
            lbLog.Text = "Thoát";
            this.lienhe_count();
            this.chuaxuly();

            if (us[0].special == false)
            {
                lbQuangCao.Visible = false;
                lbSlide.Visible = false;
                lbLHT.Visible = false;
                lbLienHe.Visible = false;
                lbLHB.Visible = false;
                lbNguoiDung.Visible = false;
                lbPhuongThuc.Visible = false;
                lbRole.Visible = false;
                lbThongKe.Visible = false;
                lbKhuyenMai.Visible = false;
            }

        }

        this.delSessionView();
    }
    // dem so luong dat hang chua xu ly:
    private void chuaxuly()
    {
        dathangBLL bs = new dathangBLL();
        lbDatHang.Text = bs.dangXuLy().ToString();
    }

    // so luong lien he:
    private void lienhe_count()
    {
        List<userpublicDAL> us = (List<userpublicDAL>)Session["adminuser"];
        lienheviewBLL bs = new lienheviewBLL();
        if (bs.count_lienhe(us[0].id_user) > 0)
        {
            lbLienHe.Visible = true;
            lbLienHe.Text = bs.count_lienhe(us[0].id_user).ToString();
        }
        else
        {
            lbLienHe.Visible = false;
        }
    }
    // xoa session view:

    private void delSessionView()
    {
        string[] file = Request.CurrentExecutionFilePath.Split('/');
        string fileName = file[file.Length - 1];
        if (fileName != "nguoidung.aspx")
        {
            Session.Remove("v");
        }
    }

    private void qtv()
    {

    }

    protected void lbLog_Click(object sender, EventArgs e)
    {
        if (Session["adminuser"] != null)
        {
            Session.Remove("adminuser");
            Response.Redirect("login.aspx");
        }
    }

    // neu la qtv thi hien full chuc nang:


}
