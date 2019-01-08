<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="lienhe.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Liên hệ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        <asp:Button ID="btnUpDate" runat="server" Text="Cập nhật" OnClick="btnUpDate_Click" />
    </div>
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tbody>
            <tr>
                <th class="checkbox">
                    <asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server" />
                </th>
                <th class="stt">STT</th>
                <th class="hinhanh">Họ và tên</th>
                <th class="tenhoa">Email</th>
                <th class="tenhoa">Số điện thoại</th>
                <th class="tenhoa">Ngày gửi</th>
            </tr>
            <asp:Repeater ID="rpLienHe" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="checkbox">
                            <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_lienhe") %>' CssClass="cbCheckDel" />
                        </td>
                        <td>
                            <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label>
                        </td>
                        <td><a href="lienheview.aspx?id=<%# Eval("id_lienhe") %>"><%# Eval("hoten") %></a><i><asp:Label ID="lbview" runat="server" Text=""></asp:Label></i></td>
                        <td><%# Eval("email") %></td>
                        <td><%# Eval("sdt") %></td>
                        <td><%# Eval("ngaygui") %></td>

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

