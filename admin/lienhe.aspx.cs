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
            this.loadLienHe();
            if (Request.QueryString["up"] == "t")
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
    }

    private void loadLienHe()
    {
        int row = 10;
        int hide = 0;

        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }

        lienheBLL bs = new lienheBLL();
        List<lienheDAL> list = bs.getLienHeP(row, hide);
        rpLienHe.DataSource = list;
        rpLienHe.DataBind();

        List<userpublicDAL> us = (List<userpublicDAL>)Session["adminuser"];
        int id_user = us[0].id_user;
        lienheviewBLL b = new lienheviewBLL();
        List<lienheDAL> ds = b.lienhe_view(id_user);



        for (int i = 0; i <= list.Count - 1; i++)
        {
            Label lbSTT = rpLienHe.Items[i].FindControl("lbSTT") as Label;
            lbSTT.Text = (hide + i + 1).ToString();
            Label lbView = rpLienHe.Items[i].FindControl("lbview") as Label;
            if (check(list[i].id_lienhe) == true)
            {
                //  lbView.Visible = false;
                lbView.Text = "[Đã xem]";
            }
            else
            {
                lbView.Visible = true;
            }

        }

        // phan trang:
        int current = Convert.ToInt32(Request.QueryString["p"]);
        phantrang pt = new phantrang();
        lbPage.Text = pt.paging(bs.countP(), row, "", current);

    }

    private bool check(int id)
    {
        List<userpublicDAL> us = (List<userpublicDAL>)Session["adminuser"];
        int id_user = us[0].id_user;
        bool tf = false;
        lienheviewBLL b = new lienheviewBLL();
        List<lienheDAL> ds = b.lienhe_view(id_user);
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            if (id == ds[i].id_lienhe)
            {
                tf = true;
                break;
            }
        }
        return tf;
    }
    protected void btnUpDate_Click(object sender, EventArgs e)
    {
        lienheBLL bs = new lienheBLL();
        lienheviewBLL bss = new lienheviewBLL();
        
        string id = "";
        int lengh = 0;
        bool tf = false;
        bool tff = false;
        bool check = false;
        for (int i = 0; i <= rpLienHe.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpLienHe.Items[i].FindControl("cbDell") as CheckBox;

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
            tff = bss.del(hid);
            tf = bs.del(hid);
            if (tff == true && tf == true)
            {

                Response.Redirect("lienhe.aspx?up=t");
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