using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Centralised_License_Tracker
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LicenseDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartments();
                LoadLicenses();
            }
            LoadProfilePicture();
        }

        void LoadProfilePicture()
        {
            string adminUser = Session["AdminUser"] as string ?? "admin";
            lblAdminName.Text = adminUser;

            string uploadsDir = Server.MapPath("~/uploads/");
            string profilePicPath = FindProfilePicture(uploadsDir, adminUser);

            if (profilePicPath != null)
            {
                imgProfile.ImageUrl = "~/uploads/" + Path.GetFileName(profilePicPath);
            }
            else
            {
                imgProfile.ImageUrl = "";
                imgProfile.AlternateText = adminUser.Substring(0, 1).ToUpper();
            }
        }

        string FindProfilePicture(string uploadsDir, string adminUser)
        {
            if (!Directory.Exists(uploadsDir))
                return null;

            string[] extensions = { ".jpg", ".jpeg", ".png", ".gif" };
            foreach (string ext in extensions)
            {
                string filePath = Path.Combine(uploadsDir, adminUser + "_profile" + ext);
                if (File.Exists(filePath))
                    return filePath;
            }
            return null;
        }

        protected void btnUploadPic_Click(object sender, EventArgs e)
        {
            if (!fuProfilePic.HasFile)
            {
                lblProfileMsg.Text = "Please select an image file.";
                lblProfileMsg.CssClass = "profile-msg error";
                return;
            }

            string extension = Path.GetExtension(fuProfilePic.FileName).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            if (Array.IndexOf(allowedExtensions, extension) < 0)
            {
                lblProfileMsg.Text = "Only image files (.jpg, .jpeg, .png, .gif) are allowed.";
                lblProfileMsg.CssClass = "profile-msg error";
                return;
            }

            if (fuProfilePic.PostedFile.ContentLength > 2 * 1024 * 1024)
            {
                lblProfileMsg.Text = "File size must be under 2 MB.";
                lblProfileMsg.CssClass = "profile-msg error";
                return;
            }

            string contentType = fuProfilePic.PostedFile.ContentType;
            if (!contentType.StartsWith("image/"))
            {
                lblProfileMsg.Text = "Only image files are allowed.";
                lblProfileMsg.CssClass = "profile-msg error";
                return;
            }

            string adminUser = Session["AdminUser"] as string ?? "admin";
            string uploadsDir = Server.MapPath("~/uploads/");

            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir);

            // Remove any existing profile picture for this user
            string[] existingExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            foreach (string ext in existingExtensions)
            {
                string existingFile = Path.Combine(uploadsDir, adminUser + "_profile" + ext);
                if (File.Exists(existingFile))
                    File.Delete(existingFile);
            }

            string fileName = adminUser + "_profile" + extension;
            string savePath = Path.Combine(uploadsDir, fileName);
            fuProfilePic.SaveAs(savePath);

            lblProfileMsg.Text = "Profile picture updated successfully!";
            lblProfileMsg.CssClass = "profile-msg success";
            LoadProfilePicture();
        }

        void LoadDepartments()
        {
            ddlDepartment.Items.Clear();

          
            ddlDepartment.Items.Add("All Departments");

           
            string[] staticDepartments = { "IT", "HR", "Finance", "Legal", "Operations", "Sales", "Marketing", "Procurement" };
            foreach (var dept in staticDepartments)
            {
                ddlDepartment.Items.Add(dept);
            }

          
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Department FROM Licenses", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string dept = rdr["Department"].ToString();
                    if (ddlDepartment.Items.FindByValue(dept) == null)
                        ddlDepartment.Items.Add(dept);
                }
            }
        }

        void LoadLicenses(string dept = "")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Licenses";
                if (!string.IsNullOrEmpty(dept) && dept != "All Departments")
                {
                    query += " WHERE Department=@dept";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                if (!string.IsNullOrEmpty(dept) && dept != "All Departments")
                    cmd.Parameters.AddWithValue("@dept", dept);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvLicenses.DataSource = dt;
                gvLicenses.DataBind();
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLicenses(ddlDepartment.SelectedValue);
        }

        protected void gvLicenses_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvLicenses.EditIndex = e.NewEditIndex;
            LoadLicenses(ddlDepartment.SelectedValue);
        }

        protected void gvLicenses_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvLicenses.EditIndex = -1;
            LoadLicenses(ddlDepartment.SelectedValue);
        }

        protected void gvLicenses_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int licenseID = Convert.ToInt32(gvLicenses.DataKeys[e.RowIndex].Value);
            string expiryDate = (gvLicenses.Rows[e.RowIndex].Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            string status = (gvLicenses.Rows[e.RowIndex].Cells[6].Controls[0] as System.Web.UI.WebControls.TextBox).Text;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Licenses SET ExpiryDate=@expiry, Status=@status WHERE LicenseID=@id", con);
                cmd.Parameters.AddWithValue("@expiry", expiryDate);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", licenseID);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            gvLicenses.EditIndex = -1;
            LoadLicenses(ddlDepartment.SelectedValue);
        }

        protected void gvLicenses_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int licenseID = Convert.ToInt32(gvLicenses.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Licenses WHERE LicenseID=@id", con);
                cmd.Parameters.AddWithValue("@id", licenseID);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadLicenses(ddlDepartment.SelectedValue);
        }
    }
}
