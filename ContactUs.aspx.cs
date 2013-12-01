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

public partial class ContactUs : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    SMSAndEmail objSmsEmail = new SMSAndEmail();

    protected void Page_Load(object sender, EventArgs e)
    {

        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (!IsPostBack)
        {
            loaddata();
        }
    }
    protected void loaddata()
    {


        string DivContant = "";
        if (con.State == ConnectionState.Closed) con.Open();
        this.cmd = new MySqlCommand("Select * from  modules where ModuleName='ContactUs'", this.con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            LblHeader.Text = dr["Title"].ToString();
            this.Title = dr["Title"].ToString();
            HtmlMeta meta = new HtmlMeta();
            meta.Name = dr["Title"].ToString();
            meta.Content = dr["Metatag"].ToString();
            this.Header.Controls.Add(meta);
            ContactDetail.InnerHtml = dr["ModuleContent"].ToString();
            ArrayList Desh = new ArrayList();
            string Des = dr["ModuleContent"].ToString();
            char[] cc = Des.ToCharArray();

            int nn1 = cc.Length;
            string ss1 = "";
            for (int g = 0; g < nn1; g++)
            {
                if (cc[g] == '\n')
                {
                    if (ss1 != "")
                    {
                        Desh.Add(ss1);
                    }
                    ss1 = "";
                }
                else
                {
                    ss1 = ss1 + cc[g];
                }

            }
            if (ss1 != "")
            {
                Desh.Add(ss1);
            }


            for (int s = 0; s < Desh.Count; s++)
            {

                DivContant = DivContant + Convert.ToString(Desh[s]) + "<br/>";

            }
        

        }
        dr.Close(); 
        //ContactDetail.InnerHtml = "";
        //ContactDetail.InnerHtml = DivContant;
        if (con.State == ConnectionState.Open) con.Close(); ;

        
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        LblError.Text = "";
      
   
        if (con.State == ConnectionState.Closed) con.Open();


        string MessageId = "Subject : " + Txtsubject.Text +  "\r\nName : " +  TxtFirstName.Text + " " + txtLastName.Text + "\r\nAddress : " + txtAddress.Text + "\r\nContact No : " + TxtContactNo.Text + "\r\nEmail ID : " + TxtEmail.Text + "\r\nMessage : " + TxtMessage.Text;

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
            objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), OptionDataTable.Rows[0]["AdminEmailId1"].ToString(), "Internet Enquiry", MessageId,false ,StrAttachment );
            objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), TxtEmail.Text, "Internet Enquiry", "Thank you for submitting your enquiry.  We will contact you soon. Thanks, Miami & Miami",false,StrAttachment );

            LblError.Text = "Thank you for submitting your enquiry.  We will contact you soon. Thanks, Miami & Miami";
            

      
        if (con.State == ConnectionState.Open) con.Close();

        Txtsubject.Text = "";
        TxtFirstName.Text = "";
        txtLastName.Text = "";
        txtAddress.Text = "";
        TxtContactNo.Text = "";
        TxtEmail.Text = "";
        TxtMessage.Text = "";



        
    }
}
