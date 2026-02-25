<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Centralised_License_Tracker.AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - License Tracker</title>
    <link rel="stylesheet" type="text/css" href="styles/login.css" />
</head>
<body>
    <form id="form1" runat="server" class="login-container">
        <div class="login-box">
            <h2>Login</h2>
            <asp:Label ID="lblUser" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="input-box"></asp:TextBox>

            <asp:Label ID="lblPass" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-box"></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="error-msg"></asp:Label>
        </div>
    </form>
</body>
</html>
