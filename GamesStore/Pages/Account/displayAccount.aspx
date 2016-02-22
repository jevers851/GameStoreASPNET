<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Account/Customer.Master" AutoEventWireup="true" CodeBehind="displayAccount.aspx.cs" Inherits="GamesStore.Pages.Account.displayAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="createAccountForm" class="create" runat="server">
            <h2>Your account details!</h2>
            These are your account details. You can also update values from below. 
            <div id="errors" data-valmsg-summary="true">
                <ul>
                    <li style="display: none"></li>
                </ul>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>
            <h2>Account</h2>
                <input name="CustomerId" runat="server" id="CustomerId" type="hidden" />
            <h3>Address</h3>
            <div>
                <label for="name">Name:</label>
                <input value="<% Name.Value %>" name="Name" runat="server" id="Name" data-val="true" data-val-required="" />
            </div>
            <div>
                <label for="line1">Line 1:</label>
                <input value="<% Line1.Value %>" name="Line1" runat="server" id="Line1" />
            </div>
            <div>
                <label for="line2">Line 2:</label>
                <input value="<% Line2.Value %>" name="Line2" runat="server" id="Line2" />
            </div>
            <div>
                <label for="city">City:</label>
                <input value="<% City.Value %>" name="City" runat="server" id="City" />
            </div>
            <div>
                <label for="state">State:</label>
                <input value="<% State.Value %>" name="State" runat="server" id="State" />
            </div>
            <div>
                <label for="postal">Postal Code:</label>
                <input value="<% PostalCode.Value %>" name="PostalCode" runat="server" id="PostalCode" />
            </div>
            <div>
                <label for="email">Email:</label>
                <input value="<% Email.Value %>" name="Email" runat="server" id="Email" />
            </div>
            <div>
                <label for="password">Password:</label>
                <input value="<% Password.Value %>" name="Password" runat="server" id="Password" />
            </div>
            <p class="actionButtons">
                <button class="actionButtons" type="submit">Update Account</button>
            </p>
        </div>
    </div>
</asp:Content>
