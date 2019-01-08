<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="phuongthucadd.aspx.cs" Inherits="admin_Default2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Thêm phương thức thanh toán
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <td>Tên phương thức:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" MaxLength="100" Width="200px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Tên phương thức không được để trống." ForeColor="Red" ControlToValidate="txtTen"></asp:RequiredFieldValidator>

                <asp:Label ID="lbTen" runat="server" ForeColor="Red"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>Chi tiết:</td>
            <td>
                <CKEditor:CKEditorControl ID="txtTT" runat="server"></CKEditor:CKEditorControl>
            </td>
        </tr>
         <tr>
            <td></td>
            <td>
                <asp:Button ID="btnThem" runat="server" Text="Thêm phương thức" OnClick="btnThem_Click"/>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

