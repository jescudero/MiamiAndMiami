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
using System.IO;
using System.Text;
using System.Data.OleDb;
public partial class UploadHotel : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    static string str = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        if ((FileUpload1.HasFile))
        {
            try
            {


                string strFileName = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                string strFileType = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();
                string strNewPath = Server.MapPath("../CSVLoad/" + strFileName + strFileType);
                //strNewPath = "http://portal.silverstoneperformance.org.uk/portal/UploadedExcel/" + strFileName + strFileType;

                //Check file type
                if (strFileType == ".csv" || strFileType == ".csv")
                {
                    FileUpload1.SaveAs(Server.MapPath("../CSVLoad/" + strFileName + strFileType));
                    //FileUpload1.SaveAs(strNewPath);
                }
                else
                {
                    lblMessage.Text = "Only Excel Files Allowed";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                    return;
                }

                StreamReader Sr = new StreamReader(strNewPath);

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (con.State == ConnectionState.Closed) con.Open();
                string s;
                Int32 rowIndex = 2;
                while (!Sr.EndOfStream)
                {
                    s = Sr.ReadLine();
                    if (rowIndex != 2)
                    {

                        
                        ProductInsertData( Convert.ToString(s.Split(',')[0]), (String)Session["sessionUserkey"], Convert.ToString(s.Split(',')[1]), Convert.ToString(s.Split(',')[2]), Convert.ToString(s.Split(',')[3]), Convert.ToString(s.Split(',')[4]), Convert.ToString(s.Split(',')[5]), Convert.ToString(s.Split(',')[6]), Convert.ToString(s.Split(',')[7]), Convert.ToString(s.Split(',')[8]), Convert.ToString(s.Split(',')[9]), Convert.ToString(s.Split(',')[10]), Convert.ToString(s.Split(',')[11]), Convert.ToString(s.Split(',')[12]), Convert.ToString(s.Split(',')[13]), Convert.ToString(s.Split(',')[14]) , Convert.ToString(s.Split(',')[15]));

                    }
                    rowIndex = rowIndex + 1;
                }


                con.Close();
            }
            catch (Exception ex)
            {
            }
        }
       

    }


    private void ProductInsertData(string HotelKey, string UserKey, string HotelName, string ListingType, string ShortDescription, string HotelImage, string HotelOverview, string VideoLink, string PricePerDay, string GoogleMapLocation, string EmailID, string PhoneNumber, string Address, string City, string State, string Country, string Website)
    {
        bool Status = false;
         string q = "select * from Hotels where HotelKey = '" + HotelKey+"' ";
        cmd = new MySqlCommand(q, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Status = true;
        }
        dr.Close();

        if (Status == true)
        {
             q = "UPDATE Hotels SET UserKey=@UserKey,HotelName=@HotelName,ListingType=@ListingType,ShortDescription=@ShortDescription,HotelImage=@HotelImage,HotelOverview=@HotelOverview,VideoLink=@VideoLink,PricePerDay=@PricePerDay,GoogleMapLocation=@GoogleMapLocation,EmailID=@EmailID,PhoneNumber=@PhoneNumber,Address=@Address,City=@City,State=@State,Country=@Country,Website=@Website WHERE HotelKey = @HotelKey";
            cmd = new MySqlCommand(q, con);

        }
        else
        {
            cmd = new MySqlCommand("insert into Hotels (UserKey,HotelName,ListingType,ShortDescription,HotelImage,HotelOverview,VideoLink,PricePerDay,GoogleMapLocation,EmailID,PhoneNumber,Address,City,State,Country,Website) values (@UserKey,@HotelName,@ListingType,@ShortDescription,@HotelImage,@HotelOverview,@VideoLink,@PricePerDay,@GoogleMapLocation,@EmailID,@PhoneNumber,@Address,@City,@State,@Country,@Website)", con);

        }
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@UserKey", UserKey);
        cmd.Parameters.AddWithValue("@HotelName", HotelName);
        cmd.Parameters.AddWithValue("@ListingType", ListingType);
        cmd.Parameters.AddWithValue("@ShortDescription", ShortDescription);
        cmd.Parameters.AddWithValue("@HotelImage", HotelImage);
        cmd.Parameters.AddWithValue("@HotelOverview", HotelOverview);
        cmd.Parameters.AddWithValue("@VideoLink", VideoLink);
        if (PricePerDay == "")
        {
            cmd.Parameters.AddWithValue("@PricePerDay", 0);
        }
        else
        {
            cmd.Parameters.AddWithValue("@PricePerDay", PricePerDay);
        }
        cmd.Parameters.AddWithValue("@GoogleMapLocation", GoogleMapLocation);
        cmd.Parameters.AddWithValue("@EmailID", EmailID);
        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
        cmd.Parameters.AddWithValue("@Address", Address);
        cmd.Parameters.AddWithValue("@City", City);
        cmd.Parameters.AddWithValue("@State", State);
        cmd.Parameters.AddWithValue("@Country", Country);
        cmd.Parameters.AddWithValue("@Website", Website);

        cmd.Parameters.AddWithValue("@HotelKey", HotelKey);
        cmd.ExecuteNonQuery();

    }
}
