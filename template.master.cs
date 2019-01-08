using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class template : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.chaomung();
        this.loadDanhMuc();
        this.countShoppingCart();
        this.xoaSessionMK();
        this.dannhmuc();
    }
    // cau chao mung
    private void chaomung()
    {
        if (Session["userPublic"] != null)
        {
            List<userpublicDAL> usp = (List<userpublicDAL>)Session["userPublic"];
            lbTen.Text = usp[0].hoten;
            lbtnLog.Text = "Thoát";
            lbtnLog.PostBackUrl = "logout.aspx";
        }
        else
        {
            lbTen.Text = "Chào khách !";
            lbtnLog.Text = "Đăng nhập";
            lbtnLog.PostBackUrl = "dangnhap.aspx";
        }
    }

    // danh muc :

    private void loadDanhMuc()
    {
        danhmucBLL bs = new danhmucBLL();
        menusubtitle.DataSource = bs.getMenu();
        menusubtitle.DataBind();
    }

    //private void page()
    //{
    //    string[] file = Request.CurrentExecutionFilePath.Split('/');
    //    string fileName = file[file.Length - 1];

    //}
    // dem so luong san pham trong gio hang

    private void countShoppingCart()
    {
        if (Session["cart"] != null)
        {
            List<giohangDAL> cart = (List<giohangDAL>)Session["cart"];
            if (cart.Count() > 0)
            {
                lbCountCart.Text = cart.Count().ToString();
            }

        }
        else
        {
            lbCountCart.Visible = false;
        }

    }

    // xoa session doi mat khau :
    private void xoaSessionMK()
    {
        string[] file = Request.CurrentExecutionFilePath.Split('/');
        string fileName = file[file.Length - 1];
        if (fileName != "quenmatkhau-matkhaumoi.aspx")
        {
            if (Session["quenmatkhau"] != null)
            {
                Session.Remove("quenmatkhau");
            }
        }

    }
    // load danh muc tim kiem

    private void dannhmuc()
    {
        danhmucBLL bs = new danhmucBLL();
        IList<danhmucDAL> list = bs.getDanhMucTimKiem();
        search_se.Items.Add("Tất cả");
        for (int i = 0; i <= list.Count - 1; i++)
        {
            search_se.Items.Add(list[i].ten_danhmuc);
        }
    }


}
