<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="roleedit.aspx.cs" Inherits="admin_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thông tin quyền người dùng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <td style="width: 133px">Role:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTen" Display="Dynamic" ErrorMessage="Role không được để trống." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:Label ID="lbRole" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 133px">Truy cập vào CMS:</td>
            <td>
                <asp:RadioButton ID="rbYes" GroupName="cms" runat="server" Text="Cho phép" />
                <asp:RadioButton ID="rbNo" GroupName="cms" runat="server" Text="Từ chối" />
            </td>
        </tr>
        <tr>
            <td style="width: 133px">Special:</td>
            <td>
                <asp:RadioButton ID="rbYess" GroupName="sp" runat="server" Text="Cho phép" />
                <asp:RadioButton ID="rbNos" GroupName="sp"  runat="server" Text="Từ chối" />
            </td>
        </tr>
        <tr>
            <td style="width: 133px"></td>
            <td>
                <asp:Button ID="btnSua" runat="server" Text="Lưu lại" OnClick="btnSua_Click" Width="75px" />
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

