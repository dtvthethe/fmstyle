<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dathanguser.aspx.cs" Inherits="ajax_dathanguser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tbLichSu">
            <tr>
                <th>STT</th>
                <th>Hình ảnh</th>
                <th>Tên sản phẩm</th>
                <th>Số lượng</th>
                <th>Size</th>
            </tr>
            <asp:Repeater ID="rpDatHang" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label></td>
                        <td>
                            <%# Eval("hinhanh") %>
                        </td>
                        <td>
                            <a href="../chitietsanpham.aspx?id=<%# Eval("id_sanpham") %>"><%# Eval("ten_sanpham")%></a>
                        </td>
                        <td><%# Eval("soluong") %></td>
                        <td><%# Eval("size") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="5">Tổng tiền:  
                    <asp:Label ID="lbTongTien" runat="server" Text=""></asp:Label>

                </td>

            </tr>
        </table>

    </form>
</body>
</html>
