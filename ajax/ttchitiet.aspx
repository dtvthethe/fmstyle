<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ttchitiet.aspx.cs" Inherits="ajax_ttchitiet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <asp:Repeater ID="rpDatHang" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("hinhanh") %>
                        </td>
                        <td>
                            <a href="sanphamedit.aspx?id=<%# Eval("id_sanpham") %>"><%# Eval("ten_sanpham")%></a>
                        </td>
                        <td><%# Eval("soluong") %></td>
                        <td><%# Eval("size") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
