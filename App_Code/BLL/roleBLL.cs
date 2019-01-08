using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for roleBLL
/// </summary>
public class roleBLL
{
    public roleBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();

    // lay ten role 
    public List<roleDAL> getRole()
    {
        List<roleDAL> list = new List<roleDAL>();
        string sql = "SELECT * FROM role";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            roleDAL ds = new roleDAL();
            ds.id_role = rd.GetInt32(0);
            ds.role = rd.GetString(1);
            ds.truycap_cms = rd.GetBoolean(2);
            ds.special = rd.GetBoolean(3);
            list.Add(ds);
        }
        cmd.Dispose();
        cn.Close();
        return list;
    }

    // lay 1 ten role thong qua id
    public List<roleDAL> getRolebyId(int id)
    {
        List<roleDAL> list = new List<roleDAL>();
        string sql = "SELECT * FROM role WHERE id_role=" + id;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            roleDAL ds = new roleDAL();
            ds.id_role = rd.GetInt32(0);
            ds.role = rd.GetString(1);
            ds.truycap_cms = rd.GetBoolean(2);
            ds.special = rd.GetBoolean(3);
            list.Add(ds);
        }
        cmd.Dispose();
        cn.Close();
        return list;
    }

    // them pt

    public bool add(string role, string cms, string s)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "INSERT INTO role(role,truycap_cms, special) VALUES(N'" + role + "','" + cms + "','" + s + "')";
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

    // kiem tra ten
    public bool check(string ten)
    {
        bool tf = false;
        string sql = "SELECT COUNT(*) FROM role WHERE role = N'" + ten + "'";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
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
        cmd.Dispose();
        cn.Close();
        return tf;
    }

    // kiem tra ten
    public bool check(string ten, int id)
    {
        bool tf = false;
        string sql = "SELECT COUNT(*) FROM role WHERE role = N'" + ten + "' AND id_role != "+id;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
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
        cmd.Dispose();
        cn.Close();
        return tf;
    }

    // sua pt:

    public bool edit(int id, string ten, string cms, string s)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "UPDATE role SET role=N'" + ten + "', truycap_cms='" + cms + "', special = '" + s + "' WHERE id_role=" + id + "";
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

    // sua ptSP:

    public bool editsp(string s, int id)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "UPDATE role SET special = '" + s + "' WHERE id_role=" + id + "";
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
        string sql = "DELETE FROM role WHERE id_role IN (" + id + ")";
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