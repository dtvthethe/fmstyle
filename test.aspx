<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/public/awfafa.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>

               <asp:Label ID="lbgia" runat="server" Text='<%# Eval("ten_danhmuc")%>'></asp:Label>
                
                
            </ItemTemplate>
        </asp:Repeater>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        <ul>

            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%#  Eval("ten_danhmuc") %>'></asp:Label>
                    
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

       

    </form>
</body>
</html>
