using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for phuongthucthanhtoanBLL
/// </summary>
public class phuongthucthanhtoanBLL
{
    public phuongthucthanhtoanBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();

    public List<phuongthucthanhtoanDAL> getPhuongThuc()
    {
        List<phuongthucthanhtoanDAL> list = new List<phuongthucthanhtoanDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM phuong_thuc_thanh_toan";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            phuongthucthanhtoanDAL ds = new phuongthucthanhtoanDAL();
            ds.id_pt = rd.GetInt32(0);
            ds.ten_phuongthuc = rd.GetString(1);
            ds.chitiet = rd.GetString(2);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // hien thi du lieu:
    public List<phuongthucthanhtoanDAL> getPhuongThucById(int id)
    {
        List<phuongthucthanhtoanDAL> list = new List<phuongthucthanhtoanDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM phuong_thuc_thanh_toan WHERE id_pt ="+id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            phuongthucthanhtoanDAL ds = new phuongthucthanhtoanDAL();
            ds.id_pt = rd.GetInt32(0);
            ds.ten_phuongthuc = rd.GetString(1);
            ds.chitiet = rd.GetString(2);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // them pt

    public bool add(string ten, string tt)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "INSERT INTO phuong_thuc_thanh_toan (ten_phuongthuc, chitiet) VALUES(N'" + ten + "',N'" + tt + "')";
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
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

    // 
    // check:
    public bool  check(string ten)
    {
        bool tf =false;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT COUNT(*) FROM phuong_thuc_thanh_toan WHERE ten_phuongthuc = N'"+ten+"'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        if (rd.GetInt32(0) > 0)
        {
            tf=true;
        }
        else
        {
            tf = false;
        }
        return tf;
        cmd.Dispose();
        cn.Close();
    }

    // check:
    public bool check(int id, string ten)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT COUNT(*) FROM phuong_thuc_thanh_toan WHERE ten_phuongthuc = N'"+ten+"' and id_pt !=" + id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        if (rd.GetInt32(0) > 0)
        {
            tf = true;
        }
        else
        {
            tf = false;
        }
        return tf;
        cmd.Dispose();
        cn.Close();
    }
    // sua pt:

    public bool edit(int id, string ten, string tt)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "UPDATE phuong_thuc_thanh_toan SET ten_phuongthuc=N'" + ten + "', chitiet=N'" + tt + "' WHERE id_pt=" + id + "";
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
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


    // xoa:

    public bool del(string id)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "DELETE FROM phuong_thuc_thanh_toan WHERE id_pt IN("+id+")";
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
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