<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChatAppWebInterface.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="center">
    <form id="form1" runat="server">
    <div class="row">
        <div>
            Email Id:</div>
        <div>
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div>
            Password:</div>
        <div>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Button ID="btnRegister" runat="server" Text="Register" 
                onclick="btnRegister_Click" /></div>
    </div>
    <div class="row">
        <div>
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
