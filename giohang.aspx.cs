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
        if (!IsPostBack)
        {
            if (Session["cart"] != null)
            {
                decimal tongtien = 0;
                List<giohangDAL> ds = (List<giohangDAL>)Session["cart"];
                rpgioHang.DataSource = ds;
                rpgioHang.DataBind();
                for (int i = 0; i <= ds.Count() - 1; i++)
                {
                    tongtien += ds[i].giaNhanSoLuong;
                }
                lbTongTien.Text = "Tổng tiền: " + String.Format("{0:0,0 vnđ}", tongtien);

            }
            else
            {
                btnCapNhat.Visible = false;
                btnThanhToan.Visible = false;

            }
        }

    }

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        //for (int i = 0; i <= rpgioHang.Items.Count - 1; i++)
        //{
        //    TextBox tb = rpgioHang.Items[i].FindControl("txtSoLuong") as TextBox;
        //    Response.Write(tb.Text.ToString());
        //}

        // cap nhat so luong va gia
        List<giohangDAL> cart = (List<giohangDAL>)Session["cart"];
        for (int i = 0; i <= rpgioHang.Items.Count - 1; i++)
        {
            TextBox txtsoluong = (TextBox)rpgioHang.Items[i].FindControl("txtSoLuong");
            int soluong = Convert.ToInt32(txtsoluong.Text);
            cart[i].soluong = soluong;
            cart[i].giaNhanSoLuong = soluong * cart[i].gia;
        }

        // cap nhat san pham trong gio hang
        for (int i = 0; i <= rpgioHang.Items.Count - 1; i++)
        {
            CheckBox cb = (CheckBox)rpgioHang.Items[i].FindControl("cbCheckDel");
            if (cb.Checked == true)
            {
                cart.Remove(cart[i]);

            }
        }
        Response.Redirect(Request.Url.ToString());

    }

    protected void btnThanhToan_Click(object sender, EventArgs e)
    {
        if (Session["userpublic"] == null)
        {
            Response.Redirect("dangnhap.aspx");
        }
        else
        {
            Response.Redirect("thanhtoan.aspx");
         }
    }

    protected void allCk_CheckedChanged(object sender, EventArgs e)
    {
        //CheckBox cball = (CheckBox)rpgioHang.Items[0].FindControl("allCk");
        //CheckBox cb = (CheckBox)rpgioHang.Items[0].FindControl("cbCheckDel");
        //if (cball.Checked == true)
        //{
        //    cb.Checked = true;
        //}
        //else
        //{
        //    cb.Checked = false;
        //}
    }
}