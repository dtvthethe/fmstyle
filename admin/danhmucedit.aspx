<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="danhmucedit.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Sửa danh mục cha
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
     <table>

        <tr>
            <td style="width: 125px">Tên danh mục cha:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" MaxLength="100" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tên danh mục không được để trống !" ControlToValidate="txtTen" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 125px"></td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="Sửa danh mục" OnClick="btnEdit_Click"/>

            </td>
        </tr>
    </table>
</asp:Content>

