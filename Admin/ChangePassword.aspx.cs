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

public partial class Admin_ChangePassword : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    PasswordEncription Encryption = new PasswordEncription();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


    }

    protected void LnkDone_Click(object sender, EventArgs e)
    {
        string CurrentPassword = TxtCurrentPassword .Text;
        string encrptionpass = Encryption.PasswordEncryption(ref CurrentPassword);


        if (con.State == ConnectionState.Closed ) con.Open();
        cmd = new MySqlCommand("Select * from Users where UserKey='" + (String)Session["sessionUserkey"] + "' and Password='" + encrptionpass + "'", con);
        MySqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.Read())
        {
            Dr.Close();
            if (TxtConfirmPassword.Text == TxtNewPassword.Text)
            {
                string NewPassword = TxtNewPassword.Text;
                string Newencrptionpass = Encryption.PasswordEncryption(ref NewPassword);
                cmd = new MySqlCommand("Update Users set Password='" + Newencrptionpass + "' where UserKey='" + (String)Session["sessionUserKey"] + "'", con);
                cmd.ExecuteNonQuery();
                TxtConfirmPassword.Text = "";
                TxtNewPassword.Text = "";
                TxtCurrentPassword.Text = "";
                LblError.Text = "Password Successfully Update";
                      
            }

            else
            {
                LblError.Text = "Password is not Match";
            }
        }
        else
        {
            LblError.Text = "Current Password Not Correct";

        }


    }
    protected void LnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
     
    }
   
}
