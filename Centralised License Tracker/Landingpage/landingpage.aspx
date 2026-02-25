<%@ Page Language="C#" AutoEventWireup="true" CodeFile="landingpage.aspx.cs" Inherits="Centralised_License_Tracker.landingpage" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Landing Page - License Tracker - Hitachi</title>
    <link rel="stylesheet" type="text/css" href="/styles/landingpage.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />

</head>
<body>
    <form id="form1" runat="server">
       
        <video autoplay muted loop id="bgVideo">
            <source src="/videos/landing-page-video.mp4" type="video/mp4">
            Your browser does not support HTML5 video.
        </video>

       
        <div class="overlay">

          
            <nav class="navbar">
                <div class="logo">Hitachi</div>
                <ul class="nav-links">
                    <li><a href="#">Home</a></li>
                    <li><a href="#features">Features</a></li>
                    <li><a href="#">Flow</a></li>
                    <li><a href="#">Contact Us</a></li>
                </ul>
                <div class="social-icons">
                    <a href="#"><i class="fab fa-linkedin"></i></a>
                    <a href="#"><i class="fab fa-instagram"></i></a>
                    <a href="#"><i class="fab fa-twitter"></i></a>
                </div>
            </nav>

            <!-- Hero Content -->
            <div class="hero-content">
                <h1>Centralized License & Compliance Tracker</h1>
                <p>Effortlessly manage and track your enterprise software licenses.</p>
                <div class="buttons">

                   <asp:Button ID="btnAddLicense" runat="server" Text="Add License" CssClass="hero-btn" OnClick="btnAddLicense_Click" />

                    <asp:Button ID="btnUploadLicense"  runat="server" Text="Upload License" CssClass="hero-btn" OnClick="btnUploadLicense_Click" />

                    <asp:Button ID="btnManageLicenses" runat="server" Text="Manage all licences" CssClass="hero-btn secondary-btn" OnClick="btnManageLicenses_Click" />
    

                </div>
            </div>

        </div>


            <!-- Features Section Start -->
   <section class="features-section" id="features">
    <h2>Key Features</h2>
    <div class="features-grid">

        <div class="feature-card dark-card">
            <div class="icon-placeholder"><i class="fa-regular fa-clock"></i></div>
            <h3>Never Miss a License Renewal</h3>
            <p>We’ll remind you before any license expires so you always stay on time.</p>
            
        </div>

        <div class="feature-card light-card">
            <div class="icon-placeholder"><i class="fa-solid fa-chart-simple"></i></div>
            <h3>Know Which Licenses Are Being Used</h3>
            <p>Get clear reports showing which licenses are active and how they’re being used.</p>
            
        </div>

        <div class="feature-card dark-card">
            <div class="icon-placeholder"><i class="fa-regular fa-clipboard"></i></div>
            <h3>Manage All Licenses in One Place</h3>
            <p>No more spreadsheets! View and organize all your licenses in a single dashboard.</p>
            
        </div>

        <div class="feature-card light-card">
            <div class="icon-placeholder"><i class="fa-solid fa-lock"></i></div>
            <h3>Be Always Audit-Ready</h3>
            <p>Keep a history of all license activities to stay fully prepared for any audits.</p>
          
        </div>

    </div>
</section>


        <!-- flow -->

        <section class="workflow-section" id="workflow">
    <h2>How it Works</h2>
    <p class="workflow-subtext">Understand how the License Tracker simplifies license management in 3 easy steps.</p>

    <div class="workflow-steps">

        <div class="workflow-step">
            <div class="workflow-icon"><i class="fa-solid fa-file-circle-plus"></i></div>
            <h3>Add License</h3>
            <p>Employees can easily add new software licenses by filling details like license name, expiry date, and can also upload the license PDF document.</p>
        </div>

        <div class="workflow-step">
            <div class="workflow-icon"><i class="fa-solid fa-circle-info"></i></div>
            <h3>Extract License Data</h3>
            <p>The License Tracker automatically reads the uploaded documents, extracts license information, and saves it in a centralized system.</p>
        </div>

        <div class="workflow-step">
            <div class="workflow-icon"><i class="fa-solid fa-user-tie"></i></div>
            <h3>Admin Dashboard</h3>
            <p>Admin can view all active licenses, track usage, manage assignments, and monitor compliance from the Admin Dashboard.</p>
        </div>

    </div>

    <div class="workflow-line"></div>
</section>


        <!-- contact us -->


     <footer class="footer-contact" id="contact">
    <h2>Contact Us</h2>
    <div class="footer-container">

        <div class="footer-info">
            <h3>Hitachi Systems India Pvt. Ltd.</h3>
            <p>Sector 18, Gurugram, Haryana - 122015</p>
            <p>Email: support@hitachisystems.com</p>
            <p>Phone: +91 9876543210</p>
            <div class="footer-socials">
                <a href="#"><i class="fab fa-linkedin"></i></a>
                <a href="#"><i class="fab fa-instagram"></i></a>
                <a href="#"><i class="fab fa-twitter"></i></a>
            </div>
        </div>
        
        <div class="footer-form">
            <form action="#" method="POST">
                <input type="text" name="name" placeholder="Name" />
                <input type="email" name="email" placeholder="Email" />
                <textarea name="message" placeholder="Message" rows="3" ></textarea>
                <button type"submit">Send</button>
            </form>
        </div> -

    </div>
</footer>



    </form>
</body>
</html>
