using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for SMSAndEmail
/// </summary>
public class SMSAndEmail
{
	public SMSAndEmail()
	{
		//
		// TODO: Add constructor logic here
		//


	}
  
    public void SendMail(String SMTPServerName, int PortNumber, String SMTPServerEmailId, String SMTPServerEmailPassword, String SendToEmailId, String Subject, string Body, bool BodyHtml, String[] Attachment)
    {
        try
        {
            SmtpClient smtpclient;
            if (PortNumber == 0)
            {
                smtpclient = new SmtpClient(SMTPServerName);
            }
            else
            {
                smtpclient = new SmtpClient(SMTPServerName,PortNumber );
            }
            
            smtpclient.UseDefaultCredentials = true;
            smtpclient.Credentials = new NetworkCredential(SMTPServerEmailId, SMTPServerEmailPassword);
            MailMessage Message = new MailMessage(SMTPServerEmailId, SendToEmailId);
            Message.Subject = Subject;
            Message.Body = Body;
            Message.Priority = System.Net.Mail.MailPriority.High;
            Message.IsBodyHtml = BodyHtml ;
            string[] StrAttachment = Attachment;

            System.Net.Mail.Attachment MyAttachement;

            if (StrAttachment.Length > 0)
            {
                foreach (string strfile in StrAttachment)
                {

                    Message.Attachments.Add(new Attachment(strfile));
                }
            }
            if (SMTPServerName.Contains("gmail") == true || SMTPServerName.Contains("live") == true || SMTPServerName.Contains("hotmail") == true)
            {
                smtpclient.EnableSsl = true;
            }
            else
            {
                smtpclient.EnableSsl = false;
            }
            smtpclient.Send(Message);
        }
        catch
        {
        }
        finally
        {

        }

    }
 
    public void SendSMS(String userid, String Password, String Mask, String SendToPhoneNumber, String Message)
    {
        string result = "";
        WebRequest request = null;
        HttpWebResponse response = null;
        try
        {
            string url;
            if (Mask != "")
                url = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=sendMessage&send_to= " + SendToPhoneNumber + "&msg=" + Message + "&mask=" + Mask + "&userid=" + userid + "&password=" + Password + "&v=1.1&msg_type=TEXT&auth_scheme=PLAIN";
            else
                url = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=sendMessage&send_to= " + SendToPhoneNumber + "&msg=" + Message + "&userid=" + userid + "&password=" + Password + "&v=1.1&msg_type=TEXT&auth_scheme=PLAIN";

            request = WebRequest.Create(url);
            response =((HttpWebResponse )request .GetResponse());
            Stream stream = response.GetResponseStream();
            Encoding ec = Encoding.GetEncoding("utf-8");
            StreamReader reader = new StreamReader(stream, ec);
            result = reader.ReadToEnd();
            Console.WriteLine(result);
            reader.Close();
            stream.Close();
        }
        catch(Exception exp)
        {
            Console.WriteLine(exp.Message);
        }
        finally
        {
            if (response != null)
            {
                response.Close();
            }

        }
    }
}
