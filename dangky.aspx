<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="dangky.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Đăng ký tài khoản
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a  style="color:#01c4c4" href="Default.aspx">Trang chủ</a>/ Đăng ký tài khoản</h4>
    <div class="title">
        <h3 class="title-names">Đăng ký tài khoản</h3>
    </div>
    <fieldset style="margin: 70px auto; border-radius:7px; border: 1px solid #01c4c4;width: 400px">
        <legend style="color:#01c4c4; font-weight:bold; margin-left:15px">Đăng ký tài khoản người dùng</legend>
        <table style="padding: 20px 30px; width: 392px; height: 409px;">
            <tr>
                <td class="hinhGioHang" style="width: 728px; height: 23px;"></td>
                <td style="width: 292px; height: 23px; color:red">
                    " * " Là trường bắt buộc phải nhập!
                </td>
            </tr>
            <tr>
                <td class="hinhGioHang" style="width: 728px; height: 48px;">Tên đăng nhập (<span style="color:red">*</span>):</td>
                <td style="width: 292px; height: 48px;">
                    <asp:TextBox ID="txtTK" runat="server" MaxLength="30" Height="29px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="rfvTK" runat="server" ErrorMessage="Tên đăng nhập không được để trống." ControlToValidate="txtTK" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="td-right-tbLienHe" style="width: 728px">Mật khẩu (<span style="color:red">*</span>):</td>
                <td style="width: 292px">
                    <asp:TextBox ID="txtMK1" type="password" runat="server" MaxLength="100" Height="29px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="rfvMK" runat="server" ErrorMessage="Mật khẩu không được để trống." ControlToValidate="txtMK1" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="td-right-tbLienHe" style="width: 728px">Nhập lại mật khẩu (<span style="color:red">*</span>):</td>
                <td style="width: 292px">
                    <asp:TextBox ID="txtMK2" type="password" runat="server" MaxLength="100" Height="29px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMK2" ForeColor="Red" runat="server" ErrorMessage="Mật khẩu không được để trống." ControlToValidate="txtMK2" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ForeColor="Red" ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu không chính xác !" ControlToValidate="txtMK2" ControlToCompare="txtMK1" Display="Dynamic">*</asp:CompareValidator>
                    </td>
            </tr>
            <tr>
                <td class="td-right-tbLienHe" style="width: 728px">Họ và tên (<span style="color:red">*</span>):</td>
                <td style="width: 292px">
                    <asp:TextBox ID="txtHoTen" runat="server" MaxLength="100" Height="29px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="rfvTen" runat="server" ErrorMessage="Họ tên không được để trống." ControlToValidate="txtHoTen" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="td-right-tbLienHe" style="width: 728px">Số điện thoại:</td>
                <td style="width: 292px">
                    <asp:TextBox ID="txtDT" runat="server" MaxLength="11" Height="29px" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDT" Display="Dynamic" ErrorMessage="Đây không phải là số điện thoại !" ForeColor="Red" ValidationExpression="^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*[-\/\.]?\s*(\d{3})\s*[-\/\.]?\s*(\d{5})\s*(([xX]|[eE][xX][tT])\.?\s*(\d+))*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="td-right-tbLienHe" style="width: 728px; height: 55px;">Email (<span style="color:red">*</span>):</td>
                <td style="width: 292px; height: 55px;">
                    <asp:TextBox ID="txtEmail" runat="server" Height="29px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="rfvEmail" runat="server" ErrorMessage="Email không được để trống." ControlToValidate="txtEmail" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Đây không phải là địa chỉ email !" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
            </tr>
            <tr>
                <td class="td-right-tbLienHe" style="width: 728px">Địa chỉ (<span style="color:red">*</span>):</td>
                <td style="width: 292px">
                    <asp:TextBox ID="txtDiaChi" runat="server" MaxLength="100" Height="29px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="rfvDiaChi" runat="server" ErrorMessage="Địa chỉ không được để trống." ControlToValidate="txtDiaChi" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="td-right-tbLienHe" style="width: 728px"></td>
                <td style="width: 292px">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    <asp:Button ID="btnDangKy" runat="server" Text="Đăng ký" OnClick="btnDangKy_Click" Height="22px" Width="107px" />

                </td>
            </tr>
            <tr>
                <td class="td-right-tbLienHe" style="width: 728px"></td>
                <td style="width: 292px">
                   <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            
        </table>
    </fieldset>
</asp:Content>

