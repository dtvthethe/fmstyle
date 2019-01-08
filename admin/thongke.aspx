<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="thongke.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Thống kê
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <div class="dathang">
        <div class="dathang-left" style="width: 30%">
            <table>
                <tbody>
                    <tr>
                        <th>Thống kê theo</th>
                        <th>Chi tiết</th>
                    </tr>
                    <tr>
                        <td>Thống kê doanh thu</td>


                        <td>
                            <a href="javascript:void(0)" onclick="doanhthu();" class="ten">Xem-&gt;</a>

                        </td>
                    </tr>
                    <tr>
                        <td>Thống kê đơn hàng</td>


                        <td>
                            <a href="javascript:void(0)" onclick="donhang();" class="ten">Xem-&gt;</a>

                        </td>
                    </tr>
                    <tr>
                        <td>Sản phẩm tồn kho</td>


                        <td>
                           <a href="javascript:void(0)" onclick="tonkho();" class="ten">Xem-&gt;</a>

                        </td>
                    </tr>
                   
                    <tr>
                        <td>Sản phẩm được mua nhiều</td>


                        <td>
                            <a href="javascript:void(0)" onclick="muanhieu();" class="ten">Xem-&gt;</a>

                        </td>
                    </tr>
                    <tr>
                        <td>Danh sách đặt hàng (Chưa thanh toán)</td>


                        <td>
                            <a href="javascript:void(0)" onclick="thanhtoan();" class="ten">Xem-&gt;</a>

                        </td>
                    </tr>
                    <tr>
                        <td>Danh sách sản phẩm khuyến mãi</td>


                        <td>
                            <a href="javascript:void(0)" onclick="khuyenmai();" class="ten">Xem-&gt;</a>

                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Label ID="lbPage" runat="server" Text=""></asp:Label>
        </div>





        <div class="dathang-right" style="width: 65%">
            <div class="descdesc">
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $(".ten").click(function () {
            $(".descdesc").html("<img src='../images/admin/ajax-loader.gif' />");
        });

        function doanhthu() {

            $.ajax({
                type: "POST",
                url: "../ajax/doanhthu.aspx",
                data: {},
                success: function (data) {
                    $(".descdesc").html(data);
                }
            })
        }

        function donhang() {

            $.ajax({
                type: "POST",
                url: "../ajax/dondathang.aspx",
                data: {},
                success: function (data) {
                    $(".descdesc").html(data);
                }
            })
        }

        function tonkho() {

            $.ajax({
                type: "POST",
                url: "../ajax/tonkho.aspx",
                data: {},
                success: function (data) {
                    $(".descdesc").html(data);
                }
            })
        }

        function muanhieu() {

            $.ajax({
                type: "POST",
                url: "../ajax/muanhieu.aspx",
                data: {},
                success: function (data) {
                    $(".descdesc").html(data);
                }
            })
        }

        function thanhtoan() {

            $.ajax({
                type: "POST",
                url: "../ajax/chuathanhtoan.aspx",
                data: {},
                success: function (data) {
                    $(".descdesc").html(data);
                }
            })
        }

        function khuyenmai() {

            $.ajax({
                type: "POST",
                url: "../ajax/khuyenmai.aspx",
                data: {},
                success: function (data) {
                    $(".descdesc").html(data);
                }
            })
        }
    </script>
</asp:Content>

