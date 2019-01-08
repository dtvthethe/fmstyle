using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for roleDAL
/// </summary>
public class roleDAL
{
	public roleDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int id_role { get; set; }
    public string role { get; set; }
    public bool truycap_cms { get; set; }
    public bool special { get; set; }

}