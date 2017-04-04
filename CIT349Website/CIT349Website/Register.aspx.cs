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

    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ourdb"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Register_Clicked(object sender, EventArgs e)
        {
            // string error = "";
            try
            {

                if (!string.IsNullOrEmpty(txtUser.Text) || !string.IsNullOrEmpty(txtPass.Text) || !string.IsNullOrEmpty(txtConfirm.Text)
                    || !string.IsNullOrEmpty(txtFName.Text) || !string.IsNullOrEmpty(txtLName.Text) )
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }


                    SqlCommand sqlAccount = new SqlCommand();
                    sqlAccount.CommandText = "INSERT INTO Account (ACCT_USERNAME, ACCT_PASSWORD, ACCT_FIRSTNAME, ACCT_LASTNAME) VALUES (@value1, @value2, @value3, @value4);";
                    sqlAccount.Parameters.AddWithValue("@value1", txtUser.Text);
                    sqlAccount.Parameters.AddWithValue("@value2", txtPass.Text);
                    sqlAccount.Parameters.AddWithValue("@value3", txtFName.Text);
                    sqlAccount.Parameters.AddWithValue("@value4", txtLName.Text);
                    sqlAccount.Connection = con;
                    sqlAccount.ExecuteNonQuery();
                     
                
                  
                 
                    Session["User"] = txtFName.Text + " " + txtLName.Text;
                    Session["UserStatus"] = "Sign Out";
                    Response.Redirect("~/Default");
                    sqlAccount.Dispose();
                    }else{

                    }
                       

            }
            catch (Exception k)
            {
                Response.Write(k.Message);
                //throw;
            }
            finally { con.Close(); }
        }
    }
}