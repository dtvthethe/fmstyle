<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="danhmucsubadd.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thêm danh mục con
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
    <table>

        <tr>
            <td style="width: 135px">Tên danh mục con:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" Width="200px" MaxLength="100"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTen" Display="Dynamic" ErrorMessage="Tên danh mục không được để trống !" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 135px">Thuộc danh mục:</td>
            <td>
                <asp:DropDownList ID="ddlDM" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 135px"></td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Thêm danh mục" OnClick="btnAdd_Click" />

            </td>
        </tr>
    </table>
</asp:Content>

