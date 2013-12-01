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
using System.Net.Mail;
public partial class HotelDetail : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    static string HotelKey = "";
    string HotelImage = "";
    static string EmailID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (!IsPostBack)
        {
          
        
            if ((String)Request.QueryString["HotelID"] != null && (String)Request.QueryString["HotelID"] != "")
            {
                HotelKey = (String)Request.QueryString["HotelID"];
                GetPhaseData();

            }
            else
            {
                Response.Redirect("ListingHotel");
            }
           
        }
        TxtAdult.Attributes.Add("onKeyDown", "var key1=event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if((key1>=48 && key1<=57)||(key1>=96 && key1<=105)||(key1==8)||(key1==9)||(key1==12)||(key1==27)||(key1==37)||(key1==39)||(key1==46)){return true;}else{return false;}");
        TxtChild .Attributes.Add("onKeyDown", "var key1=event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if((key1>=48 && key1<=57)||(key1>=96 && key1<=105)||(key1==8)||(key1==9)||(key1==12)||(key1==27)||(key1==37)||(key1==39)||(key1==46)){return true;}else{return false;}");

    }

    protected void GetPhaseData()
    {
        if (con.State == ConnectionState.Closed) con.Open();

        if ((String)Session["sessionUserkey"] != "" && (String)Session["sessionUserkey"] != null)
        {
            MySqlCommand cmd2 = new MySqlCommand("Select * from userfavoritehotels Where HotelKey = '" + HotelKey + "' AND UserKey='" + (String)Session["sessionUserkey"] + "'", con);
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count == 0)
            {
                Fav.InnerHtml = "<a onclick=\"return fnFav('Add', '" + HotelKey + "' );\" >Add Favorite</a>";
            }
            else
            {
                Fav.InnerHtml = "<a onclick=\"return fnFav('Remove', '" + HotelKey + "');\" href=\"#\">Remove Favorite</a>";
            }
        }

        string q = "select * From Hotels where HotelKey = '" + HotelKey+"' ";
        cmd = new MySqlCommand(q, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            this.Title = dr["HotelName"].ToString();
            HtmlMeta meta = new HtmlMeta();
            meta.Name = "Hotel";
            meta.Content = dr["HotelName"].ToString() +  ", Hotel In " + dr["State"].ToString() + ", Hotel In " + dr["Country"].ToString() ;
            this.Header.Controls.Add (meta);
            Review.HRef = "Review.aspx?HotelID=" + HotelKey;
            //Enquiry.HRef = "Review.aspx?HotelID=" + HotelKey;
            hotelrent.InnerHtml = "<b>Rate : </b> " + dr["PricePerDay"].ToString() + " Per Day";
            LblHotel.Text = dr["HotelName"].ToString();
            //DDLListingType.Text = dr["ListingType"].ToString();
            hoteldesc.InnerHtml = dr["ShortDescription"].ToString();
            HotelImage = dr["HotelImage"].ToString();
            overview.InnerHtml  = dr["HotelOverview"].ToString();
            
            if (dr["VideoLink"].ToString() != "")
            {
                HotelVideo.Visible = true;
                HotelVideo.InnerHtml = "<iframe  src=" + dr["VideoLink"].ToString() + " frameborder=\"0\" allowfullscreen></iframe>";
            }
            else
            {
                HotelVideo.Visible = false;
            }

            //Map
            string street = "";
            string mapKey = ConfigurationManager.AppSettings["googlemaps.subgurim.net"];
            street = dr["Address"].ToString() + ", " + dr["City"].ToString() + ", " + dr["State"].ToString() + ", " + dr["Country"].ToString();
            var GeoCode = Subgurim.Controles.GMap.geoCodeRequest(street, mapKey);
            var gLatLng = new Subgurim.Controles.GLatLng(GeoCode.Placemark.coordinates.lat, GeoCode.Placemark.coordinates.lng);

            GMap1.setCenter(gLatLng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            Subgurim.Controles.GMarker oMarker = new Subgurim.Controles.GMarker(gLatLng);
          
            var window = new Subgurim.Controles.GInfoWindow(oMarker, "<b>" + dr["HotelName"].ToString() + "</b>" , true, new Subgurim.Controles.GInfoWindowOptions(0, 200));
            GMap1.Add(window);

            if ((dr["PriceTo"].ToString() != "") && (dr["PriceFrom"].ToString() != ""))
            {
                Pricelist1.Visible = true;
                P1.InnerHtml = "<p> From <strong>" + dr["PriceTo"].ToString() + "</strong> to <strong>" + dr["PriceFrom"].ToString() + "</strong></p>";
            }
            else
            {
                Pricelist1.Visible = false;
            }
            EmailID = dr["EmailID"].ToString();
            //TxtPhone.Text = dr["PhoneNumber"].ToString();
            //TxtAddress.Text = dr["Address"].ToString();
            //TxtCity.Text = dr["City"].ToString();
            //TxtState.Text = dr["State"].ToString();
            //TxtCountry.Text = dr["Country"].ToString();
            //TxtWebsite.Text = dr["Website"].ToString();
           ImgHotel.Src = "Hotel/" + HotelImage;


        }
        else
        {
            Response.Redirect("ListingHotel");
        }
        dr.Close();
        string DivContant = "";

        
        //activities section
        this.cmd = new MySqlCommand("Select a.description from hotelactivities ha inner join activities a on ha.ActivitiesKey=a.ActivityKey where ha.hotelkey=" + HotelKey , this.con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Activities.InnerHtml = "<ul>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str2 = dt.Rows[i]["description"].ToString();
                Activities.InnerHtml = Activities.InnerHtml + "<li>" + str2 + "</li>";
            }

            Activities.InnerHtml = Activities.InnerHtml + "</ul>";
            Activitieslist1.Visible = true;
        }
        else
        {
            Activitieslist1.Visible = false;
        }

        //facilities section
        this.cmd = new MySqlCommand("Select f.description from hotelfacilities hf inner join facilities f on hf.FacilitiesKey=f.FacilitiesKey where hf.hotelkey=" + HotelKey, this.con);
        da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Facilities.InnerHtml = "<ul>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str2 = dt.Rows[i]["description"].ToString();
                Facilities.InnerHtml = Facilities.InnerHtml + "<li>" + str2 + "</li>";
            }

            Facilities.InnerHtml = Facilities.InnerHtml + "</ul>";
            featurelist1.Visible = true;
        }
        else
        {
            featurelist1.Visible = false;
        }

        this.cmd = new MySqlCommand("Select * from hotelphotos where HotelKey='" + HotelKey + "'  order by UploadDate desc", this.con);
        da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                string str2 = dt.Rows[i]["ImageName"].ToString();
                string ProductImage = "Hotel/" + dt.Rows[i]["ImageName"].ToString();
                if (File.Exists(Server.MapPath("Hotel/" + str2)) == true)
                {
                    //DivContant =DivContant+ "<a class=\"pirobox\" href=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" title=\"" + dt.Rows[i]["Caption"].ToString() + "\"><img src=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" alt=\"\" width=\"215px\" height=\"150px\" style=\"border:1px solid #224467; padding:2px; margin:5px;border-radius: 8px; opacity: 1;\" /></a>"
                   //DivContant = DivContant + "<a  class=\"highslide\" href=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" onclick=\"return hs.htmlExpand(this, { objectType: 'iframe'  })\" title=\"" + dt.Rows[i]["Caption"].ToString() + "\"><img src=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" title=\"Click to enlarge\" alt=\"Highslide JS\" width=\"215px\" height=\"150px\" style=\"border:1px solid #224467; padding:2px; margin:5px;border-radius: 8px; opacity: 1;\" /></a>";
                  //  DivContant = DivContant + "<a class=\"fancybox\" href=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" data-fancybox-group=\"gallery\" title=\"" + dt.Rows[i]["Caption"].ToString() + "\"><img src=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" alt=\"\" width=\"215px\" height=\"150px\" style=\"border:1px solid #224467; padding:2px; margin:5px;border-radius: 8px; opacity: 1;\" /></a>";
                    DivContant = DivContant + "<a  href=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\"  title=\"" + dt.Rows[i]["Caption"].ToString() + "\" onclick=\"showPreview('" + ProductImage + "','" + (i + 1) + "');return false\"><img src=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\"></a>	";


                }
            }
            galleryContainer.Visible = true;
          // Gallery.Visible = true;
        }
        else
        {
            galleryContainer.Visible = false;
           // Gallery.Visible = false;
        }
        theImages.InnerHtml = DivContant + "  <div id=\"slideEnd\"></div>";
     //  UserImages.InnerHtml = DivContant;
       DivContant = "";
       this.cmd = new MySqlCommand("Select * from hotelreviews where HotelKey='" + HotelKey + "' And Status='Published'  order by ReviewDate desc", this.con);
       MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
       DataTable dt1 = new DataTable();
       da1.Fill(dt1);
       if (dt1.Rows.Count > 0)
       {

           for (int i = 0; i < dt1.Rows.Count; i++)
           {

               DivContant = DivContant + "<li class=\"item\"><div style=\"height:28px;\"><div class=\"y-name\">" + dt1.Rows[i]["YName"].ToString() + " (" + dt1.Rows[i]["Email"].ToString() + ")</div><div class=\"review\"> Date : " + Convert.ToDateTime(dt1.Rows[i]["ReviewDate"]).ToString("dd-MMMM-yyyy") + "</div></div> <div class=\"desc\">" + dt1.Rows[i]["Comment"].ToString() + "</div></li>";

           }
           HotelReview.Visible = true;
       }
       else
       {
           HotelReview.Visible = false;
       }
       ReviewsList.InnerHtml = DivContant;
        if (con.State == ConnectionState.Open) con.Close();

    }

    protected void BtnEnquiry_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed) con.Open();

        string ArrivalDate = null;// DateTime.ParseExact(TxtArrival.Text, "yyyy-MM-dd", System.DateTime);
        string DepartureDate = null;// DateTime.ParseExact(TxtDeparture.Text, "yyyy-MM-dd", System.DateTime);
        if (HiddenField1.Value != "")
        {
            ArrivalDate = HiddenField1.Value.Substring(6, 4) + "-" + HiddenField1.Value.Substring(3, 2) + "-" + HiddenField1.Value.Substring(0, 2);
        }
        if (HiddenField2.Value != "")
        {
            DepartureDate = HiddenField2.Value.Substring(6, 4) + "-" + HiddenField2.Value.Substring(3, 2) + "-" + HiddenField2.Value.Substring(0, 2);
        }

        cmd = new MySqlCommand("insert into enquiries (HotelKey,PackageKey,Type,YName,Email,Telephone,FromCity,ArrivalDate,DepartureDate,Adult,Child,Requriments,HotelName,EnquiryDate,Status) values (@HotelKey,@PackageKey,@Type,@YName,@Email,@Telephone,@FromCity,@ArrivalDate,@DepartureDate,@Adult,@Child,@Requriments,@HotelName,@EnquiryDate,@Status)", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
        cmd.Parameters.AddWithValue("@PackageKey", 0);
        cmd.Parameters.AddWithValue("@Type", "Hotel");
        cmd.Parameters.AddWithValue("@YName", TxtName.Text);
        cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
        cmd.Parameters.AddWithValue("@Telephone", TxtTelephone .Text);
        cmd.Parameters.AddWithValue("@FromCity", "");
        cmd.Parameters.AddWithValue("@ArrivalDate", ArrivalDate);
        cmd.Parameters.AddWithValue("@DepartureDate", DepartureDate);
        cmd.Parameters.AddWithValue("@Adult", TxtAdult.Text);
        cmd.Parameters.AddWithValue("@Child", TxtChild .Text);
        cmd.Parameters.AddWithValue("@Requriments", TxtMessage .Text);
        cmd.Parameters.AddWithValue("@HotelName", LblHotel.Text);
        cmd.Parameters.AddWithValue("@Status", "Unpublished");
        cmd.Parameters.AddWithValue("@EnquiryDate", DateTime.Now);
        cmd.ExecuteNonQuery();

        string Message_to_Admin = "Name : " + TxtName.Text + " " + "\r\nEmail ID : " + TxtEmail.Text + "\r\nTelephone : " + TxtTelephone.Text + "\r\nArrival Date : " + HiddenField1.Value + "\r\nDeparture Date : " + HiddenField2.Value + "\r\nAdult : " + TxtAdult.Text + "\r\nChild : " + TxtChild.Text + "\r\nRequriments : " + TxtMessage.Text;
        string Message_to_Hotel = "Name : " + TxtName.Text + " " + "\r\nArrival Date : " + HiddenField1.Value + "\r\nDeparture Date : " + HiddenField2.Value + "\r\nAdult : " + TxtAdult.Text + "\r\nChild : " + TxtChild.Text + "\r\nRequriments : " + TxtMessage.Text;

        cmd = new MySqlCommand("SELECT  *  FROM Options Where OptionKey=1", con);
        MySqlDataAdapter objOptionAdapter = new MySqlDataAdapter(cmd);
        DataTable OptionDataTable = new DataTable();

        objOptionAdapter.Fill(OptionDataTable);

        int Portnumber = 0;
        if (OptionDataTable.Rows[0]["PortNumber"].ToString() != "")
        {
            Portnumber = Convert.ToInt32(OptionDataTable.Rows[0]["PortNumber"].ToString());
        }

        SmtpClient client = new SmtpClient();
        client.Port = Portnumber;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString());
        client.Host = "localhost";
        //client.Host = OptionDataTable.Rows[0]["SMTPServerName"].ToString()

        //mail to the admin
        MailMessage mail_admin = new MailMessage(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["AdminEmailId"].ToString());
        mail_admin.Subject = "Miami & Miami Enquiry";
        mail_admin.Body = Message_to_Admin;
        client.Send(mail_admin);

        //mail to the hotel
        MailMessage mail_hotel = new MailMessage(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), EmailID);
        mail_hotel.Subject = "Miami & Miami Enquiry";
        mail_hotel.Body = Message_to_Hotel;
        client.Send(mail_hotel);

        //mail to the client
        MailMessage mail_client = new MailMessage(OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), TxtEmail.Text);
        mail_client.Subject = "Miami & Miami Enquiry";
        mail_client.Body = "Thank you for submitting your Hotel Enquiry for " + LblHotel.Text + ". \r\n We will contact you soon. \r\n Thanks, Miami & Miami";
        client.Send(mail_client);

        Label1.Text = "Thank you for submitting your enquiry.  We will contact you soon. Thanks, Miami & Miami";

        TxtName.Text = "";
        TxtEmail.Text = "";
        TxtAdult.Text = "1";
     
        TxtArrival.Text = "";
        TxtChild.Text = "0";
        TxtDeparture.Text = "";
        TxtMessage.Text = "";
        TxtTelephone.Text = ""; 
 


        if (con.State == ConnectionState.Open) con.Close();

      
    }
}
