using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


/// <summary>
/// Summary description for slideBLL
/// </summary>
public class slideBLL
{
    public slideBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();
    // view:

    public List<slideDAL> getSlide()
    {
        List<slideDAL> list = new List<slideDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM slide ORDER BY id_slide DESC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            slideDAL ds = new slideDAL();
            ds.id_slide = rd.GetInt32(0);
            ds.hinhanh = rd.GetString(1);
            ds.link = rd.GetString(2);
            ds.vitri = rd.GetInt32(3);

            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }
    // view public:

    public List<slideDAL> getSlidePublic()
    {
        List<slideDAL> list = new List<slideDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM slide ORDER BY vitri ASC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            slideDAL ds = new slideDAL();
            ds.id_slide = rd.GetInt32(0);
            ds.hinhanh = rd.GetString(1);
            ds.link = rd.GetString(2);
            ds.vitri = rd.GetInt32(3);

            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }
    // view:

    public List<slideDAL> getSlideById(int id)
    {
        List<slideDAL> list = new List<slideDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM slide WHERE id_slide = "+id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            slideDAL ds = new slideDAL();
            ds.id_slide = rd.GetInt32(0);
            ds.hinhanh = rd.GetString(1);
            ds.link = rd.GetString(2);
            ds.vitri = rd.GetInt32(3);

            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // them:

    public bool add(string hinh, string link, int vitri)
    {
        bool tf = false;
        string sql = "INSERT INTO slide(hinhanh, link, vitri) VALUES('"+hinh+"', '"+link+"',"+vitri+")";
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



    // sua:

    public bool edit(string link, int vitri, int id)
    {
        bool tf = false;
        string sql = "UPDATE slide SET link = '"+link+"', vitri = "+vitri+" WHERE id_slide = "+ id;
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


    // xoa:

    public bool del(string id)
    {
        bool tf = false;
        string sql = "DELETE FROM slide WHERE id_slide IN ("+id+")";
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