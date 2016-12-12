<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="DummyProj.Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="EMP ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="eID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="EMP NUM"></asp:Label>
            </td>
            <td>
                <asp:Label ID="emp_num" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="NAME"></asp:Label>
            </td>
            <td>
                <asp:Label ID="name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="OCCUPATION"></asp:Label>
            </td>
            <td>
                <asp:Label ID="occ" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="START DATE"></asp:Label>
            </td>
            <td>
                <asp:Label ID="sdate" runat="server"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="DELETE" />
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="EDIT" />
            </td>
        </tr>
    </table>
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="EMP_ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="EMP_ID" HeaderText="EMP_ID" ReadOnly="True" SortExpression="EMP_ID" />
                <asp:BoundField DataField="EMP_NUM" HeaderText="EMP_NUM" SortExpression="EMP_NUM" />
                <asp:BoundField DataField="EMP_NAME" HeaderText="EMP_NAME" SortExpression="EMP_NAME" />
                <asp:BoundField DataField="OCCUPATION" HeaderText="OCCUPATION" SortExpression="OCCUPATION" />
                <asp:BoundField DataField="SDATE" HeaderText="SDATE" SortExpression="SDATE" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Employee.EMP_ID, Employee.EMP_NUM, EmployeeMore.EMP_NAME, EmployeeMore.OCCUPATION, EmployeeMore.SDATE FROM Employee CROSS JOIN EmployeeMore"></asp:SqlDataSource>
    </form>
</body>
</html>
