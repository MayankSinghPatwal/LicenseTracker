using System;

namespace Centralised_License_Tracker
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

       
            if (username == "admin" && password == "admin123")
            {
                Session["AdminUser"] = username;
                Response.Redirect("admin_dashboard.aspx"); 
            }
            else
            {
                lblMessage.Text = "Invalid Username or Password!";
            }
        }
    }
}
