using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GamesStore.Models.Repository;
using GamesStore.Models;
using System.Web.ModelBinding;

namespace GamesStore.Pages.Account
{
    public partial class createAccount : System.Web.UI.Page
    {
        private Repository repo = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Customer myCustomer = new Customer();

                if(TryUpdateModel(myCustomer, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    repo.SaveCustomer(myCustomer);

                    Session["Email"] = myCustomer.Email;
                    Session["Password"] = myCustomer.Password;

                    Response.Redirect("/Pages/Account/displayAccount.aspx");
                }
            }
        }
    }
}