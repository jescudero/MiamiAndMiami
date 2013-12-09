using System;
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
public partial class _Default : System.Web.UI.Page 
{
    private MySqlCommand cmd;
    private MySqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if ((string)(String)Session["sessionUserName"] == "" || (string)(String)Session["sessionUserName"] == null)
        {

            LnkLogin.Text = "Log In";
            LnkLogin.ToolTip = "Login to Miami and Miami";
            reg.Visible = true;
            LnkPassword.Visible = false;
        }
        else
        {

            LnkLogin.Text = "Log Out";
            LnkLogin.ToolTip = "Log out to Miami and Miami";
            reg.Visible = false;
            LnkPassword.Visible = true; 
        }
        if (!IsPostBack)
        {
            
            loaddata();
        }
        
    }
    protected void loaddata()
    {

        if (con.State == ConnectionState.Closed) con.Open();
        MySqlDataAdapter da;
        DataTable dt;
        string HotelListContaint = "";

        cmd = new MySqlCommand("Select * from Hotels Where Hotels.Status = 'Activate'", con);
        da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                string HotelImage = "Hotel/" + dt.Rows[i]["HotelImage"].ToString();
                string hotelDescription = dt.Rows[i]["ShortDescription"].ToString();

                if (hotelDescription.Length > 70)
                {
                    int pos = hotelDescription.LastIndexOf(" ", 70);
                    if (pos < 50)
                    {
                        pos = 70;
                    }
                    hotelDescription = hotelDescription.Substring(0, pos) + "...";
                }

                HotelListContaint = HotelListContaint + "<li><a href=\"HotelDetail.aspx?HotelID=" + dt.Rows[i]["HotelKey"].ToString() + "\" title=\"" + dt.Rows[i]["HotelName"].ToString() + "\" ><img src=" + HotelImage + " alt=\"" + dt.Rows[i]["HotelName"].ToString() + "\" width=\"206\" height=\"120\" /></a><p><a href=\"HotelDetail.aspx?HotelID=" + dt.Rows[i]["HotelKey"].ToString() + "\" title=\"" + dt.Rows[i]["HotelName"].ToString() + "\" >" + dt.Rows[i]["HotelName"].ToString() + "</a><br />" + hotelDescription + "</p></li>";
            }
            HotelList.InnerHtml = HotelListContaint;
        }


        cmd = new MySqlCommand("Select * from testimonials Where Status = 'Published'", con);
        da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
       
        if (dt.Rows.Count > 0)
        {
            testimonial.InnerHtml = dt.Rows[0]["TestimonialContent"].ToString();
        }

        cmd = new MySqlCommand("Select * from Modules", con);
        da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ModuleName"].ToString() == "MiamiSale")
                {
                    MiamiSale.InnerHtml = dt.Rows[i]["SortDescription"].ToString(); 
                }
                else if (dt.Rows[i]["ModuleName"].ToString() == "HotelsPartner")
                {
                    HotelsPartner.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                }
                else if (dt.Rows[i]["ModuleName"].ToString() == "MiamiBeachRestaurants")
                {
                    MiamiBeachRestaurants.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                }
                else if (dt.Rows[i]["ModuleName"].ToString() == "MiamiShopping")
                {
                    MiamiShopping.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                }
                else if (dt.Rows[i]["ModuleName"].ToString() == "FunandLeisure")
                {
                    FunandLeisure.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                }
                else if (dt.Rows[i]["ModuleName"].ToString() == "Events")
                {
                    Events.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                }
                else if (dt.Rows[i]["ModuleName"].ToString() == "VacationRentals")
                {
                    VacationRentals.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                }
                else if (dt.Rows[i]["ModuleName"].ToString() == "VisitMiami")
                {
                    VisitMiami.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                }
                else 
                {
                   
                }
                
            }
        }

        if (con.State == ConnectionState.Open ) con.Close();
    }
    
    protected void LnkLogin_Click(object sender, EventArgs e)
    {
        base.Session.RemoveAll();
        if (LnkLogin.Text == "Log In")
        {
            Response.Redirect("Login.aspx");

        }
        else
        {

            Session["sessionUserName"] = null;
            Session["sessionUserType"] = null;
            Session["LoginUserkey"] = null;
                       
            Session.RemoveAll();
            Response.Redirect("Default.aspx");

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Convert.ToString((String)Session["sessionUserType"]) == "Admin")
        {
            Response.Redirect("Admin/AdminHome.aspx");
        }
        else if (Convert.ToString((String)Session["sessionUserType"]) == "User")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    //protected void Unnamed1_Click(object sender, EventArgs e)
    //{
    //    String city = TxtDestinationCity.Text.Replace("&", "");
    //    Response.Redirect("HotelListing.aspx?City=" + city + "&Person=" + PostiLetto.Value + "&FromDate=" + HiddenField1.Value + "&ToDate=" + HiddenField2.Value);
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        String city = TxtSearchMiami.Text.Replace("&", "");
        Response.Redirect("SearchResult.aspx?Search=" + city);
    }
}
