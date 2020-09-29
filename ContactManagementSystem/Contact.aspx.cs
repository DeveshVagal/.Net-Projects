using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Contact : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        DisplayRecord();
        Label7.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "")
        {
            Response.Write("<script>alert('Please Fill all the Details');</script>");
        }
        else
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO ContactDetails (Name, EmailID, PhoneNumber1, PhoneNumber2, TelephoneNumber, Address) VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Contact Inserted Successfully');</script>");
                DisplayRecord();
                clear();
                con.Close();
            }
            catch (Exception ex)
            {
                Label7.Text = ex.Message;
            }
        }
    }

    private void clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "")
        {
            Response.Write("<script>alert('Please Fill all the Details');</script>");
        }
        else
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("UPDATE ContactDetails SET Name ='" + TextBox1.Text + "', EmailID ='" + TextBox2.Text + "', PhoneNumber1 ='" + TextBox3.Text + "', PhoneNumber2 ='" + TextBox4.Text + "', TelephoneNumber ='" + TextBox5.Text + "', Address ='" + TextBox6.Text + "' WHERE id='" + TextBox7.Text + "' ", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Contact Updated Successfully');</script>");
                DisplayRecord();
                clear();
                con.Close();
            }
            catch (Exception ex)
            {
                Label7.Text = ex.Message;
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox7.Text == "")
        {
            Response.Write("<script>alert('Please Enter the ID to fetch data');</script>");
            clear();
        }
        else
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("DELETE FROM ContactDetails WHERE id='" + TextBox7.Text + "'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Contact Deleted Successfully');</script>");
                DisplayRecord();
                clear();
                con.Close();
            }
            catch (Exception ex)
            {
                Label7.Text = ex.Message;
            }
        }
    }

    public DataTable DisplayRecord()
    {
        SqlConnection con = new SqlConnection(conn);
        SqlDataAdapter Adp = new SqlDataAdapter("select * from ContactDetails", con);
        DataTable Dt = new DataTable();
        Adp.Fill(Dt);
        GridView1.DataSource = Dt;
        GridView1.DataBind();
        return Dt;
    }

    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox7.Text == "")
        {
            Response.Write("<script>alert('Please Enter the ID to fetch data');</script>");
            clear();
        }
        else
        {
            SqlConnection con = new SqlConnection(conn);

            con.Open();


            SqlCommand cmd = new SqlCommand("select * from ContactDetails where id='" + TextBox7.Text.Trim() + "'", con);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())

            {

                TextBox1.Text = reader["Name"].ToString();

                TextBox2.Text = reader["EmailID"].ToString();

                TextBox3.Text = reader["PhoneNumber1"].ToString();

                TextBox4.Text = reader["PhoneNumber2"].ToString();

                TextBox5.Text = reader["TelephoneNumber"].ToString();

                TextBox6.Text = reader["Address"].ToString();

                reader.Close();

                con.Close();

            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('Logged Out Successfully');window.location='Logout.aspx';</script>");
    }
}