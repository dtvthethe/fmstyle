using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for khuyenmaiBLL
/// </summary>
public class khuyenmaiBLL
{
	public khuyenmaiBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private connect cnn = new connect();


    public int getKhuyenMaibyId(int id)
    {
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT giatri FROM khuyenmai WHERE id_khuyenmai="+id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();
    }


    public bool edit(int giatri, int id)
    {
        bool tf = false;
        string sql = "UPDATE khuyenmai SET giatri="+giatri+" WHERE id_khuyenmai="+id;
        SqlConnection cn = cnn.connectToSql();
        SqlCommand cmd = new SqlCommand(sql, cn);
        cn.Open();
        try
        {
            cmd.ExecuteNonQuery();
            tf = true;
        }
        catch
        {
            tf = false;
        }

        return tf;
    }

}