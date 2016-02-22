<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Account/Customer.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="GamesStore.Pages.Account.Forgot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="content">
        <div id="forgotAccountForm" class="create" runat="server">
            <table>
                <tr>
                    <td colspan="2">
                        <center><h2>Forgot Password</h2></center>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">Email:</td>
                    <td style="width: 200px">
                        <input class="form-field" type="text" name="email" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input class="submit-button" type="submit" value="Submit" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
