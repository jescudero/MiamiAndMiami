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

public partial class Testimonial : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;
    private static string ImageName = "";
    private static int TKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!base.IsPostBack)
        {
          
        }
            
    }
    private long RandomPinNumber()
    {
        Random random = new Random(Environment.TickCount);
        return (long)random.Next(0, 0x989680);
    }
    protected void modifydata()
    {
        if (FileUpload1.HasFile)
        {


            Int64 fileSizeByte = FileUpload1.PostedFile.ContentLength;

            string Fullfilename;
            string extension = Path.GetExtension(this.FileUpload1.FileName);
            Fullfilename = "User" + Session["LoginUserkey"] + "_" + this.RandomPinNumber() + extension;
            this.FileUpload1.SaveAs(base.Server.MapPath("images/Testimonials/") + Fullfilename);

            if (con.State == ConnectionState.Closed) con.Open();



            this.cmd = new MySqlCommand("update  testimonials set UserKey=@UserKey,UserName=@UserName,EmailId=@EmailId,Location=@Location,ImageName=@ImageName,TestimonialContent=@TestimonialContent,UploadedDate=@UploadedDate,Status=@Status where UserKey='" +Convert.ToString( Session["LoginUserkey"]) + "'  ", this.con);
            this.cmd.CommandType = CommandType.Text;
            this.cmd.Parameters.AddWithValue("@UserKey", Session["LoginUserkey"].ToString());
            this.cmd.Parameters.AddWithValue("@UserName", TxtFullName.Text);
            this.cmd.Parameters.AddWithValue("@EmailId", TxtEmail.Text);
            this.cmd.Parameters.AddWithValue("@Location", TxtLocation.Text);
            this.cmd.Parameters.AddWithValue("@TestimonialContent", TxtTestimonial.Text);
            this.cmd.Parameters.AddWithValue("@UploadedDate", System.DateTime.Now);
            this.cmd.Parameters.AddWithValue("@ImageName", Fullfilename);
            this.cmd.Parameters.AddWithValue("@Status", "Pending");
            this.cmd.ExecuteNonQuery();



            if (con.State == ConnectionState.Open) con.Close();
        }
        lblMessage.Text = "Your Testimonial is updated";

    }
   
    protected void adddata()
    {
       
        if (FileUpload1.HasFile)
        {

            Int64 fileSizeByte = FileUpload1.PostedFile.ContentLength;

            string Fullfilename;
            string extension = Path.GetExtension(this.FileUpload1.FileName);
            Fullfilename = "User" + Session["LoginUserkey"] + "_" + this.RandomPinNumber() + extension;
            this.FileUpload1.SaveAs(base.Server.MapPath("images/Testimonials/") + Fullfilename);

            if (con.State == ConnectionState.Closed) con.Open();
           


            this.cmd = new MySqlCommand("Insert into  testimonials(UserKey,UserName,EmailId,Location,ImageName,TestimonialContent,UploadedDate,Status) values (@UserKey,@UserName,@EmailId,@Location,@ImageName,@TestimonialContent,@UploadedDate,@Status)  ", this.con);
            this.cmd.CommandType = CommandType.Text;
            this.cmd.Parameters.AddWithValue("@UserKey", Session["LoginUserkey"].ToString());
            this.cmd.Parameters.AddWithValue("@UserName", TxtFullName.Text);
            this.cmd.Parameters.AddWithValue("@EmailId", TxtEmail.Text);
            this.cmd.Parameters.AddWithValue("@Location", TxtLocation.Text);
            this.cmd.Parameters.AddWithValue("@TestimonialContent", TxtTestimonial.Text);
            this.cmd.Parameters.AddWithValue("@UploadedDate", System.DateTime.Now);
            this.cmd.Parameters.AddWithValue("@ImageName", Fullfilename);
            this.cmd.Parameters.AddWithValue("@Status", "Pending");
            this.cmd.ExecuteNonQuery();



            if (con.State == ConnectionState.Open) con.Close();
        }
        lblMessage.Text = "Your Testimonial is added";

    }
    protected void BtnOk_Click(object sender, EventArgs e)
    {
        adddata();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


    
}