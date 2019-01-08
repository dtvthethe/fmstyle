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
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                this.loadDanhMuc();
                this.loadTTSP(id);
            }
            else
            {
                Response.Redirect("error.aspx");
            }
        }
    }

    // load danh muc;
    private void loadDanhMuc()
    {
        danhmucBLL bs = new danhmucBLL();
        ddlDM.DataSource = bs.getDanhMuclv(2);
        ddlDM.DataTextField = "ten_danhmuc";
        ddlDM.DataValueField = "id_danhmuc";
        ddlDM.DataBind();
    }


    // load thong tin san pham:
    private void loadTTSP(int id)
    {
        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> list = bs.getSPbyId(id);
        if (list.Count == 1)
        {

            lbGia.Text = string.Format("{0:0,0 vnđ}", list[0].gia);
            txtGia.Text = list[0].gia.ToString(); ;
            txtSoLuong.Text = list[0].soluong.ToString();
            txtTen.Text = list[0].ten_sanpham;
            txtTT.Text = list[0].tt_chitiet;

            // ddlist:

            ddlDM.SelectedValue = list[0].id_danhmuc.ToString();

            // radio:
            if (list[0].khuyenmai == true)
            {
                rbYes.Checked = true;
            }
            else
            {
                rbNo.Checked = true;
            }

            // hinh anh:
            if (list[0].hinhanh != "")
            {
                lbHinh.Text = "<img width='100' height='100' style='display: block;' src='/uploads/" + list[0].hinhanh + "' alt='" + list[0].ten_sanpham + "'>";
                lbHinh.ToolTip = list[0].hinhanh;
                fuPicture.Visible = false;
                lbErrorPic.Visible = false;
                btnHinhKhac.Visible = true;
            }
            else
            {
                lbHinh.Visible = false;
                fuPicture.Visible = true;
                lbErrorPic.Visible = true;
                btnHinhKhac.Visible = false;
            }

        }
        else
        {
            Response.Redirect("error.aspx");
        }
    }

    // sua :
    private void sua()
    {
        string b = "";
        sanphamBLL bs = new sanphamBLL();
        DateTime datet = DateTime.Now;
        string namePic = lbHinh.ToolTip;
        string ext = Path.GetExtension(fuPicture.FileName);
        
        if (rbYes.Checked == true)
        {
            b = "true";
        }
        else
        {
            b = "false";
        }
        string ten = txtTen.Text.Trim();
        int soluong = Convert.ToInt32(txtSoLuong.Text);
        int idd = Convert.ToInt32(ddlDM.SelectedValue);
        string tt = txtTT.Text;
        decimal gia = Convert.ToDecimal(txtGia.Text);
        int id_sp = Convert.ToInt32(Request.QueryString["id"]);
        if (bs.check(txtTen.Text, id_sp) == true)
        {
            lbTen.Text = "Sản phẩm này đã tồn tại.";
        }
        else
        {
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
            bool tf = bs.edit(ten, soluong, namePic, idd, tt, gia, b, id_sp);
            if (tf == true)
            {
                Response.Redirect("sanpham.aspx?edit=t");
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

    // xoa hinh anh
    private void del_Hinh()
    {
        bool xoa = false;

        // xoa hinh trong thu muc uploads
        int id = Convert.ToInt32(Request.QueryString["id"]);
        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> list = bs.getSPbyId(id);
        string imageFilePath = Server.MapPath("~/uploads/" + list[0].hinhanh + "");
        try
        {
            System.IO.File.Delete(imageFilePath);
            xoa = true;
        }
        catch
        {
            xoa = false;
        }

        // xoa hinh trong csdl:
        bool tf = bs.delHinh("", id);

        if (xoa == true && tf == true)
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Xóa hình thành công !</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
        else
        {
            lbError.Text = "<div class='error'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Xóa hình không thành công!</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.sua();
    }
    protected void btnHinhKhac_Click(object sender, EventArgs e)
    {
        this.del_Hinh();
        lbHinh.Visible = false;
        fuPicture.Visible = true;
        lbErrorPic.Visible = true;
        btnHinhKhac.Visible = false;
    }
}