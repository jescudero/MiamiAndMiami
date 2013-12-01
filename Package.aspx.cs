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

public partial class Package : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    static string PackageKey = "";
    string PackageSerach = "";
     user obj = new user();
    string PackageImage = "";
    static string EmailID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!IsPostBack)
        {

            //string name = Page.RouteData.Values["PackageID"] as string;
            //if (name != null)
            //{
            //    name = name.Replace("Package", "");

            //    if (name != null && name != "")
            //    {
            //        PackageKey = name;
            //        GetPhaseData();

            //    }
            //    else
            //    {
            //        Response.Redirect("ListingPackage");
            //    }
            //}
            //else
            //{
            //    Response.Redirect("ListingPackage");
            //}

            if ((String)Request.QueryString["PackageID"] != null && (String)Request.QueryString["PackageID"] != "")
            {
                PackageKey = (String)Request.QueryString["PackageID"];
                GetPhaseData();

            }
            else
            {
                Response.Redirect("ListingPackage");
            }

        }
          
    }

    protected void GetPhaseData()
    {
        //PackageSerach = obj.loadurl();

        //if (PackageSerach != "")
        // {

        //     PackageKey = PackageSerach.Replace("PackageID","");
             if (con.State == ConnectionState.Closed) con.Open();


             string q = "select * From Packages where PackageKey = '" + PackageKey +"' " ;
             cmd = new MySqlCommand(q, con);
             MySqlDataReader dr = cmd.ExecuteReader();
             if (dr.Read())
             {
                 this.Title = dr["PackageName"].ToString();
                 HtmlMeta meta = new HtmlMeta();
                 meta.Name = "Package";
                 meta.Content = dr["PackageName"].ToString();
                 this.Header.Controls.Add(meta);
                 BookNow.HRef = "OnlineReservation.aspx?Type=Package&ID=" + PackageKey;
                 Enquiry.HRef = "Enquiry.aspx?Type=Package&ID=" + PackageKey;
                 //Enquiry.HRef = "Review.aspx?HotelID=" + HotelKey;
                 hotelrent.InnerHtml = dr["Price"].ToString();
                 LblHotel.Text = dr["PackageName"].ToString();
                 //DDLListingType.Text = dr["ListingType"].ToString();
                 hoteldesc.InnerHtml = dr["ShortDescription"].ToString();
                 PackageImage = dr["PackageImage"].ToString();
                 overview.InnerHtml = dr["PackageOverview"].ToString();
                 //TxtVideo.Text = dr["VideoLink"].ToString();
                 if (dr["VideoLink"].ToString() != "")
                 {
                     Video.Visible = true;
                     Video.InnerHtml = "<iframe  src=" + dr["VideoLink"].ToString() + " frameborder=\"0\" allowfullscreen></iframe>";
                 }
                 else
                 {
                     Video.Visible = false;
                 }
                 if (dr["GoogleMapLocation"].ToString() != "")
                 {
                     GoogleMap.Visible = true;
                     GoogleMap.InnerHtml = "<iframe width=\"920\" height=\"350\" frameborder=\"0\" scrolling=\"no\" marginheight=\"0\" marginwidth=\"0\" src=" + dr["GoogleMapLocation"].ToString() + "></iframe><br /><small><a href=" + dr["GoogleMapLocation"].ToString() + " style=\"color:#0000FF;text-align:left\">View Larger Map</a></small>";
                 }
                 else
                 {
                     GoogleMap.Visible = false;
                 }
                 EmailID = dr["EmailID"].ToString();
           
                 ImgHotel.Src = "Packages/" + PackageImage;


             }
             else
             {
                 Response.Redirect("ListingPackage");
             }
             dr.Close();
             string DivContant = "";

             this.cmd = new MySqlCommand("Select * from Packagephotos where PackageKey='" + PackageKey + "'  order by UploadDate desc", this.con);
             MySqlDataAdapter da = new MySqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             if (dt.Rows.Count > 0)
             {

                 for (int i = 0; i < dt.Rows.Count; i++)
                 {
                     string ProductImage = "Packages/" + dt.Rows[i]["ImageName"].ToString();
                     string str2 = dt.Rows[i]["ImageName"].ToString();
                     if (File.Exists(Server.MapPath("Packages/" + str2)) == true)
                     {
                         //DivContant =DivContant+ "<a class=\"pirobox\" href=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" title=\"" + dt.Rows[i]["Caption"].ToString() + "\"><img src=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" alt=\"\" width=\"215px\" height=\"150px\" style=\"border:1px solid #224467; padding:2px; margin:5px;border-radius: 8px; opacity: 1;\" /></a>"
                         //DivContant = DivContant + "<a  class=\"highslide\" href=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" onclick=\"return hs.htmlExpand(this, { objectType: 'iframe'  })\" title=\"" + dt.Rows[i]["Caption"].ToString() + "\"><img src=\"Hotel/" + dt.Rows[i]["ImageName"].ToString() + "\" title=\"Click to enlarge\" alt=\"Highslide JS\" width=\"215px\" height=\"150px\" style=\"border:1px solid #224467; padding:2px; margin:5px;border-radius: 8px; opacity: 1;\" /></a>";
                         // DivContant = DivContant + "<a class=\"fancybox\" href=\"Packages/" + dt.Rows[i]["ImageName"].ToString() + "\" data-fancybox-group=\"gallery\" title=\"" + dt.Rows[i]["Caption"].ToString() + "\"><img src=\"Packages/" + dt.Rows[i]["ImageName"].ToString() + "\" alt=\"\" width=\"215px\" height=\"150px\" style=\"border:1px solid #224467; padding:2px; margin:5px;border-radius: 8px; opacity: 1;\" /></a>";
                         DivContant = DivContant + "<a  href=\"Packages/" + dt.Rows[i]["ImageName"].ToString() + "\"  title=\"" + dt.Rows[i]["Caption"].ToString() + "\" onclick=\"showPreview('" + ProductImage + "','" + (i + 1) + "');return false\"><img src=\"Packages/" + dt.Rows[i]["ImageName"].ToString() + "\"></a>	";


                     }
                 }
                 galleryContainer.Visible = true;
             }
             else
             {
                 galleryContainer.Visible = false;
             }
             // UserImages.InnerHtml = DivContant;
             theImages.InnerHtml = DivContant + "  <div id=\"slideEnd\"></div>";
             if (con.State == ConnectionState.Open) con.Close();
         //}
         //else
         //{
         //    Response.Redirect("Package-Listing");
         //}

    }

   
}
