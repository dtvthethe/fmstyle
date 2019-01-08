<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="thanhtoan.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thanh toán - Shop thời trang FMStyle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a href="Default.aspx" style="color: #01c4c4">Trang chủ</a>/ Thanh toán</h4>
    <div class="title">
        <h3 class="title-names">Thanh toán</h3>
    </div>
    <div class="clr" style="margin-top:50px"></div>
    Lựa chọn phương thức thanh toán: <asp:DropDownList ID="ddThanhToan" runat="server" OnSelectedIndexChanged="ddThanhToan_SelectedIndexChanged" AutoPostBack="true" Height="26px" Width="100px"></asp:DropDownList>
    <asp:Button ID="btnThanhToan" runat="server" OnClick="btnThanhToan_Click" Text="Thanh toán" Height="26px" Width="106px" />
    <div class="clr"></div>
    <div class="clr" style="margin-top:50px"></div>
    <div class="clr"></div>
    <asp:Label ID="lbThanhToan" runat="server" Text=""></asp:Label>
    <div class="clr" style="margin-top:50px"></div>
</asp:Content>

