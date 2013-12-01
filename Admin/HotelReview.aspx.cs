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
public partial class Admin_HotelReview : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
      
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


        Loaddata();
    }
    protected void Loaddata()
    {
        con.Open();
        cmd = new MySqlCommand("Select hotelreviews.*,Hotels.* from hotelreviews Inner Join Hotels On hotelreviews.HotelKey=Hotels.HotelKey Where HotelReviewKey ='" + Convert.ToString(Request.QueryString["HotelID"]) + "' ", con);
        MySqlDataReader dr ; 
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Name.InnerText = dr["YName"].ToString();
            Email.InnerText = dr["Email"].ToString();
            Comment.InnerText = dr["Comment"].ToString();
            Rating.InnerText = dr["Rating"].ToString();
            ReviewDate.InnerText = Convert.ToDateTime(dr["ReviewDate"]).ToString("dd-MMM-yyyy");
            LblHotelName.Text = dr["HotelName"].ToString();

        }
        con.Close();
    }
   
}
