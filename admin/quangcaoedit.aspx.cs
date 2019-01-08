using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class admin_Default3 : System.Web.UI.Page
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
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("error.aspx");
        }
        if (!IsPostBack)
        {
            this.loadTT();
        }
    }

    // load thong tin:

    private void loadTT()
    {

        int id = Convert.ToInt32(Request.QueryString["id"]);
        advBLL bs = new advBLL();
        List<advDAL> ds = bs.getAdvById(id);
        txtTen.Text = ds[0].ten;
        txtLink.Text = ds[0].link;

        if (ds[0].hinhanh != "")
        {
            lbHinh.Visible = true;
            btnXoaHinh.Visible = true;
            fileHinh.Visible = false;
            lbErrorPic.Visible = false;

            lbHinh.Text = "<img widt='70px' height='70px' src='../adv/" + ds[0].hinhanh + "' />";
        }
        else
        {
            lbHinh.Visible = false;
            btnXoaHinh.Visible = false;
            fileHinh.Visible = true;
            lbErrorPic.Visible = true;


        }

        if (ds[0].trangthai == true)
        {
            rbYes.Checked = true;
        }
        else
        {
            rbNo.Checked = true;
        }

    }

    // sua :

    private void sua()
    {
        string namePic = "none";
        string tt = "";
        DateTime datet = DateTime.Now;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        advBLL bs = new advBLL();
        List<advDAL> ds = bs.getAdv();
        if (fileHinh.HasFile)
        {
            if (CheckFileType(fileHinh.FileName) == true)
            {
                string ext = Path.GetExtension(fileHinh.FileName);
                namePic = string.Format("{0:yyyy-M-d-HH-mm-ss}", datet) + ext;
                String filePath = "~/adv/" + namePic;

                fileHinh.SaveAs(MapPath(filePath));
                lbErrorPic.Text = filePath;
            }
            else
            {
                lbErrorPic.Text = "Hình ảnh phải ở dạng đuôi *.png, *.jpg";
            }
        }

        if (rbYes.Checked == true)
        {
            tt = "true";
            for (int i = 0; i <= ds.Count-1; i++)
            {
                if (ds[i].trangthai == true)
                {
                    bs.ttPic();
                    break;       
                }
            }

        }
        else if (rbNo.Checked == true)
        {
            tt = "false";
        }

        bool tf = bs.edit(id, txtTen.Text, txtLink.Text, namePic, tt);

        if (tf == true)
        {
            Response.Redirect("quangcao.aspx?edit=t");
        }
        else
        {
            lbError.Text = "<div class='error'>"
                                           + "<div class='tl'></div><div class='tr'></div>"
                                           + "<div class='desc'>"
                                               + "<p>Cập nhật bị lỗi !</p>"
                                           + "</div>"
                                           + "<div class='bl'></div><div class='br'></div>"
                                       + "</div>";
        }
    }

    // kiem tra duoi file:

    private bool CheckFileType(string fileName)
    {

        string ext = Path.GetExtension(fileName);

        switch (ext.ToLower()) // ToLower() : tao chuoi chu~ thuong`
        {

            case ".png":

                return true;

            case ".jpg":

                return true;


            default:

                return false;

        }

    }

    // xoa hinh :

    private void xoaHinh()
    {
        string tt = "";
        int id = Convert.ToInt32(Request.QueryString["id"]);
        advBLL bs = new advBLL();
        List<advDAL> ds = bs.getAdvById(id);
        bool xoa = false;
        // xoa hinh trong file adv:
        string imageFilePath = Server.MapPath("~/adv/" + ds[0].hinhanh + "");
        try
        {
            System.IO.File.Delete(imageFilePath);
            xoa = true;
        }
        catch
        {
            xoa = false;
        }


        if (rbYes.Checked == true)
        {
            tt = "true";
        }
        else if (rbNo.Checked == true)
        {
            tt = "false";
        }
        // xoa hinh trong csdl:
        bool tf = bs.edit(id, txtTen.Text, txtLink.Text, "", tt);

        if (xoa == true && tf == true)
        {
            lbHinh.Visible = false;
            btnXoaHinh.Visible = false;
            fileHinh.Visible = true;
            lbErrorPic.Visible = true;
        }
        else
        {
            lbError.Text = "<div class='error'>"
                                               + "<div class='tl'></div><div class='tr'></div>"
                                               + "<div class='desc'>"
                                                   + "<p>Cập nhật bị lỗi !</p>"
                                               + "</div>"
                                               + "<div class='bl'></div><div class='br'></div>"
                                           + "</div>";
        }

    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        this.sua();
    }
    protected void btnXoaHinh_Click(object sender, EventArgs e)
    {
        this.xoaHinh();
    }
}