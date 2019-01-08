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
            this.loadKM();
        }
        if (Request.QueryString["edit"] == "t")
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


    // lay gia tri khuyen mai

    private void loadKM()
    {
        khuyenmaiBLL bs= new khuyenmaiBLL();
        txtKhuyenMai.Text = bs.getKhuyenMaibyId(1).ToString(); ;
    }


    protected void btnKhuyenMai_Click(object sender, EventArgs e)
    {
        int giatri = Convert.ToInt32(txtKhuyenMai.Text);
        khuyenmaiBLL bs = new khuyenmaiBLL();
        bool tf = bs.edit(giatri,1);
        if (tf == true)
        {
            Response.Redirect("khuyenmai.aspx?edit=t");
        }
        else
        {
            lbError.Text = "<div class='error'> " +
                                             " <div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                            + "	<p>Cập nhật không thành công!</p>"
                                            + "</div>"
                                            + "<div class='bl'></div><div class='br'></div>"
                                        + "</div>";
        }

    }
}