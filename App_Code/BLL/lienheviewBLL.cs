using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for lienheviewBLL
/// </summary>
public class lienheviewBLL
{
    public lienheviewBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();
    // them :
    public bool lienheadd(int id_lienhe, int id_user)
    {
        bool tf = false;
        string sql = "INSERT INTO view_lienhe(id_lienhe, id_user) VALUES(" + id_lienhe + "," + id_user + ")";
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

    // xoa :
    public bool lienhedel(int id_lienhe)
    {
        bool tf = false;
        string sql = "DELETE FROM view_lienhe WHERE id_lienhe=" + id_lienhe;
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

    // kiem tra lien he da xem chua:

    public bool checkView(int id_lienhe, int id_user)
    {
        bool tf = false;
        string sql = "SELECT COUNT(*) FROM view_lienhe WHERE id_lienhe=" + id_lienhe + " AND id_user=" + id_user;
        SqlConnection cn = cnn.connectToSql();
        SqlCommand cmd = new SqlCommand(sql, cn);
        cn.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        if (rd.GetInt32(0) == 0)
        {
            tf = true;
        }
        else
        {
            tf = false;
        }
        return tf;
    }

    // danh sach lien he da xem:
    public List<lienheDAL> lienhe_view(int id_user)
    {
        List<lienheDAL> list = new List<lienheDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT lien_he.id_lienhe FROM lien_he, view_lienhe  WHERE lien_he.id_lienhe = view_lienhe.id_lienhe AND view_lienhe.id_user = " + id_user + " ORDER BY lien_he.id_lienhe ASC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            lienheDAL ds = new lienheDAL();
            ds.id_lienhe = rd.GetInt32(0);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }


    // so luong lien he chua xem:

    private int count_lienhe_daxem(int id_user)
    {
        int daxem = 0;
        SqlConnection cn = cnn.connectToSql();

        string sql = "SELECT COUNT(lien_he.id_lienhe) FROM lien_he, view_lienhe  WHERE lien_he.id_lienhe = view_lienhe.id_lienhe AND view_lienhe.id_user = " + id_user;
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        
        rd.Read();
        daxem = rd.GetInt32(0);
        return daxem;
        cn.Close();
    }

    // so luong lien he da xem:

    private int count_lienhe_chuaxem()
    {
        int chuaxem = 0;
        SqlConnection cn = cnn.connectToSql();
        string sql = "SELECT COUNT(lien_he.id_lienhe) FROM lien_he";
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        
        rd.Read();
        chuaxem = rd.GetInt32(0);
        return chuaxem;
        cn.Close();
    }


    // so luong lien he:

    public int count_lienhe(int id_user)
    {
        return this.count_lienhe_chuaxem() - count_lienhe_daxem(id_user);
    }

    // xoa:
    public bool del(string id_lienhe)
    {
        bool tf = false;
        string sql = "DELETE FROM view_lienhe WHERE id_lienhe IN (" + id_lienhe+")";
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