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

    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ourdb"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            BindBlog();
        }
        protected void Post_clicked(object sender, EventArgs e)
        {
            Response.Redirect("~/write");
        }
        void BindBlog()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Blog order by BLOG_DATE desc ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                cmd.Dispose();
            }
            catch (Exception k)
            {
                Response.Write(k.Message);
                //throw;
            }
            finally
            {
                con.Close();
            }

        }
    }
}