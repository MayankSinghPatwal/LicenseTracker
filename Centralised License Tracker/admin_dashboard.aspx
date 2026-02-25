<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_dashboard.aspx.cs" Inherits="Centralised_License_Tracker.AdminDashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin - Manage Licenses</title>
    <link href="styles/admin_dashboard.css" rel="stylesheet" />
</head>
<body>
    
    <form id="form1" runat="server">
        <div class="container">
            <h1> Admin Panel</h1>

            <div class="filter-section">
                <label>Select Department:</label>
                <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                     <asp:ListItem Text="IT" Value="IT"></asp:ListItem>
                    <asp:ListItem Text="HR" Value="HR"></asp:ListItem>
                    <asp:ListItem Text="Finance" Value="Finance"></asp:ListItem>
                    <asp:ListItem Text="Legal" Value="Legal"></asp:ListItem>
                    <asp:ListItem Text="Operations" Value="Operations"></asp:ListItem>
                    <asp:ListItem Text="Sales" Value="Sales"></asp:ListItem>
                    <asp:ListItem Text="Marketing" Value="Marketing"></asp:ListItem>
                    <asp:ListItem Text="Procurement" Value="Procurement"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:GridView ID="gvLicenses" runat="server" AutoGenerateColumns="False" CssClass="table"
                DataKeyNames="LicenseID" OnRowEditing="gvLicenses_RowEditing" 
                OnRowUpdating="gvLicenses_RowUpdating" OnRowCancelingEdit="gvLicenses_RowCancelingEdit"
                OnRowDeleting="gvLicenses_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="LicenseID" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="SoftwareName" HeaderText="Software" ReadOnly="true" />
                    <asp:BoundField DataField="Department" HeaderText="Department" ReadOnly="true" />
                    <asp:BoundField DataField="PurchaseDate" HeaderText="Purchased On" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="LicenseKey" HeaderText="License Key" ReadOnly="true" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />

                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
       
</body>
</html>
