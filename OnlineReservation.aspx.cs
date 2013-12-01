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
public partial class OnlineReservation : System.Web.UI.Page
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
        TxtAdult.Attributes.Add("onKeyDown", "var key1=event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if((key1>=48 && key1<=57)||(key1>=96 && key1<=105)||(key1==8)||(key1==9)||(key1==12)||(key1==27)||(key1==37)||(key1==39)||(key1==46)){return true;}else{return false;}");
        txtChildren.Attributes.Add("onKeyDown", "var key1=event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if((key1>=48 && key1<=57)||(key1>=96 && key1<=105)||(key1==8)||(key1==9)||(key1==12)||(key1==27)||(key1==37)||(key1==39)||(key1==46)){return true;}else{return false;}");
        TextBox1 .Attributes.Add("onKeyDown", "var key1=event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if((key1>=48 && key1<=57)||(key1>=96 && key1<=105)||(key1==8)||(key1==9)||(key1==12)||(key1==27)||(key1==37)||(key1==39)||(key1==46)){return true;}else{return false;}");

    }

    protected void GetPhaseData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string q = "";
        if (Type == "Hotel")
        {
             q = "select * From Hotels where HotelKey = " + ID ;
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
                LblHotelName.Text ="Hotel : " +  dr["HotelName"].ToString();
              
            }
            else
            {
                LblHotelName.Text = "Package : " + dr["PackageName"].ToString();
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

        cmd = new MySqlCommand("insert into Bookings (HotelKey,PackageKey,Type,YName,Email,Telephone,TravalingCity,PaymentType,ArrivalDate,DepartureDate,Adult,Child,NoofRooms,Requriments,Hotel_PackageName,BookingDate,Status) values (@HotelKey,@PackageKey,@Type,@YName,@Email,@Telephone,@TravalingCity,@PaymentType,@ArrivalDate,@DepartureDate,@Adult,@Child,@NoofRooms,@Requriments,@Hotel_PackageName,@BookingDate,@Status)", con);
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
        
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@YName", TxtName.Text);
        cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
        cmd.Parameters.AddWithValue("@Telephone", TxtTelephone.Text);
        cmd.Parameters.AddWithValue("@PaymentType", TxtRoomType.Text );
        cmd.Parameters.AddWithValue("@TravalingCity", TxtCity.Text);
        cmd.Parameters.AddWithValue("@ArrivalDate", ArrivalDate);
        cmd.Parameters.AddWithValue("@DepartureDate", DepartureDate);
        cmd.Parameters.AddWithValue("@Adult", TxtAdult.Text);
        cmd.Parameters.AddWithValue("@Child", txtChildren.Text);
        cmd.Parameters.AddWithValue("@NoofRooms", TextBox1.Text);
        cmd.Parameters.AddWithValue("@Requriments", TxtMessage.Text);
        cmd.Parameters.AddWithValue("@Hotel_PackageName", LblHotelName.Text);
        cmd.Parameters.AddWithValue("@Status", "Unpublished");
        cmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);
        cmd.ExecuteNonQuery();

        string MessageId = LblHotelName.Text  +"\r\nName : " + TxtName.Text + " " + "\r\nEmail ID : " + TxtEmail.Text + "\r\nTelephone : " + TxtTelephone.Text + "\r\nTravaling City : " + TxtCity.Text + "\r\nPayment Type : " + TxtRoomType.Text + "\r\nArrival Date : " + HiddenField1.Value + "\r\n Departure Date : " + HiddenField2.Value + "\r\nAdult : " + TxtAdult.Text + "\r\nChild : " + txtChildren.Text + "\r\nRoom : " + TextBox1.Text + "\r\nRequriments : " + TxtMessage.Text;

        cmd = new MySqlCommand("SELECT  *  FROM Options Where OptionKey=1", con);
        MySqlDataAdapter objOptionAdapter = new MySqlDataAdapter(cmd);
        DataTable OptionDataTable = new DataTable();

        objOptionAdapter.Fill(OptionDataTable);

        int Portnumber = 0;
        if (OptionDataTable.Rows[0]["PortNumber"].ToString() != "")
        {
            Portnumber = Convert.ToInt32(OptionDataTable.Rows[0]["PortNumber"].ToString());
        }
        SMSAndEmail objSmsEmail = new SMSAndEmail();
        //Send To Email and sms
        string[] StrAttachment = new string[0];
        if (EmailID != "")
        {
            objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), EmailID , LblHotelName.Text , MessageId, false, StrAttachment);
        }
        objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), OptionDataTable.Rows[0]["AdminEmailId1"].ToString(), LblHotelName.Text, MessageId, false, StrAttachment);
        objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), TxtEmail.Text, LblHotelName.Text, "Thank you for submitting your " + LblHotelName.Text   + ". \r\n We will contact you soon. \r\n Thanks, Miami & Miami", false, StrAttachment);


        if (con.State == ConnectionState.Open) con.Close();

        ss.Visible = false;
        Message.Visible = true;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
