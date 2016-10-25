﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Use the form below to create a new account.</h2>
    </hgroup>

    <p class="message-info">
        Passwords are required to be a minimum of 6 characters in length.
    </p>

    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li>
                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                <asp:TextBox runat="server" ID="UserName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="Email">Email address</asp:Label>
                <asp:TextBox runat="server" ID="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </li>
        </ol>
        <asp:Button runat="server" ID="btnRegister" Text="Register" OnClick="btnRegister_Click" />
    </fieldset>

</asp:Content>
