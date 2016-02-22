<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="GamesStore.Pages.Admin.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="outerContainer">
        <table id="ordersTable">
    <tr><th>Name</th><th>City</th><th>Items</th><th>Total</th><th></th></tr>
        <asp:Repeater runat="server" SelectMethod="GetOrders"
                    ItemType="GamesStore.Models.Order">
            <ItemTemplate>
                <tr>
                    <td><%#: Item.Name %></td>
                    <td><%#: Item.City %></td>
                    <td><%# Item.OrderLines.Sum(ol => ol.Quantity) %></td>
                    <td><%# Total(Item.OrderLines).ToString("C") %> </td>
                </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>
