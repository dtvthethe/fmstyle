<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="giohang.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Giỏ hàng - Shop thời trang FMStyle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a style="color:#01c4c4" href="Default.aspx">Trang chủ</a>/ Giỏ hàng</h4>
    <div id="cont">
        <div class="title">
            <h3 class="title-names">SẢN PHẨM TRONG GIỎ HÀNG</h3>
        </div>
        <div class="clr"></div>
        <div class="product">
            <table class="tbGioHang">
                <tr class="thGioHang">
                    <th class="all">

                        <asp:CheckBox ID="allCk" runat="server" OnCheckedChanged="allCk_CheckedChanged" />
                    </th>
                    <th class="hinhGioHang">Hình ảnh</th>
                    <th>Tên sản phẩm</th>
                    <th>Size</th>
                    <th>Số lượng</th>
                    <th>Gía</th>
                </tr>
                <asp:Repeater ID="rpgioHang" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:CheckBox ID="cbCheckDel" class="cbCheckDel" runat="server" /></td>
                            <td><a href="chitietsanpham.aspx?id=<%# Eval("id_sanpham") %>" title='<%# Eval("ten_sanpham") %>'>
                                <img src="<%# Eval("hinhanh") %>" height="100" alt=""></img></a></td>
                            <td><a href="chitietsanpham.aspx?id=<%# Eval("id_sanpham") %>" title='<%# Eval("ten_sanpham") %>'><%# Eval("ten_sanpham") %></a></td>
                            <td><%# Eval("size") %></td>
                            <td>
                                <asp:TextBox ID="txtSoLuong" runat="server" Text='<%# Eval("soluong") %>'></asp:TextBox>

                            </td>
                            <td><%# String.Format("{0:0,0 vnđ}", Eval("giaNhanSoLuong")) %></td>
                        </tr>
                    </ItemTemplate>

                </asp:Repeater>


                <tr class="tongTien">
                    <td colspan="6">
                        <asp:Label ID="lbTongTien" runat="server" Text="Giỏ hàng trống !"></asp:Label>
                    </td>

                </tr>
                <tr class="thanhToan">

                    <td colspan="6">

                        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" />
                        <asp:Button ID="btnThanhToan" runat="server" Text="Thanh toán" OnClick="btnThanhToan_Click" />

                    </td>

                </tr>
            </table>

        </div>
    </div>
    <script type="text/javascript">

        //chon tat ca:
        $('#allCk').click(function (event) {
            // loop through each checkbox
            $('.cbCheckDel').each(function () {
                // uncheck all checkboxes with class "checkRows"
                if (this.checked) { this.checked = false; }
                    // check all with class "checkRows"
                else { this.checked = true; }
            });
        });
    </script>
</asp:Content>



