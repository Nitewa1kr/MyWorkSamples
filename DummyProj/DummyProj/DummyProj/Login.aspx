<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DummyProj.Login" %>

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
                <asp:TextBox ID="txtUSER" runat="server" placeholder="NAME"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtPASS" runat="server" TextMode="Password" placeholder="PASSWORD"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="LOGIN" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
