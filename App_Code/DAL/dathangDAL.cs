using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dathangDAL
/// </summary>
public class dathangDAL
{
	public dathangDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int id_dathang { get; set; }
    public int id_user { get; set; }
    public int id_pt { get; set; }
    public bool trangthai { get; set; }
    public DateTime ngaydang { get; set; }
    public string ten { get; set; }
}