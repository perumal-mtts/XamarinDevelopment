<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UsersList.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Users</h1>
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
                                <asp:LinkButton runat="server" CommandName="AddFriend" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'
                                    Text="Add as friend" ID="linkBtnAddFriend" OnClick="linkBtnAddFriend_Click"></asp:LinkButton>
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
