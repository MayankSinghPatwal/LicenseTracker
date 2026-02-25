<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addlicense.aspx.cs" Inherits="Centralised_License_Tracker.addlicense" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add License</title>
    <link rel="stylesheet" type="text/css" href="styles/addlicense.css" />
</head>
<body>
    
    <form id="form1" runat="server">
        <div class="container">
            <h1>Add New License</h1>

            <div class="form-grid">
                <div class="form-group">
                    <label>Software Name</label>
                    <asp:TextBox ID="txtSoftwareName" runat="server" CssClass="input-text"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>License Key</label>
                    <asp:TextBox ID="txtLicenseKey" runat="server" CssClass="input-text"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Purchase Date</label>
                    <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="input-text" TextMode="Date"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Expiry Date</label>
                    <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="input-text" TextMode="Date"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Cost (₹)</label>
                    <asp:TextBox ID="txtCost" runat="server" CssClass="input-text"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Department</label>
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="input-text">
                        <asp:ListItem Text="Select Department" Value="" />
                        <asp:ListItem Text="IT" />
                        <asp:ListItem Text="HR" />
                        <asp:ListItem Text="Finance" />
                        <asp:ListItem Text="Admin" />
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Vendor</label>
                    <asp:TextBox ID="txtVendor" runat="server" CssClass="input-text"></asp:TextBox>
                </div>

                <div class="form-group full-width">
                    <label>Notes</label>
                    <asp:TextBox ID="txtNotes" runat="server" CssClass="input-text" TextMode="MultiLine" Rows="3"></asp:TextBox>
                </div>

                <div class="form-group full-width">
                    <label>Upload Document</label>
                    <asp:FileUpload ID="fileUploadDoc" runat="server" CssClass="input-text" />
                </div>
            </div>

            <div class="form-group full-width">
                <asp:Button ID="btnSubmit" runat="server" Text="Add License" CssClass="submit-btn" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
