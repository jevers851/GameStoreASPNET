<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Store.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="GamesStore.Pages.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
        
    <div id="content">
    <asp:Repeater ItemType="GamesStore.Models.Product"
            SelectMethod="GetProduct" runat="server">

        <ItemTemplate>
            <div class="item">
                    <div class="thumb"><img style="height:300px;width:300px;" src="/Content/Images/FullSize/<%#Item.Image %>_full.png"></img></div>
                    <h3><%# Item.Name %></h3>
                    <h4><%# Item.Description %></h4>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" type="submit"
                        value="<%# Item.ProductID %>">Add to Cart</button>
            </div>
        </ItemTemplate>
     </asp:Repeater>
    </div>

</asp:Content>
