using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Renci.SshNet;

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
        protected void didCheckProcess1(object sender, EventArgs e)
        {
            
            var PasswordConnection = new PasswordAuthenticationMethod("djmadurs", "r4vedave!");
            string myData = null;
            var connecitonInfo = new ConnectionInfo("141.210.25.85", "djmadurs", PasswordConnection);
            using (SshClient ssh = new SshClient(connecitonInfo))
            {
                ssh.Connect();
                var command = ssh.RunCommand("ps -ef | grep java");
                myData = command.Result;
                ssh.Disconnect();
            }
          

            if (myData.Contains("minecraft_server.1.11.2.jar"))
            {
                lblText1.Text = "Server Online: 141.210.25.85";
            }else
            {
                lblText1.Text = "Sorry, server is offline!";
            }
        }
        protected void didCheckProcess2(object sender, EventArgs e)
        {
            var PasswordConnection = new PasswordAuthenticationMethod("sumomuf", "Temp12345");
            string myData = null;
            var connecitonInfo = new ConnectionInfo("141.210.25.93", "sumomuf", PasswordConnection);
            using (SshClient ssh = new SshClient(connecitonInfo))
            {
                ssh.Connect();
                var command = ssh.RunCommand("ps -ef | grep java");
                myData = command.Result;
                ssh.Disconnect();
            }
            if (myData.Contains("minecraft_server.1.11.2.jar"))
            {
                lblText2.Text = "Server Online: 141.210.25.93";
            }
            else
            {
                lblText2.Text = "Sorry, server is offline!";
            }
        }
    }
}