using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Signup.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ForgotPassword.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "")
        {
            Response.Write("<script>alert('Please Fill all the Details');</script>");
        }
        else
        {
            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("Select * From LOGIN Where Username ='" + TextBox1.Text + "' and Password ='" + TextBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Session["Username"] = dr["Username"].ToString();
                Response.Redirect("Contact.aspx");
            }

            try
            {
                if (dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('Login Successfully');window.location='Contact.aspx';</script>");
                    Clear();
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Credentials');</script>");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Label3.Text = ex.Message;
            }
        }
    }

    private void Clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
}