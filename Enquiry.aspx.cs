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
public partial class Enquiry : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    static string ID = "";
    static string Type = "";
    static string EmailID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!IsPostBack)
        {

            if ((String)Request.QueryString["Type"] != null && (String)Request.QueryString["Type"] != "")
            {
                Type = (String)Request.QueryString["Type"];
            }
            if ((String)Request.QueryString["ID"] != null && (String)Request.QueryString["ID"] != "")
            {
                ID = (String)Request.QueryString["ID"];
                GetPhaseData();

            }

        }
    }

    protected void GetPhaseData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string q = "";
        if (Type == "Hotel")
        {
             q = "select * From Hotels where HotelKey = " + ID;
        }
        else
        {
             q = "select * From Packages where PackageKey = " + ID;
        }
        
        cmd = new MySqlCommand(q, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if (Type == "Hotel")
            {
                LblHotel .Text = "Hotel : " + dr["HotelName"].ToString();

            }
            else
            {
                LblHotel .Text = "Package : " + dr["PackageName"].ToString();
            }
            
            EmailID = dr["EmailID"].ToString();

        }

        dr.Close();
        if (con.State == ConnectionState.Open) con.Close();

    }
    protected void BtnEnquiry_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed) con.Open();

        string ArrivalDate = null;// DateTime.ParseExact(TxtArrival.Text, "yyyy-MM-dd", System.DateTime);
        string DepartureDate = null;// DateTime.ParseExact(TxtDeparture.Text, "yyyy-MM-dd", System.DateTime);
        if (HiddenField1.Value != "")
        {
            ArrivalDate = HiddenField1.Value.Substring(6, 4) + "-" + HiddenField1.Value.Substring(3, 2) + "-" + HiddenField1.Value.Substring(0, 2);
        }
        if (HiddenField2.Value != "")
        {
            DepartureDate = HiddenField2.Value.Substring(6, 4) + "-" + HiddenField2.Value.Substring(3, 2) + "-" + HiddenField2.Value.Substring(0, 2);
        }

        cmd = new MySqlCommand("insert into enquiries (HotelKey,PackageKey,Type,YName,Email,Telephone,FromCity,ArrivalDate,DepartureDate,Adult,Child,Requriments,HotelName,EnquiryDate,Status) values (@HotelKey,@PackageKey,@Type,@YName,@Email,@Telephone,@FromCity,@ArrivalDate,@DepartureDate,@Adult,@Child,@Requriments,@HotelName,@EnquiryDate,@Status)", con);
        cmd.CommandType = CommandType.Text;
        if (Type == "Hotel")
        {

            cmd.Parameters.AddWithValue("@HotelKey", ID);
            cmd.Parameters.AddWithValue("@PackageKey", 0);
        }
        else
        {
            cmd.Parameters.AddWithValue("@HotelKey", 0);
            cmd.Parameters.AddWithValue("@PackageKey", ID);
        }
        cmd.Parameters.AddWithValue("@Type", Type );
        cmd.Parameters.AddWithValue("@YName", TxtName.Text);
        cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
        cmd.Parameters.AddWithValue("@Telephone", TxtTelephone.Text);
        cmd.Parameters.AddWithValue("@FromCity", "");
        cmd.Parameters.AddWithValue("@ArrivalDate", ArrivalDate);
        cmd.Parameters.AddWithValue("@DepartureDate", DepartureDate);
        cmd.Parameters.AddWithValue("@Adult", TxtAdult.Text);
        cmd.Parameters.AddWithValue("@Child", TxtChild.Text);
        cmd.Parameters.AddWithValue("@Requriments", TxtMessage.Text);
        cmd.Parameters.AddWithValue("@HotelName", LblHotel.Text);
        cmd.Parameters.AddWithValue("@Status", "Unpublished");
        cmd.Parameters.AddWithValue("@EnquiryDate", DateTime.Now);
        cmd.ExecuteNonQuery();

        string Message_to_Admin = "Name : " + TxtName.Text + " " + "\r\nEmail ID : " + TxtEmail.Text + "\r\nTelephone : " + TxtTelephone.Text + "\r\nArrival Date : " + HiddenField1.Value + "\r\nDeparture Date : " + HiddenField2.Value + "\r\nAdult : " + TxtAdult.Text + "\r\nChild : " + TxtChild.Text + "\r\nRequriments : " + TxtMessage.Text;
        string Message_to_Hotel = "Name : " + TxtName.Text + " " + "\r\nArrival Date : " + HiddenField1.Value + "\r\nDeparture Date : " + HiddenField2.Value + "\r\nAdult : " + TxtAdult.Text + "\r\nChild : " + TxtChild.Text + "\r\nRequriments : " + TxtMessage.Text;

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

        //mail to the admin
        MailMessage mail_admin = new MailMessage(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["AdminEmailId"].ToString());
        mail_admin.Subject = "Miami & Miami Enquiry";
        mail_admin.Body = Message_to_Admin;
        client.Send(mail_admin);

        //mail to the hotel
        MailMessage mail_hotel = new MailMessage(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), EmailID);
        mail_hotel.Subject = "Miami & Miami Enquiry";
        mail_hotel.Body = Message_to_Hotel;
        client.Send(mail_hotel);

        //mail to the client
        MailMessage mail_client = new MailMessage(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), TxtEmail.Text);
        mail_client.Subject = "Miami & Miami Enquiry";
        mail_client.Body = "Thank you for submitting your Hotel Enquiry for " + LblHotel.Text + ". \r\n We will contact you soon. \r\n Thanks, Miami & Miami";
        client.Send(mail_client);

        if (con.State == ConnectionState.Open) con.Close();

        ss.Visible = false;
        Message.Visible = true;

    }
}
