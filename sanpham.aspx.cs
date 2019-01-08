using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    private int id = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["p"] != null && Request.QueryString["id"] != null)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            getTitle();
            this.loadSanPham(Convert.ToInt32(Request.QueryString["p"]));
        }
        else if (Request.QueryString["id"] != null && Request.QueryString["p"] == null)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            getTitle();
            loadSanPham(0);
        }
        else
        {
            Response.Redirect("error.aspx");
        }
    }

    private void loadSanPham(int hide)
    {
        int row = 10;

        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> ds = bs.getSanPhambyIdP(id,row,hide);
        rpsanpham.DataSource = ds;
        rpsanpham.DataBind();

        khuyenmaiBLL km = new khuyenmaiBLL();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbgia = rpsanpham.Items[i].FindControl("lbGia") as Label;
            if (ds[i].khuyenmai == true)
            {
                decimal khm = ds[i].gia - (ds[i].gia * km.getKhuyenMaibyId(1) / 100);
                lbgia.Text = "<span class='price'><span style='color:Red;'><del>" + String.Format("{0:0,0 vnđ}", ds[i].gia) + "</del>&nbsp;&nbsp;&nbsp;</span>" + String.Format("{0:0,0 vnđ}", khm) + "</span>";
            }
            else
            {
                lbgia.Text = "<span class='price'>" + String.Format("{0:0,0 vnđ}", ds[i].gia) + "</span>";
            }
        }

        // phan trang:
        int current = Convert.ToInt32(Request.QueryString["p"]);
        phantrang pt = new phantrang();
        int cou = bs.countP(-1, "", Convert.ToInt32(Request.QueryString["id"]));
        lbPhanTrang.Text = pt.pagingpublic(cou, row, "&id=" + Request.QueryString["id"], current);
    }
    // 
    // lay ten danh muc

    private void getTitle()
    {
        danhmucBLL bs = new danhmucBLL();
        List<danhmucDAL> ds = bs.getDanhMucbyId(id);
        if (ds.Count() == 1)
        {
            lbDanhMuc.Text = ds[0].ten_danhmuc;
            ltite.Text = ds[0].ten_danhmuc;
            lbtitle.Text = ds[0].ten_danhmuc;
        }
        else
        {
            Response.Redirect("error.aspx");
        }


    }
}