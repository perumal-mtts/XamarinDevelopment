<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChatAppWebInterface.Login" %>

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
                    <td>Email Id : </td>
                    <td>
                        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password :</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblInfo" runat="server"></asp:Label>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
