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
public partial class Admin_DeletePackagePhoto : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;
    private static string PackagePhotoKey;
    private static string PackageKey;
    protected void DeleteData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        this.cmd = new MySqlCommand("Select * from Packagephotos where PackageKey='" + PackageKey + "' And PackagePhotoKey='" + PackagePhotoKey + "' ", this.con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string ImageName = dt.Rows[0]["ImageName"].ToString();
            try
            {
                if (File.Exists(Server.MapPath("../Packages/" + ImageName)) == true)
                {

                    File.Delete(Server.MapPath("../Packages/" + ImageName));
                }
            }
            catch (Exception ex)
            {
            }
        }

        this.cmd = new MySqlCommand("Delete from Packagephotos where PackagePhotoKey='" + PackagePhotoKey + "' ", this.con);
        this.cmd.ExecuteNonQuery();
        if (con.State == ConnectionState.Open) con.Close(); ;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }

        PackagePhotoKey = base.Request.QueryString["id1"];
        PackageKey = (String)Request.QueryString["PackageID"];
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        this.DeleteData();
        this.fillData();
    }

    protected void fillData()
    {

        if (con.State == ConnectionState.Closed) con.Open();


        this.cmd = new MySqlCommand("select * from Packagephotos where PackageKey='" + PackageKey + "' order by UploadDate desc", this.con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        Label1.Text = "Package Photos (" + dt.Rows.Count + ")";
        if (dt.Rows.Count > 0)
        {
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
        if (con.State == ConnectionState.Open) con.Close(); ;

    }
    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        fillData();

    }
}
