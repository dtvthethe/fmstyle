<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="nguoidungadd.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thêm người dùng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
    <table>

        <tr>
            <td style="width: 141px">Tên đăng nhập:</td>
            <td>
                <asp:TextBox ID="txtTK" runat="server" Width="200px" MaxLength="30"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Đăng nhập không được để trống !" ForeColor="Red" ControlToValidate="txtTK" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:Label ID="lbTK" runat="server" ForeColor="Red"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="width: 141px">Mật khẩu:</td>
            <td>
                <asp:TextBox ID="txtMK1" runat="server" Width="200px" MaxLength="100" TextMode="Password"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mật khẩu không được để trống !" ForeColor="Red" ControlToValidate="txtMK1" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 141px">Nhập lại mật khẩu:</td>
            <td>
                <asp:TextBox ID="txtMK2" runat="server" Width="200px" MaxLength="100" TextMode="Password"></asp:TextBox>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtMK1" ControlToValidate="txtMK2" Display="Dynamic" ErrorMessage="Mật khẩu không chính xác !" ForeColor="Red"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMK2" Display="Dynamic" ErrorMessage="Mật khẩu không được để trống." ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 141px">Họ và Tên:</td>
            <td>
                <asp:TextBox ID="txtHoTen" runat="server" Width="200px" MaxLength="100"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Họ và tên không được để trống !" ForeColor="Red" ControlToValidate="txtHoTen" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 141px">Số điện thoại:</td>
            <td>
                <asp:TextBox ID="txtSDT" runat="server" Width="200px" MaxLength="11"></asp:TextBox>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="Đây không phải la số điện thoại" ForeColor="Red" ValidationExpression="^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*[-\/\.]?\s*(\d{3})\s*[-\/\.]?\s*(\d{5})\s*(([xX]|[eE][xX][tT])\.?\s*(\d+))*$"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 141px">Địa chỉ:</td>
            <td>
                <asp:TextBox ID="txtDiaChi" runat="server" TextMode="MultiLine" MaxLength="200"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Địa chỉ không được để trống" ForeColor="Red" ControlToValidate="txtDiaChi" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 141px">Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="200px" MaxLength="100"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Email không được để trống !" ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Đây không phải là địa chỉ mail " ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:Label ID="lbEmail" runat="server" ForeColor="Red"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="width: 141px">Role:</td>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 141px"></td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Thêm người dùng" OnClick="btnAdd_Click" />

            </td>
        </tr>
    </table>
</asp:Content>

