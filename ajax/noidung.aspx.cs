using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_noidung : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string noidung = Request.Form["gui"];
       
        sanphamBLL bl = new sanphamBLL();
        
        string[] noidungspli = noidung.Split('&');
        int id = Convert.ToInt32(noidungspli[0].Substring(4));
        List<sanphamDAL> ds = bl.getSPbyId(id);
        lbnoidung.Text = ds[0].tt_chitiet;
        
    }
}