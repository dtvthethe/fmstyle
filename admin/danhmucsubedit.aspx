<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="danhmucsubedit.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Sửa danh mục con
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
     <table>

        <tr>
            <td style="width: 131px">Tên danh mục con:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" MaxLength="100" Width="200px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTen" Display="Dynamic" ErrorMessage="Tên danh mục không được để trống !" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
         <tr>
            <td style="width: 131px">Thuộc danh mục:</td>
            <td>
                <asp:DropDownList ID="ddlDM" runat="server"></asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td style="width: 131px"></td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="Sửa danh mục" OnClick="btnEdit_Click"/>

            </td>
        </tr>
    </table>
</asp:Content>

