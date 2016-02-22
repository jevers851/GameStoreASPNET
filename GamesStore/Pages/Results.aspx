<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Store.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="GamesStore.Pages.Results" %>

<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">

         <div id="content">
             <p></p>
             <p>Current Listings</p>
        <asp:Repeater ItemType="GamesStore.Models.Product" SelectMethod="GetProducts" runat="server">
        <ItemTemplate>
            <div class="item">
                <div class="thumb"><img style="height:60px;width:60px;" src="/Content/Images/Thumbs/<%#Item.Image %>_thumbs.png"></img></div>
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
    
    <div class="pager">
        <% for (int i = 1; i <= MaxPage; i++)
           {
            string path2 = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "page", i } }).VirtualPath;
               
            string path = "/Pages/Results.aspx" + "/" + i;
            Response.Write(string.Format("<a href='{0}' {1}>{2}</a>", path, i == CurrentPage ? "class='selected'" : "", i));

           }%>
    </div>

</asp:Content>
