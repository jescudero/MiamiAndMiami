using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.Routing;
namespace TestCacheTimeout 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{

        
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
            RouteTable.Routes.Add("Hotel", new Route("{HotelID}", new PageRouteHandler("~/HotelDetail.aspx")));
            RouteTable.Routes.Add("Package", new Route("{Package}", new PageRouteHandler("~/Package.aspx")));
            //RouteTable.Routes.MapPageRoute("Hotel", "{HotelID}", "~/HotelDetail.aspx");
            //RouteTable.Routes.MapPageRoute("Package", "{Package}", "~/Package.aspx");
		}

               
	
        protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
           
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			Debug.WriteLine( Server.GetLastError() );
		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

