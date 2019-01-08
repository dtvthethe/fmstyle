<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="sanphamedit.aspx.cs" Inherits="admin_Default2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thông tin sản phẩm
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
    <table>

        <tr>
            <td>Tên sản phẩm:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" MaxLength="100" Width="200px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTen" Display="Dynamic" ErrorMessage="Tên sản phẩm không được để trống." ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:Label ID="lbTen" runat="server" ForeColor="Red"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>Số lượng:</td>
            <td>
                <asp:TextBox ID="txtSoLuong" runat="server" MaxLength="3" Width="200px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSoLuong" Display="Dynamic" ErrorMessage="Số lượng không được để trống." ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtSoLuong" Display="Dynamic" ErrorMessage="Gía trị nhập vào phải là chữ số." ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtSoLuong" Display="Dynamic" ErrorMessage="Gía trị nhập vào phải lớn hơn 0." ForeColor="Red" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>

            </td>
        </tr>
        <tr>
            <td>Hình ảnh:</td>
            <td>
                <asp:Label ID="lbHinh" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnHinhKhac" runat="server" Text="Xóa hình này" OnClientClick=" return confirm('Bạn có muốn xóa hình này không?');" OnClick="btnHinhKhac_Click" />
                <asp:FileUpload ID="fuPicture" runat="server" />
                <asp:Label ID="lbErrorPic" runat="server" ForeColor="Red" Text="(Chỉ chấp nhận đôi mở rộng của ảnh là *.png, *.jpg)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Danh mục:</td>
            <td>
                <asp:DropDownList ID="ddlDM" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Thông tin chi tiết:</td>
            <td>
                <%--<asp:TextBox ID="txtTT" runat="server" class="ckeditor" name="editor1" TextMode="MultiLine"></asp:TextBox>--%>
                <ckeditor:ckeditorcontrol id="txtTT" runat="server"></ckeditor:ckeditorcontrol>
            </td>
        </tr>
        <tr>
            <td>Gía:</td>
            <td>
                <asp:TextBox ID="txtGia" runat="server" MaxLength="9" Width="200px"></asp:TextBox>vnđ
                <asp:Label ID="lbGia" runat="server" ForeColor="#0066ff" Text=""></asp:Label>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGia" Display="Dynamic" ErrorMessage="Gía không được để trống." ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGia" Display="Dynamic" ErrorMessage="Gía trị nhập vào phải là chữ số." ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtGia" Display="Dynamic" ErrorMessage="Gía trị nhập vào phải lớn hơn 0." ForeColor="Red" MaximumValue="1000000000" MinimumValue="1" Type="Integer"></asp:RangeValidator>

            </td>
        </tr>
        <tr>
            <td>Khuyến mãi:</td>
            <td>
                <asp:RadioButton ID="rbYes" GroupName="km" runat="server" Text="Là sản phẩm khuyến mãi" />
                <asp:RadioButton ID="rbNo" GroupName="km" runat="server" Text="Không phải sản phẩm khuyến mãi" />

            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Lưu lại" OnClick="btnAdd_Click" Width="78px" />
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

