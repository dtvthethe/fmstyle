<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="quangcaoadd.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thêm quảng cáo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <td>Tên:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" MaxLength="100" Width="200px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tên không được để trống." ForeColor="Red" ControlToValidate="txtTen"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>Link:</td>
            <td>
                <asp:TextBox ID="txtLink" runat="server" MaxLength="200" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Link không được để trống." ForeColor="Red" ControlToValidate="txtLink"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Hình ảnh:</td>
            <td>
                <asp:FileUpload ID="fileHinh" runat="server" /><asp:Label ID="lbErrorPic" ForeColor="Red" runat="server" Text="(Chỉ chấp nhận đôi mở rộng của ảnh là *.png, *.jpg)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Trạng thái:</td>
            <td>
                <asp:RadioButton ID="rbYes" GroupName="tt" runat="server" Text="Bật" />
                <asp:RadioButton ID="rbNo" GroupName="tt" runat="server" Text="Tắt" Checked="true" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLuu" runat="server" Text="Thêm quảng cáo" OnClick="btnLuu_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

