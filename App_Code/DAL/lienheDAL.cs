using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for lienheDAL
/// </summary>
public class lienheDAL
{
	public lienheDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int id_lienhe { get; set; }
    public string hoten { get; set; }
    public string email { get; set; }
    public string sdt { get; set; }
    public string noidung { get; set; }
    public DateTime ngaygui { get; set; }
    public string diachi { get; set; }
   
}