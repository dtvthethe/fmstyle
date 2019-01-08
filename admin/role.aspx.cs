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
        }

        if (Request.QueryString["add"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Thêm thành công!</p>"
                                        + "</div>"
                                        + "<div class='bl'></div><div class='br'></div>"
                                    + "</div>";
        }
        else if (Request.QueryString["edit"] == "t")
        {
            lbError.Text = "<div class='success'> " +
                                         " <div class='tl'></div><div class='tr'></div>"
                                        + "<div class='desc'>"
                                        + "	<p>Sửa thành công!</p>"
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
        roleBLL bs = new roleBLL();
        List<roleDAL> list = bs.getRole();
        rpRole.DataSource = list;
        rpRole.DataBind();

        for (int i = 0; i <= list.Count - 1; i++)
        {
            Label lbCMS = rpRole.Items[i].FindControl("lbCMS") as Label;
            Label lbSTT = rpRole.Items[i].FindControl("lbSTT") as Label;
            DropDownList ddlSp = rpRole.Items[i].FindControl("ddlSp") as DropDownList;
            if (list[i].truycap_cms == true)
            {
                lbCMS.Text = "Cho phép";
            }
            else
            {
                lbCMS.Text = "Từ chối";
            }
            if (list[i].special == true)
            {
                ddlSp.SelectedValue = "1";
            }
            else
            {
                ddlSp.SelectedValue = "0";
            }
            lbSTT.Text = (i + 1).ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string id = "";
        bool tf = false;
        bool tff = false;
        bool check = false;
        roleBLL bs = new roleBLL();
        for (int i = 0; i <= rpRole.Items.Count - 1; i++)
        {
            DropDownList ddlSp = rpRole.Items[i].FindControl("ddlSp") as DropDownList;
            CheckBox cbDell = rpRole.Items[i].FindControl("cbDell") as CheckBox;
            if (ddlSp.SelectedValue == "0")
            {
                tf = bs.editsp("false", Convert.ToInt32(cbDell.ToolTip));
            }
            else
            {
                tf = bs.editsp("true", Convert.ToInt32(cbDell.ToolTip));
            }
            if (cbDell.Checked)
            {
                id += cbDell.ToolTip + ",";
            }
        }

        for (int i = 0; i <= rpRole.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpRole.Items[i].FindControl("cbDell") as CheckBox;
            if (cbDell.Checked)
            {
                id += cbDell.ToolTip + ",";
                check = true;
            }
        }

        int hid = id.Length;

        if (check == true)
        {
            string up = id.Remove(hid - 1);
            tff = bs.del(up);

        }
        if (tff == true | tf == true)
        {
            Response.Redirect("role.aspx?up=t");
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