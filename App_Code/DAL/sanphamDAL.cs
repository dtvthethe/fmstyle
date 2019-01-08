using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for sanphamDAL
/// </summary>
public class sanphamDAL
{
	public sanphamDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int id_sanpham { get; set; }
    public string ten_sanpham { get; set; }
    public int soluong { get; set; }
    public string hinhanh { get; set; }
    public int id_danhmuc { get; set; }
    public string tt_chitiet { get; set; }
    public DateTime ngaydang { get; set; }
    public decimal gia { get; set; }
    public bool khuyenmai { get; set; }
}