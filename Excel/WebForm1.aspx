<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Excel.WebForm1" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NAS server pinger</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Hi</h1>
    </div>
            
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:TextBox ID="TextBox1" runat="server" Height="126px" Width="279px" MaxLength="60000"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server"   BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" BackColor="#FFCC00" Height="186px" OnRowDataBound="GridView1_RowDataBound" Width="370px">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="Black" BackColor="#CFCCD0" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            
           <%-- <Columns>
                <asp:BoundField DataField="Store" HeaderText="Store" />
                <asp:BoundField DataField="IP" HeaderText="IP" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
            --%>
        </asp:GridView>

    </form>
</body>
</html>
