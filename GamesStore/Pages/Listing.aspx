<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" MasterPageFile="/Pages/Store.Master" Inherits="GamesStore.Pages.Listing" %>

<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.Routing" %>



<asp:Content ContentPlaceHolderID="bodyContent" runat="server">

    <div id="content">
        <a href="/Pages/Featured.aspx/">Featured</a>
        <asp:Repeater ItemType="GamesStore.Models.Product"
            SelectMethod="GetFProducts" runat="server">
            <ItemTemplate>
                <div class="item">
                    <div class="thumb">
                        <img style="height: 60px; width: 60px;" src="/Content/Images/Thumbs/<%#Item.Image %>_thumbs.png"></img></div>
                    <asp:HyperLink
                        ID="HyperLink1"
                        runat="server"
                        Text="<%# Item.Name %>"
                        NavigateUrl='<%#Eval("ProductID","~/Pages/Item.aspx/?ProductID={0}") %>'>
                    </asp:HyperLink>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" type="submit"
                        value="<%# Item.ProductID %>">
                        Add to Cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <a href="/Pages/WhatsHot.aspx/">What's Hot</a>
        <asp:Repeater ItemType="GamesStore.Models.Product"
            SelectMethod="GetHProducts" runat="server">
            <ItemTemplate>
                <div class="item">
                    <div class="thumb">
                        <img style="height: 60px; width: 60px;" src="/Content/Images/Thumbs/<%#Item.Image %>_thumbs.png"></img></div>
                    <asp:HyperLink
                        ID="HyperLink1"
                        runat="server"
                        Text="<%# Item.Name %>"
                        NavigateUrl='<%#Eval("ProductID","~/Pages/Item.aspx/?ProductID={0}") %>'>
                    </asp:HyperLink>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" type="submit"
                        value="<%# Item.ProductID %>">
                        Add to Cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <p>Current Listings</p>
        <asp:Repeater ItemType="GamesStore.Models.Product"
            SelectMethod="GetProducts" runat="server">
            <ItemTemplate>
                <div class="item">
                    <div class="thumb">
                        <img style="height: 60px; width: 60px;" src="/Content/Images/Thumbs/<%#Item.Image %>_thumbs.png"></img></div>
                    <asp:HyperLink
                        ID="HyperLink1"
                        runat="server"
                        Text="<%# Item.Name %>"
                        NavigateUrl='<%#Eval("ProductID","~/Pages/Item.aspx/?ProductID={0}") %>'>
                    </asp:HyperLink>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" type="submit"
                        value="<%# Item.ProductID %>">
                        Add to Cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="pager">
        <% for (int i = 1; i <= MaxPage; i++)
           {

               string currentCategory = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
               string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "page", i } }).VirtualPath;
               if (currentCategory != null)
               {
                   string path2 = "/list/" + currentCategory + "/" + i;
                   Response.Write(string.Format("<a href='{0}' {1}>{2}</a>", path2, i == CurrentPage ? "class='selected'" : "", i));
               }
               else
               {
                   Response.Write(string.Format("<a href='{0}' {1}>{2}</a>", path, i == CurrentPage ? "class='selected'" : "", i));
               }
           }%>
    </div>
</asp:Content>
