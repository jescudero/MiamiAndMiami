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
public partial class Admin_Package : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    static string PackageKey = "";
    static string PackageImage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!IsPostBack)
        {

            if ((String)Request.QueryString["PackageID"] != null && (String)Request.QueryString["PackageID"] != "")
            {
                PackageKey = (String)Request.QueryString["PackageID"];
                GetPhaseData();


            }
            else
            {
                ImgHotel.Visible = false;
                PackageKey = "";
            }

            TxtName.Focus();
        }
        TxtPricePerDay.Attributes.Add("onKeyDown", "var key1=event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if((key1>=48 && key1<=57)||(key1>=96 && key1<=105)||(key1==8)||(key1==9)||(key1==12)||(key1==27)||(key1==37)||(key1==39)||(key1==46)){return true;}else{return false;}");


    }
    protected void GetPhaseData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string q = "select * from Packages where PackageKey = " + PackageKey;
        cmd = new MySqlCommand(q, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            TxtName.Text = dr["PackageName"].ToString();
            TxtShortDescription.Text = dr["ShortDescription"].ToString();
            PackageImage = dr["PackageImage"].ToString();
            FCKeditor1.Value = dr["PackageOverview"].ToString();
            TxtPricePerDay.Text = dr["Price"].ToString();
            //TxtVideo.Text = dr["VideoLink"].ToString();
            //txtGoogleMap.Text = dr["GoogleMapLocation"].ToString();
            //TtxEmail.Text = dr["EmailID"].ToString();
            //TxtPhone.Text = dr["PhoneNumber"].ToString();
            //TxtAddress.Text = dr["Address"].ToString();
            //TxtCity.Text = dr["City"].ToString();
            //TxtState.Text = dr["State"].ToString();
            //TxtCountry.Text = dr["Country"].ToString();
            //TxtWebsite.Text = dr["Website"].ToString();
            ImgHotel.Src = "../Packages/" + PackageImage;


        }

        dr.Close();
        if (con.State == ConnectionState.Open) con.Close();

    }

    protected void btnadd_Click(object sender, EventArgs e)
    {

        if (PackageKey != "" && PackageKey != null)
        {
            modifydata();


        }
        else
        {
            adddata();
        }
       
        Response.Redirect("Packages.aspx");

    }
    protected void adddata()
    {

        PackageImage = "NoImage.jpg";
        try
        {
            if (this.FileUpload1.HasFile)
            {
               
                string extension = Path.GetExtension(this.FileUpload1.FileName);
               //PackageImage = "Package" + PackageKey + extension;
                PackageImage = DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
                this.FileUpload1.SaveAs(base.Server.MapPath("../Packages/") + PackageImage);

            }
        }
        catch (Exception ex)
        {
        }


        if (con.State == ConnectionState.Closed) con.Open();
        cmd = new MySqlCommand("insert into Packages (UserKey,PackageName,ListingType,ShortDescription,PackageImage,PackageOverview,VideoLink,Price,GoogleMapLocation,EmailID,PhoneNumber,Address) values (@UserKey,@PackageName,@ListingType,@ShortDescription,@PackageImage,@PackageOverview,@VideoLink,@Price,@GoogleMapLocation,@EmailID,@PhoneNumber,@Address)", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@UserKey", (String)Session["sessionUserkey"]);
        cmd.Parameters.AddWithValue("@PackageName", TxtName.Text);
        cmd.Parameters.AddWithValue("@ListingType", "Premium");
        cmd.Parameters.AddWithValue("@ShortDescription", TxtShortDescription.Text);
        cmd.Parameters.AddWithValue("@PackageImage", PackageImage);
        cmd.Parameters.AddWithValue("@PackageOverview", FCKeditor1.Value);
        cmd.Parameters.AddWithValue("@VideoLink", "");
        if (TxtPricePerDay.Text == "")
        {
            cmd.Parameters.AddWithValue("@Price", 0);
        }
        else
        {
            cmd.Parameters.AddWithValue("@Price", TxtPricePerDay.Text);
        }
        cmd.Parameters.AddWithValue("@GoogleMapLocation", "");
        cmd.Parameters.AddWithValue("@EmailID", "");
        cmd.Parameters.AddWithValue("@PhoneNumber", "");
        cmd.Parameters.AddWithValue("@Address", "");
      
        cmd.ExecuteNonQuery();

        if (con.State == ConnectionState.Open) con.Close();

    }
    protected void modifydata()
    {
        try
        {
            if (this.FileUpload1.HasFile)
            {

                if (PackageImage != "NoImage.jpg")
                {
                    try
                    {

                        if (File.Exists(Server.MapPath("../Packages/" + PackageImage)) == true)
                        {

                            File.Delete(Server.MapPath("../Packages/" + PackageImage));
                        }

                    }
                    catch
                    {
                    }
                }
                string extension = Path.GetExtension(this.FileUpload1.FileName);
                PackageImage = DateTime.Now .ToString("ddMMyyyyhhmmss")  + extension;
                this.FileUpload1.SaveAs(base.Server.MapPath("../Packages/") + PackageImage);

            }
        }
        catch (Exception ex)
        {
        }
        if (con.State == ConnectionState.Closed) con.Open();
        string q = "UPDATE Packages SET UserKey=@UserKey,PackageName=@PackageName,ListingType=@ListingType,ShortDescription=@ShortDescription,PackageImage=@PackageImage,PackageOverview=@PackageOverview,VideoLink=@VideoLink,Price=@Price,GoogleMapLocation=@GoogleMapLocation,EmailID=@EmailID,PhoneNumber=@PhoneNumber,Address=@Address WHERE PackageKey = @PackageKey";
        cmd = new MySqlCommand(q, con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@UserKey", (String)Session["sessionUserkey"]);
        cmd.Parameters.AddWithValue("@PackageName", TxtName.Text);
        cmd.Parameters.AddWithValue("@ListingType", "Premium");
        cmd.Parameters.AddWithValue("@ShortDescription", TxtShortDescription.Text);
        cmd.Parameters.AddWithValue("@PackageImage", PackageImage);
        cmd.Parameters.AddWithValue("@PackageOverview", FCKeditor1.Value);
        cmd.Parameters.AddWithValue("@VideoLink", "");
        if (TxtPricePerDay.Text == "")
        {
            cmd.Parameters.AddWithValue("@Price", 0);
        }
        else
        {
            cmd.Parameters.AddWithValue("@Price", TxtPricePerDay.Text);
        }
        cmd.Parameters.AddWithValue("@GoogleMapLocation", "");
        cmd.Parameters.AddWithValue("@EmailID", "");
        cmd.Parameters.AddWithValue("@PhoneNumber", "");
        cmd.Parameters.AddWithValue("@Address", "");
        cmd.Parameters.AddWithValue("@PackageKey", PackageKey);
        cmd.ExecuteNonQuery();
        if (con.State == ConnectionState.Open) con.Close();

    }
    protected void deletedata()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        cmd = new MySqlCommand("delete from Packages where PackageKey = @PackageKey", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@PackageKey", PackageKey);
        cmd.ExecuteNonQuery();
        Response.Redirect("Packages.aspx");
        if (con.State == ConnectionState.Open) con.Close();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Packages.aspx");
    }
    protected void BtnAnother_Click(object sender, EventArgs e)
    {
        if (PackageKey != "" && PackageKey != null)
        {
            modifydata();


        }
        else
        {
            adddata();
        }
        TxtName.Text = "";
        TxtShortDescription.Text = "";
         FileUpload1.Dispose();// = "";
        PackageImage = "";
        PackageKey = "";
        ImgHotel.Visible = false;
        TxtName.Focus();

    }

    protected void btnPhotoPreview_Click(object sender, EventArgs e)
    {
        Session["ImageBytes"] = FileUpload1.FileBytes;
        ImgHotel.Src = "ImageHandler.ashx";
    }
}
