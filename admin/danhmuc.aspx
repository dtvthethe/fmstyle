<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="danhmuc.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    Danh mục
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật"  OnClientClick="return confirm('Bạn có muốn thực hiện cập nhật không?');"  OnClick="btnCapNhat_Click" />

        <asp:Button ID="addDMCha" runat="server" Text="Thêm danh mục cha"  PostBackUrl="~/admin/danhmucadd.aspx" />
    </div>
    <asp:Label ID="lbError" runat="server" ForeColor="Red" Text=""></asp:Label>
  <h3>Level1: Danh mục cha:</h3>  
    <table>
        <tbody>
            <tr>
                <th class="checkbox">
                    <%--<asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server"/>--%>
                    <input type="checkbox" name="checkbox" value="all" id="Checkbox2"></input>All
                </th>
                <th class="stt">STT</th>
                <th class="hinhanh">Tên danh mục</th>
            </tr>
            <asp:Repeater ID="rpLV2" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="checkbox">
                            <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_danhmuc") %>' CssClass="cbCheckDel" />
                        </td>
                        <td>
                            <asp:Label ID="lbDanhMucSTT" runat="server" Text=""></asp:Label>
                        </td>
                        <td><a href="danhmucedit.aspx?id=<%# Eval("id_danhmuc") %>"><%# Eval("ten_danhmuc") %></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <hr />
   <h3>Level2: Danh mục con:</h3>
        <div class="tool">
            <asp:Button ID="btnCapNhatCon" runat="server" Text="Cập nhật"  OnClientClick="return confirm('Bạn có muốn thực hiện cập nhật không?');"  OnClick="btnCapNhatCon_Click" />


            <asp:Button ID="btnThemdanhmuccon" runat="server" Text="Thêm danh mục con" PostBackUrl="~/admin/danhmucsubadd.aspx" />
        </div>
    <table>
        <tbody>
            <tr>
                <th class="checkbox">
                    <input type="checkbox" name="checkbox" value="all" id="Checkbox1"></input>All</th>
                <th class="stt">STT</th>
                <th class="hinhanh">Tên danh mục</th>
                <th class="hinhanh">Xem theo:
                    <asp:DropDownList ID="ddlLevel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                    </asp:DropDownList>
                </th>
            </tr>
            <asp:Repeater ID="rpLV1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="checkbox">
                            <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_danhmuc") %>' CssClass="cbCheckDel" />

                        </td>
                        <td>
                            <asp:Label ID="lbDanhMucSubSTT" runat="server" Text=""></asp:Label></td>
                        <td><a href="danhmucsubedit.aspx?id=<%# Eval("id_danhmuc") %>"><%# Eval("ten_danhmuc") %></a></td>
                        <td></td>
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

