<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Store.Master" AutoEventWireup="true" CodeBehind="Featured.aspx.cs" Inherits="GamesStore.Pages.Featured" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
         <div id="content">
            <p>Featured Items</p>
        <asp:Repeater ItemType="GamesStore.Models.Product"
            SelectMethod="GetFProducts" runat="server">
        <ItemTemplate>
            <div class="item">
                <div class="thumb"><img style="height:120px;width:120px;" src="/Content/Images/Thumbs/<%#Item.Image %>_thumbs.png"></img></div>
        <asp:HyperLink 
            ID="HyperLink1" 
            runat="server"
            Text="<%# Item.Name %>"
            NavigateUrl='<%#Eval("ProductID","~/Pages/Item.aspx/?ProductID={0}") %>'
            >
        </asp:HyperLink>
                <h4><%# Item.Price.ToString("c") %></h4>
                <button name="add" type="submit"
                    value="<%# Item.ProductID %>">Add to Cart</button>
            </div>
        </ItemTemplate>
        </asp:Repeater>
        </div>
</asp:Content>
