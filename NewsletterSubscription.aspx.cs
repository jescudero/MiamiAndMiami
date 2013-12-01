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
using MySql.Data.MySqlClient;
public partial class NewsletterSubscription : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        EmialID();
    }

    private void EmialID()
    {
        string Email = Convert.ToString((String)Request.QueryString["Email"]);

        if (con.State == ConnectionState.Closed) con.Open();
        MySqlDataAdapter da;
        DataTable dt;
         cmd = new MySqlCommand("Select * from newsletters Where SubscribeEmailID = '" + Email + "'", con);

        da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
  
        if (dt.Rows.Count == 0)
        {

            cmd = new MySqlCommand("insert into newsletters (SubscribeEmailID,SubscribeDate) values (@SubscribeEmailID,@SubscribeDate)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@SubscribeEmailID", Email);
            cmd.Parameters.AddWithValue("@SubscribeDate", DateTime.Now );
            cmd.ExecuteNonQuery();
            ss.InnerHtml = "Thank you for subscribing to our email list";
            ss.Attributes.Add("class", "email_successbg");


            string msgUser = "Please keep this email for later reference." + Email;

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
            SMSAndEmail objSmsEmail = new SMSAndEmail();
            objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), OptionDataTable.Rows[0]["AdminEmailId1"].ToString(), "New Newsletter Subscriber", msgUser,false ,StrAttachment );
            objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), Email, "Welcome to our Newsletter", "Welcome to our Newsletter \r\nPlease keep this email for later reference. \r\nThanks, Miami & Miami",false,StrAttachment );

           
        }
        else
        {
            ss.InnerHtml = "Your Email Already Subscribe with us.";
            ss.Attributes.Add("class", "email_errorbg");
        }
        if (con.State == ConnectionState.Open) con.Close();
    }
}
