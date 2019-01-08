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
        if (Session["userpublic"] != null)
        {
            this.danhsach();
        }
        else
        {
            Response.Redirect("dangnhap.aspx");
        }
    }

    // lay danh sach da dat hang:

    private void danhsach()
    { 
        List<userpublicDAL> usp = (List<userpublicDAL>)Session["userPublic"];
        int id = usp[0].id_user;
        dathangBLL bs = new dathangBLL();
        List<dathangDAL> ds = bs.getDathangPublic(id);
        rpLichSuMua.DataSource = ds;
        rpLichSuMua.DataBind();


        phuongthucthanhtoanBLL pt_bs = new phuongthucthanhtoanBLL();
        
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            List<phuongthucthanhtoanDAL> pt_ds = pt_bs.getPhuongThucById(ds[i].id_pt);
            Label lbPT = rpLichSuMua.Items[i].FindControl("lbPT") as Label;
            Label lbSTT = rpLichSuMua.Items[i].FindControl("lbSTT") as Label;
            lbSTT.Text = (i + 1).ToString();
            lbPT.Text = pt_ds[0].ten_phuongthuc;
            Label lbTrangThai = rpLichSuMua.Items[i].FindControl("lbTrangThai") as Label;
            if (ds[i].trangthai == true)
            {
                lbTrangThai.Text = "Đã giao hàng";
            }
            else
            {
                lbTrangThai.Text = "Đang chờ giao hàng";
            }
            
        }

    }
}