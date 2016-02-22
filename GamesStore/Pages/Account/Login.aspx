<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Account/Customer.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GamesStore.Pages.Account.Login" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary runat="server" DisplayMode="SingleParagraph" CssClass="error" />

    <div class="loginContainer">
        <div>
            <label for="email">Email:</label>
            <input name="email" />
        </div>
        <div>
            <label for="password">Password:</label>
            <input type="password" name="password" />
        </div>
        <button name="login" type="submit" value="1">Log In</button>
        <button name="login" type="submit" value="2">Log Out</button>
        <br />
        <button name="login" type="submit" value="3">Forgot Password</button>
        <button name="login" type="submit" value ="4">Create Account</button>

    </div>
</asp:Content>
