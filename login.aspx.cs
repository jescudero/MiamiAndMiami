using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Login : System.Web.UI.Page
{
    MySqlCommand cmd;
    MySqlConnection con;
    string UserKey;
    PasswordEncription Encryption = new PasswordEncription();
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (!IsPostBack)
        {
            CheckRemember();
            TxtUserName.Focus();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        checkuservalid();
    }
    protected void CheckRemember()
    {
        if (Request.Cookies["cookierememberusername"] != null)
        {
            ChkRememberMe.Checked = true;
            TxtUserName.Text = Request.Cookies["cookierememberusername"].Value;
            TxtPassword.Text = Request.Cookies["cookierememberpassword"].Value;
        }

    }
    protected void checkuservalid()
    {
        string strUserName = "";
        string strUserType = "";


        if (con.State == ConnectionState.Closed) con.Open();
        string CurrentPassword = TxtPassword.Text;
        string encrptionpass = Encryption.PasswordEncryption(ref CurrentPassword);
        cmd = new MySqlCommand("SELECT * FROM Users INNER JOIN registrations ON Users.UserKey = registrations.UserKey WHERE Users.Status = 'Activate' AND registrations.Status = 'Activate' And  Users.username = '" + TxtUserName.Text + "' and Users.password = '" + encrptionpass + "'", con);

        MySqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            if (dr.Read())
            {
                strUserName = dr["username"].ToString();
                strUserType = dr["usertype"].ToString();
                UserKey = dr["userkey"].ToString();

                if (ChkRememberMe.Checked == true)
                {
                    Response.Cookies["cookierememberusername"].Value = TxtUserName.Text;
                    Response.Cookies["cookierememberpassword"].Value = TxtPassword.Text;
                    Response.Cookies["cookierememberusername"].Expires = DateTime.Now.AddDays(365);
                    Response.Cookies["cookierememberpassword"].Expires = DateTime.Now.AddDays(365);

                }
                else
                {
                    Response.Cookies["cookierememberusername"].Value = null;
                    Response.Cookies["cookierememberusername"].Expires = DateTime.Now.AddDays(-365);
                    Response.Cookies["cookierememberpassword"].Value = null;
                    Response.Cookies["cookierememberpassword"].Expires = DateTime.Now.AddDays(-365);
                }

                dr.Close();

                Session["sessionUserName"] = strUserName;
                Session["sessionUserType"] = strUserType;
                Session["sessionUserkey"] = UserKey;

                if (strUserType == "Admin")
                {
                    Response.Redirect("Admin/AdminHome.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }



            }

            if (con.State == ConnectionState.Open) con.Close();
        }
        else
        {
            lblError0.Visible = true;
            lblError0.Text = "Invalid Username or Password";
        }

    }

}
