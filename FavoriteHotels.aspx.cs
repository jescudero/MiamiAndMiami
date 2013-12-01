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
public partial class FavoriteHotels : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;
    Int32 PageSize = 20;
    Int32 PageNumber;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (!IsPostBack)
        {
            PageNumber = 1;
            if (Convert.ToString(Request.QueryString["City"]) != "" && Convert.ToString(Request.QueryString["City"]) != null)
            {
                Txtsearch.Text = Convert.ToString(Request.QueryString["City"]);
            }

            if (Convert.ToString(Request.QueryString["page"]) != "" && Convert.ToString(Request.QueryString["page"]) != null)
            {
                PageNumber = Convert.ToInt32(Request.QueryString["page"]);
            }
            loaddata();
        }
        if (PageNumber == 0)
        {
            PageNumber = 1;
            loaddata();
        }
    }
    protected void loaddata()
    {

        if (con.State == ConnectionState.Closed) 
            con.Open();
        MySqlDataAdapter da;
        DataTable dt;
        string HotelListContaint = "";
        if (Txtsearch.Text != "" && Txtsearch.Text != "City,State,Country")
        {
            cmd = new MySqlCommand("Select Hotels.* from Hotels Inner Join userfavoritehotels On Hotels.HotelKey=userfavoritehotels.HotelKey Where ( Hotels.Status = 'Activate' AND City LIKE '%" + Txtsearch.Text + "%' ) OR ( Hotels.Status = 'Activate' AND State LIKE '%" + Txtsearch.Text + "%' ) OR ( Hotels.Status = 'Activate' AND Country LIKE '%" + Txtsearch.Text + "%' )", con);
        }
        else
        {
            cmd = new MySqlCommand("Select * from Hotels Where Hotels.Status = 'Activate'", con);
        }
        da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        Int32 strt = (PageNumber - 1) * PageSize;
        if (dt.Rows.Count == 0)
        {
            Message.InnerHtml = "No Search Result Found";
            Message.Visible = true;
            Paging.Visible = false;
        }
        else
        {
            Message.InnerHtml = "";
            Message.Visible = false;
            Paging.Visible = true;
        }
        for (Int32 i = strt; i < dt.Rows.Count; i++)
        {
            if ((strt + PageSize) <= i)
            {
                break;
            }


            string HotelImage = "Hotel/" + dt.Rows[i]["HotelImage"].ToString();
            HotelListContaint = HotelListContaint + "<li class=\"item\"><a href=\"HotelDetail.aspx?HotelID=" + dt.Rows[i]["HotelKey"].ToString() + "\" title=\"" + dt.Rows[i]["HotelName"].ToString() + "\" class=\"hotel-image\"><img src=" + HotelImage + "  alt=\"" + dt.Rows[i]["HotelName"].ToString() + "\" /></a>" +
                "<h3 class=\"hotel-name\"><a href=\"HotelDetail.aspx?HotelID=" + dt.Rows[i]["HotelKey"].ToString() + "\" title=\"" + dt.Rows[i]["HotelName"].ToString() + "\">" + dt.Rows[i]["HotelName"].ToString() + "</a></h3><div class=\"review\"> Customer reviews " + dt.Rows[i]["NoofReview"].ToString() + "</div>" +
                "<div class=\"desc\">" + dt.Rows[i]["ShortDescription"].ToString() + "</div><div class=\"price-box\"><h3 class=\"price\" >Rate " + dt.Rows[i]["PricePerDay"].ToString() + " per Day</h3></div>";
            if ((String)Session["sessionUserkey"] != "" && (String)Session["sessionUserkey"] != null)
            {
                MySqlCommand cmd2 = new MySqlCommand("Select * from userfavoritehotels Where HotelKey = '" + dt.Rows[i]["HotelKey"].ToString() + "' AND UserKey='" + (String)Session["sessionUserkey"] + "'", con);
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count == 0)
                {
                    HotelListContaint = HotelListContaint + "<div class=\"Favorite\"><a onclick=\"return fnFav('Add', '" + dt.Rows[i]["HotelKey"].ToString() + "' );\" >Add Favorite</a></div>";
                }
                else
                {
                    HotelListContaint = HotelListContaint + "<div class=\"Favorite\"><a onclick=\"return fnFav('Remove', '" + dt.Rows[i]["HotelKey"].ToString() + "');\" >Remove Favorite</a></div>";
                }
            }
            HotelListContaint = HotelListContaint + "<div class=\"actions\"><a type=\"button\" title=\"View Details\" class=\"button btn-cart\" href=\"HotelDetail.aspx?HotelID=" + dt.Rows[i]["HotelKey"].ToString() + "\"><span><span>View Details</span></span></a>" +
                "<a class=\"button\" href=\"OnlineReservation.aspx?Type=Hotel&ID=" + dt.Rows[i]["HotelKey"].ToString() + "\" onclick=\"return hs.htmlExpand( this, { objectType: 'iframe', outlineType: 'glossy-dark', wrapperClassName: 'highslide-wrapper drag-header', outlineWhileAnimating: true, preserveContent: false, width: 480 } )\"><span><span>Book now</span></span> </a><a class=\"button\" href=\"Enquiry.aspx?Type=Hotel&ID=" + dt.Rows[i]["HotelKey"].ToString() + "\" onclick=\"return hs.htmlExpand( this, { objectType: 'iframe', outlineType: 'glossy-dark', wrapperClassName: 'highslide-wrapper drag-header', outlineWhileAnimating: true, preserveContent: false, width: 630 } )\"><span><span>Enquiry</span></span></a></div></li>";



        }
        HotelList.InnerHtml = HotelListContaint;
        Pagging(dt.Rows.Count);
        if (con.State == ConnectionState.Open) con.Close();
    }

    public void Pagging(Int32 TotalRow)
    {

        string Str = "<ul id=\"pagination-digg\">";
        if (PageNumber > 1)
        {
            Str = Str + "<li class=\"previous\"><a href=\"?page=" + (PageNumber - 1) + "\">« Previous</a></li>";
        }
        else
        {
            Str = Str + "<li class=\"previous\" style=\"border:solid 1px #9aafe5;display:block;float:left;padding:3px 5px;\">« Previous</li>";

        }
        int Number = 0;
        Int32 i;

        Int32 Strt = PageNumber - 1;
        if ((PageNumber - 1) % 10 == 0)
        {
            Strt = PageNumber - 1;

        }
        else
        {
            if (PageNumber % 10 == 0)
            {
                Strt = PageNumber - 10;
            }
            else
            {


                Strt = PageNumber - PageNumber % 10;
            }
        }

        Number = Strt;
        Int32 totalnumber = Number;
        Int16 j = 0;
        for (i = (PageSize * Strt); i < TotalRow; i += PageSize)
        {
            totalnumber = totalnumber + 1;
            if (Strt % 10 == 0 && Strt >= 10 && j == 0)
            {
                Str = Str + "<li> <a href=\"?page=" + Number + "\">..</a></li>";

            }

            if (Number % 10 == 0 && j != 0)
            {
                Str = Str + "<li> <a href=\"?page=" + (Number + 1) + "\">..</a></li>";
                break;
            }

            Number = Number + 1;
            j++;
            if (Number == PageNumber)
            {
                Str = Str + "<li class=\"active\" >" + Number + "</li>";
            }
            else
            {
                Str = Str + "<li> <a href=\"?page=" + Number + "\">" + Number + "</a></li>";
            }


        }

        if (PageNumber < totalnumber)
        {
            Str = Str + "<li class=\"next\" ><a href=\"?page=" + (PageNumber + 1) + "\">Next »</a></li></ul>";
        }
        else
        {
            Str = Str + "<li class=\"next\" style=\"border:solid 1px #9aafe5;display:block;float:left;padding:3px 5px;\">Next »</li></ul>";

        }
        Paging.InnerHtml = Str;
    }
    protected void BtnSer_Click(object sender, EventArgs e)
    {
        PageNumber = 1;
        loaddata();
    }
}