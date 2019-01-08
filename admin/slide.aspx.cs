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
            this.loadSlide();
        }
        if (Request.QueryString["edit"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                                 " <div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                + "	<p>Cập nhật thành công !</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
        }
        else if (Request.QueryString["add"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                                 " <div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                + "	<p>Thêm thành công !</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
        }
    }

    private void loadSlide()
    {
        slideBLL bs = new slideBLL();
        List<slideDAL> ds = bs.getSlide();
        rpSlide.DataSource = ds;
        rpSlide.DataBind();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbSTT = rpSlide.Items[i].FindControl("lbSTT") as Label;
            Label lbHinh = rpSlide.Items[i].FindControl("lbHinh") as Label;
            lbSTT.Text = (i + 1).ToString();
            lbHinh.Text = "<img src='../slide/" + ds[i].hinhanh + "'  width='300px' height='130px'  />";
        }
    }

    // cap nhat:

    private void capnhat()
    {
        bool edit = false;
        bool del = false;
        bool delcb = false;
        string cb = "";

        slideBLL bs = new slideBLL();
        List<slideDAL> ds = bs.getSlide();
        // cap nhat csdl:
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            TextBox txtLink = rpSlide.Items[i].FindControl("txtLink") as TextBox;
            TextBox txtViTri = rpSlide.Items[i].FindControl("txtViTri") as TextBox;
            edit = bs.edit(txtLink.Text, Convert.ToInt32(txtViTri.Text), ds[i].id_slide);
        }

        // cap nhat hinh anh:
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            CheckBox cbDell = rpSlide.Items[i].FindControl("cbDell") as CheckBox;
            if(cbDell.Checked)
            {
                cb += cbDell.ToolTip+",";
                delcb = true;

                // xoa hinh anh trong file slide:

                string imageFilePath = Server.MapPath("~/slide/" + ds[i].hinhanh + "");
                try
                {
                    System.IO.File.Delete(imageFilePath);
                   
                }
                catch(Exception ex)
                {
                    throw (ex);
                }
            }
        }

        
        if (delcb == true)
        {
            int le = cb.Length - 1;
            string id_slide = cb.Remove(le);
            bs.del(id_slide);
        }

        if (edit == true)
        {
            Response.Redirect("slide.aspx?edit=t");
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
    protected void btnUpDate_Click(object sender, EventArgs e)
    {
        this.capnhat();
    }
}