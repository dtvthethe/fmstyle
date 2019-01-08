<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập hệ thống</title>
    <link href="../images/public/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="../js/admin/jquery-1.11.1.min.js"></script>
    <link href="../css/admin/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper_login">
            <div id="menu">
                <div id="left"></div>
                <div id="right"></div>
                <h2>Đăng nhập</h2>
                <div class="clear"></div>
            </div>
            <div id="desc">
                <div class="body">
                    <div class="col w10 last bottomlast">
                        <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
                        <p>
                            <label for="username">Tên đăng nhập:</label>

                            <asp:TextBox ID="txtTK" class="text" runat="server"></asp:TextBox>
                            <br>
                        </p>
                        <p>
                            <label for="password">Mật khẩu:</label>

                            <asp:TextBox ID="txtMK" class="text" runat="server" TextMode="Password"></asp:TextBox>
                            <br>
                        </p>
                        <p class="last">
                            <asp:Button ID="btnLogin" CssClass="btnDangNhap" runat="server" Text="Login" OnClick="btnLogin_Click" />

                            <br>
                        </p>


                        <div class="clear"></div>

                    </div>
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
                <div id="body_footer">
                    <div id="bottom_left">
                        <div id="bottom_right"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
