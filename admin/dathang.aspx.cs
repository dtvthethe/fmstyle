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
            if (Request.QueryString["v"] != null)
            {
                string tf = "";
                if (Request.QueryString["v"] == "1")
                {
                    tf = "true";
                }
                else if (Request.QueryString["v"] == "2")
                {
                    tf = "false";
                }
                else
                {
                    tf = "";
                }
                this.loadDatHang(tf);
                ddlXem.SelectedValue = Request.QueryString["v"];
            }
            else
            {
                this.loadDatHang("");
            }
        }
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



    // load dat hang
    private void loadDatHang(string v)
    {
        int row = 10;
        int hide = 0;
        if (Request.QueryString["p"] != null)
        {
            hide = Convert.ToInt32(Request.QueryString["p"]);
        }
        dathangBLL bs = new dathangBLL();
        phuongthucthanhtoanBLL pt_bs = new phuongthucthanhtoanBLL();
        dathangdetailBLL dhdt_bs = new dathangdetailBLL();
        nguoidungBLL nd_bs = new nguoidungBLL();
        khuyenmaiBLL km = new khuyenmaiBLL();
        List<dathangDAL> ds = bs.getDathangP(row, hide, v);
        rpDatHang.DataSource = ds;
        rpDatHang.DataBind();
        for (int i = 0; i <= ds.Count - 1; i++)
        {
            List<nguoidungDAL> nd_ds = nd_bs.getNguoiDungbyId(ds[i].id_user);
            List<phuongthucthanhtoanDAL> pt_ds = pt_bs.getPhuongThucById(ds[i].id_pt);
            List<dathangdetail> dhdt_ds = dhdt_bs.getdathangDetail(ds[i].id_dathang);
            Label lbNguoiDung = rpDatHang.Items[i].FindControl("lbNguoiDung") as Label;
            lbNguoiDung.Text = nd_ds[0].hoten;
            Label lbThanhToan = rpDatHang.Items[i].FindControl("lbThanhToan") as Label;
            lbThanhToan.Text = pt_ds[0].ten_phuongthuc;
            Label lbTongTien = rpDatHang.Items[i].FindControl("lbTongTien") as Label;
            decimal tongTien = 0;
            for (int j = 0; j <= dhdt_ds.Count - 1; j++)
            {
                if (dhdt_ds[j].khuyenmai == true)
                {
                    tongTien += (dhdt_ds[j].gia - (dhdt_ds[j].gia * km.getKhuyenMaibyId(1) / 100)) * dhdt_ds[j].soluong;
                }
                else
                {
                    tongTien += (dhdt_ds[j].gia * dhdt_ds[j].soluong);
                }

            }
            lbTongTien.Text = String.Format("{0:0,0 VNĐ}", tongTien);
            Label lbHinh = rpDatHang.Items[i].FindControl("lbHinh") as Label;
            if (ds[i].trangthai == true)
            {
                lbHinh.Text = "<img src=\"../images/admin/dathutien.jpg\" alt=\"Đã thu tiền\">";
            }

            Label lbSTT = rpDatHang.Items[i].FindControl("lbSTT") as Label;
            lbSTT.Text += (i + 1 + hide).ToString();
        }
        string view = "";

        if (v != "")
        {
            view = "&v=" + Request.QueryString["v"];
        }

        // phan trang:
        int current = Convert.ToInt32(Request.QueryString["p"]);
        phantrang pt = new phantrang();
        lbPage.Text = pt.paging(bs.countP(v), row, view, current);
    }
    protected void ddlXem_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("dathang.aspx?v=" + ddlXem.Text);
    }
    protected void btnUpDate_Click(object sender, EventArgs e)
    {
        dathangBLL bs = new dathangBLL();
        dathangdetailBLL bss = new dathangdetailBLL();
        string id = "";
        int lengh = 0;
        bool tf = false;
        bool tff = false;
        bool check = false;
        for (int i = 0; i <= rpDatHang.Items.Count - 1; i++)
        {
            CheckBox cbDell = rpDatHang.Items[i].FindControl("cbDell") as CheckBox;

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

                Response.Redirect("dathang.aspx?up=t");
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