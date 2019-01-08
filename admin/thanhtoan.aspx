<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="thanhtoan.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Trạng thái giao hàng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 145px">
                Trạng thái giao hàng:
            </td>
            <td>
                <asp:RadioButton ID="rbYes" GroupName="rbacc" runat="server" Text="Đã thanh toán" />
                <asp:RadioButton ID="rbNo" GroupName="rbacc" runat="server" Text="Chưa thanh toán" />
                <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
            </td>
            <td>
                <asp:Label ID="lbHinh" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnHinhKhac" runat="server" Text="Hình khác" OnClick="btnHinhKhac_Click" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                Mã xác thực:
            </td>
            <td>
                <asp:TextBox ID="txtXacNhan" runat="server" MaxLength="10" Width="200px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtXacNhan" Display="Dynamic" ErrorMessage="Mã xác thực không được để trống !" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 145px"></td>
            <td>
                <asp:Button ID="btnThanhToan" runat="server" Text="Thanh toán" OnClientClick="return confirm('Bạn có muốn thanh toán cho đơn hàng này không?');" OnClick="btnThanhToan_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

