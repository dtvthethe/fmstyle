using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for danhmucBLL
/// </summary>
public class danhmucBLL
{
    public danhmucBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();
    // load danh muc
    public List<danhmucDAL> getDanhMuc()
    {
        List<danhmucDAL> list = new List<danhmucDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        // string sql = "SELECT * FROM danhmuc";
        string sql = "SELECT * FROM danhmuc ORDER BY groupdanhmuc ASC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            danhmucDAL ds = new danhmucDAL();
            ds.id_danhmuc = rd.GetInt32(0);
            ds.ten_danhmuc = rd.GetString(1);
            ds.groupdanhmuc = rd.GetDouble(2);

            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    public List<danhmucDAL> getDanhMuclv(int y)
    {
        List<danhmucDAL> list = new List<danhmucDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        // string sql = "SELECT * FROM danhmuc";
        string sql = "SELECT * FROM danhmuc ORDER BY groupdanhmuc ASC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            string j = Convert.ToString(rd.GetDouble(2));
            string[] spl = j.Split('.');
            if (Convert.ToInt32(spl[1]) == y)
            {
                danhmucDAL ds = new danhmucDAL();
                ds.id_danhmuc = rd.GetInt32(0);
                ds.ten_danhmuc = rd.GetString(1);
                ds.groupdanhmuc = rd.GetDouble(2);

                list.Add(ds);
            }
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }


    // xem theo danh muc:

    public List<danhmucDAL> getDanhMuclvXem(double y)
    {
        List<danhmucDAL> list = new List<danhmucDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        // string sql = "SELECT * FROM danhmuc";
        string sql = "SELECT * FROM danhmuc WHERE groupdanhmuc="+y;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            
                danhmucDAL ds = new danhmucDAL();
                ds.id_danhmuc = rd.GetInt32(0);
                ds.ten_danhmuc = rd.GetString(1);
                ds.groupdanhmuc = rd.GetDouble(2);

                list.Add(ds);
            
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // load menu:

    public List<danhmucDAL> getMenu()
    {
        double id = -1;
        List<danhmucDAL> list = new List<danhmucDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM danhmuc ORDER BY groupdanhmuc ASC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            danhmucDAL ds = new danhmucDAL();
            if (list.Count() == 0)
            {
                ds.id_danhmuc = rd.GetInt32(0);
                ds.ten_danhmuc = "<li class='menu-item-1'><a href='#'>" + rd.GetString(1) + "</a><ul>";
                ds.groupdanhmuc = rd.GetDouble(2);
                id = Math.Round(rd.GetDouble(2), 0);
            }
            else
            {
                if (Math.Round(rd.GetDouble(2), 0) != id)
                {
                    ds.id_danhmuc = rd.GetInt32(0);
                    ds.ten_danhmuc = "</ul></li><li class='menu-item-1'><a href='#'>" + rd.GetString(1) + "</a><ul>";
                    ds.groupdanhmuc = rd.GetDouble(2);
                    id = Math.Round(rd.GetDouble(2), 0);
                }
                else
                {
                    ds.id_danhmuc = rd.GetInt32(0);
                    ds.ten_danhmuc = "<li class=''><a href='sanpham.aspx?id=" + rd.GetInt32(0) + "'>" + rd.GetString(1) + "</a></li>";
                    ds.groupdanhmuc = rd.GetDouble(2);
                    id = Math.Round(rd.GetDouble(2), 0);
                }
            }


            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    //load danh muc timkiem:

    public List<danhmucDAL> getDanhMucTimKiem()
    {
        List<danhmucDAL> list = new List<danhmucDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM danhmuc ORDER BY groupdanhmuc ASC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();

        while (rd.Read())
        {
            string i = Convert.ToString(rd.GetDouble(2));
            string[] l = i.Split('.');
            if (l[1] == "2")
            {
                danhmucDAL ds = new danhmucDAL();
                ds.id_danhmuc = rd.GetInt32(0);
                ds.ten_danhmuc = rd.GetString(1);
                ds.groupdanhmuc = Math.Round(rd.GetDouble(2));
                list.Add(ds);
            }

        }
        return list;
        cmd.Dispose();
        cn.Close();
    }
    // lay id danh muc:
    public int getIdDanhMucbyName(string ten)
    {
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT id_danhmuc FROM danhmuc WHERE ten_danhmuc = N'"+ten+"' ";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();
    }
    public List<danhmucDAL> getDanhMucbyId(int id)
    {
        List<danhmucDAL> list = new List<danhmucDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM danhmuc WHERE id_danhmuc = " + id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            danhmucDAL ds = new danhmucDAL();
            ds.id_danhmuc = rd.GetInt32(0);
            ds.ten_danhmuc = rd.GetString(1);
            ds.groupdanhmuc = rd.GetDouble(2);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // kiem tra trung lap:
    public bool kiemtraTrungLap(string ten)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT ten_danhmuc FROM danhmuc";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            if (ten == rd.GetString(0))
            {
                tf = true;
                break;
            }
        }
        return tf;
        cmd.Dispose();
        cn.Close();
    }

    // lay gia tri group lon nhat:
    public int grMax()
    {
        int va = -1;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT TOP (1) groupdanhmuc FROM danhmuc ORDER BY groupdanhmuc DESC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            va = Convert.ToInt32(Math.Round(rd.GetDouble(0), 0));
        }
        return va;
        cmd.Dispose();
        cn.Close();
    }
    // sua danh muc

    public bool danhmucadd(string ten)
    {
        bool tf = false;
        double gr = grMax() + 1.1;
        string sql = "INSERT INTO danhmuc(ten_danhmuc, groupdanhmuc) VALUES(N'" + ten + "'," + gr + ")";
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

    // them danh muc
    public bool danhmucedit(int id, string ten)
    {
        bool tf = false;
        string sql = "UPDATE danhmuc SET ten_danhmuc=N'" + ten + "' WHERE id_danhmuc =" + id;
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

    // sua danh muc con
    public bool danhmucedit(int id, string ten,double gr)
    {
        bool tf = false;
        string sql = "UPDATE danhmuc SET ten_danhmuc=N'" + ten + "', groupdanhmuc="+gr+" WHERE id_danhmuc =" + id;
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

    // them danh muc con

    public bool danhmucconadd(string ten,double gr)
    {
        bool tf = false;
        string sql = "INSERT INTO danhmuc(ten_danhmuc, groupdanhmuc) VALUES(N'" + ten + "'," + gr + ")";
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


    public bool del(string id)
    {
        bool tf = false;
        string sql = "DELETE FROM danhmuc WHERE id_danhmuc IN("+id+")";
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