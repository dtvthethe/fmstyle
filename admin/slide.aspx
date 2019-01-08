<%@ Page Title="" Language="C#" MasterPageFile="~/admin/templateadmin.master" AutoEventWireup="true" CodeFile="slide.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   Slide
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tool">
        
        <asp:Button ID="btnUpDate" runat="server" Text="Cập nhật" OnClick="btnUpDate_Click"  OnClientClick="return confirm('Bạn có muốn thực hiện cập nhật không ?')"/>
        <asp:Button ID="btnAdd" runat="server" Text="Thêm Slide" PostBackUrl="~/admin/slideadd.aspx" />
    </div>
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <th>
                <asp:CheckBox ID="allCk" CssClass="allCk" onclick="selectAll(this)" runat="server" />
            </th>
            <th>STT</th>
            <th>Hình ảnh
            </th>
            <th>Link
            </th>
            <th>Vị trí
            </th>
        </tr>
        <asp:Repeater ID="rpSlide" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="cbDell" runat="server" ToolTip='<%# Eval("id_slide") %>' CssClass="cbCheckDel" />
                    </td>
                    <td>
                        <asp:Label ID="lbSTT" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbHinh" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLink" MaxLength="200" Width="200" runat="server" Text='<%# Eval("link") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtViTri" MaxLength="2" Width="50"  runat="server" Text='<%# Eval("vitri") %>'></asp:TextBox>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

