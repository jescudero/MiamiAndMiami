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
public partial class Admin_PackageGalleries : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;
    private static string PackageKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!base.IsPostBack)
        {
            this.fillData();
        }


    }

    protected void adddata()
    {
        if (FileUpload1.HasFile)
        {
            Int64 fileSizeByte = FileUpload1.PostedFile.ContentLength;

            string Fullfilename;
            string extension = Path.GetExtension(this.FileUpload1.FileName);
            Fullfilename = "Package" + PackageKey + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
            this.FileUpload1.SaveAs(base.Server.MapPath("../Packages/") + Fullfilename);

            if (con.State == ConnectionState.Closed) con.Open();
            this.cmd = new MySqlCommand("Insert into packagephotos(PackageKey,ImageName,Caption,SizeINByte,UploadDate) values (@PackageKey,@ImageName,@Caption,@SizeINByte,@UploadDate) ", this.con);
            this.cmd.CommandType = CommandType.Text;
            this.cmd.Parameters.AddWithValue("@PackageKey", PackageKey);
            this.cmd.Parameters.AddWithValue("@ImageName", Fullfilename);
            this.cmd.Parameters.AddWithValue("@Caption", txtDescription.Text);
            this.cmd.Parameters.AddWithValue("@SizeINByte", fileSizeByte);
            this.cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);
            this.cmd.ExecuteNonQuery();


            txtDescription.Text = "";
            this.fillData();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        adddata();

    }


    protected void fillData()
    {

        if (con.State == ConnectionState.Closed) con.Open();

        this.cmd = new MySqlCommand("select * from Packages where PackageKey='" + (String)Request.QueryString["PackageID"] + "' ", this.con);
        MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            Label2.Text = dt1.Rows[0]["PackageName"].ToString() + " Gallery";
            HiddenField1.Value = dt1.Rows[0]["PackageKey"].ToString();
            PackageKey = dt1.Rows[0]["PackageKey"].ToString();
        }
        else
        {
            Response.Redirect("Packages.aspx");
        }

        this.cmd = new MySqlCommand("select * from packagephotos where PackageKey='" + PackageKey + "' order by UploadDate desc", this.con);
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


    private long RandomPinNumber()
    {
        Random random = new Random(Environment.TickCount);
        return (long)random.Next(0, 0x989680);
    }
}
