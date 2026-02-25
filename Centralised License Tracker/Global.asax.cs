using System;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Centralised_License_Tracker
{
    public partial class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            // Removed RouteConfig because it does not exist in this project
        }

        protected void Session_Start(object sender, EventArgs e) { }
        protected void Application_BeginRequest(object sender, EventArgs e) { }
        protected void Application_Error(object sender, EventArgs e) { }
        protected void Session_End(object sender, EventArgs e) { }
        protected void Application_End(object sender, EventArgs e) { }
    }
}
