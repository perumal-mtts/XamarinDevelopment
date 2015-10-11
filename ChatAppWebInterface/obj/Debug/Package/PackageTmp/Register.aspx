<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ChatAppWebInterface.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
        <div>
            Name :
        </div>
        <div>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div>
            Email Id :</div>
        <div>
            <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div>
            Password :
        </div>
        <div>
            <asp:TextBox ID="txtPwd1" TextMode="Password" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div>
            Confirm password :</div>
        <div>
            <asp:TextBox ID="txtPwd2" TextMode="Password" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </div>
    <div>
        <div>
            <asp:Label ID="lblInfo" ForeColor="Red" runat="server"></asp:Label></div>
    </div>
    </form>
</body>
</html>
