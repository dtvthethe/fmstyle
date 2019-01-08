<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="role.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Quyền người dùng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"/>
        <asp:Button ID="btnThem" runat="server" Text="Thêm Role" PostBackUrl="~/admin/roleadd.aspx"/>
    </div>
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tbody>
            <tr>
                <th class="checkbox">
                    <asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server"/>
                </th>
                <th class="stt">STT</th>
                <th class="hinhanh">Role</th>
                <th class="hinhanh">Truy cập CMS</th>
                <th class="hinhanh">Special</th>
            </tr>
            <asp:Repeater ID="rpRole" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="checkbox">
                            <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_role") %>' CssClass="cbCheckDel" />
                        </td>
                        <td>
                            <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label></td>
                        <td><a href="roleedit.aspx?id=<%# Eval("id_role") %>"><%# Eval("role") %></a></td>
                        <td><asp:Label ID="lbCMS" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlSp" runat="server">
                                <asp:ListItem Value="0" Text="Từ chối"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Cho phép"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
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

