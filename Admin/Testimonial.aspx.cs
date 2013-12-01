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
public partial class Admin_Testimonial : System.Web.UI.Page
{
     private MySqlCommand cmd;
    private MySqlConnection con;
    private static string ImageName = "";
    private static string TestimonialKey="";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!base.IsPostBack)
        {
          TestimonialKey=Convert.ToString((String )Request.QueryString ["Testimonial"]) ;
          Loaddata();
        }
            
    }

    protected void Loaddata()
    {
        
            if (con.State == ConnectionState.Closed) con.Open();

            this.cmd = new MySqlCommand("Select * From  testimonials  where TestimonialKey='" + TestimonialKey + "'  ", this.con);
           MySqlDataReader dr; 
           dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TxtFullName.Text=dr["UserName"].ToString ();
                TxtEmail.Text=dr["EmailId"].ToString ();
                TxtLocation.Text=dr["Location"].ToString ();
                TxtTestimonial.Text=dr["TestimonialContent"].ToString ();
                ImageName=dr["ImageName"].ToString ();
               
                             

               
            }
            dr.Close();
             if (con.State == ConnectionState.Open) con.Close();
       
    }
   
    private long RandomPinNumber()
    {
        Random random = new Random(Environment.TickCount);
        return (long)random.Next(0, 0x989680);
    }
    protected void modifydata()
    {
        
           
            if (FileUpload1.HasFile ==true )
            {
           
            string extension = Path.GetExtension(this.FileUpload1.FileName);
            ImageName = "Testimonial" + TestimonialKey + "_" + this.RandomPinNumber() + extension;
            this.FileUpload1.SaveAs(base.Server.MapPath("../images/Testimonials/") + ImageName);
            }
            if (con.State == ConnectionState.Closed) con.Open();

            this.cmd = new MySqlCommand("update  testimonials set UserKey=@UserKey,UserName=@UserName,EmailId=@EmailId,Location=@Location,ImageName=@ImageName,TestimonialContent=@TestimonialContent,UploadedDate=@UploadedDate where TestimonialKey='" + TestimonialKey + "'  ", this.con);
            this.cmd.CommandType = CommandType.Text;
            this.cmd.Parameters.AddWithValue("@UserKey", (String)Session["sessionUserkey"]);
            this.cmd.Parameters.AddWithValue("@UserName", TxtFullName.Text);
            this.cmd.Parameters.AddWithValue("@EmailId", TxtEmail.Text);
            this.cmd.Parameters.AddWithValue("@Location", TxtLocation.Text);
            this.cmd.Parameters.AddWithValue("@TestimonialContent", TxtTestimonial.Text);
            this.cmd.Parameters.AddWithValue("@UploadedDate", System.DateTime.Now);
            this.cmd.Parameters.AddWithValue("@ImageName", ImageName);
            
            this.cmd.ExecuteNonQuery();
            
            if (con.State == ConnectionState.Open) con.Close();
       
        lblMessage.Text = "Your Testimonial is updated";
        TestimonialKey = "";
        TxtFullName.Text = "";
        TxtEmail.Text = "";
        TxtLocation.Text = "";
        TxtTestimonial.Text = "";
    }
   
    protected void adddata()
    {
       
        ImageName="";
            if (FileUpload1.HasFile ==true )
            {
           
            string extension = Path.GetExtension(this.FileUpload1.FileName);
            ImageName = "Testimonial" + TestimonialKey + "_" + this.RandomPinNumber() + extension;
            this.FileUpload1.SaveAs(base.Server.MapPath("../images/Testimonials/") + ImageName);
            }
            if (con.State == ConnectionState.Closed) con.Open();
           


            this.cmd = new MySqlCommand("Insert into  testimonials(UserKey,UserName,EmailId,Location,ImageName,TestimonialContent,UploadedDate,Status) values (@UserKey,@UserName,@EmailId,@Location,@ImageName,@TestimonialContent,@UploadedDate,@Status)  ", this.con);
            this.cmd.CommandType = CommandType.Text;
            this.cmd.Parameters.AddWithValue("@UserKey", (String)Session["sessionUserkey"]);
            this.cmd.Parameters.AddWithValue("@UserName", TxtFullName.Text);
            this.cmd.Parameters.AddWithValue("@EmailId", TxtEmail.Text);
            this.cmd.Parameters.AddWithValue("@Location", TxtLocation.Text);
            this.cmd.Parameters.AddWithValue("@TestimonialContent", TxtTestimonial.Text);
            this.cmd.Parameters.AddWithValue("@UploadedDate", System.DateTime.Now);
            this.cmd.Parameters.AddWithValue("@ImageName", ImageName);
            this.cmd.Parameters.AddWithValue("@Status", "Unpublished");
            this.cmd.ExecuteNonQuery();



            if (con.State == ConnectionState.Open) con.Close();
        
        lblMessage.Text = "Your Testimonial is added";

    }
    protected void BtnOk_Click(object sender, EventArgs e)
    {

        if (TestimonialKey != "" && TestimonialKey != null)
        {
            modifydata();


        }
        else
        {
            adddata();
        }
        
    }
   
    }

