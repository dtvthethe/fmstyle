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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string namePic = "";
        slideBLL bs = new slideBLL();
        DateTime datet = DateTime.Now;

        // upload hinh:
        if (filePic.HasFile)
        {
            string ext = Path.GetExtension(filePic.FileName);
            if (CheckFileType(filePic.FileName) == true)
            {
                namePic = string.Format("{0:yyyy-M-d-HH-mm-ss}", datet) + ext;
                String filePath = "~/slide/" + namePic;

                filePic.SaveAs(MapPath(filePath));
                lbErrorPic.Text = filePath;
            }
            else
            {
                lbErrorPic.Text = "Hình ảnh phải ở dạng đuôi *.png, *.jpg";
            }
        }

        // them vao csdl:
        bool tf = bs.add(namePic, txtLink.Text, Convert.ToInt32(txtViTri.Text));

        if (tf == true)
        {
            Response.Redirect("slide.aspx?add=t");
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
}