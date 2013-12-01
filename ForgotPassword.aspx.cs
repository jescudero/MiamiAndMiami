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

public partial class ForgotPassword : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    SMSAndEmail objSmsEmail = new SMSAndEmail();
    PasswordEncription Encryption = new PasswordEncription();
    protected void Page_Load(object sender, EventArgs e)
    {

        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    }


    protected void Btnok_Click(object sender, EventArgs e)
    {
        LblError.Text = "";
        if (TxtEmailId.Text != "")
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd = new MySqlCommand("SELECT * FROM Users WHERE Users.UserName =  '" + TxtEmailId.Text + "'", con);

            MySqlDataAdapter MemberAdpt = new MySqlDataAdapter(cmd);
            DataTable MemberDT = new DataTable();
            MemberAdpt.Fill(MemberDT);
            if (MemberDT.Rows.Count > 0)
            {
                string CurrentPassword = MemberDT.Rows[0]["Password"].ToString();
                string encrptionpass = Encryption.PasswordDecryption(ref CurrentPassword);

                string MessageId = "Dear " + MemberDT.Rows[0]["UserName"].ToString() + ",\r\n \r\n You are now a registered member of http://MiamiandMiami.com. \r\n \r\n Your password for the username '" + MemberDT.Rows[0]["UserName"].ToString() + "' is displayed below: \r\n Password: " + encrptionpass + "\r\n \r\n If you wish to change your password, login and click the ‘Change Password’ link to change it.\r\n \r\n Thanks,\r\nMiami and Miami Team.";
              
                cmd = new MySqlCommand("SELECT  *  FROM Options Where OptionKey=1", con);
                MySqlDataAdapter objOptionAdapter = new MySqlDataAdapter(cmd);
                DataTable OptionDataTable = new DataTable();

                objOptionAdapter.Fill(OptionDataTable);

                int Portnumber = 0;
                if (OptionDataTable.Rows[0]["PortNumber"].ToString() != "")
                {
                    Portnumber = Convert.ToInt32(OptionDataTable.Rows[0]["PortNumber"].ToString());
                }

                //Send To Email and sms
                string[] StrAttachment = new string[0];
                objSmsEmail.SendMail (OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), MemberDT.Rows[0]["UserName"].ToString(), "Recovery Password", MessageId,false,StrAttachment);


                LblError.Text = "Your password has been sent to your registered email id.";
                TxtEmailId.Text = "";

            }
            else
            {
                LblError.Text = "This email id is not registered with us.";
            }
            if (con.State == ConnectionState.Open) con.Close();

        }
        else
        {
            LblError.Text = "This email id is not registered with us.";
        }

        
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
