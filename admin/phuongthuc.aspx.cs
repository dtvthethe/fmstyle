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
            this.loadPhuonThuc();
        }
        
        if (Request.QueryString["add"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Thêm phương thức thành công!</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
        else if (Request.QueryString["edit"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Sửa phương thức thành công!</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
        else if (Request.QueryString["up"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                             " <div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                            + "	<p>Cập nhật thành công!</p>"
                                            + "</div>"
                                            + "<div class='bl'></div><div class='br'></div>"
                                        + "</div>";
        }
    }
    private void loadPhuonThuc()
    {
        phuongthucthanhtoanBLL bs = new phuongthucthanhtoanBLL();
        rpPhuongThuc.DataSource = bs.getPhuongThuc();
        rpPhuongThuc.DataBind();
    }
    protected void btnUpDate_Click(object sender, EventArgs e)
    {
        phuongthucthanhtoanBLL bs = new phuongthucthanhtoanBLL();

        string id = "";
        int lengh = 0;
        bool tf = false;
        bool check = false;
        for (int i = 0; i <= rpPhuongThuc.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpPhuongThuc.Items[i].FindControl("cbDell") as CheckBox;

            if (cbDell.Checked)
            {
                id += cbDell.ToolTip + ",";
                check = true;
            }
        }
        lengh = id.Length;
        
        if (check == true)
        {
            string hid = id.Remove(lengh - 1);
            tf = bs.del(hid);
            if (tf == true)
            {

                Response.Redirect("phuongthuc.aspx?up=t");
            }
            else
            {
                lbError.Text = "<div class='error'> " +
                                                 " <div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                + "	<p>Cập nhật thất bại!</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
            }
        }
        
    }
}