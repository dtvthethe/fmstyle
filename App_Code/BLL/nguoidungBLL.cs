using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for nguoidungBLL
/// </summary>
public class nguoidungBLL
{
    public nguoidungBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private connect cnn = new connect();

    // lay thong tin nguoi dung:
    // lay thong tin cua tat ca nguoi dung
    public List<nguoidungDAL> getNguoiDungbyId(int id)
    {
        List<nguoidungDAL> list = new List<nguoidungDAL>();
        string sql = "SELECT * FROM nguoidung WHERE id_user=" + id;
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            nguoidungDAL ds = new nguoidungDAL();
            ds.id_user = rd.GetInt32(0);
            ds.username = rd.GetString(1);
            ds.password = rd.GetString(2);
            ds.hoten = rd.GetString(3);
            ds.sdt = rd.GetString(4);
            ds.diachi = rd.GetString(5);
            ds.role = rd.GetInt32(6);
            ds.email = rd.GetString(7);
            list.Add(ds);
        }
        cmd.Dispose();
        cn.Close();
        return list;
    }

    // lay thong tin cua tat ca nguoi dung
    public List<nguoidungDAL> getNguoiDung()
    {
        List<nguoidungDAL> list = new List<nguoidungDAL>();
        string sql = "SELECT * FROM nguoidung, role WHERE nguoidung.role = role.id_role";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            nguoidungDAL ds = new nguoidungDAL();
            ds.id_user = rd.GetInt32(0);
            ds.username = rd.GetString(1);
            ds.hoten = rd.GetString(3);
            ds.sdt = rd.GetString(4);
            ds.diachi = rd.GetString(5);
            ds.role = rd.GetInt32(6);
            ds.email = rd.GetString(7);
            ds.stringrole = rd.GetString(9);
            list.Add(ds);
        }
        cmd.Dispose();
        cn.Close();
        return list;
    }


    // lay thong tin cua tat ca nguoi dung
    public List<nguoidungDAL> getNguoiDungP(int row, int hide)
    {
        List<nguoidungDAL> list = new List<nguoidungDAL>();
        string sql = "select top " + row + " * from nguoidung, role where nguoidung.role = role.id_role AND id_user not in (select top " + hide + " id_user from nguoidung order by id_user DESC ) order by id_user DESC";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            nguoidungDAL ds = new nguoidungDAL();
            ds.id_user = rd.GetInt32(0);
            ds.username = rd.GetString(1);
            ds.hoten = rd.GetString(3);
            ds.sdt = rd.GetString(4);
            ds.diachi = rd.GetString(5);
            ds.role = rd.GetInt32(6);
            ds.email = rd.GetString(7);
            ds.stringrole = rd.GetString(9);
            list.Add(ds);
        }
        cmd.Dispose();
        cn.Close();
        return list;
    }

    // lay so luong tat ca nguoi dung
    public int countP()
    {
        string sql = "SELECT COUNT(*) FROM nguoidung";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();

    }

    // lay so luong tat ca nguoi dung
    public int countV(string role)
    {
        string sql = "SELECT COUNT(*) FROM nguoidung,role WHERE nguoidung.role = role.id_role AND role.role='" + role + "'";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();

    }

    // lay so luong tat ca nguoi dung
    public int countT(string noidung, string danhmuc)
    {
        string sql = "";
        if (danhmuc == "All")
        {
            sql = "select COUNT( *) from nguoidung, role where nguoidung.role = role.id_role  AND nguoidung.hoten LIKE N'%" + noidung + "%'";
        }
        else
        {
            sql = "select COUNT( *) from nguoidung, role where nguoidung.role = role.id_role AND role.role = N'" + danhmuc + "' AND nguoidung.hoten LIKE N'%" + noidung + "%'";
        }
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();
        return rd.GetInt32(0);
        cmd.Dispose();
        cn.Close();

    }

    //view

    public List<nguoidungDAL> getNguoiDungV(int row, int hide, string role)
    {
        List<nguoidungDAL> list = new List<nguoidungDAL>();

        string sql = "select top " + row + " * from nguoidung, role where nguoidung.role = role.id_role AND role.role = '" + role + "' AND id_user not in (select top " + hide + " id_user from nguoidung order by id_user DESC ) order by id_user DESC";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            nguoidungDAL ds = new nguoidungDAL();
            ds.id_user = rd.GetInt32(0);
            ds.username = rd.GetString(1);
            ds.hoten = rd.GetString(3);
            ds.sdt = rd.GetString(4);
            ds.diachi = rd.GetString(5);
            ds.role = rd.GetInt32(6);
            ds.email = rd.GetString(7);
            ds.stringrole = rd.GetString(9);
            list.Add(ds);
        }
        cmd.Dispose();
        cn.Close();
        return list;
    }

    //view

    public List<nguoidungDAL> getNguoiDungT(int row, int hide, string noidung, string danhmuc)
    {
        string sql = "";
        List<nguoidungDAL> list = new List<nguoidungDAL>();

        if (danhmuc == "All")
        {
            sql = "select top " + row + " * from nguoidung, role where nguoidung.role = role.id_role  AND nguoidung.hoten LIKE N'%" + noidung + "%' AND id_user not in (select top " + hide + " id_user from nguoidung order by id_user DESC ) order by id_user DESC";
        }
        else
        {
            sql = "select top " + row + " * from nguoidung, role where nguoidung.role = role.id_role AND role.role = N'" + danhmuc + "' AND nguoidung.hoten LIKE N'%" + noidung + "%' AND id_user not in (select top " + hide + " id_user from nguoidung order by id_user DESC ) order by id_user DESC";
        }
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            nguoidungDAL ds = new nguoidungDAL();
            ds.id_user = rd.GetInt32(0);
            ds.username = rd.GetString(1);
            ds.hoten = rd.GetString(3);
            ds.sdt = rd.GetString(4);
            ds.diachi = rd.GetString(5);
            ds.role = rd.GetInt32(6);
            ds.email = rd.GetString(7);
            ds.stringrole = rd.GetString(9);
            list.Add(ds);
        }
        cmd.Dispose();
        cn.Close();
        return list;
    }
    // dang nhap
    public List<nguoidungDAL> dangNhap(string tk, string mk)
    {

        List<nguoidungDAL> list = new List<nguoidungDAL>();
        string sql = "SELECT * FROM nguoidung WHERE username = '" + tk + "' AND password = '" + mk + "'";
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            nguoidungDAL ds = new nguoidungDAL();
            ds.id_user = rd.GetInt32(0);
            ds.username = rd.GetString(1);
            ds.hoten = rd.GetString(3);
            ds.sdt = rd.GetString(4);
            ds.diachi = rd.GetString(5);
            ds.role = rd.GetInt32(6);
            ds.email = rd.GetString(7);
            list.Add(ds);
        }
        cmd.Dispose();
        cn.Close();
        return list;
    }

    // quen mat khau:
    public int quenMatKhau(string tk, string email)
    {
        int id = 0;
        List<nguoidungDAL> list = new List<nguoidungDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT * FROM nguoidung WHERE username= '" + tk + "' AND email = '" + email + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            id = rd.GetInt32(0);
        }

        return id;
        cmd.Dispose();
        cn.Close();
    }

    //quen mat khau- doi mat khau:
    public bool qenMatKhau_doiMatKhau(string mk, int id)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "UPDATE nguoidung SET password = '" + mk + "' WHERE id_user=" + id + "";
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        try
        {
            cmd.ExecuteNonQuery();
            tf = true;
        }
        catch (Exception ex)
        {
            tf = false;
        }
        return tf;
    }

    // kiem tra tinh duy nhat:
    // tai khoan:
    public bool uniqueTK(string tk)
    {
        int id = 0;
        bool tf = false;
        List<nguoidungDAL> list = new List<nguoidungDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT username FROM nguoidung WHERE username = '"+tk+"'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            id++;
        }
        if (id > 0)
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

    // email:

    public bool uniqueEmail(string email)
    {
        int id = 0;
        bool tf = false;
        List<nguoidungDAL> list = new List<nguoidungDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "SELECT email FROM nguoidung WHERE email = '"+email+"'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            id++;
        }
        if (id > 0)
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

    // email tt nguoi dung:

    public bool uniqueEmailtt(string email, int id)
    {
        bool tf = false;
        List<nguoidungDAL> list = new List<nguoidungDAL>();
        SqlConnection cn = cnn.connectToSql();
        cn.Open();
        string sql = "select COUNT(*) from nguoidung where email = '" + email + "' and id_user != "+id;
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
    
    // dang ky

    public bool dangKy(string username, string pass, string hoten, string sdt, string diachi, string email)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "INSERT INTO nguoidung (username, password, hoten, sdt, diachi, role, email) VALUES('" + username + "','" + pass + "',N'" + hoten + "','" + sdt + "',N'" + diachi + "',3,'" + email + "')";
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        try
        {
            cmd.ExecuteNonQuery();
            tf = true;
        }
        catch (Exception ex)
        {
            tf = false;
        }
        return tf;
    }

    // them nguoi dung

    public bool add(string username, string pass, string hoten, string sdt, string diachi, string email, int role)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "INSERT INTO nguoidung (username, password, hoten, sdt, diachi, role, email) VALUES('" + username + "','" + pass + "',N'" + hoten + "','" + sdt + "',N'" + diachi + "'," + role + ",'" + email + "')";
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);
        try
        {
            cmd.ExecuteNonQuery();
            tf = true;
        }
        catch (Exception ex)
        {
            tf = false;
        }
        return tf;
    }

    // sua nguoi dung:

    public bool suanguoidung(int id, string hoten, string sdt, string diachi, int role, string email)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "UPDATE nguoidung SET hoten=N'" + hoten + "', sdt='" + sdt + "', diachi = N'" + diachi + "',role = " + role + ", email = '" + email + "' WHERE id_user=" + id + "";
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

    // xac thuc doi mat khau:

    public bool xacthuc(string mk, int id)
    {
        int i = 0;
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "SELECT * FROM nguoidung WHERE id_user = " + id + " AND password='" + mk + "'";
        cn.Open();
        SqlCommand cmd = new SqlCommand(sql, cn);

        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            i++;
        }

        if (i == 1)
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

    // doi thong tin ca nhan:

    public bool updateTTcaNhan(int id, string hoten, string sdt, string diachi, string email)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "UPDATE nguoidung SET hoten=N'" + hoten + "', sdt='" + sdt + "', diachi = N'" + diachi + "', email = '" + email + "' WHERE id_user=" + id + "";
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

    public bool del(string id_user)
    {
        bool tf = false;
        SqlConnection cn = cnn.connectToSql();
        string sql = "DELETE FROM nguoidung WHERE id_user IN("+id_user+")";
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