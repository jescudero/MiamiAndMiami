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
public partial class SearchResult : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;
    string SearchText = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (!IsPostBack)
        {

            if (Convert.ToString(Request.QueryString["Search"]) != "" && Convert.ToString(Request.QueryString["Search"]) != null)
            {
                SearchText = Convert.ToString(Request.QueryString["Search"]);
            }
            LoadData();
        }

    }

    private void LoadData()
    {

        string Contant = "No Search Result Found";
        if (con.State == ConnectionState.Closed) con.Open();
        MySqlDataAdapter da;
        DataTable dt;
        Int64 Total = 0;
        cmd = new MySqlCommand("Select * from modules Where (  ModuleContent LIKE '%" + SearchText + "%' ) OR  (  SortDescription LIKE '%" + SearchText + "%' ) OR (  Title LIKE '%" + SearchText + "%' ) ", con);
        da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                if (Total == 0)
                {
                    Contant = "<div class=\"search\"><h3 calss=\"searchHead\"><a href=\"Indexpage.aspx?Page=" + dt.Rows[i]["ModuleName"].ToString() + " \" >" + dt.Rows[i]["Title"].ToString() + "</a></h3><div class=\"desc\">" + dt.Rows[i]["SortDescription"].ToString() + "</div></div><hr/  style=\"margin-left:45px;Width:450px;\">";
                }
                else
                {
                    Contant = Contant + "<div class=\"search\"><h3 calss=\"searchHead\"><a href=\"Indexpage.aspx?Page=" + dt.Rows[i]["ModuleName"].ToString() + " \" >" + dt.Rows[i]["Title"].ToString() + "</a></h3><div class=\"desc\">" + dt.Rows[i]["SortDescription"].ToString() + "</div></div><hr/ style=\"margin-left:45px;Width:450px;\">"; ;
                }
                Total = Total + 1;
            }
        }

       
        UserImages.InnerHtml = Contant;
    }
   

}
