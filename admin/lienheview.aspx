<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="lienheview.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Liên hệ chi tiết
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 141px">Họ và tên:</td>
            <td>
                <asp:Label ID="lbHoTen" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 141px">Email:</td>
            <td>
                <asp:Label ID="lbEmail" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 141px">Số điện thoại:</td>
            <td>
                <asp:Label ID="lbSDT" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 141px">Ngày gửi:</td>
            <td>
                <asp:Label ID="lbNgayGui" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color:#fff; border:1px solid">
                <asp:Label ID="lbNoidung" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
