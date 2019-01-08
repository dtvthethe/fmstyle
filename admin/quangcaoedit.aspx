<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="quangcaoedit.aspx.cs" Inherits="admin_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thông tin quảng cáo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <td>Tên:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>Link:</td>
            <td>
                <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Hình ảnh:</td>
            <td>
                <asp:Label ID="lbHinh" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnXoaHinh" runat="server" Text="Xóa hình này" OnClientClick="return confirm('Bạn có muốn xóa hình này không ?')" OnClick="btnXoaHinh_Click" />
                <asp:FileUpload ID="fileHinh" runat="server" />
                <asp:Label ID="lbErrorPic" ForeColor="Red" runat="server" Text="(Chỉ chấp nhận đôi mở rộng của ảnh là *.png, *.jpg)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Trạng thái:</td>
            <td>
                <asp:RadioButton ID="rbYes" GroupName="tt" runat="server" Text="Bật" />
                <asp:RadioButton ID="rbNo" GroupName="tt" runat="server" Text="Tắt" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLuu" runat="server" Text="Lưu lại" OnClick="btnLuu_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

