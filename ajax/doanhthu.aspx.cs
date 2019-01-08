using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_doanhthu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            loadDatHang();
        }
    }

    private void loadDatHang()
    {
        decimal tong = 0;
        dathangBLL bs = new dathangBLL();
        dathangdetailBLL dhdt_bs = new dathangdetailBLL();
        khuyenmaiBLL km = new khuyenmaiBLL();
        List<dathangDAL> ds = bs.getDathangdoanhthu("true");
        rpDatHang.DataSource = ds;
        rpDatHang.DataBind();
        for (int i = 0; i <= ds.Count - 1; i++)
        {

  
            List<dathangdetail> dhdt_ds = dhdt_bs.getdathangDetail(ds[i].id_dathang);

            Label lbTongTien = rpDatHang.Items[i].FindControl("lbTongTien") as Label;
            decimal tongTien = 0;
            for (int j = 0; j <= dhdt_ds.Count - 1; j++)
            {
                if (dhdt_ds[j].khuyenmai == true)
                {
                    tongTien += (dhdt_ds[j].gia - (dhdt_ds[j].gia * km.getKhuyenMaibyId(1) / 100)) * dhdt_ds[j].soluong;
                }
                else
                {
                    tongTien += (dhdt_ds[j].gia * dhdt_ds[j].soluong);
                }

            }
            tong += tongTien;
            lbTongTien.Text = String.Format("{0:0,0 VNĐ}", tongTien);
           
           

            Label lbSTT = rpDatHang.Items[i].FindControl("lbSTT") as Label;
            lbSTT.Text += (i + 1).ToString();
        }
        lbSum.Text ="Tổng doanh thu:"+ String.Format("{0:0,0 VNĐ}", tong);
    }
}