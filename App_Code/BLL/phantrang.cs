using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for phantrang
/// </summary>
public class phantrang
{
    public phantrang()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string paging(int row, int show, string page, int current)
    {
        string firt = "<div style='clear: both'></div><ul>";
        string chuoi = "";
        string last = "</ul>";
        double trang = row / show;
        string pag = "";

        int soTrang = (int)Math.Ceiling(trang);
        int seCur = current / show;

        for (int i = 0; i <= soTrang; i++)
        {
            int numberview = i + 1;
            int numberPage = i * show;
            if (seCur == i)
            {
                chuoi += "<li class='lipt'> <a href='?p=" + numberPage + page + "' class='aptSe'>" + numberview + "</a></li>";
            }
            else
            {
                chuoi += "<li class='lipt'> <a href='?p=" + numberPage + page + "' class='apt'>" + numberview + "</a></li>";
            }
            
        }
        pag = firt + chuoi + last;

        return pag;
    }

    public string pagingpublic(int row, int show, string page,int current)
    {
        string firt = "<ul class='page'>";
        string chuoi = "";
        string last = "</ul>";
        double trang = row / show;
        string pag = "";

        int soTrang = (int)Math.Ceiling(trang);

        int seCur = current / show;

        for (int i = 0; i <= soTrang; i++)
        {
            int numberview = i + 1;
            int numberPage = i * show;
            if (seCur == i)
            {
                chuoi += "<li class=''> <a href='?p=" + numberPage + page + "' class='currentpage'>" + numberview + "</a></li>";              
            }
            else
            {
                chuoi += "<li class=''> <a href='?p=" + numberPage + page + "' class='pagea'>" + numberview + "</a></li>";
            }
            
        }
        pag = firt + chuoi + last;

        return pag;
    }
}


  

