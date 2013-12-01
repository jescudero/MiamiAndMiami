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
public partial class Review : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    static string HotelKey = "";
    
    static string EmailID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!IsPostBack)
        {

            if ((String)Request.QueryString["HotelID"] != null && (String)Request.QueryString["HotelID"] != "")
            {
                HotelKey = (String)Request.QueryString["HotelID"];
                GetPhaseData();

            }
           
        }
    }

    protected void GetPhaseData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string q = "select * From Hotels where HotelKey = " + HotelKey;
        cmd = new MySqlCommand(q, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            
         
            LblHotelName.Text = dr["HotelName"].ToString();
            EmailID = dr["EmailID"].ToString();
            


        }

        dr.Close();
        if (con.State == ConnectionState.Open) con.Close();

    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed) con.Open();

        cmd = new MySqlCommand("insert into hotelreviews (HotelKey,YName,Email,Comment,Rating,Status,ReviewDate) values (@HotelKey,@YName,@Email,@Comment,@Rating,@Status,@ReviewDate)", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
        cmd.Parameters.AddWithValue("@YName", TxtName .Text);
        cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
        cmd.Parameters.AddWithValue("@Comment", TxtComment.Text);
        cmd.Parameters.AddWithValue("@Rating", DropDownList1 .Text);
        cmd.Parameters.AddWithValue("@Status", "Unpublished");
        cmd.Parameters.AddWithValue("@ReviewDate", DateTime.Now );
        cmd.ExecuteNonQuery();
        cmd = new MySqlCommand("UPDate HOTELS SET   NoofReview=NoofReview+1 WHERE HotelKey ='"+ HotelKey  +"'", con);
        cmd.ExecuteNonQuery();
        string MessageId = "Name : " + TxtName.Text + " " + "\r\nEmail ID : " + TxtEmail.Text + "\r\nRating : " + DropDownList1 .Text  + "\r\nComment : " + TxtComment.Text;

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
        objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), EmailID , "New Post Review", MessageId,false,StrAttachment);
        objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), OptionDataTable.Rows[0]["AdminEmailId1"].ToString(), "Post Review", "Hotel Post Review : " + LblHotelName .Text   +"\r\n " +MessageId,false,StrAttachment);
        objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), TxtEmail.Text, "Miami & Miami Post Review", "Thank you for submitting your Comment.  We will contact you soon. Thanks, Miami & Miami",false,StrAttachment );

        //LblError.Text = "Thank you for submitting your enquiry.  We will contact you soon. Thanks, Miami & Miami";



        if (con.State == ConnectionState.Open) con.Close();

        ss.Visible = false;
        Message.Visible = true;

    }
}
