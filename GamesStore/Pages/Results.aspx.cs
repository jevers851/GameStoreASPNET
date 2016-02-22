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
    public partial class Results : System.Web.UI.Page
    {
            private Repository repo = new Repository();
            private int pageSize = 5;

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
            public IEnumerable<Product> GetProducts()
            {
                IEnumerable<Product> products = repo.Products;


                try
                {
                string keyword = Session["keyword"].ToString().ToLower();

                var q = from p in products where p.Name.ToLower().Contains(keyword) || p.Description.ToLower().Contains(keyword) select p;
                return q;
                }
                catch(NullReferenceException)
                {

                }

                return null;

                /*return FilterProducts()
                    .OrderBy(p => p.ProductID)
                    .Skip((CurrentPage - 1) * pageSize)
                    .Take(pageSize);*/
            }



            public IEnumerable<Product> GetFProducts()
            {
                return FeaturedProducts();
            }
            public IEnumerable<Product> GetHProducts()
            {
                return HotProducts();
            }
            protected int CurrentPage
            {
                get
                {
                    int page = GetPageFromRequest();
                    return page > MaxPage ? MaxPage : page;
                }
            }
            protected int MaxPage
            {
                get
                {
                    int prodCount = FilterProducts().Count();
                    return (int)Math.Ceiling((decimal)prodCount / pageSize);
                }
            }

            private IEnumerable<Product> FilterProducts()
            {
                IEnumerable<Product> products = repo.Products;
                string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
                return currentCategory == null ? products
                : products.Where(p => p.Category == currentCategory);
            }

            private int GetPageFromRequest()
            {
                int page;
                string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
                return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
            }
            private IEnumerable<Product> FeaturedProducts()
            {
                IEnumerable<Product> products = repo.Products;
                bool t = true;
                return products.Where(p => p.featured == t);
            }
            private IEnumerable<Product> HotProducts()
            {
                IEnumerable<Product> products = repo.Products;
                bool t = true;
                return products.Where(p => p.hot == t);
            }
            protected void btnlogin_Click(object sender, EventArgs e)
            {
                Response.Redirect("/Pages/Account/Login.aspx");
            }
        }
}