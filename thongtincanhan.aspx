<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="thongtincanhan.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thông tin cá nhân
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a href="Default.aspx" style="color: #01c4c4">Trang chủ</a>/ Thông tin cá nhân</h4>
    <div class="title">
        <h3 class="title-names">Thông tin cá nhân</h3>
    </div>
    <div class="clr"></div>
    <fieldset style="margin: 70px auto; border-radius: 7px; border: 1px solid #01c4c4; width: 400px">
        <legend style="color: #01c4c4; font-weight: bold; margin-left: 15px">Thông tin cá nhân</legend>
        <table style="height: 296px; width: 458px; margin: 20px">

            <tr>
                <td style="width: 125px; height: 35px">Tên đăng nhập:</td>
                <td class="space" style="height: 35px">
                    <asp:Label ID="lbTK" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 34px">Mật khẩu:</td>
                <td class="space" style="height: 34px">
                    <a href="doimatkhau.aspx" title="Đổi mật khẩu">Đổi mật khẩu</a>
                </td>
            </tr>
            <tr>
                <td style="width: 125px">Họ và tên (<span style="color: red">*</span>):</td>
                <td>
                    <asp:TextBox ID="txtHoTen" runat="server" Height="29px" Width="300px" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTen" runat="server" ErrorMessage="Tên không được để trống !" ForeColor="Red" Text="*" ControlToValidate="txtHoTen" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 125px">Số điện thoại:</td>
                <td>
                    <asp:TextBox ID="txtSDT" runat="server" Height="29px" Width="300px" MaxLength="11"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="Đây không phải là số điện thoại !" ForeColor="Red" ValidationExpression="^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*[-\/\.]?\s*(\d{3})\s*[-\/\.]?\s*(\d{5})\s*(([xX]|[eE][xX][tT])\.?\s*(\d+))*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 125px">Địa chỉ (<span style="color: red">*</span>):</td>
                <td>
                    <asp:TextBox ID="txtDiaChi" TextMode="MultiLine" runat="server" Width="300px" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Text="*" ErrorMessage="Địa chỉ không được để trống !" ControlToValidate="txtDiaChi" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 125px">Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Height="29px" Width="300px" MaxLength="100"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Đây không phải là địa chỉ email !" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 125px"></td>
                <td>
                    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 31px"></td>
                <td class="space">
                    <asp:Button ID="btnCapNhat" runat="server" ToolTip="Cập nhật" Text="Cập nhật" OnClick="btnCapNhat_Click" Height="29px" Width="101px" />
                </td>
            </tr>
            <tr>
                <td style="width: 125px"></td>
                <td>
                    <a href="lichsumua.aspx" title="Lịch sử mua hàng">Lịch sử mua hàng</a>
                </td>
            </tr>
        </table>
    </fieldset>

</asp:Content>

