<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Shop thời trang FMStyle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="menu_bar">
        <ul class="menu_bar_ul">
            <li class="menu_bar_li1">
                <a class="menu_bar_a" href="#new">Mới nhất</a>
            </li>
            <li class="menu_bar_li">
                <a class="menu_bar_a" href="#ro">Bán chạy</a>
            </li>
            <li class="menu_bar_li">
                <a class="menu_bar_a" href="#kh">Khuyến mãi</a>
            </li>
        </ul>
    </div>
    <div class="noibat">
        <div class="slide-container">
            <div class="slide-stage">
                <asp:Repeater ID="rpSLIDE" runat="server">
                    <ItemTemplate>
                        <div class="slide-image">
                            <a href='<%# Eval("link") %>' title="">
                                <img class="img_sp" src='slide/<%# Eval("hinhanh") %>' />
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


            </div>
            <div class="slide-pager">
                <ul></ul>
                <!--<div class="slide-control-prev">&#60;</div>-->
                <!--<div class="slide-control-next">&#62;</div>-->
            </div>
        </div>
        <div class="sp_noibat">


            <asp:Label ID="lbHinhADV" runat="server" Text=""></asp:Label>

            <a name="new"></a>
        </div>
    </div>
    <div class="clr"></div>
    <div id="cont">

        <div class="title">

            <h3 class="title-name">SẢN PHẨM MỚI</h3>
            <a class="more" href="xemnhieuhon.aspx?v=new" title="Xem nhiều hơn">Xem nhiều hơn</a>
        </div>
        <div class="clr"></div>
        <div class="product">
            <asp:Repeater ID="spmoi" runat="server">
                <ItemTemplate>
                    <div class="productItem">
                        <a href="chitietsanpham.aspx?id=<%# Eval("id_sanpham") %>&gr=<%# Eval("id_danhmuc") %>" title="<%# Eval("ten_sanpham") %>">
                            <span class="product-img">
                                <img class="hinhsp" height="350" width="275" alt="<%# Eval("ten_sanpham") %>" src="/uploads/<%# Eval("hinhanh") %>" style="display: block;" />
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

        </div>
        <div class="clr"></div>
        <div class="ttthem">
            <a href="xemnhieuhon.aspx?v=new">
                <img src="/images/public/spmoi.png" alt="Sản phẩm mới"></img>
            </a>
            <a name="ro"></a>
        </div>
        <div class="clr"></div>

        <div class="title">

            <h3 class="title-namebc">SẢN PHẨM BÁN CHẠY</h3>
            <a class="more" href="xemnhieuhon.aspx?v=bc" title="Xem nhiều hơn">Xem nhiều hơn</a>
        </div>
        <div class="clr"></div>
        <div class="product">
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
        <div class="ttthem">
            <a href="xemnhieuhon.aspx?v=bc">
                <img src="/images/public/spbanchay.png" alt="Sản phẩm bán chạy"></img>
            </a>
            <a name="kh"></a>
        </div>

        <div class="clr"></div>

        <div class="title">

            <h3 class="title-namekm">SẢN PHẨM KHUYẾN MÃI</h3>
            <a class="more" href="xemnhieuhon.aspx?v=km" title="Xem nhiều hơn">Xem nhiều hơn</a>
        </div>
        <div class="clr"></div>
        <div class="product">

            <asp:Repeater ID="rpkhuyenmai" runat="server">
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

        </div>
        <div class="clr"></div>
        <div class="ttthem">
            <a href="xemnhieuhon.aspx?v=km">
                <img src="/images/public/spkhuyenmai.png" alt="Sản phẩm khuyến mãi"></img>
            </a>
        </div>
    </div>
</asp:Content>

