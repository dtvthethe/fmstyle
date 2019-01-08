<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="nguoidungedit.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thông tin người dùng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
    <table>

        <tr>
            <td style="width: 110px">Tên đăng nhập:</td>
            <td>
                <asp:Label ID="lbTK" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 110px">Mật khẩu:</td>
            <td id="doimk">
                <asp:Button ID="btnDoiMK" runat="server" Text="Thiết lập lại mật khẩu" OnClick="btnDoiMK_Click" />
                
            </td>
        </tr>
        <tr>
            <td style="width: 110px">Họ và Tên:</td>
            <td>
                <asp:TextBox ID="txtHoTen" runat="server" MaxLength="100" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHoTen" Display="Dynamic" ErrorMessage="Họ và tên không được để trống." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 110px">Số điện thoại:</td>
            <td>
                <asp:TextBox ID="txtSDT" runat="server" MaxLength="11" Width="200px"></asp:TextBox>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="Đây không phải là số điện thoại." ForeColor="Red" ValidationExpression="^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*[-\/\.]?\s*(\d{3})\s*[-\/\.]?\s*(\d{5})\s*(([xX]|[eE][xX][tT])\.?\s*(\d+))*$"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 110px">Địa chỉ:</td>
            <td>
                <asp:TextBox ID="txtDiaChi" runat="server" TextMode="MultiLine" MaxLength="200"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDiaChi" Display="Dynamic" ErrorMessage="Địa chỉ không được để trống." ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 110px">Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" Width="200px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email không được để trống." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Đây không phải là địa chỉ email." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:Label ID="lbEmail" runat="server" ForeColor="Red"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="width: 110px">Role:</td>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 110px"></td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Cập nhật" OnClick="btnAdd_Click" />

            </td>
        </tr>
    </table>
</asp:Content>

