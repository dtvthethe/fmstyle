<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="quenmatkhau.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Quên mật khẩu
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a style="color: #01c4c4" href="Default.aspx">Trang chủ</a>/ Quên mật khẩu</h4>
    <div class="title">
        <h3 class="title-names">Quên mật khẩu</h3>
    </div>
    <fieldset style="margin: 70px auto; border-radius: 7px; border: 1px solid #01c4c4; width: 400px">
        <legend style="color: #01c4c4; font-weight: bold; margin-left: 15px">Quên mật khẩu</legend>

        <table style="padding: 20px; height: 98px;">
            <tr>
                <td>Tên đăng nhập:</td>
                <td>
                    <asp:TextBox ID="txtTK" runat="server" Height="29px" MaxLength="30" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Text="*" ErrorMessage="Tên đăng nhập không được để trống !" ControlToValidate="txtTK"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Địa chỉ email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Height="29px" MaxLength="100" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Text="*" ErrorMessage="Email không được để trống" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Đây không phải là địa chỉ email !" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 14px"></td>
                <td style="height: 14px">
                    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label><br />
                    <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="space" style="height: 24px"></td>
                <td class="space" style="height: 24px">
                    <asp:Button ID="btnSubmit" runat="server" Text="Xác nhận" OnClick="btnSubmit_Click" />
                </td>
            </tr>

        </table>
    </fieldset>
</asp:Content>

