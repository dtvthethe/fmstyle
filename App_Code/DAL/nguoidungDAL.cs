using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for nguoidungDAL
/// </summary>
public class nguoidungDAL
{
	public nguoidungDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int id_user { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string hoten { get; set; }
    public string sdt { get; set; }
    public string diachi { get; set; }
    public int role { get; set; }
    public string email { get; set; }
    public string stringrole { get; set; }
}