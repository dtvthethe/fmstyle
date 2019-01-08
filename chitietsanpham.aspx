<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="chitietsanpham.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" Text="" ID="atitle"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><a  style="color:#01c4c4" href="Default.aspx">Trang chủ</a>/ Thông tin sản phẩm</h4>
    <div class="title">
        <h3 class="title-names">THÔNG TIN SẢN PHẨM</h3>
    </div>
    <div class="product-top">
        <div class="product-top-l">


            <asp:Image class="img-product-top hinhsp" Height="350" Width="275" Style="display: block;" ID="imgsp" runat="server" />
        </div>
        <div class="product-top-r">
            <h3 class="product-top-rh3">BẠN MUỐN MUA SẢN PHẨM NÀY ? </h3>
            <table class="tb-product-top">
                <tr>
                    <td class="tbproduct-ti">Tên sản phẩm:</td>
                    <td style="color: #01c4c4" class="tbproduct-no">
                        <asp:Label ID="lbTenSP" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Gía sản phẩm: </td>
                    <td style="color: #01c4c4">
                        <asp:Label ID="lbGia" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Tình trạng:</td>
                    <td style="color: #01c4c4">
                        <asp:Label ID="lbTinhTrang" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Chọn Size: </td>
                    <td>
                        <asp:DropDownList ID="ddlMau" runat="server">
                            <asp:ListItem Value="S" Text="S"></asp:ListItem>
                            <asp:ListItem Value="M" Text="M"></asp:ListItem>
                            <asp:ListItem Value="L" Text="L"></asp:ListItem>
                            <asp:ListItem Value="XL" Text="XL"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Số lượng:</td>
                    <td>
                        <asp:TextBox ID="txtSoLuong" runat="server" Text="1" MaxLength="3" CausesValidation="False" Style="height: 29px; width: 100%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Số lượng không được bỏ trống !" ControlToValidate="txtSoLuong" EnableClientScript="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ErrorMessage="Sai định dạng đầu vào !" Type="Integer" ControlToValidate="txtSoLuong" CultureInvariantValues="False" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        <asp:RangeValidator ID="RangeValidator1" ForeColor="Red" runat="server" ErrorMessage="Gía trị nhập vào phải lớn hơn 0 và nhỏ hơn 100" ControlToValidate="txtSoLuong" Display="Dynamic" MinimumValue="1" MaximumValue="100" Type="Integer"></asp:RangeValidator>
                        <asp:Label ID="lbError" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>

            <asp:Button class="buy" ID="btnMua" runat="server" Text="Mua ngay !" OnClick="btnMua_Click" />

        </div>
    </div>
    <div class="clr"></div>
    <div class="product-bottom">
        <ul class="title" style="padding-left: 0px">
            <li>
                <%--<asp:Button class="btn" ToolTip="Thông tin" ID="btntt" runat="server" Text="Thông tin" />--%>
                <input type="button" class="btn" title="Thông tin" id="btntt" onclick="loadnoidung();" value="Thông tin" />
            </li>
            <li>
                <%--<asp:Button ID="Button1" class="btn" ToolTip="Sản phẩm cùng loại" runat="server" Text="Sản phẩm cùng loại" />--%>
                <input type="button" class="btn" title="Sản phẩm cùng loại" id="spcungloai" onclick="loadsplienquan();" value="Sản phẩm cùng loại" />
            </li>
        </ul>

        <div id="noidung">
            <asp:Label ID="lbnoidung" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <script type="text/javascript">

        $(".btn").click(function () {
            $("#noidung").html("<img src='../images/public/ajax-loader.gif' style='margin-left: 550px' />");
        });

        function loadnoidung() {
            nd = $(location).attr('search');
            $.ajax({
                type: "POST",
                url: "ajax/noidung.aspx",
                data: { gui: nd },
                success: function (data) {
                    $("#noidung").html(data);
                }
            })
        }

        function loadsplienquan() {
            nd = $(location).attr('search');
            $.ajax({
                type: "POST",
                url: "ajax/sanphamlienquan.aspx",
                data: { gui: nd },
                success: function (data) {
                    $("#noidung").html(data);
                }
            })
        }


    </script>

</asp:Content>

