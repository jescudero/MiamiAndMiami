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

public partial class Admin_IndexPage : System.Web.UI.Page
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
        
    }


    protected void loaddata()
    {
        if (con.State == ConnectionState.Closed) con.Open();

        LblArticalHeading.Text = Convert.ToString(Request.QueryString["page"]);
        this.TxtPagetitle.Text = Convert.ToString(Request.QueryString["page"]);
        this.TxtDescription.Text = Convert.ToString(Request.QueryString["page"]);
        this.TxtMatatagKeword.Text = Convert.ToString(Request.QueryString["page"]);
        this.cmd = new MySqlCommand("select * from modules  where ModuleName='" + Convert.ToString(Request.QueryString["page"]) + "'  ", this.con);
        MySqlDataReader reader = this.cmd.ExecuteReader();
        if (reader.HasRows && reader.Read())
        {
            this.FCKeditor1.Value = reader["ModuleContent"].ToString();
            if (Convert.ToString(reader["Title"]) != "")
            {
                LblArticalHeading.Text= reader["Title"].ToString();
                this.TxtPagetitle.Text = reader["Title"].ToString();
            }
            if (Convert.ToString(reader["SortDescription"]) != "")
            {
                this.TxtDescription.Text = reader["SortDescription"].ToString();
            }
            if (Convert.ToString(reader["Metatag"]) != "")
            {
                this.TxtMatatagKeword.Text = reader["Metatag"].ToString();
            }
           
          
        }
        this.Title = LblArticalHeading.Text;
        reader.Close();
        if (con.State == ConnectionState.Open) con.Close(); 
    }

    protected void UpdateData()
    {
        if (con.State == ConnectionState.Closed) con.Open();

        this.cmd = new MySqlCommand("Delete From Modules  where ModuleName='" + Convert.ToString(Request.QueryString["page"]) + "' ", this.con);
        this.cmd.ExecuteNonQuery();
        this.cmd = new MySqlCommand("INSERT INTO Modules(ModuleName,ModuleContent,Title,SortDescription,Metatag) VALUES (@ModuleName,@ModuleContent,@Title,@SortDescription,@Metatag)", this.con);
        this.cmd.CommandType = CommandType.Text;
        this.cmd.Parameters.AddWithValue("@ModuleContent", this.FCKeditor1.Value);
        this.cmd.Parameters.AddWithValue("@ModuleName", Convert.ToString(Request.QueryString["page"]));
        this.cmd.Parameters.AddWithValue("@Title", TxtPagetitle.Text);
        this.cmd.Parameters.AddWithValue("@SortDescription", TxtDescription.Text);
        this.cmd.Parameters.AddWithValue("@Metatag", TxtMatatagKeword.Text);
        this.cmd.ExecuteNonQuery();

        if (con.State == ConnectionState.Open) con.Close(); 
    }

    protected void LnkSave_Click(object sender, EventArgs e)
    {
        UpdateData();
        this.lblMessage.Text = TxtPagetitle.Text + " updated.";
    }
    protected void LnkSaveClose_Click(object sender, EventArgs e)
    {
        UpdateData();
        Response.Redirect("AdminHome.aspx");
    }
}