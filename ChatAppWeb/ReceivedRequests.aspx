<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ReceivedRequests.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Requests From</h1>
    </hgroup>

    <article>
      <asp:DataList ID="grdData" RepeatLayout="Flow" RepeatDirection="Vertical" runat="server">
        <ItemTemplate>
            <div>
                <%# DataBinder.Eval(Container.DataItem,"Name") %>,
                <%# DataBinder.Eval(Container.DataItem,"EmailId") %>
                 <div>
                    <div>
                        <a href="#">
                            <asp:LinkButton runat="server" CommandName="Approve" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'
                                Text="Approve" ID="linkBtnAddFriend" OnClick="linkBtnAddFriend_Click"></asp:LinkButton>
                        </a>
                    </div>
                    <div>
                        <a href="#">
                            <asp:LinkButton runat="server" CommandName="Reject" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'
                                Text="Reject" ID="LinkButton1" OnClick="linkBtnAddFriend_Click"></asp:LinkButton>
                        </a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    </article>

    <aside>
        <p class="validation-summary-errors">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </aside>
</asp:Content>
