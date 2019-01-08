using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_tonkho : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        sanphamBLL sp = new sanphamBLL();
        
        dathangdetailBLL bs = new dathangdetailBLL();
        List<dathangdetail> ds = bs.getdathangDetailMuaNhieu();
        rpDatHang.DataSource = ds;
        rpDatHang.DataBind();

        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbSTT = rpDatHang.Items[i].FindControl("lbSTT") as Label;
            Label lbTen = rpDatHang.Items[i].FindControl("lbTen") as Label;
            lbSTT.Text += (i + 1).ToString();

            List<sanphamDAL> lsp = sp.getSPbyId(ds[i].id_sanpham);
            lbTen.Text = lsp[0].ten_sanpham;
        }
    }
}