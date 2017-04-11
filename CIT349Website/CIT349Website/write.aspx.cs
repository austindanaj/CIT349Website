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
  
    public partial class write : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ourdb"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            txbxAuthor.Text = (string)(Session["User"]);
            txbxAuthor.Enabled = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txbxAuthor.Text) && !string.IsNullOrEmpty(txbxContent.Text) && !string.IsNullOrEmpty(txbxTitle.Text))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("insert into Blog (BLOG_TITLE,BLOG_CONTENT,BLOG_AUTHOR, BLOG_DATE) values(@title,@content,@author,@date)", con);
                    cmd.Parameters.AddWithValue("@title", txbxTitle.Text);
                    cmd.Parameters.AddWithValue("@content", txbxContent.Text);
                    cmd.Parameters.AddWithValue("@author", txbxAuthor.Text);
                    cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Response.Redirect("~/Default");
                }else
                {
                    displayErrorMessage("Please fill in all fields!");
                }
            }
            catch (Exception k)
            {
             //   Response.Write(k.Message);
                //throw;
            }
            finally { con.Close(); }

        }
        public void displayErrorMessage(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString(), true);
        }
    }
}