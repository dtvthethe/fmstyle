<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="dathang.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Đặt hàng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        <asp:Button ID="btnUpDate" runat="server" Text="Cập nhật" OnClick="btnUpDate_Click" />
        Xem theo:
        <asp:DropDownList ID="ddlXem" runat="server" OnSelectedIndexChanged="ddlXem_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
            <asp:ListItem Value="1" Text="Đã giao hàng"></asp:ListItem>
            <asp:ListItem Value="2" Text="Chưa giao hàng"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <div class="dathang">
        <div class="dathang-left">
            <table>
                <tbody>
                    <tr>
                        <th class="checkbox">

                            <asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server" />
                        </th>
                        <th class="stt">STT</th>
                        <th class="">Họ và tên</th>
                        <th class=""></th>
                        <th class="">Ngày mua</th>
                        <th class="">Tổng tiền</th>
                        <th class="">Phương thức</th>
                        <th class="">Thanh toán</th>
                        <th class="sua">Xem nhanh</th>
                    </tr>
                    <asp:Repeater ID="rpDatHang" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="checkbox">
                                    <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_dathang") %>' CssClass="cbCheckDel" />
                                </td>
                                <td>
                                    <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label></td>
                                <td><a href="nguoidungedit.aspx?id=<%# Eval("id_user") %>" class="ten">
                                    <asp:Label ID="lbNguoiDung" runat="server" Text=""></asp:Label>
                                </a></td>
                                <td>
                                    <asp:Label ID="lbHinh" runat="server" Text=""></asp:Label>
                                </td>
                                <td><%# Eval("ngaydang") %></td>
                                <td>
                                    <asp:Label ID="lbTongTien" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbThanhToan" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <a href="thanhtoan.aspx?id=<%# Eval("id_dathang") %>" title="Thanh toán">Thanh toán
                                    </a>
                                </td>
                                <td>
                                    <a href="javascript:void(0)" onclick="ttChiTiet(<%# Eval("id_dathang") %>);" id="ajaxLoadTT" class="ten">Xem nhanh-&gt;</a>

                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div style="text-align: center">
                <asp:Label ID="lbPage" runat="server" Text=""></asp:Label>
            </div>
        </div>





        <div class="dathang-right">
            <div class="col last">
                <div class="content">
                    <div class="box header">
                        <div class="head">
                            <div></div>
                        </div>
                        <h2>Tên hàng hóa, dịch vụ</h2>
                        <div class="descdesc">

                            <div style="width: 222px;">
                                <img alt="Click" src="../images/admin/xemnhanh.png">
                                <p>Click chọn vào <strong>xem nhanh-&gt;</strong> để xem Tên hàng hóa, dịch vụ</p>
                            </div>
                            <table>
                            </table>


                        </div>
                        <div class="bottom">
                            <div></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $("#ajaxLoadTT").click(function () {
            $(".descdesc").html("<img src='../images/admin/ajax-loader.gif' />");
        });


        function ttChiTiet(id) {

            $.ajax({
                type: "POST",
                url: "../ajax/ttchitiet.aspx",
                data: { id: id },
                success: function (data) {
                    $(".descdesc").html(data);
                }
            })
        }

        function selectAll(invoker) {
            // Since ASP.NET checkboxes are really HTML input elements
            //  let's get all the inputs 
            var inputElements = document.getElementsByTagName('input');

            for (var i = 0; i < inputElements.length; i++) {
                var myElement = inputElements[i];

                // Filter through the input types looking for checkboxes
                if (myElement.type === "checkbox") {

                    // Use the invoker (our calling element) as the reference 
                    //  for our checkbox status
                    myElement.checked = invoker.checked;
                }
            }
        }
    </script>


</asp:Content>

