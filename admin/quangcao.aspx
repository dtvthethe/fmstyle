<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="quangcao.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Quảng cáo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        <asp:Button ID="btnUpDate" runat="server" Text="Cập nhật" OnClientClick="return confirm('Bạn có muốn thực hiện cập nhật không ?')" OnClick="btnUpDate_Click"/>
        <asp:Button ID="btnAdd" runat="server" Text="Thêm quảng cáo" PostBackUrl="~/admin/quangcaoadd.aspx" />
    </div>
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <th>

                <asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server" />
            </th>
            <th>STT</th>
            <th>Hình ảnh</th>
            <th>Tên</th>
            <th>Link</th>
            <th>Trạng thái</th>
        </tr>
        <asp:Repeater ID="rpQC" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="checkbox">
                        <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_adv") %>' ValidationGroup='<%# Eval("hinhanh") %>' CssClass="cbCheckDel" />
                    </td>
                    <td>
                        <asp:Label ID="lbSTT" runat="server" Text="" ToolTip='<%# Eval("id_adv") %>'></asp:Label></td>
                    <td>
                        <img width="70px" height="70px" src='../adv/<%# Eval("hinhanh") %>' alt='<%# Eval("ten") %>' />
                    </td>
                    <td>
                        <a href="quangcaoedit.aspx?id=<%# Eval("id_adv") %>"><%# Eval("ten") %></a>
                    </td>
                    <td>
                        <%# Eval("link") %>
                    </td>
                    <td>
                        <asp:Label ID="lbTT" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

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

