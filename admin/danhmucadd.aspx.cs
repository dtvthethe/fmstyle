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

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        danhmucBLL bs = new danhmucBLL();
        string ten = txtTen.Text.Trim();
        if (bs.kiemtraTrungLap(ten) == false)
        {
            bool tf = bs.danhmucadd(ten);
            if (tf == true)
            {
                Response.Redirect("danhmuc.aspx?add=t");
            }
            else
            {
                lbError.Text =  "<div class='error'>"
										+"<div class='tl'></div><div class='tr'></div>"
										+"<div class='desc'>"
											+"<p>Thêm bị lỗi !</p>"
										+"</div>"
										+"<div class='bl'></div><div class='br'></div>"
									+"</div>";
            }
        }
        else
        {
            lbError.Text =  "<div class='error'>"
										+"<div class='tl'></div><div class='tr'></div>"
										+"<div class='desc'>"
											+"<p>Tên danh mục này đã tồn tại !</p>"
										+"</div>"
										+"<div class='bl'></div><div class='br'></div>"
									+"</div>";
        }
    }
}