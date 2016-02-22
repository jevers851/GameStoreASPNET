using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GamesStore.Models.Repository;
using GamesStore.Models;
using GamesStore.Pages.Helpers;
using System.Web.Routing;

namespace GamesStore.Pages
{
    public partial class Item : System.Web.UI.Page
    {
        private Repository repo = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedProductId;
                if (int.TryParse(Request.Form["add"], out selectedProductId))
                {
                    Product selectedProduct = repo.Products
                    .Where(p => p.ProductID == selectedProductId).FirstOrDefault();
                    if (selectedProduct != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedProduct, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                        Request.RawUrl);
                        Response.Redirect(RouteTable.Routes
                        .GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }
        }
        private IEnumerable<Product> FilterProducts()
        {
            IEnumerable<Product> products = repo.Products;
            string id = Request["ProductID"];
            return id == null ? products : products.Where(p => p.ProductID == Convert.ToInt32(id));


        }
        public IEnumerable<Product> GetProduct()
        {
            return FilterProducts();
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Account/Login.aspx");
        }

    }
}