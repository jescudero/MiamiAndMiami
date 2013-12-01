using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
public partial class MasterPage : System.Web.UI.MasterPage
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
        if (Convert.ToString((String )Session["sessionUserType"]) == "Admin")
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

    
    protected void loaddata()
    {

        if (con.State == ConnectionState.Closed) con.Open();
        MySqlDataAdapter da;
        DataTable dt;
       


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
                //else if (dt.Rows[i]["ModuleName"].ToString() == "MiamiShopping")
                //{
                //    MiamiShopping.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                //}
                //else if (dt.Rows[i]["ModuleName"].ToString() == "FunandLeisure")
                //{
                //    FunandLeisure.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                //}
                //else if (dt.Rows[i]["ModuleName"].ToString() == "Events")
                //{
                //    Events.InnerHtml = dt.Rows[i]["SortDescription"].ToString();
                //}
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
        if (con.State == ConnectionState.Open) con.Close();
    }
   
 

    
    protected void Button1_Click(object sender, EventArgs e)
    {
        String city = TxtSearchMiami.Text.Replace("&", "");
        Response.Redirect("SearchResult.aspx?Search=" + city);
    }
}
