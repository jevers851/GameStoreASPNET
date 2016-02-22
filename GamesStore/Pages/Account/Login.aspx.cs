using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GamesStore.Models.Repository;
using GamesStore.Models;
using System.Web.ModelBinding;
using System.Web.Security;

namespace GamesStore.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        Repository repo = new Repository();

        int redirect;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ReturnUrl"] != "" &&
                Request.QueryString["ReturnUrl"] != null &&
                Request.QueryString["ReturnUrl"].Contains("Admin"))
            {
                Response.Redirect("/Pages/Admin/AdminLogin.aspx");
            }
            if (IsPostBack)
            {
                string email = Request.Form["email"];
                string pass = Request.Form["password"];



                int.TryParse(Request.Form["login"], out redirect);

                if (redirect == 1 && email != null && pass != null && repo.ValidateAccount(email, pass))
                {
                    Session["Email"] = email;
                    Session["Password"] = pass;

                    Response.Redirect(Request["ReturnUrl"] ?? "/");
                }
                else
                {
                    ModelState.AddModelError("fail", "Login failed. Please try again.");
                }
                if(redirect == 2)
                {
                    FormsAuthentication.SignOut();
                }
                else if (redirect == 3)
                {
                    Response.Redirect("/Pages/Account/Forgot.aspx");
                }
                else if (redirect == 4)
                {
                    Response.Redirect("/Pages/Account/createAccount.aspx");
                }
                Response.Redirect(Request.Path);
            }
        }
        protected string GetUser()
        {
            return Context.User.Identity.Name;
        }
        protected bool GetRequestStatus()
        {
            return Request.IsAuthenticated;
        }
    }
}