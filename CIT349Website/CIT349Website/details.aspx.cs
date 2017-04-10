using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CIT349Website
{



    public partial class details : Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ourdb"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("Id") != null)
            {
                DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
                detail();
                bindComment();
            }
        }

        void detail()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from Blog where BLOG_ID=@id", con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ds.Tables[0].Columns.Add("FormDate", typeof(string));
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DateTime date = (DateTime)ds.Tables[0].Rows[0]["BLOG_DATE"];
                    string format = "MMM ddd d, yyyy";
                    ds.Tables[0].Rows[0]["FormDate"] = date.ToString(format);
                }
                DetailsView1.DataSource = ds;
                DetailsView1.DataBind();
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

        void bindComment()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Comments where COM_BLOG_ID=@id", con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    GridViewcomment.Visible = false;
                    LabelNoComment.Visible = true;
                }
                else
                {
                    GridViewcomment.Visible = true;
                    LabelNoComment.Visible = false;
                    GridViewcomment.DataSource = ds;
                    GridViewcomment.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbxcomment.Text != txbxcomment.ToolTip.ToString() || txbxcommentauthor.Text != txbxcommentauthor.ToolTip.ToString())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("insert into Comments(COM_BLOG_ID, COM_COMMENT, COM_NAME, COM_DATE) values(@bid,@com,@name,@date)", con);
                    cmd.Parameters.AddWithValue("@bid", Request.QueryString["Id"]);
                    cmd.Parameters.AddWithValue("@com", txbxcomment.Text);
                    cmd.Parameters.AddWithValue("@name", txbxcommentauthor.Text);
                    cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    txbxcomment.Text = String.Empty;
                    txbxcommentauthor.Text = String.Empty;
                    bindComment();
                }
                else
                {

                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }
    }
}