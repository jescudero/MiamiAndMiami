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

public partial class Admin_ContactUs : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        // this.lblName.Text = this.Session["sessionBridename"].ToString() + " & " + this.Session["sessionGroomname"].ToString();
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (!base.IsPostBack)
        {
            this.loaddata();
            this.lblMessage.Text = "";
        }
        //CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        //_FileBrowser.BasePath = "../ckeditor/ckfinder/";
        //_FileBrowser.SetupCKEditor(FCKeditor1);
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed) con.Open();
        this.cmd = new MySqlCommand("Delete From modules  where ModuleName='ContactUs' ", this.con);
        this.cmd.ExecuteNonQuery();


        this.cmd = new MySqlCommand("Insert Into modules (ModuleContent,ModuleName,Header ) Values(@ModuleContent,@ModuleName,@Header) ", this.con);
        this.cmd.CommandType = CommandType.Text;
        this.cmd.Parameters.AddWithValue("@ModuleContent", this.FCKeditor1.Value );
        this.cmd.Parameters.AddWithValue("@ModuleName", "ContactUs");
        this.cmd.Parameters.AddWithValue("@Header", "Contact Us"); 
        this.cmd.ExecuteNonQuery();
      
        if (con.State == ConnectionState.Open) con.Close(); 
        this.lblMessage.Text = "Contact Us updated.";
    }

    protected void loaddata()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        this.cmd = new MySqlCommand("select ModuleContent from modules  where ModuleName='ContactUs'  ", this.con);
        MySqlDataReader reader = this.cmd.ExecuteReader();
        if (reader.HasRows && reader.Read())
        {
            this.FCKeditor1.Value  = reader["ModuleContent"].ToString();
        }
        reader.Close();
        if (con.State == ConnectionState.Open) con.Close(); ;
    }
}
