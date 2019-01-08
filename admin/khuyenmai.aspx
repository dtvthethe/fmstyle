<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="khuyenmai.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Khuyến mãi
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <div style="text-align: center; height:200px">
        <p style="font-size: 12px; margin-top:100px">
            Phần trăm khuyến mãi hiện tại là: 
    <asp:TextBox ID="txtKhuyenMai" runat="server" MaxLength="2" Width="200px"></asp:TextBox>
            %
    <asp:Button ID="btnKhuyenMai" runat="server" Text="Lưu lại" OnClick="btnKhuyenMai_Click" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Phần trăm khuyến mãi không được để trống !" Display="Dynamic" ForeColor="Red" ControlToValidate="txtKhuyenMai"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Phần trăm phải lớn hơn 0 và nhỏ nhơn 100" ControlToValidate="txtKhuyenMai" Display="Dynamic" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        </p>
    </div>
</asp:Content>

