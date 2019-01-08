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
        if (Session["adminuser"] != null)
        {
            List<userpublicDAL> us = (List<userpublicDAL>)Session["adminuser"];
            if (us[0].special == false)
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        
        if (!IsPostBack)
        {
            this.loadrole();
            this.loadNguoiDung();
            if (Session["v"] != null)
            {
                ddlRole.Text = Session["v"].ToString();
                loadNguoiDungV(Session["v"].ToString());
            }
            else if (Request.QueryString["tkey"] != null)
            {
                this.loadNguoiDungT(Request.QueryString["tval"], Request.QueryString["tkey"]);
            }
            else
            {
                loadNguoiDung();
                Session.Remove("v");
            }

            if (Request.QueryString["tval"] != null)
            {
                txtTimKiem.Text = Request.QueryString["tval"];
            }
            if (Request.QueryString["tkey"] != null)
            {
                ddlTimKiem.Text = Request.QueryString["tkey"];
            }
        }

        if (Request.QueryString["add"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Thêm người dùng thành công!</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
        else if (Request.QueryString["edit"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Sửa người dùng thành công!</p>"
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

    private void loadrole()
    {
        roleBLL rb = new roleBLL();
        List<roleDAL> rd = rb.getRole();
        ddlRole.Items.Add("All");
        ddlTimKiem.Items.Add("All");
        for (int i = 0; i <= rd.Count - 1; i++)
        {
            ddlRole.Items.Add(rd[i].role);
            ddlTimKiem.Items.Add(rd[i].role);
        }
        ddlRole.DataBind();
        ddlTimKiem.DataBind();
    }

    private void loadNguoiDung()
    {
        int row = 10;
        int hide = 0;
        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }

        nguoidungBLL bs = new nguoidungBLL();
        List<nguoidungDAL> ds = bs.getNguoiDungP(row, hide);
        rpNguoiDung.DataSource = ds;
        rpNguoiDung.DataBind();

        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbSTT = rpNguoiDung.Items[i].FindControl("lbSTT") as Label;
            lbSTT.Text += (i + 1 + hide).ToString();
        }
        // phan trang:
        int current = Convert.ToInt32(Request.QueryString["p"]);
        phantrang pt = new phantrang();
        lbPage.Text = pt.paging(bs.countP(), row, "", current);
    }

    private void loadNguoiDungV(string role)
    {
        int row = 10;
        int hide = 0;
        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }
        nguoidungBLL bs = new nguoidungBLL();
        List<nguoidungDAL> ds = bs.getNguoiDungV(row, hide, role);
        rpNguoiDung.DataSource = ds;
        rpNguoiDung.DataBind();

        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbSTT = rpNguoiDung.Items[i].FindControl("lbSTT") as Label;
            lbSTT.Text += (i + 1 + hide).ToString();
        }
        // phan trang:
        int current = Convert.ToInt32(Request.QueryString["p"]);
        phantrang pt = new phantrang();
        lbPage.Text = pt.paging(bs.countV(ddlRole.Text), row, "", current);
    }

    private void loadNguoiDungT(string noidung, string danhmuc)
    {
        int row = 10;
        int hide = 0;
        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }
        nguoidungBLL bs = new nguoidungBLL();
        List<nguoidungDAL> ds = bs.getNguoiDungT(row, hide, noidung, danhmuc);
        rpNguoiDung.DataSource = ds;
        rpNguoiDung.DataBind();

        for (int i = 0; i <= ds.Count - 1; i++)
        {
            Label lbSTT = rpNguoiDung.Items[i].FindControl("lbSTT") as Label;
            lbSTT.Text += (i + 1 + hide).ToString();
        }
        string pa = "&tval=" + noidung + "&tkey=" + danhmuc;

        // phan trang:
        int current = Convert.ToInt32(Request.QueryString["p"]);
        phantrang pt = new phantrang();
        lbPage.Text = pt.paging(bs.countT(noidung, danhmuc), row, pa, current);
    }


    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.Text != "All")
        {
            this.loadNguoiDungV(ddlRole.Text);
            Session["v"] = ddlRole.Text;
        }
        else
        {
            loadNguoiDung();
            Session.Remove("v");
        }
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        Response.Redirect("nguoidung.aspx?tval=" + txtTimKiem.Text + "&tkey=" + ddlTimKiem.Text);
    }
    protected void btnUpDate_Click(object sender, EventArgs e)
    {
        nguoidungBLL bs = new nguoidungBLL();
        bool check = false;
        string id = "";
        int lengh = 0;
        bool tf = false;

        for (int i = 0; i <= rpNguoiDung.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpNguoiDung.Items[i].FindControl("cbDell") as CheckBox;

            if (cbDell.Checked)
            {
                id += cbDell.ToolTip + ",";
                check = true;
            }
        }
        lengh = id.Length;
        
        if (check == true)
        {
            string hid = id.Remove(lengh - 1);
            tf = bs.del(hid);
            if (tf == true)
            {

                Response.Redirect("nguoidung.aspx?up=t");
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