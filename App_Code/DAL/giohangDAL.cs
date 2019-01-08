using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for giohangDAL
/// </summary>
public class giohangDAL
{
	public giohangDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int id_sanpham { get; set; }
    public string ten_sanpham { get; set; }
    public int soluong { get; set; }
    public string hinhanh { get; set; }
    public decimal gia { get; set; }
    public string size { get; set; }
    public decimal giaNhanSoLuong { get; set; }
}