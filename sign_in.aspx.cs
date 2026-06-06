using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class sign_in : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void submit(object sender, EventArgs e)
    {
        String username = txtUsername.Text;
        String password = txtPassword.Text;
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomer\Downloads\first_robotics_fixed\App_Data\Database.mdf;Integrated Security=True";
        string sql = "SELECT isadmin FROM infothingy WHERE username=@u AND password=@p";
        using (SqlConnection con = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows) 
                {
                    reader.Read();
                    lblMessage.Text = "Login successful.";
                    lblMessage.ForeColor = Color.Green;
                    Session["LoggedIn"] = "True" ;
                    Session["username"] = username;
                    
                    object isAdminValue = reader["isadmin"];
                    if (isAdminValue != DBNull.Value && Convert.ToString(isAdminValue).Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        Session["isadmin"] = "True";
                    }
                    else
                    {
                        Session["isadmin"] = "False";
                    }

                    
                    Response.Redirect("AcountDetails.aspx");
                }
                else
                {
                    lblMessage.Text = "wrong username or password.";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
    }

    protected void reset(object sender, EventArgs e)
    {
        txtUsername.Text = "";
        txtPassword.Text = "";
    }
}