using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["v"] != null)
            {
                if (Request.QueryString["v"] == "new")
                {
                    rpbanchay.Visible = false;
                    rpsanpham.Visible = true;
                    this.loadspMoi();
                }
                else if (Request.QueryString["v"] == "km")
                {
                    rpbanchay.Visible = false;
                    rpsanpham.Visible = true;
                    this.loadspKM();
                }
                else if (Request.QueryString["v"] == "bc")
                {
                    rpbanchay.Visible = true;
                    rpsanpham.Visible = false;
                    this.spbanchay(1);
                }
            }
            else
            {
                Response.Redirect("error.aspx");
            }
        }
    }

    // load san pham moi:

    private void loadspMoi()
    {
        lbtitle.Text = "Sản phẩm mới";
        lbDanhMuc.Text = "Sản phẩm mới";
        int hide = 0;

        int row = 10;
        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }
        phantrang pt = new phantrang();
        khuyenmaiBLL km = new khuyenmaiBLL();
        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> ds = bs.getSanPhamP(row, hide, -1, "", -1);
        rpsanpham.DataSource = ds;
        rpsanpham.DataBind();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbGia = rpsanpham.Items[i].FindControl("lbGia") as Label;
            if (ds[i].khuyenmai == true)
            {
                decimal khm = ds[i].gia - (ds[i].gia * km.getKhuyenMaibyId(1) / 100);
                lbGia.Text = "<span class='price'><span style='color:Red;'><del>" + String.Format("{0:0,0 vnđ}", ds[i].gia) + "</del>&nbsp;&nbsp;&nbsp;</span>" + String.Format("{0:0,0 vnđ}", khm) + "</span>";
            }
            else
            {
                lbGia.Text = "<span class='price'>" + String.Format("{0:0,0 vnđ}", ds[i].gia) + "</span>";
            }
        }
        int r = bs.countP(-1, "", -1);
        lbPhanTrang.Text = pt.pagingpublic(r, row, "&v=new", hide);
    }

    // load san pham khuyen mai:
    private void loadspKM()
    {
        lbtitle.Text = "Sản phẩm khuyến mãi";
        lbDanhMuc.Text = "Sản phẩm khuyến mãi";
        int hide = 0;

        int row = 10;
        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }
        phantrang pt = new phantrang();
        khuyenmaiBLL km = new khuyenmaiBLL();
        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> ds = bs.getSanPhamKMP(hide, row);
        rpsanpham.DataSource = ds;
        rpsanpham.DataBind();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbGia = rpsanpham.Items[i].FindControl("lbGia") as Label;
            if (ds[i].khuyenmai == true)
            {
                decimal khm = ds[i].gia - (ds[i].gia * km.getKhuyenMaibyId(1) / 100);
                lbGia.Text = "<span class='price'><span style='color:Red;'><del>" + String.Format("{0:0,0 vnđ}", ds[i].gia) + "</del>&nbsp;&nbsp;&nbsp;</span>" + String.Format("{0:0,0 vnđ}", khm) + "</span>";
            }
            else
            {
                lbGia.Text = "<span class='price'>" + String.Format("{0:0,0 vnđ}", ds[i].gia) + "</span>";
            }
        }
        int r = bs.countKMP();
        lbPhanTrang.Text = pt.pagingpublic(r, row, "&v=km", hide);
    }

    // load san pham ban chay:

    private void spbanchay(int id_khm)
    {
        lbtitle.Text = "Sản phẩm bán chạy";
        lbDanhMuc.Text = "Sản phẩm bán chạy";
        int row = 10;
        int hide =0;
        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }
        phantrang pt = new phantrang();
        khuyenmaiBLL km = new khuyenmaiBLL();
        sanphamBLL spbs = new sanphamBLL();
        dathangdetailBLL bs = new dathangdetailBLL();
        List<dathangdetail> ds = bs.getdathangDetailMuaNhieuP(row, hide);
        rpbanchay.DataSource = ds;
        rpbanchay.DataBind();
        for (int i = 0; i <= ds.Count() - 1; i++)
        {
            Label lbA = rpbanchay.Items[i].FindControl("lbA") as Label;
            Label lbHinh = rpbanchay.Items[i].FindControl("lbHinh") as Label;
            Label lbTen = rpbanchay.Items[i].FindControl("lbTen") as Label;
            Label lbGia = rpbanchay.Items[i].FindControl("lbGia") as Label;
            List<sanphamDAL> sptt = spbs.getSPbyId(ds[i].id_sanpham);
            lbA.Text = "<a href='chitietsanpham.aspx?id=" + sptt[0].id_sanpham + "&gr=" + sptt[0].id_danhmuc + "' title='" + sptt[0].ten_sanpham + "'>";
            lbHinh.Text = "<img class='hinhsp' height='350' width='275' alt='" + sptt[0].ten_sanpham + "' src='/uploads/" + sptt[0].hinhanh + "' style='display: block;' />";
            lbTen.Text = "<span class='productName'>" + sptt[0].ten_sanpham + "</span>";
            if (sptt[0].khuyenmai == true)
            {
                decimal khm = sptt[0].gia - (sptt[0].gia * km.getKhuyenMaibyId(id_khm) / 100);
                lbGia.Text = "<span class='price'><span style='color:Red;'><del>" + String.Format("{0:0,0 vnđ}", sptt[0].gia) + "</del>&nbsp;&nbsp;&nbsp;</span>" + String.Format("{0:0,0 vnđ}", khm) + "</span>";
            }
            else
            {
                lbGia.Text = "<span class='price'>" + String.Format("{0:0,0 vnđ}", sptt[0].gia) + "</span>";
            }
        }
        int r = bs.countMuaNhieuP();
        lbPhanTrang.Text = pt.pagingpublic(r, row, "&v=bc", hide);
    }

}