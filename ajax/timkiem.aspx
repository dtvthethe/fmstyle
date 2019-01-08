<%@ Page Language="C#" AutoEventWireup="true" CodeFile="timkiem.aspx.cs" Inherits="ajax_timkiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>
            <asp:Label ID="lbresult" runat="server" Text=""></asp:Label></h4>
        <div class="product">
            <asp:Repeater ID="sptimkiem" runat="server">
                        <ItemTemplate>
                            <div class="productItem">
						        <a href="chitietsanpham.aspx?id=<%# Eval("id_sanpham") %>&gr=<%# Eval("id_danhmuc") %>" title="<%# Eval("ten_sanpham") %>">
							        <span class="product-img">
								        <img class="hinhsp" height="350" width="275" alt="<%# Eval("ten_sanpham") %>" 
								        src="/uploads/<%# Eval("hinhanh") %>" style="display: block;"/>
							        </span>
							        <span class="productName"><%# Eval("ten_sanpham") %></span>
							        <br><span class="price">
                                        <asp:Label ID="lbGia" runat="server" Text=""></asp:Label>
							            </span>
						        </a>
					        </div>
                        </ItemTemplate>
                    </asp:Repeater>


        </div>
        <div class="clr"></div>
    </form>
</body>
</html>
