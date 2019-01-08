using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dathangdetail
/// </summary>
public class dathangdetail
{
    public dathangdetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int id_dathang_detail { get; set; }
    public int id_sanpham { get; set; }
    public int id_dathang { get; set; }
    public int soluong { get; set; }
    public string size { get; set; }
    public string hinhanh { get; set; }
    public decimal gia { get; set; }
    public string ten_sanpham { get; set; }
    public bool khuyenmai { get; set; }
}