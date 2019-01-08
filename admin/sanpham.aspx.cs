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
        if (!IsPostBack)
        {
            this.loaddanhmuc();
            int danhmuc = -1;
            string noidung = "";
            int view = -1;
            if (Request.QueryString["v"] != null)
            {
                view = Convert.ToInt32(Request.QueryString["v"]);
                ddlView.Text = Request.QueryString["val"];
            }
            else if (Request.QueryString["t"] != null && Request.QueryString["n"] != null)
            {
                danhmuc = Convert.ToInt32(Request.QueryString["t"]);
                noidung = Request.QueryString["n"];
                ddlTimKiem.Text = Request.QueryString["val"];
                txtTimKiem.Text = Request.QueryString["n"];
            }

            this.loadsp(danhmuc, noidung, view);
        }

        if (Request.QueryString["add"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Thêm sản phẩm thành công!</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
        else if (Request.QueryString["edit"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Sửa sản phẩm thành công!</p>"
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
    private void loadsp(int danhmuc, string noidung, int view)
    {
        int row = 10;
        int hide = 0;
        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }

        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> ds = bs.getSanPhamP(row, hide, danhmuc, noidung, view);
        rpSanpham.DataSource = ds;
        rpSanpham.DataBind();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbSTT = rpSanpham.Items[i].FindControl("lbSTT") as Label;
            DropDownList ddKuyenMai = rpSanpham.Items[i].FindControl("ddKuyenMai") as DropDownList;
            lbSTT.Text += (i + 1 + hide).ToString();
            if (ds[i].khuyenmai == true)
            {
                ddKuyenMai.SelectedValue = "1";
            }
            else
            {
                ddKuyenMai.SelectedValue = "0";
            }
        }
        string pa = "";
        if (view != -1)
        {
            pa = "&v=" + view + "&val=" + Request.QueryString["val"].ToString();
        }
        else if (danhmuc != -1 && noidung != "")
        {
            pa = "&t=" + danhmuc + "&n=" + noidung + "&val=" + Request.QueryString["val"].ToString();
        }
        // phan trang:
        int current = Convert.ToInt32(Request.QueryString["p"]);
        phantrang pt = new phantrang();
        lbPage.Text = pt.paging(bs.countP(danhmuc, noidung, view), row, pa, current);
    }


    // load danh muc san pham()
    private void loaddanhmuc()
    {
        danhmucBLL bs = new danhmucBLL();
        List<danhmucDAL> list = bs.getDanhMucTimKiem();
        ddlTimKiem.Items.Add("Tất cả");
        ddlView.Items.Add("Tất cả");
        for (int i = 0; i <= list.Count - 1; i++)
        {
            ddlTimKiem.Items.Add(list[i].ten_danhmuc);
            ddlView.Items.Add(list[i].ten_danhmuc);
        }
    }
    protected void ddlView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlView.Text != "Tất cả")
        {
            danhmucBLL b = new danhmucBLL();
            int id = b.getIdDanhMucbyName(ddlView.Text);
            Response.Redirect("sanpham.aspx?v=" + id + "&val=" + ddlView.Text);
        }

    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        if (ddlTimKiem.Text == "Tất cả")
        {
            danhmucBLL b = new danhmucBLL();
            Response.Redirect("sanpham.aspx?t=" + 0 + "&n=" + txtTimKiem.Text + "&val=" + ddlTimKiem.Text);
        }
        else
        {
            danhmucBLL b = new danhmucBLL();
            int id = b.getIdDanhMucbyName(ddlTimKiem.Text);
            Response.Redirect("sanpham.aspx?t=" + id + "&n=" + txtTimKiem.Text + "&val=" + ddlTimKiem.Text);
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        bool tf = false;
        bool check = false;
        sanphamBLL bs = new sanphamBLL();
        //cap nhat san pham khuyen mai:
        for (int i = 0; i <= rpSanpham.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpSanpham.Items[i].FindControl("cbDell") as CheckBox;
            DropDownList ddKuyenMai = rpSanpham.Items[i].FindControl("ddKuyenMai") as DropDownList;
            if (ddKuyenMai.SelectedValue == "0")
            {
                tf = bs.suaKhuyenMai("false", Convert.ToInt32(cbDell.ToolTip));
            }
            else
            {
                tf = bs.suaKhuyenMai("true", Convert.ToInt32(cbDell.ToolTip));
            }
        }
        string id = "";
        int lengh = 0;
        // xoa  san pham:
        for (int i = 0; i <= rpSanpham.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpSanpham.Items[i].FindControl("cbDell") as CheckBox;
            DropDownList ddKuyenMai = rpSanpham.Items[i].FindControl("ddKuyenMai") as DropDownList;
            if (cbDell.Checked)
            {
                //tf = bs.del(Convert.ToInt32(cbDell.ToolTip));

                string imageFilePath = Server.MapPath("~/uploads/" + ddKuyenMai.ValidationGroup + "");
                try
                {
                    System.IO.File.Delete(imageFilePath);
                    tf = true;
                }
                catch
                {
                    tf = false;
                }
                id += cbDell.ToolTip + ",";
                lengh = id.Length;
                check = true;

            }


        }




        if (check == true)
        {
            string hid = id.Remove(lengh - 1);
            tf = bs.del(hid);
            
        }

        if (tf == false)
        {
            lbError.Text = "<div class='error'> " +
                                             " <div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                            + "	<p>Cập nhật thất bại!</p>"
                                            + "</div>"
                                            + "<div class='bl'></div><div class='br'></div>"
                                        + "</div>";

        }
        else
        {

            Response.Redirect("sanpham.aspx?up=t");
        }

    }
}