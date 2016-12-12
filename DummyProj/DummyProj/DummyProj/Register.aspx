<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DummyProj.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
    </style>
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
                <asp:Label ID="emp_ID"  runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="EMP NUM"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="emp_num" runat="server" Height="16px" Width="99px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="e_id"></asp:Label>
            </td>
            <td>
                <asp:Label ID="e_id" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="NAME"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmp_name" runat="server" Height="16px" Width="99px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="PASSWORD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" textmode="Password" runat="server" Width="89px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="OCCUPATION"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="Occ" runat="server">
                    <asp:ListItem Text="PT-Student" Value="0"></asp:ListItem>
                    <asp:ListItem Text="PT-S PT-E" Value="1"></asp:ListItem>
                    <asp:ListItem Text="PT-Employee" Value="2"></asp:ListItem>
                    <asp:ListItem Text="FT-Employee" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label runat="server" Text="START DATE"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSDate" textmode="Date" runat="server" Width="89px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnInsert" runat="server" Text="INSERT" OnClick="btnInsert_Click" />
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" />
            </td>
        </tr>
    </table>
    </div>
        <asp:Label ID="Result" runat="server" Text="Result"></asp:Label>
    </form>
</body>
</html>
