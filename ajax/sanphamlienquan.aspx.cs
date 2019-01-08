using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_sanphamlienquan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string noidung = Request.Form["gui"];
        
        sanphamBLL bl = new sanphamBLL();

        string[] noidungspli = noidung.Split('&');
        int id = Convert.ToInt32(noidungspli[1].Substring(3));
        List<sanphamDAL> ds = bl.getSanPhambyId(id);

        splienquan.DataSource = ds;
        splienquan.DataBind();

        khuyenmaiBLL km = new khuyenmaiBLL();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbgia = splienquan.Items[i].FindControl("lbGia") as Label;
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
}