<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="lichsumua.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Lịch sử mua hàng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a style="color: #01c4c4" href="Default.aspx">Trang chủ</a>/ Lịch sử mua hàng</h4>
    <div class="title">
        <h3 class="title-names">Lịch sử mua hàng</h3>
    </div>
    <div class="clr" style="margin-bottom:10px"></div>
    <div style="float: left">
        <table class="tbLichSu"  style="width:750px">
            <tr>
                <th>STT</th>
                <th>Thời gian</th>
                <th>Phương thức thanh toán</th>
                <th>Trạng thái</th>
                <th>Chi tiết</th>
            </tr>
            <asp:Repeater ID="rpLichSuMua" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><asp:Label ID="lbSTT" runat="server" Text=""></asp:Label></td>
                        <td><%# Eval("ngaydang") %></td>
                        <td>
                            <asp:Label ID="lbPT" runat="server" Text=""></asp:Label>

                        </td>
                        <td><asp:Label ID="lbTrangThai" runat="server" Text=""></asp:Label></td>
                        <td><a href="javascript:void(0);" id="btn" title="Chi tiết" onclick="lichsumua(<%# Eval("id_dathang") %>);">Chi tiết</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div style="float: right; overflow:auto;height: 400px;" id="noidung">

    </div>
    <script type="text/javascript">

        $("#btn").click(function () {
            $("#noidung").html("<img src='../images/public/ajax-loader.gif' style='margin-right: 200px' />");
        });

        function lichsumua(id) {
            
            $.ajax({
                type: "POST",
                url: "ajax/dathanguser.aspx",
                data: { id: id },
                success: function (data) {
                    $("#noidung").html(data);
                }
            })
        }
    </script>
</asp:Content>
