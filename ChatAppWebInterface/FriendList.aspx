<%@ Page Title="" Language="C#" MasterPageFile="~/inner.Master" AutoEventWireup="true" CodeBehind="FriendList.aspx.cs" Inherits="ChatAppWebInterface.FriendList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:DataList ID="grdData" RepeatLayout="Flow" RepeatDirection="Vertical" runat="server">
        <ItemTemplate>
            <div style="border: 2px solid #ccc; padding: 5px; margin-right: 15px; width: 15%">
                <%# DataBinder.Eval(Container.DataItem,"Name") %>,
                <%# DataBinder.Eval(Container.DataItem,"EmailId") %>
                <div style="padding: 5px; width: 20% border: 1px solid #140404">
                    <div>
                        <a href="#">Remove friend</a></div>
                    <div>
                        <a href="#">Chat</a></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
