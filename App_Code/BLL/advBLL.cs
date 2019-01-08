using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


/// <summary>
/// Summary description for advBLL
/// </summary>
public class advBLL
{
    public advBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();


    // load adv
    public List<advDAL> getAdv()
    {
        List<advDAL> list = new List<advDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM quangcao ORDER BY id_adv";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            advDAL ds = new advDAL();
            ds.id_adv = rd.GetInt32(0);
            ds.ten = rd.GetString(1);
            ds.link = rd.GetString(2);
            ds.hinhanh = rd.GetString(3);
            ds.trangthai = rd.GetBoolean(4);

            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // load mot adv 

    public List<advDAL> getAdvById(int id)
    {
        List<advDAL> list = new List<advDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM quangcao WHERE id_adv=" + id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            advDAL ds = new advDAL();
            ds.id_adv = rd.GetInt32(0);
            ds.ten = rd.GetString(1);
            ds.link = rd.GetString(2);
            ds.hinhanh = rd.GetString(3);
            ds.trangthai = rd.GetBoolean(4);

            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // load mot adv 

    public List<advDAL> getAdvPubLic()
    {
        List<advDAL> list = new List<advDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM quangcao WHERE trangthai= 'true'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            advDAL ds = new advDAL();
            ds.id_adv = rd.GetInt32(0);
            ds.ten = rd.GetString(1);
            ds.link = rd.GetString(2);
            ds.hinhanh = rd.GetString(3);
            ds.trangthai = rd.GetBoolean(4);

            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // cap nhat adv:
    public bool edit(int id, string ten, string link, string hinh, string tt)
    {
        bool tf = false;
        string sql = "";
        if (hinh == "none")
        {
            sql = "UPDATE quangcao SET ten= N'" + ten + "', link = '" + link + "', trangthai='" + tt + "' WHERE id_adv = " + id;
        }
        else
        {
            sql = "UPDATE quangcao SET ten= N'" + ten + "', link = '" + link + "', hinhanh = '" + hinh + "', trangthai='" + tt + "' WHERE id_adv = " + id;
        }
       
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

    // them adv:
    public bool add(string ten, string link, string hinh, string tt)
    {
        bool tf = false;
        string sql = "INSERT INTO quangcao (ten, link, hinhanh, trangthai) VALUES(N'"+ten+"','"+link+"','"+hinh+"','"+tt+"')";
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

    // xoa adv:
    public bool del(string id)
    {
        bool tf = false;
        string sql = "DELETE FROM quangcao WHERE id_adv IN("+id+")";
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

    // xoa hinh anh
    public bool delPic(int id)
    {
        bool tf = false;
        string sql = "UPDATE quangcao SET hinhanh = ''  WHERE id_adv = " + id;
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

    // reset trang thai
    public bool ttPic()
    {
        bool tf = false;
        string sql = "UPDATE quangcao SET trangthai = 'false'";
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