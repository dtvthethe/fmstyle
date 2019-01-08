<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="xemnhieuhon.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><span style="color: #01c4c4">Trang chủ/</span>
        <asp:Label ID="lbtitle" runat="server" Text="Label"></asp:Label></h4>
    <div id="cont">
        <div class="title">
            <h3 class="title-names">
                <asp:Label ID="lbDanhMuc" runat="server" Text="Label"></asp:Label></h3>
        </div>
        <div class="clr"></div>
        <div class="product">
            <asp:Repeater ID="rpsanpham" runat="server">
                <ItemTemplate>
                    <div class="productItem">
                        <a href="chitietsanpham.aspx?id=<%# Eval("id_sanpham") %>&gr=<%# Eval("id_danhmuc") %>" title="<%# Eval("ten_sanpham") %>">
                            <span class="product-img">
                                <img class="hinhsp" height="350" width="275" alt="<%# Eval("ten_sanpham") %>"
                                    src="/uploads/<%# Eval("hinhanh") %>" style="display: block;" />
                            </span>
                            <span class="productName"><%# Eval("ten_sanpham") %></span>
                            <br>
                            <span class="price">
                                <asp:Label ID="lbGia" runat="server" Text=""></asp:Label>
                            </span>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <asp:Repeater ID="rpbanchay" runat="server">
                <ItemTemplate>
                    <div class="productItem">
                        <asp:Label ID="lbA" runat="server" Text='<%# Eval("id_sanpham") %>'></asp:Label>

                            <span class="product-img">
                                <asp:Label ID="lbHinh" runat="server" Text=""></asp:Label>

                            </span>
                            <asp:Label ID="lbTen" runat="server" Text=""></asp:Label>

                            <br>
                            <span class="price">
                                <asp:Label ID="lbGia" runat="server" Text=""></asp:Label>

                            </span>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clr"></div>
        <div class="phantrang">
            <asp:Label ID="lbPhanTrang" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

