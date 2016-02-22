using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using GamesStore.Models;
using GamesStore.Models.Repository;
using GamesStore.Pages.Helpers;

namespace GamesStore.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                Order myOrder = new Order();
                if (TryUpdateModel(myOrder,
                new FormValueProvider(ModelBindingExecutionContext)))
                {
                    myOrder.OrderLines = new List<OrderLine>();

                    GamesStore.Models.Cart myCart = SessionHelper.GetCart(Session);
                    foreach (CartLine line in myCart.Lines)
                    {
                        myOrder.OrderLines.Add(new OrderLine
                        {
                            Order = myOrder,
                            Product = line.Product,
                            Quantity = line.Quantity
                        });
                    }
                    new Repository().SaveOrder(myOrder);
                    myCart.Clear();
                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Account/Login.aspx");
        }
    }
}