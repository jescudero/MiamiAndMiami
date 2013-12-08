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
public partial class Hotel : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    static string HotelKey = "";
    static string HotelImage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!IsPostBack)
        {

            if ((String)Request.QueryString["HotelID"] != null && (String)Request.QueryString["HotelID"] != "")
            {
                HotelKey = (String)Request.QueryString["HotelID"];
                CreateCheckBoxes();
                GetPhaseData();
                
              

            }
            else
            {
                
                HotelKey = "";
            }

            TxtName .Focus();
        }
        TxtPricePerDay .Attributes.Add("onKeyDown", "var key1=event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if((key1>=48 && key1<=57)||(key1>=96 && key1<=105)||(key1==8)||(key1==9)||(key1==12)||(key1==27)||(key1==37)||(key1==39)||(key1==46)){return true;}else{return false;}");
      

    }

    protected void CreateCheckBoxes()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string q = "select * from activities";
        cmd = new MySqlCommand(q, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ListItem li = new ListItem(dr["Description"].ToString(), dr["ActivityKey"].ToString());
            li.Attributes.Add("Style", "width:200px;display:block");

            ChkActivities.Items.Add(li);
            ;
        }
        dr.Close();

        q = "select * from facilities";
        cmd = new MySqlCommand(q, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ListItem li = new ListItem(dr["Description"].ToString(), dr["FacilitiesKey"].ToString());
            li.Attributes.Add("Style", "width:200px;display:block");

            ChkFacilities.Items.Add(li);
            ;
        }
        dr.Close();
        con.Close();

    }

    protected void GetPhaseData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string q = "select * from Hotels where HotelKey = " + HotelKey;
        cmd = new MySqlCommand(q, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            TxtName.Text = dr["HotelName"].ToString();
            DDLListingType.Text = dr["ListingType"].ToString();
            TxtShortDescription.Text = dr["ShortDescription"].ToString();
            HotelImage = dr["HotelImage"].ToString();
            FCKeditor1.Value  = dr["HotelOverview"].ToString();
            TxtVideo.Text = dr["VideoLink"].ToString();
            TxtPricePerDay.Text = dr["PricePerDay"].ToString();
            txtGoogleMap .Text = dr["GoogleMapLocation"].ToString();
            TtxEmail.Text = dr["EmailID"].ToString();
            TxtPhone.Text = dr["PhoneNumber"].ToString();
            TxtAddress.Text = dr["Address"].ToString();
            TxtCity.Text = dr["City"].ToString();
            TxtState.Text = dr["State"].ToString();
            TxtCountry.Text = dr["Country"].ToString();
            TxtWebsite.Text = dr["Website"].ToString();
            txtPriceTo.Text = dr["PriceTo"].ToString();
            txtPriceFrom.Text = dr["PriceFrom"].ToString();
            ImgHotel.Src = "../Hotel/" + HotelImage;
        }

        dr.Close();

        q = "select * from hotelfacilities where HotelKey = " + HotelKey;
        cmd = new MySqlCommand(q, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ListItem myListItem = ChkFacilities.Items.FindByValue(dr["FacilitiesKey"].ToString());
            if (myListItem != null)
                myListItem.Selected = true;
        }
        dr.Close();

        q = "select * from hotelactivities where HotelKey = " + HotelKey;
        cmd = new MySqlCommand(q, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ListItem myListItem = ChkActivities.Items.FindByValue(dr["ActivitiesKey"].ToString());
            if (myListItem != null)
                myListItem.Selected = true;
        }
        dr.Close();

        if (con.State == ConnectionState.Open) con.Close();

    }
    
    protected void btnadd_Click(object sender, EventArgs e)
    {
       
            if (HotelKey != "" && HotelKey !=null )
            {
                modifydata();
               
            
            }
            else
            {
                adddata();
            }
            Response.Redirect("Hotels.aspx");
        
    }
    protected void adddata()
    {

        HotelImage = "NoImage.jpg";
        try
        {
            if (this.FileUpload1.HasFile)
            {
                
                string extension = Path.GetExtension(this.FileUpload1.FileName);
                HotelImage = DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
                this.FileUpload1.SaveAs(base.Server.MapPath("../Hotel/") + HotelImage);

            }
        }
        catch(Exception ex)
        {
        }


        if (con.State == ConnectionState.Closed) con.Open();
        cmd = new MySqlCommand("insert into Hotels (UserKey,HotelName,ListingType,ShortDescription,HotelImage,HotelOverview,VideoLink,PricePerDay,GoogleMapLocation,EmailID,PhoneNumber,Address,City,State,Country,Website,PriceTo,PriceFrom) values (@UserKey,@HotelName,@ListingType,@ShortDescription,@HotelImage,@HotelOverview,@Facilities,@Activities,@VideoLink,@PricePerDay,@GoogleMapLocation,@EmailID,@PhoneNumber,@Address,@City,@State,@Country,@Website,@PriceList,@PriceTo,@PriceFrom)", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@UserKey",(String)Session["sessionUserkey"]);
        cmd.Parameters.AddWithValue("@HotelName",TxtName.Text );
        cmd.Parameters.AddWithValue("@ListingType",DDLListingType.Text);
        cmd.Parameters.AddWithValue("@ShortDescription",TxtShortDescription .Text);
        cmd.Parameters.AddWithValue("@HotelImage", HotelImage);
        cmd.Parameters.AddWithValue("@HotelOverview",FCKeditor1.Value );
        cmd.Parameters.AddWithValue("@VideoLink",TxtVideo.Text);
        if (TxtPricePerDay.Text == "")
        {
            cmd.Parameters.AddWithValue("@PricePerDay", 0);
        }
        else
        {
            cmd.Parameters.AddWithValue("@PricePerDay", TxtPricePerDay.Text);
        }
        cmd.Parameters.AddWithValue("@GoogleMapLocation",txtGoogleMap .Text);
        cmd.Parameters.AddWithValue("@EmailID",TtxEmail .Text);
        cmd.Parameters.AddWithValue("@PhoneNumber",TxtPhone.Text);
        cmd.Parameters.AddWithValue("@Address",TxtAddress.Text);
        cmd.Parameters.AddWithValue("@City",TxtCity.Text);
        cmd.Parameters.AddWithValue("@State",TxtState.Text);
        cmd.Parameters.AddWithValue("@Country",TxtCountry .SelectedItem.Text);
        cmd.Parameters.AddWithValue("@Website",TxtWebsite .Text);
        cmd.Parameters.AddWithValue("@PriceTo", txtPriceTo.Text);
        cmd.Parameters.AddWithValue("@PriceFrom", txtPriceFrom.Text);
        cmd.ExecuteNonQuery();

        //remove activities add new
        cmd = new MySqlCommand("Delete from hotelactivities where HotelKey = " + HotelKey, con);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();

        //add activities
        foreach (ListItem item in ChkActivities.Items)
        {
            cmd = new MySqlCommand("insert into hotelactivities (HotelKey, ActivitiesKey) values (@HotelKey, @ActivitiesKey)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
            cmd.Parameters.AddWithValue("@ActivitiesKey", item.Value);
            cmd.ExecuteNonQuery();
        }

        //remove facilities add new
        cmd = new MySqlCommand("Delete from hotelfacilities where HotelKey = " + HotelKey, con);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();

        //add facilities
        foreach (ListItem item in ChkActivities.Items)
        {
            cmd = new MySqlCommand("insert into hotelfacilities (HotelKey, FacilitiesKey) values (@HotelKey, @FacilitiesKey)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
            cmd.Parameters.AddWithValue("@FacilitiesKey", item.Value);
            cmd.ExecuteNonQuery();
        }

        if (con.State == ConnectionState.Open) con.Close();

    }
    protected void modifydata()
    {
        try
        {
            if (this.FileUpload1.HasFile )
            {
                if (HotelImage != "NoImage.jpg")
                {
                    try
                    {

                        if (File.Exists(Server.MapPath("../Hotel/" + HotelImage)) == true)
                        {

                            File.Delete(Server.MapPath("../Hotel/" + HotelImage));
                        }

                    }
                    catch
                    {
                    }
                }
              
                string extension = Path.GetExtension(this.FileUpload1.FileName);
                HotelImage = DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
                this.FileUpload1.SaveAs(base.Server.MapPath("../Hotel/") + HotelImage);

            }
        }
        catch(Exception ex)
        {
        }
        if (con.State == ConnectionState.Closed) con.Open();
        string q = "UPDATE Hotels SET UserKey=@UserKey,HotelName=@HotelName,ListingType=@ListingType,ShortDescription=@ShortDescription,HotelImage=@HotelImage,HotelOverview=@HotelOverview, VideoLink=@VideoLink,PricePerDay=@PricePerDay,GoogleMapLocation=@GoogleMapLocation,EmailID=@EmailID,PhoneNumber=@PhoneNumber,Address=@Address,City=@City,State=@State,Country=@Country,Website=@Website,PriceTo=@PriceTo,PriceFrom=@PriceTo WHERE HotelKey = @HotelKey";
        cmd = new MySqlCommand(q, con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@UserKey", (String)Session["sessionUserkey"]);
        cmd.Parameters.AddWithValue("@HotelName", TxtName.Text);
        cmd.Parameters.AddWithValue("@ListingType", DDLListingType.Text);
        cmd.Parameters.AddWithValue("@ShortDescription", TxtShortDescription.Text);
        cmd.Parameters.AddWithValue("@HotelImage", HotelImage);
        cmd.Parameters.AddWithValue("@HotelOverview", FCKeditor1.Value);
        cmd.Parameters.AddWithValue("@VideoLink", TxtVideo.Text);
        if (TxtPricePerDay.Text == "")
        {
            cmd.Parameters.AddWithValue("@PricePerDay", 0);
        }
        else
        {
            cmd.Parameters.AddWithValue("@PricePerDay", TxtPricePerDay.Text);
        }
        cmd.Parameters.AddWithValue("@GoogleMapLocation", txtGoogleMap.Text);
        cmd.Parameters.AddWithValue("@EmailID", TtxEmail.Text);
        cmd.Parameters.AddWithValue("@PhoneNumber", TxtPhone.Text);
        cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
        cmd.Parameters.AddWithValue("@City", TxtCity.Text);
        cmd.Parameters.AddWithValue("@State", TxtState.Text);
        cmd.Parameters.AddWithValue("@Country", TxtCountry.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@Website", TxtWebsite.Text);
        cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
        cmd.Parameters.AddWithValue("@PriceTo", txtPriceTo.Text);
        cmd.Parameters.AddWithValue("@PriceFrom", txtPriceFrom.Text);
        cmd.ExecuteNonQuery();

        //remove activities add new
        cmd = new MySqlCommand("Delete from hotelactivities where HotelKey = " + HotelKey, con);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        //add activities
        foreach (ListItem item in ChkActivities.Items)
        {
            if (item.Selected)
            {
                cmd = new MySqlCommand("insert into hotelactivities (HotelKey, ActivitiesKey) values (@HotelKey, @ActivitiesKey)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
                cmd.Parameters.AddWithValue("@ActivitiesKey", item.Value);
                cmd.ExecuteNonQuery();
            }
        }

        //remove facilities add new
        cmd = new MySqlCommand("Delete from hotelfacilities where HotelKey = " + HotelKey, con);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();

        //add facilities
        foreach (ListItem item in ChkFacilities.Items)
        {
            if (item.Selected)
            {
                cmd = new MySqlCommand("insert into hotelfacilities (HotelKey, FacilitiesKey) values (@HotelKey, @FacilitiesKey)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
                cmd.Parameters.AddWithValue("@FacilitiesKey", item.Value);
                cmd.ExecuteNonQuery();

            }
        }

        if (con.State == ConnectionState.Open) con.Close();

    }
    protected void deletedata()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        cmd = new MySqlCommand("delete from Hotels where HotelKey = @HotelKey", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
        cmd.ExecuteNonQuery();
        Response.Redirect("Hotels.aspx");
        if (con.State == ConnectionState.Open) con.Close();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hotels.aspx");
    }
    protected void BtnAnother_Click(object sender, EventArgs e)
    {
        if (HotelKey != "" && HotelKey != null)
        {
            modifydata();


        }
        else
        {
            adddata();
        }
        TxtName .Text = "";
        TxtShortDescription .Text = "";
        TxtAddress .Text = "";
        TxtCity.Text = "";
        TxtState.Text = "";
        TxtPhone .Text = "";
        TtxEmail .Text = "";
        TxtWebsite .Text = "";
        txtGoogleMap.Text = "";
        TxtVideo .Text = "";
        FileUpload1.Dispose ();// = "";
        HotelImage = "";
        HotelKey = "";
        ImgHotel.Src = "../images/No-Photo-Available.jpg";
        TxtName.Focus();
       
    }
   
   
}
