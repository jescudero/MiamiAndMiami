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
public partial class Default2 : System.Web.UI.Page
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

            if ((String)Request.QueryString["id1"] != null && (String)Request.QueryString["id1"] != "")
            {
                Type = (String)Request.QueryString["id1"];
            }
            if ((String)Request.QueryString["HotelID"] != null && (String)Request.QueryString["HotelID"] != "")
            {
                ID = (String)Request.QueryString["HotelID"];
                GetPhaseData();

            }

        }
    }

    protected void GetPhaseData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
      
        if (Type == "Add")
        {
            cmd = new MySqlCommand("insert into userfavoritehotels (UserKey,HotelKey,ActivateDate) values (@UserKey,@HotelKey,@ActivateDate)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserKey", (String)Session["sessionUserkey"]);
            cmd.Parameters.AddWithValue("@HotelKey", ID) ;
            cmd.Parameters.AddWithValue("@ActivateDate", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
        else
        {
            cmd = new MySqlCommand("DELETE FROM userfavoritehotels WHERE UserKey=@UserKey AND HotelKey=HotelKey", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserKey", (String)Session["sessionUserkey"]);
            cmd.Parameters.AddWithValue("@HotelKey", ID);
            cmd.ExecuteNonQuery();
        }

        
        if (con.State == ConnectionState.Open) con.Close();

    }
}