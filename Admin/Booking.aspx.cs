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
public partial class Admin_Booking : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    string Key = "";
    string Mode1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        Key = Convert.ToString(Request.QueryString["BookingID"]);
        Loaddata();
    }
    protected void Loaddata()
    {
        con.Open();
        cmd = new MySqlCommand("Select * from Bookings Where Bookingkey ='" + Key + "' ", con);
        MySqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            BookingDate.InnerHtml = Convert.ToDateTime(dr["BookingDate"]).ToString("dd-MMM-yyyy");
            LblHotelName.Text = Convert.ToString(dr["Hotel_PackageName"]);
            Name .InnerText = dr["YName"].ToString();
            Email.InnerText = dr["Email"].ToString();
            Phone.InnerText = dr["Telephone"].ToString();
            TravalingCity.InnerText = dr["TravalingCity"].ToString();
            PaymentType.InnerText = dr["PaymentType"].ToString();
            CheckinDate.InnerText = Convert.ToDateTime(dr["ArrivalDate"]).ToString("dd-MMM-yyyy");
            CheckOutDate.InnerText = Convert.ToDateTime(dr["DepartureDate"]).ToString("dd-MMM-yyyy");
            Adults.InnerText = dr["Adult"].ToString();
            Children.InnerText = dr["Child"].ToString();
            NoofRooms.InnerText = dr["NoofRooms"].ToString();
            Requirements.InnerText = dr["Requriments"].ToString();

        }
        con.Close();
    }
}