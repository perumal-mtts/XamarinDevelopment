<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChatAppWebInterface.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email Id : 
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
            Password :
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Button" OnClick="btnLogin_Click" />
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
