using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for sanphamBLL
/// </summary>
public class sanphamBLL
{
    public sanphamBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();

    // lay san pham:
    public List<sanphamDAL> getSanPham()
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM san_pham";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }


    public List<sanphamDAL> getSanPhamTonKho()
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select * from san_pham order by soluong desc";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    public List<sanphamDAL> getSanPhamP(int row, int hide, int danhmuc, string noidung, int view)
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "";
        if (view != -1)
        {
            sql = "select top " + row + "* from san_pham where id_danhmuc=" + view + " AND id_sanpham not in (select top " + hide + " id_sanpham from san_pham where id_danhmuc=" + view + " order by id_sanpham DESC ) order by id_sanpham DESC";
        }
        else if (danhmuc == 0 && noidung != "")
        {
            sql = "select top " + row + "* from san_pham where  ten_sanpham like N'%" + noidung + "%' AND id_sanpham not in (select top " + hide + " id_sanpham from san_pham where  ten_sanpham like N'%" + noidung + "%' order by id_sanpham DESC ) order by id_sanpham DESC";

        }
        else if (danhmuc != -1 && noidung != "")
        {
            sql = "select top " + row + "* from san_pham where id_danhmuc=" + danhmuc + " AND ten_sanpham like N'%" + noidung + "%' AND id_sanpham not in (select top " + hide + " id_sanpham from san_pham where id_danhmuc=" + danhmuc + " AND ten_sanpham like N'%" + noidung + "%' order by id_sanpham DESC ) order by id_sanpham DESC";

        }
        else
        {
            sql = "select top " + row + "* from san_pham where ten_sanpham like N'%" + noidung + "%' AND id_sanpham not in (select top " + hide + " id_sanpham from san_pham where ten_sanpham like N'%" + noidung + "%' order by id_sanpham DESC ) order by id_sanpham DESC";
        }

        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    public int countP(int danhmuc, string noidung, int view)
    {
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "";
        if (view != -1)
        {
            sql = "SELECT COUNT(*) FROM san_pham WHERE id_danhmuc = " + view;
        }
        else if (danhmuc == 0 && noidung != "")
        {
            sql = "SELECT COUNT(*) FROM san_pham WHERE ten_sanpham LIKE N'%" + noidung + "%'";
        }
        else if (danhmuc != -1 && noidung != "")
        {
            sql = "SELECT COUNT(*) FROM san_pham WHERE id_danhmuc=" + danhmuc + " AND ten_sanpham LIKE N'%" + noidung + "%'";
        }
        else
        {
            sql = "SELECT COUNT(*) FROM san_pham";
        }

        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();
    }

