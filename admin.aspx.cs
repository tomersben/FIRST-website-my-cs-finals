using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class admin : System.Web.UI.Page
{
    string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomer\Downloads\first_robotics_fixed\App_Data\Database.mdf;Integrated Security=True";

    string[] allowedFields = { "username", "password", "first name", "last name", "eamil", "phone", "gender", "hobbies", "age", "teamname", "teamnumber" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isadmin"] == null || Session["isadmin"].ToString() != "True")
        {
            Response.Redirect("sign_in.aspx");
        }
        if (!IsPostBack)
        {
            LoadUsers("username");
        }
    }

    private void LoadUsers(string orderBy)
    {
        if (Array.IndexOf(allowedFields, orderBy) < 0)
        {
            orderBy = "username";
        }
        using (SqlConnection con = new SqlConnection(connStr))
        {
            string sql = "SELECT * FROM infothingy ORDER BY [" + orderBy + "]";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Session["UsersData"] = dt;
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
        }
    }

    protected void btnsortABC_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["UsersData"];
        DataView dv = dt.DefaultView;
        dv.Sort = "username ASC";
        gvUsers.DataSource = dv;
        gvUsers.DataBind();
    }
    protected void btnsortint(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["UsersData"];
        DataView dv = dt.DefaultView;
        dv.Sort = "Id ASC";
        gvUsers.DataSource = dv;
        gvUsers.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string username = txtDeleteUsername.Text;
        using (SqlConnection con = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand("DELETE FROM infothingy WHERE username=@u", con))
        {
            cmd.Parameters.AddWithValue("@u", username);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        LoadUsers("username");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string username = txtUpdateUsername.Text;
        string field = ddlField.SelectedValue;
        string newValue = txtNewValue.Text;
        if (Array.IndexOf(allowedFields, field) < 0)
        {
            return;
        }
        using (SqlConnection con = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand("UPDATE infothingy SET [" + field + "]=@val WHERE username=@u", con))
        {
            cmd.Parameters.AddWithValue("@val", newValue);
            cmd.Parameters.AddWithValue("@u", username);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        LoadUsers("username");
    }

    protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadUsers(ddlSort.SelectedValue);
    }
}