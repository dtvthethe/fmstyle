using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
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
    }

    // them
    private void add()
    {
        advBLL bs = new advBLL();
        List<advDAL> ds = bs.getAdv();
        string ten = txtTen.Text;
        string link = txtLink.Text;
        string tt = "";
        string namePic = "";

        DateTime datet = DateTime.Now;

        if (rbYes.Checked == true)
        {
            tt = "true";
            for (int i = 0; i <= ds.Count - 1; i++)
            {
                if (ds[i].trangthai == true)
                {
                    bs.ttPic();
                    break;

                }
            }
        }
        else
        {
            tt = "false";
        }

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
        bool tf = bs.add(ten, link, namePic, tt);

        if (tf == true)
        {
            Response.Redirect("quangcao.aspx?add=t");
        }
        else
        {
            lbError.Text = "<div class='error'>"
                                       + "<div class='tl'></div><div class='tr'></div>"
                                       + "<div class='desc'>"
                                           + "<p>Thêm bị lỗi !</p>"
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



    protected void btnLuu_Click(object sender, EventArgs e)
    {
        this.add();
    }
}