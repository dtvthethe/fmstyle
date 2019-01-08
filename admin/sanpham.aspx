<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="sanpham.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Sản phẩm
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" />
        <asp:Button ID="btnThem" runat="server" Text="Thêm sản phẩm" PostBackUrl="~/admin/sanphamadd.aspx" />
        Tìm kiếm:
        <asp:TextBox ID="txtTimKiem" runat="server"></asp:TextBox>

        <asp:DropDownList ID="ddlTimKiem" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnTim" runat="server" Text="Tìm kiếm" OnClick="btnTim_Click" />
        Xem theo:<asp:DropDownList ID="ddlView" runat="server" OnSelectedIndexChanged="ddlView_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
    </div>

    <asp:Label ID="lbError" runat="server" ForeColor="Red" Text=""></asp:Label>
    <table>
        <tbody>
            <tr>
                <th class="checkbox">
                    <%--<input type="checkbox" value="all" id="allCk" />--%>
                    <asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server" />
                </th>
                <th class="stt">STT</th>
                <th class="hinhanh">Hình ảnh</th>
                <th class="tenhoa">Tên sản phẩm</th>
                <th class="tenhoa">Số lượng</th>
                <th class="gia">Gía</th>
                <th class="khuyenmai">Khuyến mãi</th>
                <th class="khuyenmai">Ngày đăng</th>

            </tr>
            <asp:Repeater ID="rpSanpham" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="checkbox">
                            <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_sanpham") %>' CssClass="cbCheckDel" />
                            <%--<input type="checkbox" value='<%# Eval("id_sanpham") %>' class="cbCheckDel">--%>
                        </td>
                        <td>
                            <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <a href="sanphamedit.aspx?id=<%# Eval("id_sanpham") %>">

                                <img style="" width="70px" height="70px" alt="" src="../uploads/<%# Eval("hinhanh") %>" />
                            </a>
                        </td>
                        <td><a href="sanphamedit.aspx?id=<%# Eval("id_sanpham") %>"><%# Eval("ten_sanpham") %></a></td>
                        <td><%# Eval("soluong") %></td>
                        <td><%# String.Format("{0:0,0 vnđ}", Eval("gia")) %></td>
                        <td>
                            <asp:DropDownList ID="ddKuyenMai" runat="server" ValidationGroup='<%# Eval("hinhanh") %>'>
                                <asp:ListItem Value="0" Text="Sai"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Đúng"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>

                            <%# Eval("ngaydang") %>

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <div style="text-align: center">
        <asp:Label ID="lbPage" runat="server" Text=""></asp:Label>
    </div>




    <script type="text/javascript">
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

