using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_timkiem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        sanphamBLL bs = new sanphamBLL();
        
        string column = Request.Form["co"];
        string value = Request.Form["va"];
        List<sanphamDAL> ds = bs.timkiem(column, value);
        sptimkiem.DataSource = ds;
        sptimkiem.DataBind();

        khuyenmaiBLL km = new khuyenmaiBLL();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbgia = sptimkiem.Items[i].FindControl("lbGia") as Label;
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

        lbresult.Text = "Kết quả tìm được " + ds.Count + " sản phẩm " + value;
    }
}