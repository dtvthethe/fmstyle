using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for userpublicDAL
/// </summary>
public class userpublicDAL
{
	public userpublicDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int id_user { get; set; }
    public string username { get; set; }
    public string hoten { get; set; }
    public string sdt { get; set; }
    public string diachi { get; set; }
    public string email { get; set; }
    public int role { get; set; }
    public bool special { get; set; }
}