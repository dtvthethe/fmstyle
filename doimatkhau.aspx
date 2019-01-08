<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="doimatkhau.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Đổi mật khẩu
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a style="color:#01c4c4" href="Default.aspx">Trang chủ</a>/ Đổi mật khẩu</h4>
    <div class="title">
        <h3 class="title-names">Đổi mật khẩu</h3>
    </div>
    <fieldset style="margin: 70px auto; border-radius: 7px; border: 1px solid #01c4c4; width: 400px">
        <legend style="color: #01c4c4; font-weight: bold; margin-left: 15px">Đăng ký tài khoản người dùng !</legend>

        <table style="margin: 20px auto; height: 152px;">
            <tr>
                <td style="width: 160px">Mật khẩu cũ (<span style="color: red">*</span>):</td>
                <td>
                    <asp:TextBox ID="txtmk" runat="server" Height="29px" Width="200px" TextMode="Password" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="rfvMK" runat="server" ErrorMessage="Mật khẩu cũ không được để trống!" Display="Dynamic" ControlToValidate="txtmk">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 160px">Mật khẩu mới (<span style="color: red">*</span>):</td>
                <td>
                    <asp:TextBox ID="txtmk1" runat="server" Height="29px" Width="200px" TextMode="Password" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="rfvMK1" runat="server" ErrorMessage="Mật khẩu mới không được để trống!" Display="Dynamic" ControlToValidate="txtmk1">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td style="width: 160px">Nhập lại mật khẩu mới (<span style="color: red">*</span>):</td>
                <td>
                    <asp:TextBox ID="txtmk2" runat="server" Height="29px" Width="200px" TextMode="Password" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="rfvMK2" runat="server" ErrorMessage="Mật khẩu mới không được để trống!" Display="Dynamic" ControlToValidate="txtmk2">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" Text="*" runat="server" ErrorMessage="Mật khẩu không chính xác !" ControlToValidate="txtmk2" ControlToCompare="txtmk1"></asp:CompareValidator>
                     </td>
            </tr>
            <tr>
                <td style="width: 160px"></td>
                <td>
                    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 160px"></td>
                <td>
                    <asp:Button ID="btndoimatkhau" runat="server" Text="Đổi mật khẩu" OnClick="btndoimatkhau_Click" />
                </td>
            </tr>

        </table>
    </fieldset>
</asp:Content>

