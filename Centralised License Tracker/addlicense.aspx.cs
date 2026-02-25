using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace Centralised_License_Tracker
{
    public partial class addlicense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["LicenseDBConnection"].ConnectionString; 

            // Save uploaded file (abhi error fix krne h)
            string filePath = "";
            if (fileUploadDoc.HasFile)
            {
                string folderPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                filePath = "~/Uploads/" + Path.GetFileName(fileUploadDoc.FileName);
                fileUploadDoc.SaveAs(Server.MapPath(filePath));
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO Licenses 
                                (SoftwareName, LicenseKey, PurchaseDate, ExpiryDate, Cost, Department, Vendor, Notes, DocumentPath) 
                                VALUES (@SoftwareName, @LicenseKey, @PurchaseDate, @ExpiryDate, @Cost, @Department, @Vendor, @Notes, @DocumentPath)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SoftwareName", txtSoftwareName.Text);
                cmd.Parameters.AddWithValue("@LicenseKey", txtLicenseKey.Text);

                //  Purchase Date
                DateTime purchaseDate;
                if (DateTime.TryParse(txtPurchaseDate.Text, out purchaseDate))
                    cmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
                else
                    cmd.Parameters.AddWithValue("@PurchaseDate", DBNull.Value);

                //  Expiry Date
                DateTime expiryDate;
                if (DateTime.TryParse(txtExpiryDate.Text, out expiryDate))
                    cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                else
                    cmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);

                //  Cost
                decimal cost;
                if (decimal.TryParse(txtCost.Text, out cost))
                    cmd.Parameters.AddWithValue("@Cost", cost);
                else
                    cmd.Parameters.AddWithValue("@Cost", DBNull.Value);

                cmd.Parameters.AddWithValue("@Department", ddlDepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@Vendor", txtVendor.Text);
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
                cmd.Parameters.AddWithValue("@DocumentPath", filePath);

                con.Open();
                cmd.ExecuteNonQuery();


            }

            Response.Redirect("~/Landingpage/landingpage.aspx");



        }
    }
}
