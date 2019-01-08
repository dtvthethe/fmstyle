<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="nguoidung.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Người dùng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        <asp:Button ID="btnUpDate" runat="server" Text="Cập nhật" OnClick="btnUpDate_Click" />

        <asp:Button ID="btnThem" runat="server" Text="Thêm người dùng" PostBackUrl="~/admin/nguoidungadd.aspx" />
        Xem theo:<asp:DropDownList ID="ddlRole" runat="server" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        Tìm kiếm:
        <asp:TextBox ID="txtTimKiem" runat="server"></asp:TextBox>

        <asp:DropDownList ID="ddlTimKiem" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnTim" runat="server" OnClick="btnTim_Click" Text="Tìm kiếm" />
    </div>
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tbody>
            <tr>
                <th class="checkbox">
                    <asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server" />
                </th>
                <th class="stt">STT</th>
                <th class="hinhanh">Username</th>
                <th class="tenhoa">Họ và tên</th>
                <th class="tenhoa">Số điện thoại</th>
                <th class="tenhoa">Địa chỉ</th>
                <th class="tenhoa">Email</th>
                <th class="tenhoa">Role</th>
            </tr>
            <asp:Repeater ID="rpNguoiDung" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="checkbox">
                            <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_user") %>' CssClass="cbCheckDel" />
                        </td>
                        <td>
                            <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label></td>
                        <td><a href="nguoidungedit.aspx?id=<%# Eval("id_user") %>"><%# Eval("username") %></a></td>
                        <td><%# Eval("hoten") %></td>
                        <td><%# Eval("sdt") %></td>
                        <td><%# Eval("diachi") %></td>
                        <td><%# Eval("email") %></td>
                        <td><%# Eval("stringrole") %></td>
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