    // lay san pham kuyen mai:
    public List<sanphamDAL> getSanPhamKMP(int hide, int row)
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select top "+row+" * from san_pham where khuyenmai = 'true' AND id_sanpham not in (select top "+hide+" id_sanpham from san_pham where khuyenmai = 'true' order by id_sanpham DESC ) order by id_sanpham DESC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }
    // lay so luong san pham khuyen mai:
    public int countKMP()
    {
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "";

        sql = "SELECT COUNT(*) FROM san_pham WHERE khuyenmai = 'true'";

        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();
    }

    // lay san pham  theo danh muc
    public List<sanphamDAL> getSanPhambyId(int id)
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM san_pham WHERE id_danhmuc = " + id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // lay san pham  theo danh muc co phan trang
    public List<sanphamDAL> getSanPhambyIdP(int id, int row, int hide)
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select top " + row + " * from san_pham where id_danhmuc=" + id + " AND id_sanpham not in (select top " + hide + " id_sanpham from san_pham where id_danhmuc=" + id + " order by id_sanpham DESC ) order by id_sanpham DESC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // load 10 san pham moi nhat

    public List<sanphamDAL> getSanPhamMoi()
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT  TOP 10 * FROM san_pham ORDER BY id_sanpham DESC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // load 10 san pham moi khuyen mai

    public List<sanphamDAL> getSanPhamKhuyenMai()
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT  TOP 10 * FROM san_pham WHERE khuyenmai = 1 ORDER BY id_sanpham DESC";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // thong ke san pham khuyen mai

    public List<sanphamDAL> getSanPhamKhuyenMaiAD()
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT  * FROM san_pham WHERE khuyenmai = 1";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }
    // load thong tin chi tiet 1 san pham:
    public List<sanphamDAL> getSPbyId(int id)
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM san_pham WHERE id_sanpham = " + id;
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.soluong = rd.GetInt32(2);
            ds.hinhanh = rd.GetString(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.tt_chitiet = rd.GetString(5);
            ds.ngaydang = rd.GetDateTime(6);
            ds.gia = rd.GetDecimal(7);
            ds.khuyenmai = rd.GetBoolean(8);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }


    // load sanpham khuyen mai:
    public List<sanphamDAL> getSPkhuyenmai()
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT id_sanpham, ten_sanpham, hinhanh FROM san_pham WHERE khuyenmai = 'true' order by id_sanpham desc";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.hinhanh = rd.GetString(2);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // tim kiem

    public List<sanphamDAL> timkiem(string column, string value)
    {
        List<sanphamDAL> list = new List<sanphamDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "";

        if (column == "Tất cả")
        {
            sql = "SELECT san_pham.id_sanpham, san_pham.ten_sanpham, san_pham.hinhanh, san_pham.gia, danhmuc.id_danhmuc AS iddanhmuc, san_pham.khuyenmai FROM danhmuc INNER JOIN san_pham ON danhmuc.id_danhmuc = san_pham.id_danhmuc WHERE (san_pham.ten_sanpham LIKE N'%" + value + "%')";
        }
        else
        {
            sql = "SELECT san_pham.id_sanpham, san_pham.ten_sanpham, san_pham.hinhanh, san_pham.gia, danhmuc.id_danhmuc AS iddanhmuc, san_pham.khuyenmai FROM danhmuc INNER JOIN san_pham ON danhmuc.id_danhmuc = san_pham.id_danhmuc WHERE (danhmuc.ten_danhmuc = N'" + column + "') AND (san_pham.ten_sanpham LIKE N'%" + value + "%')";
        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            sanphamDAL ds = new sanphamDAL();
            ds.id_sanpham = rd.GetInt32(0);
            ds.ten_sanpham = rd.GetString(1);
            ds.hinhanh = rd.GetString(2);
            ds.gia = rd.GetDecimal(3);
            ds.id_danhmuc = rd.GetInt32(4);
            ds.khuyenmai = rd.GetBoolean(5);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // them san pham:

    public bool add(string ten, int soluong, string hinh, int id, string chitiet, decimal gia, string km)
    {

        bool tf = false;
        DateTime ngaydang = DateTime.Now;
        string sql = "INSERT INTO san_pham (ten_sanpham ,soluong ,hinhanh ,id_danhmuc ,tt_chitiet ,ngaydang ,gia ,khuyenmai) VALUES (N'" + ten + "'," + soluong + ",'" + hinh + "'," + id + ",N'" + chitiet + "','" + ngaydang + "'," + gia + ",'" + km + "')";

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


    // load sanpham khuyen mai:
    public bool check(string ten)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT COUNT(*) FROM san_pham WHERE ten_sanpham= N'"+ten+"'";
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
    // load sanpham khuyen mai:
    public bool check(string ten, int id)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT COUNT(*) FROM san_pham WHERE ten_sanpham= N'" + ten + "' AND id_sanpham !="+id;
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

    // sua san pham:

    public bool edit(string ten, int soluong, string hinh, int id, string chitiet, decimal gia, string km, int id_sp)
    {

        bool tf = false;
        DateTime ngaydang = DateTime.Now;

        string sql = "UPDATE san_pham SET ten_sanpham=N'" + ten + "', soluong = " + soluong + ", hinhanh = '" + hinh + "',id_danhmuc = " + id + ", tt_chitiet = N'" + chitiet + "', ngaydang = '" + ngaydang + "', gia = " + gia + ", khuyenmai = '" + km + "' WHERE id_sanpham= " + id_sp + " ";
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

    // cap nhat khuyen mai:
    public bool suaKhuyenMai(string tr, int id_sp)
    {

        bool tf = false;
        DateTime ngaydang = DateTime.Now;

        string sql = "UPDATE san_pham SET khuyenmai = '" + tr + "' WHERE id_sanpham= " + id_sp + " ";
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

    public bool delHinh(string hinh, int id_sp)
    {

        bool tf = false;
        DateTime ngaydang = DateTime.Now;

        string sql = "UPDATE san_pham SET hinhanh = '" + hinh + "' WHERE id_sanpham= " + id_sp + " ";
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

    //xoa
    public bool del(string id_sp)
    {

        bool tf = false;
        string sql = "DELETE FROM san_pham Where id_sanpham IN (" + id_sp + ")";
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

