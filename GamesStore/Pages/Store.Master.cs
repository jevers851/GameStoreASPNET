using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesStore.Pages
{
    public partial class Store : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int redirect = -1;

            int.TryParse(Request.Form["login"], out redirect);

            if (IsPostBack && redirect == 20)
            {
                string keyword = Request["keyword"];

                Session["keyword"] = keyword;

                Response.Redirect("/Pages/Results.aspx");
            }
            else if(IsPostBack && redirect == 1)
            {
                Response.Redirect("/Pages/Account/Login.aspx");
            }
            
        }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        
    }
    }
}