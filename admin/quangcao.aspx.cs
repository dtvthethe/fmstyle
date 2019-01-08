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
        if (Session["adminuser"] != null)
        {
            List<userpublicDAL> us = (List<userpublicDAL>)Session["adminuser"];
            if (us[0].special == false)
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            this.loadadv();
        }
        if (Request.QueryString["add"] == "t")
        {
            lbError.Text = "<div class='success'>"
                                       + "<div class='tl'></div><div class='tr'></div>"
                                       + "<div class='desc'>"
                                           + "<p>Thêm thành công !</p>"
                                       + "</div>"
                                       + "<div class='bl'></div><div class='br'></div>"
                                   + "</div>";
        }
        else if (Request.QueryString["edit"] == "t")
        {
            lbError.Text = "<div class='success'>"
                                           + "<div class='tl'></div><div class='tr'></div>"
                                           + "<div class='desc'>"
                                               + "<p>Sửa thành công !</p>"
                                           + "</div>"
                                           + "<div class='bl'></div><div class='br'></div>"
                                       + "</div>";
        }
        else if (Request.QueryString["up"] == "t")
        {
            lbError.Text = "<div class='success'>"
                                           + "<div class='tl'></div><div class='tr'></div>"
                                           + "<div class='desc'>"
                                               + "<p>Cập nhật thành công !</p>"
                                           + "</div>"
                                           + "<div class='bl'></div><div class='br'></div>"
                                       + "</div>";
        }
    }

    // load adv
    private void loadadv()
    {
        advBLL bs = new advBLL();
        List<advDAL> ds = bs.getAdv();
        rpQC.DataSource = ds;
        rpQC.DataBind();

        for (int i = 0; i < ds.Count; i++)
        {
            CheckBox cbDell = rpQC.Items[i].FindControl("cbDell") as CheckBox;
            Label lbSTT = rpQC.Items[i].FindControl("lbSTT") as Label;
            Label lbTT = rpQC.Items[i].FindControl("lbTT") as Label;
            lbSTT.Text = (i + 1).ToString();
            if (ds[i].trangthai == true)
            {
                lbTT.Text = "Đang hoạt động";
            }
            else
            {
                lbTT.Text = "Đã tắt";
            }
            if (ds[i].trangthai == true)
            {
                cbDell.Enabled = false;
            }

        }
    }
    protected void btnUpDate_Click(object sender, EventArgs e)
    {
        advBLL bs = new advBLL();
        bool check = false;
        bool ttf = false;
        string trangthai = "";
        for (int i = 0; i < rpQC.Items.Count; i++)
        {
            Label lbTT = rpQC.Items[i].FindControl("lbTT") as Label;
            CheckBox cbDell = rpQC.Items[i].FindControl("cbDell") as CheckBox;
            if (cbDell.Checked)
            {
                trangthai += (cbDell.ToolTip + ",");
                // xoa hinh trong file adv:
                string imageFilePath = Server.MapPath("~/adv/" + cbDell.ValidationGroup + "");
                System.IO.File.Delete(imageFilePath);
                check = true;
            }
        }
        if (check == true)
        {
            int le = trangthai.Length - 1;
            string id_adv = trangthai.Remove(le);

            ttf = bs.del(id_adv);
        }

        if (ttf == true)
        {
            Response.Redirect("quangcao.aspx?up=t");
        }
        else
        {
            lbError.Text = "<div class='error'>"
                                           + "<div class='tl'></div><div class='tr'></div>"
                                           + "<div class='desc'>"
                                               + "<p>Cập nhật thất bại !</p>"
                                           + "</div>"
                                           + "<div class='bl'></div><div class='br'></div>"
                                       + "</div>";
        }


    }
}