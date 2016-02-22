<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Account/Customer.Master" AutoEventWireup="true" CodeBehind="createAccount.aspx.cs" Inherits="GamesStore.Pages.Account.createAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="createAccountForm" class="create" runat="server">
            <h2>Create Account</h2>
            Please enter your details, so we know who you are!
            <div id="errors">
                <ul>
                    <li style="display: none"></li>
                </ul>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>
            <h3>Address</h3>
            <div>
                <label for="name">Name:</label>
                <SX:VInput Property="Name" runat="server" />
            </div>
            <div>
                <label for="line1">Line 1:</label>
                <SX:VInput Property="Line1" runat="server" />
            </div>
            <div>
                <label for="line2">Line 2:</label>
                <SX:VInput Property="Line2" runat="server" />
            </div>
            <div>
                <label for="city">City:</label>
                <SX:VInput Property="City" runat="server" />
            </div>
            <div>
                <label for="state">State:</label>
                <SX:VInput Property="State" runat="server" />
            </div>
            <div>
                <label for="postalcode">Postal Code:</label>
                <SX:VInput Property="PostalCode" runat="server" />
            </div>
            <div>
                <label for="email">Email:</label>
                <SX:VInput Property="Email" runat="server" />
            </div>
            <div>
                <label for="password">Password:</label>
                <SX:VInput Property="Password" runat="server" />
            </div>
            <p class="actionButtons">
                <asp:button CommandName="Submit" text="Create Account" runat="server"/>
            </p>
        </div>
    </div>

</asp:Content>
