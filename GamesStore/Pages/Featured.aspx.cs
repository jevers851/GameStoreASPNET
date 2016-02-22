using System;
using System.Collections.Generic;
using GamesStore.Models;
using GamesStore.Models.Repository;
using System.Linq;
using GamesStore.Pages.Helpers;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace GamesStore.Pages
{
    public partial class Featured : System.Web.UI.Page
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
        public IEnumerable<Product> GetFProducts()
        {
            return FeaturedProducts();
        }
        private IEnumerable<Product> FeaturedProducts()
        {
            IEnumerable<Product> products = repo.Products;
            bool t = true;
            return products.Where(p => p.featured == t);
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Account/Login.aspx");
        }
    }
}