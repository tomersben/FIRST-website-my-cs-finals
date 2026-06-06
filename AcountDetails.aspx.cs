using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class AcountDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoggedIn"] == null || Session["LoggedIn"].ToString() != "True")
        {
            Response.Redirect("sign_in.aspx");
        }
        String username = Session["username"] as String;
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomer\Downloads\first_robotics_fixed\App_Data\Database.mdf;Integrated Security=True";
        string sql = "SELECT * FROM infothingy WHERE username=@u";
        using (SqlConnection con = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@u", username);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblUsername.Text = reader["username"] as String;
                lblFirstName.Text = reader["first name"] as String;
                lblLastName.Text = reader["last name"] as String;
                lblEmail.Text = reader["eamil"] as String;
                lblPhone.Text = reader["phone"] as String;
                lblGender.Text = reader["gender"] as String;
                lblHobbies.Text = reader["hobbies"] as String;
                lblAge.Text = reader["age"] as String;
                lblTeamName.Text = reader["teamname"] as String;
                lblTeamNumber.Text = reader["teamnumber"] as String;
                lbladmin.Text = reader["isadmin"] as String;
                con.Close();
            }
        }
    }
    protected void logout(object sender, EventArgs e)
    {
        Session["LoggedIn"] = null;
        Session["username"] = null;
    }
}