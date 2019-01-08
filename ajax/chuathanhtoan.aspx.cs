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
       
        dathangBLL bs = new dathangBLL();
        List<dathangDAL> ds = bs.getDathangthanhtoan();
        rpDatHang.DataSource = ds;
        rpDatHang.DataBind();

        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbSTT = rpDatHang.Items[i].FindControl("lbSTT") as Label;
            lbSTT.Text += (i + 1).ToString();
        }
    }
}