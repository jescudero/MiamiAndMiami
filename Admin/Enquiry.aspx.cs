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
public partial class Admin_Enquiry : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    string Key = "";
    string Mode1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        Key = Convert.ToString(Request.QueryString["EnID"]);
        Loaddata();
    }
    protected void Loaddata()
    {
        con.Open();
        cmd = new MySqlCommand("Select * from Enquiries Where Enquirykey ='" + Key + "' ", con);
        MySqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            EnquiryDate.InnerHtml = Convert.ToDateTime(dr["EnquiryDate"]).ToString("dd-MMM-yyyy");
            ContactPerson.InnerText = dr["YName"].ToString();
            Email.InnerText = dr["Email"].ToString();
            Telephone.InnerText = dr["Telephone"].ToString();
            FromCity.InnerText = dr["FromCity"].ToString();
            ArrivalDate.InnerText = Convert.ToDateTime(dr["ArrivalDate"]).ToString("dd-MMM-yyyy");
            DepartureDate.InnerText = Convert.ToDateTime(dr["DepartureDate"]).ToString("dd-MMM-yyyy");
            Adult.InnerText = dr["Adult"].ToString();
            Child.InnerText = dr["Child"].ToString();
            Requirement.InnerText = dr["Requriments"].ToString();

        }
        con.Close();
    }
}
