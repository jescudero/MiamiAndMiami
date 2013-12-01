using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    private MySqlCommand cmd;
    private MySqlConnection con;


    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if ((string)(String)Session["sessionUserName"] == "" || (string)(String)Session["sessionUserName"] == null)
        {

            LnkLogin.Text = "Log In";
            reg.Visible = true;
            LnkPassword.Visible = false;
        }
        else
        {

            LnkLogin.Text = "Log Out";
            reg.Visible = false;
            LnkPassword.Visible = true;
        }
    }
    protected void LnkLogin_Click(object sender, EventArgs e)
    {
        base.Session.RemoveAll();
        if (LnkLogin.Text == "Log In")
        {
            Response.Redirect("Login.aspx");

        }
        else
        {

            Session["sessionUserName"] = null;
            Session["sessionUserType"] = null;
            Session["LoginUserkey"] = null;

            Session.RemoveAll();
            Response.Redirect("Default.aspx");

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Convert.ToString((String)Session["sessionUserType"]) == "Admin")
        {
            Response.Redirect("Admin/AdminHome.aspx");
        }
        else if (Convert.ToString((String)Session["sessionUserType"]) == "User")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}
