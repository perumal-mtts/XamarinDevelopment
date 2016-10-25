<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="FriendList.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <hgroup class="title">
        <h1>Friends</h1>
    </hgroup>

    <article>
        <asp:DataList ID="grdData" RepeatLayout="Flow" RepeatDirection="Vertical" runat="server">
            <ItemTemplate>
                <div>
                    <img id='stat1<%#Eval("UserId")%>' title="<%#Eval("NewStatus") %>" width="18px" height="18px" src="images/offline.png" />
                    <a id='status1<%#Eval("UserId")%>' class="UserItem" data-userid="<%#Eval("UserId")%>" href="#">
                        <%#Eval("UserName")%>
                    </a>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </article>

    <aside>
       
    </aside>
</asp:Content>
