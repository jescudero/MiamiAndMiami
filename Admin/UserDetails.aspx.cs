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
public partial class Admin_UserDetails : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;

    private static string MemberID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        MemberID = base.Request.QueryString["ID"];
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        this.fillMemberDetails();
    }

    protected void fillMemberDetails()
    {
        if (this.con.State == ConnectionState.Closed)
        {
            this.con.Open();
        }
        this.cmd = new MySqlCommand("SELECT Users.*,registrations.*,registrations.Status as SS,CONCAT(Users.Title,' ', Users.FirstName, '',Users.LastName) as UName  from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey  where Users.UserKey='" + MemberID + "'", this.con);
        MySqlDataAdapter adapter = new MySqlDataAdapter(this.cmd);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        if (dataTable.Rows.Count > 0)
        {


           
            LblEmail.Text = Convert.ToString(dataTable.Rows[0]["Email"]);
            DateTime RegistrationDate = Convert.ToDateTime(dataTable.Rows[0]["RegistrationDate"]);
            LblRegistrationDate.Text = RegistrationDate.ToString("dd-MMMM-yyyy") ;


            this.LblName.Text = Convert.ToString(dataTable.Rows[0]["UName"]);
            this.LblGender.Text = Convert.ToString(dataTable.Rows[0]["Gender"]);
           
            this.LblAddress.Text = Convert.ToString(dataTable.Rows[0]["Address1"]);
            this.LblAddress2.Text = Convert.ToString(dataTable.Rows[0]["Address2"]);
            this.LblCity.Text = Convert.ToString(dataTable.Rows[0]["City"]);
            this.LblState.Text = Convert.ToString(dataTable.Rows[0]["State"]);
            this.LblCountry.Text = Convert.ToString(dataTable.Rows[0]["Country"]);
            this.LblZipcode .Text = Convert.ToString(dataTable.Rows[0]["ZipCode"]);
            this.LblPhone.Text = Convert.ToString(dataTable.Rows[0]["Phone"]);

          
            

        }
        if (this.con.State == ConnectionState.Open)
        {
            if (con.State == ConnectionState.Open) con.Close(); ;
        }
    }

   

}
