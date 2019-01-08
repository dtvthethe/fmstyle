<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="lienhe.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Liên hệ - Shop thời trang FMStyle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a style="color: #01c4c4" href="Default.aspx">Trang chủ</a>/ Liên hệ</h4>
    <div class="title">
        <h3 class="title-names">Liên hệ</h3>
    </div>
    <div class="clr"></div>
    <table class="tbLienHe">

        <tr>
            <td class="td-left-tbLienHe">Họ và tên (<span style="color: red">*</span>):</td>
            <td class="td-right-tbLienHe">
                <asp:TextBox class="txt" ID="txtHoTen" runat="server" Height="29px" MaxLength="100" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvHoTen" runat="server" ErrorMessage="Họ tên không được để trống!" ControlToValidate="txtHoTen" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Địa chỉ (<span style="color: red">*</span>):</td>
            <td>
                <asp:TextBox class="txt" ID="txtDiaChi" runat="server" Height="29px" MaxLength="200" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDiaChi" runat="server" ErrorMessage="Địa chỉ không được để trống!" ControlToValidate="txtDiaChi" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox class="txt" ID="txtEmail" runat="server" Height="29px" MaxLength="100" Width="250px"></asp:TextBox>
                <asp:RegularExpressionValidator ForeColor="Red" ID="revEmail" runat="server" ErrorMessage="Email không chính xác !" Text="*" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Số điện thoại:</td>
            <td>
                <asp:TextBox class="txt" ID="txtSDT" runat="server" Height="29px" MaxLength="11" Width="250px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="Đây không phải là số điện thoại !" ForeColor="Red" ValidationExpression="^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*[-\/\.]?\s*(\d{3})\s*[-\/\.]?\s*(\d{5})\s*(([xX]|[eE][xX][tT])\.?\s*(\d+))*$">*</asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td>Nội dung (<span style="color: red">*</span>):</td>
            <td>
                <asp:RequiredFieldValidator ID="rfvtxtNoiDung" runat="server" ErrorMessage="Nội dung không được để trống" ControlToValidate="txtNoiDung" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                <%--<asp:TextBox class="txt" ID="txtNoiDung" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                <CKEditor:CKEditorControl ID="txtNoiDung" runat="server" Toolbar="Basic" Height="150px" Width="569px"></CKEditor:CKEditorControl>
            
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnGui" runat="server" Text="Gửi liên hệ" OnClick="btnGui_Click" Height="27px" Width="107px" />


            </td>
        </tr>
    </table>

</asp:Content>


