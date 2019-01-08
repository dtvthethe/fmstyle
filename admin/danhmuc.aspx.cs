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
            this.loadDMlv1();
            this.loadDMlv2();
        }

        if (Request.QueryString["add"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Thêm danh mục thành công!</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
        else if (Request.QueryString["edit"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Sửa danh mục thành công!</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
        else if (Request.QueryString["up"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                             " <div class='tl'></div><div class='tr'></div>"
                                            + "<div class='desc'>"
                                            + "	<p>Cập nhật thành công!</p>"
                                            + "</div>"
                                            + "<div class='bl'></div><div class='br'></div>"
                                        + "</div>";
        }

    }




    private void loadDMlv2()
    {
        danhmucBLL bs = new danhmucBLL();
        //DropDownList ddlLevel = rpLV1.Items[0].FindControl("ddlLevel") as DropDownList;
        List<danhmucDAL> ds = bs.getDanhMuclv(1);
        ddlLevel.Items.Add("Tất cả");
        ddlLevel.DataSource = ds;
        ddlLevel.DataTextField = "ten_danhmuc";
        ddlLevel.DataValueField = "groupdanhmuc";
        ddlLevel.DataBind();
        double index = Convert.ToDouble(ddlLevel.SelectedValue) + 0.1;
        List<danhmucDAL> list = bs.getDanhMuclvXem(index);
        rpLV1.DataSource = list;
        rpLV1.DataBind();
        for (int i = 0; i <= rpLV1.Items.Count - 1; i++)
        {
            Label lbDanhMucSTT = rpLV1.Items[i].FindControl("lbDanhMucSubSTT") as Label;
            lbDanhMucSTT.Text = (i + 1).ToString();
        }
    }


    private void loadDMlv2Xem(double u)
    {
        danhmucBLL bs = new danhmucBLL();
        rpLV1.DataSource = bs.getDanhMuclvXem(u);
        rpLV1.DataBind();
        for (int i = 0; i <= rpLV1.Items.Count - 1; i++)
        {
            Label lbDanhMucSTT = rpLV1.Items[i].FindControl("lbDanhMucSubSTT") as Label;
            lbDanhMucSTT.Text = (i + 1).ToString();
        }
    }

    private void loadDMlv1()
    {
        danhmucBLL bs = new danhmucBLL();
        List<danhmucDAL> list = bs.getDanhMuclv(1);
        rpLV2.DataSource = bs.getDanhMuclv(1);
        rpLV2.DataBind();

        for (int i = 0; i <= list.Count - 1; i++)
        {
            Label lbDanhMucSTT = rpLV2.Items[i].FindControl("lbDanhMucSTT") as Label;
            lbDanhMucSTT.Text = (i + 1).ToString();
        }

    }
    protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        double index = Convert.ToDouble(ddlLevel.SelectedValue) + 0.1;
        loadDMlv2Xem(index);
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        bool tfcha = false;
        bool check = false;
        string id = "";
        // xoa  danhmuc cha:
        for (int i = 0; i <= rpLV2.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpLV2.Items[i].FindControl("cbDell") as CheckBox;
            if (cbDell.Checked)
            {
                id += cbDell.ToolTip + ",";
                check = true;
            }

        }

        int hid = id.Length;
        
        danhmucBLL bs = new danhmucBLL();
        if (check == true)
        {
            string id_danhmuc = id.Remove(hid - 1);
            tfcha = bs.del(id_danhmuc);
            if (tfcha == true)
            {

                Response.Redirect("danhmuc.aspx?up=t");
            }
            else
            {
                lbError.Text = "<div class='error'> " +
                                                 " <div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                + "	<p>Cập nhật thất bại!</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
            }
        }



        
    }
    protected void btnCapNhatCon_Click(object sender, EventArgs e)
    {
        bool tfcon = false;
        bool check = false;
        string id = "";
        // xoa danh muc con:

        for (int i = 0; i <= rpLV1.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpLV1.Items[i].FindControl("cbDell") as CheckBox;
            if (cbDell.Checked)
            {
                id += cbDell.ToolTip + ",";
                check = true;
            }

        }

        int hidd = id.Length;
       
        danhmucBLL bs = new danhmucBLL();
        if (check == true)
        {
            string id_danhmuc_dt = id.Remove(hidd - 1);
            tfcon = bs.del(id_danhmuc_dt);
            if (tfcon == true)
            {

                Response.Redirect("danhmuc.aspx?up=t");
            }
            else
            {
                lbError.Text = "<div class='error'> " +
                                                 " <div class='tl'></div><div class='tr'></div>"
                                                + "<div class='desc'>"
                                                + "	<p>Cập nhật thất bại!</p>"
                                                + "</div>"
                                                + "<div class='bl'></div><div class='br'></div>"
                                            + "</div>";
            }
        }
        
    }
}