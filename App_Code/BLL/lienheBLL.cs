using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for lienheBLL
/// </summary>
public class lienheBLL
{
    public lienheBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();
    public void addLienHe(string ten, string diachi, string email, string sdt, string noidung)
    {
        DateTime ngaygui = DateTime.Now;
        string sql = "INSERT INTO lien_he (hoten, email, sdt, noidung, ngaygui, diachi) VALUES (N'" + ten + "', '" + email + "','" + sdt + "', N'" + noidung + "','" + ngaygui.Date + "', N'" + diachi + "')";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        cn.Close();

    }




    public List<lienheDAL> getLienHe()
    {
        List<lienheDAL> list = new List<lienheDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM lien_he";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            lienheDAL ds = new lienheDAL();
            ds.id_lienhe = rd.GetInt32(0);
            ds.hoten = rd.GetString(1);
            ds.email = rd.GetString(2);
            ds.sdt = rd.GetString(3);
            ds.noidung = rd.GetString(4);
            ds.ngaygui = rd.GetDateTime(5);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    public List<lienheDAL> getLienHeP(int row, int hide)
    {
        List<lienheDAL> list = new List<lienheDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select top "+row+" * from lien_he where id_lienhe not in (select top "+hide+" id_lienhe from lien_he order by id_lienhe DESC ) order by id_lienhe DESC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            lienheDAL ds = new lienheDAL();
            ds.id_lienhe = rd.GetInt32(0);
            ds.hoten = rd.GetString(1);
            ds.email = rd.GetString(2);
            ds.sdt = rd.GetString(3);
            ds.noidung = rd.GetString(4);
            ds.ngaygui = rd.GetDateTime(5);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    public int countP()
    {
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT COUNT(*) FROM lien_he";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();
    }

    public List<lienheDAL> getLienHebyId(int id)
    {
        List<lienheDAL> list = new List<lienheDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM lien_he WHERE id_lienhe = " + id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            lienheDAL ds = new lienheDAL();
            ds.id_lienhe = rd.GetInt32(0);
            ds.hoten = rd.GetString(1);
            ds.email = rd.GetString(2);
            ds.sdt = rd.GetString(3);
            ds.noidung = rd.GetString(4);
            ds.ngaygui = rd.GetDateTime(5);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }
    // xoa
    public bool del(string id_lienhe)
    {
        bool tf = false;
        string sql = "DELETE FROM lien_he WHERE id_lienhe IN (" + id_lienhe+")";
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