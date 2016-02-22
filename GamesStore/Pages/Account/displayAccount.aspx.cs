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
    public partial class displayAccount : System.Web.UI.Page
    {
        private Repository repo = new Repository();
        Customer c = new Customer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                c.CustomerId = Convert.ToInt32(Request.Form["ct100$ContentPlaceHolder1$CustomerId"]);
                c.Name = Request.Form["ct100$ContentPlaceHolder1$Name"];
                c.Line1 = Request.Form["ct100$ContentPlaceHolder1$Line1"];
                c.Line2 = Request.Form["ct100$ContentPlaceHolder1$Line2"];
                c.City = Request.Form["ct100$ContentPlaceHolder1$City"];
                c.State = Request.Form["ct100$ContentPlaceHolder1$State"];
                c.PostalCode = Request.Form["ct100$ContentPlaceHolder1$PostalCode"];
                c.Email = Request.Form["ct100$ContentPlaceHolder1$Email"];
                c.Password = Request.Form["ct100$ContentPlaceHolder1$Password"];

                if (TryUpdateModel(c, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    repo.SaveCustomer(c);

                    Session["Email"] = c.Email;
                    Session["Password"] = c.Password;

                    Response.Redirect("/Pages/Account/displayAccount.aspx");
                }
            }
            else
            {
                try
                {
                    string email = Session["Email"].ToString();
                    string password = Session["Password"].ToString();

                    if (email.Length == 0 || password.Length == 0)
                    {
                        Response.Redirect("/Pages/Login.aspx");
                    }
                    else
                    {
                        c = repo.GetCustomer(email, password);

                        CustomerId.Value = c.CustomerId.ToString();
                        Name.Value = c.Name;
                        Line1.Value = c.Line1;
                        Line2.Value = c.Line2;
                        City.Value = c.City;
                        State.Value = c.State;
                        PostalCode.Value = c.PostalCode.ToString();
                        Email.Value = c.Email;
                        Password.Value = c.Password;



                    }
                }
                catch
                {
                    Response.Redirect("/Pages/Account/Login.aspx");
                }
            }
        }
    }
}