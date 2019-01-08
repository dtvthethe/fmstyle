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
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                danhmucBLL bs = new danhmucBLL();
                List<danhmucDAL> ds = bs.getDanhMucbyId(id);
                if (ds.Count == 1)
                {
                    txtTen.Text = ds[0].ten_danhmuc;
                }
                else
                {
                    Response.Redirect("error.aspx");
                }
            }
            else
            {
                Response.Redirect("error.aspx");
            }
        }

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string ten = txtTen.Text.Trim();
        int id = Convert.ToInt32(Request.QueryString["id"]);
        danhmucBLL bs = new danhmucBLL();
        if (bs.kiemtraTrungLap(ten) == false)
        {
            if (bs.danhmucedit(id, ten) == true)
            {
                Response.Redirect("danhmuc.aspx?edit=t");
            }
            else
            {
                lbError.Text = "<div class='error'>"
                                        + "<div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                            + "<p>Sửa danh mục bị lỗi !</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
            }
        }
        else
        {
            lbError.Text = "<div class='error'>"
                                        + "<div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                            + "<p>Danh mục này đã tồn tại !</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
    }
}