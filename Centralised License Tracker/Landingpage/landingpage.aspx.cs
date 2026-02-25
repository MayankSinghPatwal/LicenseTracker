using System;
using System.Diagnostics;
using System.Web.UI;

namespace Centralised_License_Tracker
{
    public partial class landingpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // button click handler of uploadd license
        protected void btnUploadLicense_Click(object sender, EventArgs e)
        {
            // Redirect  to the Streamlit app running at localhost:8501
            Response.Redirect("http://localhost:8501");
        }

        protected void btnAddLicense_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/addlicense.aspx");
        }

        protected void btnManageLicenses_Click(object sender, EventArgs e)
        {
            // Redirect the user to the admin login page.
            Response.Redirect("~/login.aspx");
        }

    }
}
