<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginInfo.aspx.cs" Inherits="DummyProj1.LoginInfo" %>

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
            <td>
                <asp:Label ID="S_ID" runat="server" Text="STUDENT ID"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblS_ID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="stdName" runat="server" Text="STUDENT NAME"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtstdName" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Label ID="stdPass" runat="server" Text="STUDENT PASSWORD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtStdPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnInsert" runat="server" Text="INSERT" Width="101px" OnClick="btnInsert_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" Width="101px" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="DELETE" Width="101px" OnClick="btnDelete_Click" />   
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:Label ID="lblResult" runat="server" Text="Result"></asp:Label>
                
                
            </td>
        </tr>
    </table>
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True" DataKeyNames="S_ID,P_ID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="S_ID" HeaderText="S_ID" InsertVisible="False" ReadOnly="True" SortExpression="S_ID" Visible="False" />
                <asp:TemplateField HeaderText="STUDENT_NUM" SortExpression="STUDENT_NUM">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("STUDENT_NUM") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="NUM" runat="server" Text='<%# Bind("STUDENT_NUM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STUDENT_NAME" SortExpression="STUDENT_NAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("STUDENT_NAME") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="NAME" runat="server" Text='<%# Bind("STUDENT_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="P_ID" HeaderText="P_ID" InsertVisible="False" ReadOnly="True" SortExpression="P_ID" Visible="False" />
                <asp:TemplateField HeaderText="PASSWORD" SortExpression="PASSWORD">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PASSWORD") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="PASS" runat="server" Text='<%# Bind("PASSWORD") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Student_Name.S_ID,Student_Name.STUDENT_NUM,Student_Name.STUDENT_NAME,Student_Pass.P_ID,Student_Pass.PASSWORD FROM Student_Name CROSS JOIN Student_Pass WHERE S_ID = P_ID"></asp:SqlDataSource>
    </form>
</body>
</html>
