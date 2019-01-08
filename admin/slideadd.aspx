<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="slideadd.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Thêm slide
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <td>Hình ảnh:</td>
            <td>
                <asp:FileUpload ID="filePic" runat="server" />

                <asp:Label ID="lbErrorPic" runat="server" ForeColor="Red" Text="(Chỉ chấp nhận đôi mở rộng của ảnh là *.png, *.jpg)"></asp:Label>
            </td>

        </tr>
        <tr>
            <td>Link:</td>
            <td>
                <asp:TextBox ID="txtLink" runat="server" MaxLength="200" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLink" Display="Dynamic" ErrorMessage="Link không được để trống" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLink" Display="Dynamic" ErrorMessage="Đây không phải là url." ForeColor="#FF3300" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Vị trí:</td>
            <td>
                <asp:TextBox ID="txtViTri" runat="server" MaxLength="2" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtViTri" Display="Dynamic" ErrorMessage="Vị trí không được để trống." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtViTri" Display="Dynamic" ErrorMessage="Vị trí phải là chữ số" ForeColor="#FF3300" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ErrorMessage="Gía trị nhập vào phải lớn hơn 0" ForeColor="#FF3300" MaximumValue="100" MinimumValue="1" ControlToValidate="txtViTri" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Thêm slide" OnClick="btnAdd_Click" Width="114px"/></td>
        </tr>
    </table>
</asp:Content>

