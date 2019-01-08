using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_dathanguser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.loadsanpham();
    }

    private void loadsanpham()
    {
        sanphamBLL sp = new sanphamBLL();
        khuyenmaiBLL km = new khuyenmaiBLL();
        int id = Convert.ToInt32(Request.Form["id"]);
        dathangdetailBLL bs = new dathangdetailBLL();
        List<dathangdetail> ds = bs.getdathangDetail(id);
        rpDatHang.DataSource = ds;
        rpDatHang.DataBind();
        decimal gia = 0;


        for (int i = 0; i <= ds.Count - 1; i++)
        {
            decimal giasp = 0;
            List<sanphamDAL> list = sp.getSPbyId(ds[i].id_sanpham);
            if (list[0].khuyenmai == true)
            {
                giasp = ds[i].gia - (ds[i].gia * km.getKhuyenMaibyId(1) / 100);
            }
            else
            {
                giasp = ds[i].gia;
            }

            Label lbSTT = rpDatHang.Items[i].FindControl("lbSTT") as Label;
            gia += (giasp * ds[i].soluong);
            lbSTT.Text = (i + 1).ToString();
        }
        lbTongTien.Text = String.Format("{0:0,0 VNĐ}", gia);
    }
}