using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for connect
/// </summary>
public class connect
{
	public connect()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public SqlConnection connectToSql()
    {
        string sql = @"workstation id=fmstyledb2.mssql.somee.com;packet size=4096;user id=dtvthe_SQLLogin_1;pwd=9fd4wklchw;data source=fmstyledb2.mssql.somee.com;persist security info=False;initial catalog=fmstyledb2";
        //string sql = @"workstation id=fmstyledb2.mssql.somee.com;packet size=4096;user id=dtvtheasp_SQLLogin_1;pwd=m36pdep72q;data source=fmstyledb2.mssql.somee.com;persist security info=False;initial catalog=fmstyledb2";
        //string sql = @"Data Source=WIN-D6418QESTB3\SQLEXPRESS;Initial Catalog='C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FMSTYLE.MDF';Integrated Security=True;Max Pool Size=300;Min Pool Size=5";
        //string sql = @"Data Source=DTVTHE-PC\SQLEXPRESS;Initial Catalog='C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FMSTYLE.MDF';Integrated Security=True;Encrypt=False;TrustServerCertificate=False;Max Pool Size=300;Min Pool Size=5";
        //string sql = @"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\fmstyle.mdf';Integrated Security=True;Connect Timeout=30;User Instance=True;Max Pool Size=300;Min Pool Size=5";
        SqlConnection cn = new SqlConnection(sql);
        return cn;
    }
}