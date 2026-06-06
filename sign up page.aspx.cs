using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;

public partial class sign_up_page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Submit(object sender, EventArgs e)
    {
        string username = Request["txtUsername"];
        string password = Request["txtPassword"];
        string firstname = Request["txtFirstName"];
        string lastname = Request["txtLastName"];
        string email = Request["txtEmail"];
        string phone = Request["txtPhone"];
        string gender = Request["rblGender"] ?? "";
        string[] hobbiesArr = Request.Form.GetValues("cblHobbies");
        string hobbies = hobbiesArr != null ? string.Join(", ", hobbiesArr) : "";
        string age = Request["ddlAge"];
        string teamname = Request["txtTeamName"];
        string teamnumber = Request["txtTeamNumber"];

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomer\Downloads\first_robotics_fixed\App_Data\Database.mdf;Integrated Security=True";

        try
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                string checkSql = "SELECT COUNT(*) FROM infothingy WHERE username = @u";
                using (SqlCommand checkCmd = new SqlCommand(checkSql, con))
                {
                    checkCmd.Parameters.AddWithValue("@u", username);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = "Username already exists";
                        return;
                    }
                }

                string sql = "INSERT INTO infothingy (username, password, [first name], [last name], eamil, phone, gender, hobbies, age, teamname, teamnumber) " +
                             "VALUES (@u, @p, @f, @l, @e, @ph, @g, @h, @a, @tn, @tnum)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@f", firstname);
                    cmd.Parameters.AddWithValue("@l", lastname);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@ph", phone);
                    cmd.Parameters.AddWithValue("@g", gender);
                    cmd.Parameters.AddWithValue("@h", hobbies);
                    cmd.Parameters.AddWithValue("@a", age);
                    cmd.Parameters.AddWithValue("@tn", teamname);
                    cmd.Parameters.AddWithValue("@tnum", teamnumber);
                    cmd.ExecuteNonQuery();
                }
            }

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Sign up successful!";
            pnlVideo.Visible = true;
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "Error: " + ex.Message;
        }
    }
}