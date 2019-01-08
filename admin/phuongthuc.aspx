<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="phuongthuc.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Phương thức thanh toán
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        <asp:Button ID="btnUpDate" runat="server" Text="Cập nhật" OnClick="btnUpDate_Click" />
        <asp:Button ID="btnThem" runat="server" Text="Thêm phương thức" PostBackUrl="~/admin/phuongthucadd.aspx" />
    </div>
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tbody>
            <tr>
                <th class="checkbox">
                    <asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server" />
                </th>
                <th class="stt">STT</th>
                <th class="hinhanh">Role</th>
              
            </tr>
            <asp:Repeater ID="rpPhuongThuc" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="checkbox">
                            <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_pt") %>' CssClass="cbCheckDel" />
                        </td>
                        <td><%# Eval("id_pt") %></td>
                        <td><a href="phuongthucedit.aspx?id=<%# Eval("id_pt") %>"><%# Eval("ten_phuongthuc") %></a></td>
                    
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
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

