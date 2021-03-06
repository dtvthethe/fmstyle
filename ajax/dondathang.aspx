﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dondathang.aspx.cs" Inherits="ajax_doanhthu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="overflow:auto;height: 450px">

            <div class="tool">
                <asp:Label ID="lbSum" runat="server" Text=""></asp:Label>
            </div>
            <table>
                <tbody>
                    <tr>
                        <th class="stt">STT</th>
                        <th class="">Ngày đặt hàng</th>
                        <th class="">Tổng tiền</th>
                    </tr>
                    <asp:Repeater ID="rpDatHang" runat="server">
                        <ItemTemplate>
                            <tr>

                                <td>
                                    <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label>
                                </td>

                                <td><%# Eval("ngaydang") %></td>
                                <td>
                                    <asp:Label ID="lbTongTien" runat="server" Text=""></asp:Label>
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
