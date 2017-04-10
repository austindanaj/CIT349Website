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

    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ourdb"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty((string)Session["UserStatus"]))
                {
                    Session["UserStatus"] = "Sign In";
                    Session["User"] = "";
                }
                if (((string)Session["UserStatus"]).Equals("Sign Out"))
                {
                    txtPass.Visible = false;
                    txtUser.Visible = false;
                    lblSignIn.Visible = false;
                    btnSignIn.Text = "Sign Out";
                }
            }
        }
        protected void SignIn_Clicked(object sender, EventArgs e)
        {

            if (((string)Session["UserStatus"]).Equals("Sign In"))
            {
                // string error = "";
                try
                {
                    if (!string.IsNullOrEmpty(txtUser.Text) || (!string.IsNullOrEmpty(txtPass.Text)))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }


                        SqlCommand sqlAccount = new SqlCommand();
                        sqlAccount.CommandText = "SELECT * FROM Account WHERE ACCT_USERNAME=@value1 AND ACCT_PASSWORD=@value2;";
                        sqlAccount.Parameters.AddWithValue("@value1", txtUser.Text);
                        sqlAccount.Parameters.AddWithValue("@value2", txtPass.Text);
                        sqlAccount.Connection = con;
                        SqlDataReader readerAccount = sqlAccount.ExecuteReader();
                        int count = 0;
                        while (readerAccount.Read())
                        {
                            count++;
                            string fName = readerAccount.GetString(2);
                            string lName = readerAccount.GetString(3);
                            Session["User"] = fName + " " + lName;
                            Session["UserStatus"] = "Sign Out";
                            Response.Redirect("~/Default");
                            break;
                        }
                        sqlAccount.Dispose();
                    }
                    else
                    {

                    }





                }
                catch (Exception k)
                {
                    Response.Write(k.Message);
                    //throw;
                }
                finally { con.Close(); }
            }
            else
            {
                Session["User"] = "";
                Session["UserStatus"] = "Sign In";
                Response.Redirect("~/Default");
            }
        }
        protected void NeedAccount_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("~/Register");
        }
    }

}