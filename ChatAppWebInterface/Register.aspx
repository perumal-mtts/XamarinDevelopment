<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ChatAppWebInterface.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Name : </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email Id :</td>
                <td>
                    <asp:TextBox ID="txtEmailId" TextMode="Email" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password : </td>
                <td>
                    <asp:TextBox ID="txtPwd1" TextMode="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Confirm password :</td>
                <td>
                    <asp:TextBox ID="txtPwd2" TextMode="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblInfo" ForeColor="Red" runat="server"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
