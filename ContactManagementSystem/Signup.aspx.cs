using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Signup : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "")
        {
            Response.Write("<script>alert('Please Fill all the Details');</script>");
        }
        else
        {
            if (TextBox2.Text == TextBox3.Text)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("INSERT INTO LOGIN (Username, Password) VALUES('" + TextBox1.Text + "','" + TextBox3.Text + "')", con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Member Signed Up Successfully');window.location='Login.aspx';</script>");
                    clear();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Label4.Text = ex.Message;
                }
            }
            else
            {
                Response.Write("<script>alert('Password Do not match');</script>");
                clear();
            }
        }
        
    }

    private void clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('Back To Login');window.location='Login.aspx';</script>");
    }
}