<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="dangnhap.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Đăng nhập - Shop thời trang FMStyle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a href="Default.aspx"  style="color:#01c4c4">Trang chủ</a>/ Đăng nhập</h4>
    <div id="cont">
        <div class="title">
            <h3 class="title-names">ĐĂNG NHẬP</h3>
        </div>
        <div class="clr"></div>
        <div class="product">
            
            <fieldset class="fieDangNhap">
                <legend class="legDangNhap">Đăng nhập</legend>
                <table class="tbDangNhap">

                    <tr>
                        <td>Tên đăng nhập:</td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>Mật khẩu:</td>
                        <td>
                            <asp:TextBox ID="txtPassWord" type="password" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lbResult" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <ul>

                                <li><a href="quenmatkhau.aspx">Quên mật khẩu</a></li>
                                <li><a href="dangky.aspx">Đăng ký</a></li>
                            </ul>
                        </td>
                    </tr>
                </table>



            </fieldset>
        </div>




    </div>
</asp:Content>


