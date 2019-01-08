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
        
    }
    protected void btnGui_Click(object sender, EventArgs e)
    {
        lienheBLL bs = new lienheBLL();
        bs.addLienHe(txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtEmail.Text.Trim(), txtSDT.Text.Trim(), txtNoiDung.Text.Trim());
        Response.Redirect("lienhes.aspx");
    }
}