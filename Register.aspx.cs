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
public partial class Register : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    string userkey = "";
    PasswordEncription Encryption = new PasswordEncription();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    }
    protected void adddata()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string CurrentPassword = TxtPassword.Text;
        string encrptionpass = Encryption.PasswordEncryption(ref CurrentPassword);
        DateTime Todays = DateTime.Now.AddHours(10).AddMinutes(30);
        Todays = DateTime.Now;
        string SendingDate = null;
        SendingDate = Todays.Year.ToString() + "-" + Todays.Month.ToString() + "-" + Todays.Day.ToString() + " " + Todays.Hour.ToString() + ":" + Todays.Minute.ToString() + ":" + Todays.Second.ToString();
        cmd = new MySqlCommand("insert into Users (UserName,Password,UserType,Title,FirstName,LastName,Gender,RegistrationDate) values (@UserName,@Password,@UserType,@Title,@FirstName,@LastName,@Gender,@RegistrationDate)", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@UserName", TtxEmail.Text);
        cmd.Parameters.AddWithValue("@Password", encrptionpass);
        cmd.Parameters.AddWithValue("@UserType", "User");
        cmd.Parameters.AddWithValue("@Title", DdlTitle.Text);
        cmd.Parameters.AddWithValue("@FirstName", TxtFName.Text);
        cmd.Parameters.AddWithValue("@LastName", TxtLastName.Text);
        cmd.Parameters.AddWithValue("@Gender", DdlGender.Text);
        cmd.Parameters.AddWithValue("@RegistrationDate", SendingDate);
        cmd.ExecuteNonQuery();

        string UserKey = "";
        cmd = new MySqlCommand("Select UserKey from Users order by UserKey desc", con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            UserKey = dr["UserKey"].ToString();
        }
        dr.Close();
        Int64 num = 0;
        this.cmd = new MySqlCommand("select max(RegistrationId) as RegistrationId from Registrations ", this.con);
        MySqlDataReader reader = this.cmd.ExecuteReader();
        if (reader.HasRows)
        {
            if (reader.Read())
            {
                num = Convert.ToInt64(reader.GetValue(0));
            }
            reader.Close();
        }
        num++;

        this.cmd = new MySqlCommand("Insert into Registrations (UserKey,RegistrationId,RegistrationDate,Email,Address1,Address2,City,State,Country,Zipcode,Phone) values (@UserKey,@RegistrationId,@RegistrationDate,@Email,@Address1,@Address2,@City,@State,@Country,@Zipcode,@Phone) ", this.con);
        this.cmd.CommandType = CommandType.Text;
        this.cmd.Parameters.AddWithValue("@UserKey", UserKey);
        this.cmd.Parameters.AddWithValue("@RegistrationId", num);
        this.cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
        this.cmd.Parameters.AddWithValue("@Email", TtxEmail.Text);
        this.cmd.Parameters.AddWithValue("@Address1", "");
        this.cmd.Parameters.AddWithValue("@Address2", "");
        this.cmd.Parameters.AddWithValue("@City", "");
        this.cmd.Parameters.AddWithValue("@State", "");
        this.cmd.Parameters.AddWithValue("@Country", "");
        this.cmd.Parameters.AddWithValue("@Zipcode", "");
        this.cmd.Parameters.AddWithValue("@Phone", this.TxtMobileNumber.Text);
        this.cmd.ExecuteNonQuery();


        cmd = new MySqlCommand("SELECT  *  FROM Options Where OptionKey=1", con);
        MySqlDataAdapter objOptionAdapter = new MySqlDataAdapter(cmd);
        DataTable OptionDataTable = new DataTable();

        objOptionAdapter.Fill(OptionDataTable);
        if (OptionDataTable.Rows.Count > 0)
        {
            string Message = "Dear " + TxtFName.Text + ",\r\n \r\n You are now a registered member of http://MiamiandMiami.com . \r\n \r\n Please find your account details below:.\r\n Username : " + TtxEmail.Text + "\r\n Password : " + TxtPassword.Text + "\r\n \r\n Thanks,\r\nMiami & Miami Team.";

            SMSAndEmail objSmsEmail = new SMSAndEmail();
            string[] StrAttachment = new string[0];
            objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Convert.ToInt16(OptionDataTable.Rows[0]["PortNumber"]), OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), OptionDataTable.Rows[0]["AdminEmailId"].ToString(), "New Registration at Miami & Miami", "Dear admin,\r\n \r\n An user has been registered in the http://MiamiandMiami.com . Kindly check your inbox.\r\n \r\nThanks,\r\nMiami & Miami Team.",false, StrAttachment );
            objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Convert.ToInt16(OptionDataTable.Rows[0]["PortNumber"]), OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), TtxEmail.Text, "Your Registration at Miami & Miami", Message, false, StrAttachment);




        }
               
        con.Close();

        Response.Redirect("Thanks.aspx");
       
    }
    
    protected void btnnext_Click(object sender, EventArgs e)
    {
            if (ValidateUserName("Add") == true)
            {
                adddata();
            }
        
    }
    private Boolean ValidateUserName(string strMode)
    {
        if (strMode == "Add")
        {
            if (con.State == ConnectionState.Closed) con.Open();

            if ((TtxEmail.Text) != "")
            {
                cmd = new MySqlCommand("Select  UserName from Users where UserName='" + TtxEmail.Text + "' ", con);
                MySqlDataReader TrNameDR = cmd.ExecuteReader();

                if (TrNameDR.HasRows)
                {
                    LblErr.Text = "Email Already Exists";
                    TrNameDR.Close();
                    return false;
                }
                TrNameDR.Close();
            }
            con.Close();
            
        }
        return true;
    }
}
