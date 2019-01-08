using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_ttchitiet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.loadsanpham();
    }

    private void loadsanpham()
    {
        int id = Convert.ToInt32(Request.Form["id"]);
        dathangdetailBLL bs = new dathangdetailBLL();
        List<dathangdetail> ds = bs.getdathangDetail(id);
        rpDatHang.DataSource = ds;
        rpDatHang.DataBind();
    }
}