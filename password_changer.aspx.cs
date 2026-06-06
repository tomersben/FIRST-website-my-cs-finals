using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class password_changer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoggedIn"] == null || Session["LoggedIn"].ToString() != "True")
        {
            Response.Redirect("sign_in.aspx");
        }
    }
    protected void submit(object sender, EventArgs e)
    {
        
        String password = txtPassword.Text;
        String username = Session["username"] as String;
        String newPassword = txtNewPassword.Text;
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomer\Downloads\first_robotics_fixed\App_Data\Database.mdf;Integrated Security=True";
        string sql = "SELECT * FROM infothingy WHERE username=@u AND password=@p";
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
                    reader.Close();
                    string updateSql = "UPDATE infothingy SET password=@np WHERE username=@u";
                    using (SqlCommand updateCmd = new SqlCommand(updateSql, con))
                    {
                        updateCmd.Parameters.AddWithValue("@np", newPassword);
                        updateCmd.Parameters.AddWithValue("@u", username);
                        updateCmd.ExecuteNonQuery();
                        lblMessage.Text = "Password changed successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    lblMessage.Text = "wrong password.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
    protected void reset(object sender,EventArgs e)
    {
        txtPassword.Text = "";
        txtNewPassword.Text = "";
    }
}