<%@ Page Language="C#" AutoEventWireup="true" CodeFile="khuyenmai.aspx.cs" Inherits="ajax_khuyenmai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="overflow: auto; height: 450px">
            <div class="tool">
                <asp:Label ID="lbSum" runat="server" Text=""></asp:Label>
            </div>
            <table>
                <tbody>
                    <tr>
                        <th class="stt">STT</th>
                        <th class="">Hình ảnh</th>
                        <th class="">Tên sản phẩm</th>

                    </tr>
                    <asp:Repeater ID="rpDatHang" runat="server">
                        <ItemTemplate>
                            <tr>

                                <td>
                                    <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <img width="70px" height="70px" src="../uploads/<%# Eval("hinhanh") %>" alt="" style="">
                                </td>
                                <td>
                                    <a href="../admin/sanphamedit.aspx?id=<%# Eval("id_sanpham") %>"><%# Eval("ten_sanpham") %></a>
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
