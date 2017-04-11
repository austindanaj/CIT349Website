using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace CIT349Website
{

    public partial class UserInfo : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ourdb"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((string)Session["UserStatus"]).Equals("Sign In"))
            {
                Response.Redirect("~/Login");
            }
        }
      
    }

}