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
        this.loadDanhMuc();
    }

    // load danh muc:

    private void loadDanhMuc()
    {
        danhmucBLL bs = new danhmucBLL();
        ddlDM.DataSource = bs.getDanhMuclv(2);
        ddlDM.DataTextField = "ten_danhmuc";
        ddlDM.DataValueField = "id_danhmuc";
        ddlDM.DataBind();
    }

    // them :
    private void them()
    {
        string b = "";
        sanphamBLL bs = new sanphamBLL();
        DateTime datet = DateTime.Now;
        string namePic = "";
        string ext = Path.GetExtension(fuPicture.FileName);
        if (fuPicture.HasFile)
        {
            if (CheckFileType(fuPicture.FileName) == true)
            {
                namePic = string.Format("{0:yyyy-M-d-HH-mm-ss}", datet) + ext;
                String filePath = "~/uploads/" + namePic;

                fuPicture.SaveAs(MapPath(filePath));
                lbErrorPic.Text = filePath;
            }
            else
            {
                lbErrorPic.Text = "Hình ảnh phải ở dạng đuôi *.png, *.jpg";
            }
        }
        if (rbYes.Checked == true)
        {
            b = "true";
        }
        else
        {
            b = "false";
        }
        if (bs.check(txtTen.Text) == true)
        {
            lbTen.Text = "Sản phẩm này đã tồn tại.";
        }
        else
        {
            bool tf = bs.add(txtTen.Text.Trim(), Convert.ToInt32(txtSoLuong.Text), namePic, Convert.ToInt32(ddlDM.SelectedValue), txtTT.Text, Convert.ToDecimal(txtGia.Text), b);
            if (tf == true)
            {
                Response.Redirect("sanpham.aspx?add=t");
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
        this.them();
    }
}