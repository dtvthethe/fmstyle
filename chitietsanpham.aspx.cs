using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    private int id = -1;
    private string hinh = "";
    private string ten = "";
    private decimal gia = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            this.loadTTSP();
        }
        else
        {
            Response.Redirect("error.aspx");
        }


    }

    // load thong tin san pham
    private void loadTTSP()
    {
        khuyenmaiBLL km = new khuyenmaiBLL();
        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> ds = bs.getSPbyId(id);
        decimal khm = 0;
        if (ds.Count() == 1)
        {

            imgsp.ImageUrl = "/uploads/" + ds[0].hinhanh;
            hinh = "/uploads/" + ds[0].hinhanh;
            if (ds[0].khuyenmai == true)
            {
                 khm = ds[0].gia - (ds[0].gia * km.getKhuyenMaibyId(1) / 100);
                 lbGia.Text ="<del style='color:red'>" +String.Format("{0:0,0 vnđ}", ds[0].gia)+"</del>" + "&nbsp&nbsp&nbsp" + String.Format("{0:0,0 vnđ}", khm);
            }
            else
            {
                 khm = ds[0].gia;
                 lbGia.Text = String.Format("{0:0,0 vnđ}", khm);
            }
            
            gia = khm;
           
            lbTenSP.Text = ds[0].ten_sanpham;
            ten = ds[0].ten_sanpham;

            if (ds[0].soluong <= 2)
            {
                lbTinhTrang.Text = "Còn rất ít";
            }
            else if (ds[0].soluong == 0)
            {
                lbTinhTrang.Text = "Hết hàng";
            }
            else
            {
                lbTinhTrang.Text = "Còn hàng";
            }
            lbnoidung.Text = ds[0].tt_chitiet;
            atitle.Text = ten + " Shop thời trang FMStyle";
        }
        else
        {
            Response.Redirect("error.aspx");
        }
    }

    protected void btnMua_Click(object sender, EventArgs e)
    {
        sanphamBLL bs = new sanphamBLL();
        List<sanphamDAL> ds = bs.getSPbyId(id);
        string size = ddlMau.Text;
        int soluong = Convert.ToInt32(txtSoLuong.Text);
        int qd = ds[0].soluong - soluong;
        if (qd >= 0)
        {
            addCart(id, ten, soluong, hinh, gia, size);
            Response.Redirect("muahang.aspx");
        }
        else
        {
            lbError.Text = "Sản phẩm này đã hết hàng !<br>";
        }

    }

    // them vao gio hang
    private List<giohangDAL> addCart(int id, string ten, int soluong, string hinhanh, decimal gia, string size)
    {
        int tf = -1;
        List<giohangDAL> list;
        giohangDAL ds = new giohangDAL();
        if (Session["cart"] == null)
        {
            list = new List<giohangDAL>();
        }
        else
        {
            list = (List<giohangDAL>)Session["cart"];
            for (int i = 0; i <= list.Count() - 1; i++)
            {
                if (list[i].id_sanpham == id && list[i].size == size)
                {
                    tf = i;
                    break;
                }
            }
        }
        if (tf != -1)
        {
            list[tf].soluong += soluong;
            list[tf].giaNhanSoLuong += gia * soluong;
        }
        else
        {
            ds.id_sanpham = id;
            ds.ten_sanpham = ten;
            ds.soluong = soluong;
            ds.hinhanh = hinhanh;
            ds.gia = gia;
            ds.size = size;
            ds.giaNhanSoLuong = gia * soluong;
            list.Add(ds);
            Session["cart"] = list;
        }

        return list;
    }

}