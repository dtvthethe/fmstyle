<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="nguoidungdoimk.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td style="width: 164px">Mật khẩu mới:</td>
            <td>
                <asp:TextBox ID="txtMK1" runat="server" MaxLength="100" TextMode="Password" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Mật khẩu không được để trống." ForeColor="Red" ControlToValidate="txtMK1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 164px">Nhập lại mật khẩu mới:</td>
            <td>
                <asp:TextBox ID="txtMK2" runat="server" MaxLength="100" TextMode="Password" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mật khẩu không được để trống." ForeColor="Red" ControlToValidate="txtMK2" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtMK1" ControlToValidate="txtMK2" Display="Dynamic" ErrorMessage="Mật khẩu không chính xác." ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 164px"></td>
            <td>
                <asp:Button ID="btnDoiMK" runat="server" Text="Đổi mật khẩu" OnClick="btnDoiMK_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 164px"></td>
            <td>
                <asp:Label ID="lbError" runat="server" ForeColor="Red" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

