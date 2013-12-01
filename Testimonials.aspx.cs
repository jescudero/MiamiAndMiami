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
public partial class Testimonials : System.Web.UI.Page
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

        if (con.State == ConnectionState.Closed) con.Open();
        MySqlDataAdapter da;
        DataTable dt;
        string HotelListContaint = "";

        cmd = new MySqlCommand("Select * from testimonials Where Status = 'Published'", con);
        
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

           string HotelImage = "images/Testimonials/" + dt.Rows[i]["ImageName"].ToString();
           HotelListContaint = HotelListContaint + "<li class=\"item\"><div class=\"u-image\"> <img src=" + HotelImage + "  alt=\"Testimonials\" /></div><div class=\"test-right\"><div class=\"testimonial\">" + dt.Rows[i]["TestimonialContent"].ToString() + "</div><h3 class=\"u-name\">" + dt.Rows[i]["UserName"].ToString() + "</h3><div class=\"location\">" + dt.Rows[i]["Location"].ToString() + "</div></div></li><div class=\"clear\" style=\"height:5px;border-bottom:1px solid #ccc;\" ></div>";
     
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
