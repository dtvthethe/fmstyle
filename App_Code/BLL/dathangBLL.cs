using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dathangBLL
/// </summary>
public class dathangBLL
{
    public dathangBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private connect cnn = new connect();

    // lay don dathang:

    public List<dathangDAL> getDathang()
    {
        List<dathangDAL> list = new List<dathangDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM  dat_hang";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangDAL ds = new dathangDAL();
            ds.id_dathang = rd.GetInt32(0);
            ds.id_user = rd.GetInt32(1);
            ds.id_pt = rd.GetInt32(2);
            ds.trangthai = rd.GetBoolean(3);
            ds.ngaydang = rd.GetDateTime(4);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // lay don dathang doanh thu:

    public List<dathangDAL> getDathangdoanhthu(string y)
    {
        List<dathangDAL> list = new List<dathangDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM  dat_hang where trang_thai ='"+y+"'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangDAL ds = new dathangDAL();
            ds.id_dathang = rd.GetInt32(0);
            ds.id_user = rd.GetInt32(1);
            ds.id_pt = rd.GetInt32(2);
            ds.trangthai = rd.GetBoolean(3);
            ds.ngaydang = rd.GetDateTime(4);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // lay don dathang:

    public List<dathangDAL> getDathangP(int row, int hide,string view)
    {
        List<dathangDAL> list = new List<dathangDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "";
        if (view != "")
        {
             sql = "select top " + row + " * from dat_hang where trang_thai= '"+view+"' AND id_dathang not in (select top " + hide + " id_dathang from dat_hang order by id_dathang DESC ) order by id_dathang DESC";
        }
        else
        {
             sql = "select top " + row + " * from dat_hang where id_dathang not in (select top " + hide + " id_dathang from dat_hang order by id_dathang DESC ) order by id_dathang DESC";
        }
        
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangDAL ds = new dathangDAL();
            ds.id_dathang = rd.GetInt32(0);
            ds.id_user = rd.GetInt32(1);
            ds.id_pt = rd.GetInt32(2);
            ds.trangthai = rd.GetBoolean(3);
            ds.ngaydang = rd.GetDateTime(4);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

        // lay don dathang doanh thu:

    public List<dathangDAL> getDathangthanhtoan()
    {
        List<dathangDAL> list = new List<dathangDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select nguoidung.hoten, dat_hang.ngaydathang from dat_hang, nguoidung  where nguoidung.id_user = dat_hang.id_user and dat_hang.trang_thai = 'false'  order by ngaydathang ASC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangDAL ds = new dathangDAL();
            ds.ten = rd.GetString(0);
            ds.ngaydang = rd.GetDateTime(1);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }
    
    // so luong dathang
    public int countP(string view)
    {
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "";
        if (view != "")
        {
            sql = "SELECT COUNT(*) FROM  dat_hang WHERE trang_thai= '"+view+"'";
        }
        else
        {
            sql = "SELECT COUNT(*) FROM  dat_hang";
        }
        
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();
    }
    // so luong hang chua xu ly:

    public int dangXuLy()
    {
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT COUNT(*) FROM  dat_hang WHERE trang_thai='false'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();
    }

    // lay cap nhat trangthai don hang:


    public bool ttDonHang(int id, string tt)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "UPDATE dat_hang SET trang_thai = '"+tt+"' WHERE id_dathang = "+id;
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
        cmd.Dispose();
        cn.Close();
    }
    // lay don dathang:

    public List<dathangDAL> getDathangPublic(int id_user)
    {
        List<dathangDAL> list = new List<dathangDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM  dat_hang WHERE  id_user=" + id_user;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangDAL ds = new dathangDAL();
            ds.id_dathang = rd.GetInt32(0);
            ds.id_user = rd.GetInt32(1);
            ds.id_pt= rd.GetInt32(2);
            ds.trangthai = rd.GetBoolean(3);
            ds.ngaydang = rd.GetDateTime(4);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }
    // them don dat hang:
    public bool add_dathang(int id_user, int id_pt)
    {
        bool tf = false;
        DateTime ngaydathang = DateTime.Now;
        SqlConnection cn = cnn.connectToSql();
        string sql = "INSERT INTO dat_hang (id_user, id_pt, trang_thai, ngaydathang) VALUES(" + id_user + "," + id_pt + ",'false','" + ngaydathang + "')";
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

    // them don dat hang:
    public bool soluong_sp(int id_sp, int soluong)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "UPDATE san_pham SET soluong = "+soluong+" WHERE id_sanpham="+id_sp;
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


    // them don dat hang chi tiet:
    public bool add_dathang_detail(int id_sanpham, int id_dathang, int soluong, string size)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "INSERT INTO dat_hang_detail (id_sanpham, id_dathang, soluong, size) VALUES(" + id_sanpham + "," + id_dathang + "," + soluong + ",'" + size + "')";
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


    // lay id dat hang:

    public int id_dathang(int id_user)
    {
        string sql = "SELECT TOP 1 id_dathang FROM dat_hang WHERE id_user=" + id_user + " ORDER BY id_dathang DESC";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();
    }


    // xoa:
    public bool del(string id)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "DELETE FROM dat_hang WHERE id_dathang IN("+id+")";
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