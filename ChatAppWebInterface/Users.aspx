<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ChatAppWebInterface.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="Logout.aspx">Logout</a></li>
            </ul>
            <asp:DataList ID="grdData" RepeatLayout="Flow" RepeatDirection="Vertical" runat="server">
                <ItemTemplate>
                    <div style="border: 2px solid #ccc; padding: 15px; margin-right: 15px; width: 90%">
                        <%# DataBinder.Eval(Container.DataItem,"Name") %>, 
                        <%# DataBinder.Eval(Container.DataItem,"EmailId") %>

                        <div style="padding: 5px; width:20% border: 1px solid #140404">
                            <div> <a href="#">Add as friend</a></div>
                            <div> <a href="#">Chat</a></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
