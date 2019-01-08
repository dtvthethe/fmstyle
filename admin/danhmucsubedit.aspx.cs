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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            danhmucBLL bs = new danhmucBLL();
            if (Request.QueryString["id"] != null)
            {


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
            ddlDM.DataSource = bs.getDanhMuclv(1);
            ddlDM.DataValueField = "groupdanhmuc";
            ddlDM.DataTextField = "ten_danhmuc";
            ddlDM.DataBind();
            List<danhmucDAL> list = bs.getDanhMucbyId(id);
            ddlDM.SelectedValue = Convert.ToString(list[0].groupdanhmuc - 0.1);

        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string ten = txtTen.Text.Trim();
        double index = Convert.ToDouble(ddlDM.SelectedValue) + 0.1;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        danhmucBLL bs = new danhmucBLL();

        if (bs.danhmucedit(id, ten, index) == true)
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

}