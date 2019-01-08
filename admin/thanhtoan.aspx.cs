using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("error.aspx");
        }
        if (!IsPostBack)
        {
            this.loadhinh();
        }
    }

    // LOAD HINH 
    private void loadhinh()
    {
        string[] arrHinh = new string[10];
        arrHinh[0] = "AOIG";
        arrHinh[1] = "DFAH";
        arrHinh[2] = "EWFM";
        arrHinh[3] = "RBWT";
        arrHinh[4] = "SETG";
        arrHinh[5] = "SIEU";
        arrHinh[6] = "SJEG";
        arrHinh[7] = "SJXD";
        arrHinh[8] = "WFAI";
        arrHinh[9] = "WFYB";
        Random rd = new Random();
        int x = rd.Next(0, 9);
        string hinh = arrHinh[x];
        lbHinh.Text = "<img src='../images/acc/" + hinh + ".PNG' />";
        lbHinh.ToolTip = hinh;
    }

    protected void btnThanhToan_Click(object sender, EventArgs e)
    {
        
        
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string tt = "";
        if (rbYes.Checked == true)
        {
            tt = "true";
            this.thanhtoan(id, tt);
        }
        else if (rbNo.Checked == true)
        {
            tt = "false";
            this.thanhtoan(id, tt);
        }
        else
        {
            lbError.Text = "Bạn chưa chọn trạng thái thanh toán !";
        }
    }

    private void thanhtoan(int id, string tt)
    {
        string key = txtXacNhan.Text;
        string k = lbHinh.ToolTip;
        dathangBLL bs = new dathangBLL();
        if (key == k)
        {
            bool tf = bs.ttDonHang(id, tt);
            Response.Redirect("dathang.aspx");
        }
        else
        {
            lbError.Text = "Mã xác thực không chính xác !";
        }
    }
    protected void btnHinhKhac_Click(object sender, EventArgs e)
    {
        this.loadhinh();
    }
}