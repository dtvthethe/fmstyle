using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.load10spmoi();
        this.load10muanhieu(1);
        this.load10kmai();
        this.slide();
        this.quangcao();
    }

    // load 10 sanpham moi nhat
    private void load10spmoi()
    {
        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> ds = bs.getSanPhamMoi();
        spmoi.DataSource = ds;
        spmoi.DataBind();

        khuyenmaiBLL km = new khuyenmaiBLL();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbgia = spmoi.Items[i].FindControl("lbGia") as Label;
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

    }

    // load 10 sanpham khuyenmai
    private void load10kmai()
    {
        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> ds = bs.getSanPhamKhuyenMai();
        rpkhuyenmai.DataSource = ds;
        rpkhuyenmai.DataBind();

        khuyenmaiBLL km = new khuyenmaiBLL();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbgia = rpkhuyenmai.Items[i].FindControl("lbGia") as Label;
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

    }

    // load slide:

    private void slide()
    {
        slideBLL bs = new slideBLL();
        rpSLIDE.DataSource = bs.getSlidePublic();
        rpSLIDE.DataBind();
    }

    // load hinh quangcao:

    private void quangcao()
    {
        //<a style='height: 100%; width: 100%' href='google.com.vn' title='adv'>
        //<img class="adv_img" src="/images/public/adv.png" alt="adv"></img>
        //</a>
        advBLL bs = new advBLL();
        List<advDAL> ds = bs.getAdvPubLic();
        lbHinhADV.Text = "<a href='" + ds[0].link + "' title='" + ds[0].ten + "'>"
            + "<img style='height: 100%; width: 233px' src='../adv/" + ds[0].hinhanh + "' alt='Sản phẩm mới'></img>"
            + "</a>";
    }

    // san pham mua nhieu

    private void load10muanhieu(int id_khm)
    {
        khuyenmaiBLL km = new khuyenmaiBLL();
        sanphamBLL spbs = new sanphamBLL();
        dathangdetailBLL bs = new dathangdetailBLL();
        List<dathangdetail> ds = bs.getdathangDetailMuaNhieuPubLic();
        rpbanchay.DataSource = ds;
        rpbanchay.DataBind();
        for (int i = 0; i <= ds.Count() - 1; i++)
        {
            Label lbA = rpbanchay.Items[i].FindControl("lbA") as Label;
            Label lbHinh = rpbanchay.Items[i].FindControl("lbHinh") as Label;
            Label lbTen = rpbanchay.Items[i].FindControl("lbTen") as Label;
            Label lbGia = rpbanchay.Items[i].FindControl("lbGia") as Label;
            List<sanphamDAL> sptt = spbs.getSPbyId(ds[i].id_sanpham);
            lbA.Text = "<a href='chitietsanpham.aspx?id="+sptt[0].id_sanpham+"&gr="+sptt[0].id_danhmuc+"' title='"+sptt[0].ten_sanpham+"'>";
            lbHinh.Text = "<img class='hinhsp' height='350' width='275' alt='"+sptt[0].ten_sanpham+"' src='/uploads/"+sptt[0].hinhanh+"' style='display: block;' />";
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

       
        
    }
}

