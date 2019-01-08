<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="roleadd.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thêm quyền người dùng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <td style="width: 153px">Role:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Role không được để trống." ControlToValidate="txtTen" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:Label ID="lbRole" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 153px">Truy cập vào CMS:</td>
            <td>
                <asp:RadioButton ID="rbYes" GroupName="cms" runat="server" Text="Cho phép" />
                <asp:RadioButton ID="rbNo" GroupName="cms" Checked="true" runat="server" Text="Từ chối" />
            </td>
        </tr>
        <tr>
            <td style="width: 153px">Special:</td>
            <td>
                <asp:RadioButton ID="rbYess" GroupName="sp" runat="server" Text="Cho phép" />
                <asp:RadioButton ID="rbNos" GroupName="sp" Checked="true" runat="server" Text="Từ chối" />
            </td>
        </tr>
        <tr>
            <td style="width: 153px"></td>
            <td>
                <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" Width="68px" />
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

