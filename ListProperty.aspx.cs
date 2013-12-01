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
using System.IO;
using System.Net.Mail;

public partial class ListProperty : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed) con.Open();

        string MessageId = "Name : " + TxtFirstName.Text + " " + txtLastName.Text + " " + "\r\nHotel Name : " + txtHotelname.Text + "\r\nHotel Url : " + TxtUrl.Text + "\r\nTelephone : " + TxtContactNo.Text + "\r\nEmail Id : " + TxtEmail.Text + "\r\nRequriments : " + TxtMessage.Text;

        cmd = new MySqlCommand("SELECT  *  FROM Options Where OptionKey=1", con);
        MySqlDataAdapter objOptionAdapter = new MySqlDataAdapter(cmd);
        DataTable OptionDataTable = new DataTable();

        objOptionAdapter.Fill(OptionDataTable);

        int Portnumber = 0;
        if (OptionDataTable.Rows[0]["PortNumber"].ToString() != "")
        {
            Portnumber = Convert.ToInt32(OptionDataTable.Rows[0]["PortNumber"].ToString());
        }

        SmtpClient client = new SmtpClient();
        client.Port = Portnumber;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString());
        client.Host = "localhost";
        //client.Host = OptionDataTable.Rows[0]["SMTPServerName"].ToString()

        MailMessage mail_admin = new MailMessage(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["AdminEmailId"].ToString());
        mail_admin.Subject = "List your Property";
        mail_admin.Body = MessageId;
        client.Send(mail_admin);

        MailMessage mail_client = new MailMessage(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), TxtEmail.Text);
        mail_client.Subject = "List your Property";
        mail_client.Body = "Thank you for submitting your list property. \r\n We will contact you soon. \r\n Thanks, Miami & Miami";
        client.Send(mail_client);

        if (con.State == ConnectionState.Open) con.Close();
        ss.Visible = false;
        Message.Visible = true;
    }
}