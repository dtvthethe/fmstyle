using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dathangdetailBLL
/// </summary>
public class dathangdetailBLL
{
    public dathangdetailBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();
    // load danh sach san pham :

    public List<dathangdetail> getdathangDetail(int id_dathang)
    {
        List<dathangdetail> list = new List<dathangdetail>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT dat_hang_detail.id_dathang_detail,san_pham.hinhanh, "
            + "san_pham.gia, san_pham.ten_sanpham,dat_hang_detail.size,dat_hang_detail.soluong,dat_hang_detail.id_sanpham,san_pham.khuyenmai FROM  "
            + "dat_hang_detail,san_pham  WHERE dat_hang_detail.id_sanpham = san_pham.id_sanpham AND  "
            + "dat_hang_detail.id_dathang=" + id_dathang;

        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangdetail ds = new dathangdetail();
            ds.id_dathang_detail = rd.GetInt32(0);
            ds.hinhanh = "<img height='100' width='80' src=\"/uploads/" + rd.GetString(1) + "\"/>";
            ds.gia = rd.GetDecimal(2);
            ds.ten_sanpham = rd.GetString(3);
            ds.size = rd.GetString(4);
            ds.soluong = rd.GetInt32(5);
            ds.id_sanpham = rd.GetInt32(6);
            ds.khuyenmai = rd.GetBoolean(7);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // load danh sach san pham duoc mua nhieu:

    public List<dathangdetail> getdathangDetailMuaNhieu()
    {
        List<dathangdetail> list = new List<dathangdetail>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select SUM(dat_hang_detail.soluong) as soluong, dat_hang_detail.id_sanpham as idsp from dat_hang_detail group by dat_hang_detail.id_sanpham order by soluong DESC";

        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangdetail ds = new dathangdetail();
            ds.soluong = rd.GetInt32(0);
            ds.id_sanpham = rd.GetInt32(1);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // load danh sach san pham duoc mua nhieu:

    public List<dathangdetail> getdathangDetailMuaNhieuPubLic()
    {
        List<dathangdetail> list = new List<dathangdetail>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select TOP 10 SUM(dat_hang_detail.soluong) as soluong, dat_hang_detail.id_sanpham as idsp from dat_hang_detail group by dat_hang_detail.id_sanpham order by soluong DESC";

        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangdetail ds = new dathangdetail();
            ds.soluong = rd.GetInt32(0);
            ds.id_sanpham = rd.GetInt32(1);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // lay so luong mua 

    public int countMuaNhieuP()
    {
        List<dathangdetail> list = new List<dathangdetail>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select  dat_hang_detail.id_sanpham from dat_hang_detail group by dat_hang_detail.id_sanpham";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        int i = 0;
        while (rd.Read())
        {
            i++;
        }
        return i;
        cmd.Dispose();
        cn.Close();
    }

    // load danh sach san pham duoc mua nhieu:

    public List<dathangdetail> getdathangDetailMuaNhieuP(int row, int hide)
    {
        List<dathangdetail> list = new List<dathangdetail>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select TOP "+row+" SUM(dat_hang_detail.soluong) as soluong, dat_hang_detail.id_sanpham from dat_hang_detail"
                     +" where dat_hang_detail.id_sanpham not in(select top "+hide+" dat_hang_detail.id_sanpham from dat_hang_detail group by dat_hang_detail.id_sanpham order by SUM(dat_hang_detail.soluong) DESC)"
                     +" group by dat_hang_detail.id_sanpham order by SUM(dat_hang_detail.soluong) DESC";


        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            dathangdetail ds = new dathangdetail();
            ds.soluong = rd.GetInt32(0);
            ds.id_sanpham = rd.GetInt32(1);
            list.Add(ds);
        }
        return list;
        cmd.Dispose();
        cn.Close();
    }

    // xoa:
    public bool del(string id)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "DELETE FROM dat_hang_detail WHERE id_dathang IN(" + id + ")";
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
