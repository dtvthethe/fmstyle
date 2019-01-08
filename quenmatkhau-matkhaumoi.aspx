<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="quenmatkhau-matkhaumoi.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Mật khẩu mới
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a style="color: #01c4c4" href="Default.aspx">Trang chủ</a>/ Mật khẩu mới</h4>
    <div class="title">
        <h3 class="title-names">Mật khẩu mới</h3>
    </div>
    <fieldset style="margin: 70px auto; border-radius: 7px; border: 1px solid #01c4c4; width: 400px">
        <legend style="color: #01c4c4; font-weight: bold; margin-left: 15px">Mật khẩu mới</legend>

        <table style="padding: 20px; height: 115px;">
            <tr>
                <td>Mật khẩu mới:</td>
                <td>
                    <asp:TextBox ID="txtmk1" runat="server" Height="29px" MaxLength="100" TextMode="Password" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Mật khẩu mới không được để trống !" ControlToValidate="txtmk1" Display="Dynamic">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Nhập lại mật khẩu mới:</td>
                <td>
                    <asp:TextBox ID="txtmk2" runat="server" Height="29px" MaxLength="100" TextMode="Password" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ForeColor="Red"  ErrorMessage="Mật khẩu mới không được để trống !" ControlToValidate="txtmk2" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server"  ForeColor="Red"  ErrorMessage="Mật khẩu mới không chính xác" ControlToCompare="txtmk1" ControlToValidate="txtmk2" Display="Dynamic">*</asp:CompareValidator></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
                    <asp:ValidationSummary  ForeColor="Red"  ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Đổi mật khẩu" OnClick="btnSubmit_Click" />
                </td>
            </tr>

        </table>
    </fieldset>
</asp:Content>

