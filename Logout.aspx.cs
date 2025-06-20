using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSS
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //clear session variables
                Session.Abandon();
                //redirect to login page
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
               ;
            }
        }
    }
}