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
        if (Session["cart"] == null)
        {
            Response.Redirect("/");
        }
        if (!IsPostBack)
        {
            this.loadpt();
            this.loadthanhToan();
        }
    }

    // loa pt thanh toan
    private void loadpt()
    {
        phuongthucthanhtoanBLL bs = new phuongthucthanhtoanBLL();
        ddThanhToan.DataSource = bs.getPhuongThuc();
        ddThanhToan.DataTextField = "ten_phuongthuc";
        ddThanhToan.DataValueField = "id_pt";
        ddThanhToan.DataBind();
    }
    // load thong tin cua thanh toan:
    private void loadthanhToan()
    {
        int id = 1;
        phuongthucthanhtoanBLL bs = new phuongthucthanhtoanBLL();
        id = Convert.ToInt32(ddThanhToan.SelectedValue);
        List<phuongthucthanhtoanDAL> ds = bs.getPhuongThucById(id);
        lbThanhToan.Text = ds[0].chitiet;
    }
    // load thong tin cua thanh toan:
    private void loadthanhToanId(int id)
    {
        phuongthucthanhtoanBLL bs = new phuongthucthanhtoanBLL();
        id = Convert.ToInt32(ddThanhToan.SelectedValue);
        List<phuongthucthanhtoanDAL> ds = bs.getPhuongThucById(id);
        lbThanhToan.Text = ds[0].chitiet;
    }

    protected void btnThanhToan_Click(object sender, EventArgs e)
    {
        sanphamBLL bss = new sanphamBLL();
        List<giohangDAL> cart = (List<giohangDAL>)Session["cart"];
        List<userpublicDAL> usp = (List<userpublicDAL>)Session["userPublic"];
        dathangBLL bs = new dathangBLL();
        bs.add_dathang(usp[0].id_user, Convert.ToInt32(ddThanhToan.SelectedValue));
        int id = bs.id_dathang(usp[0].id_user);
        
        for (int i = 0; i <= cart.Count - 1; i++)
        {
            int y = Convert.ToInt32(cart[i].id_sanpham);
            List<sanphamDAL> liSoLuong = bss.getSPbyId(y);
            bs.add_dathang_detail(cart[i].id_sanpham, id, cart[i].soluong, cart[i].size);
            int pi = liSoLuong[0].soluong - cart[i].soluong;
            bs.soluong_sp(cart[i].id_sanpham, pi);
        }

        Session.Remove("cart");
        Response.Redirect("success.aspx");
    }

    protected void ddThanhToan_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(ddThanhToan.SelectedValue);
        loadthanhToanId(id);
    }
}