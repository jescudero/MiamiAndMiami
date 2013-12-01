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

public partial class Admin_Testimonials : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    AutoIncrement AutoInc = new AutoIncrement();
    static string TestimonialKey = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!base.IsPostBack)
        {
            ddlGuestType_SelectedIndexChanged(null, null);
        }
    }
   
    protected void ddlGuestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectData();
    }
  
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlGuestType_SelectedIndexChanged(null, null);
        
    }
    protected void SelectData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string ss = "";
        if (ddlGuestType.Text != "All")
        {
            ss = " Where Status='" + ddlGuestType.Text + "' ";
        }



        this.cmd = new MySqlCommand("SELECT * From testimonials  " + ss + " Order By UploadedDate DESC", this.con);
        MySqlDataAdapter adapter = new MySqlDataAdapter(this.cmd);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        this.GrdServiceProviders.DataSource = dataTable;
        if (dataTable.Rows.Count == 0)
        {
            ShowNoResultFound(dataTable, GrdServiceProviders);
        }
        this.GrdServiceProviders.DataBind();
        if (con.State == ConnectionState.Open) con.Close();
    }
    private void ShowNoResultFound(DataTable dt1, GridView gv)
    {
        DataTable dt = (DataTable)dt1;
        dt.Rows.Add(dt.NewRow());
        gv.DataSource = dt;
        gv.DataBind();
        int TotalColumns = gv.Rows[0].Cells.Count;
        gv.Rows[0].Cells.Clear();
        gv.Rows[0].Cells.Add(new TableCell());
        gv.Rows[0].Height = 0;
        gv.Rows[0].Visible = false;
    }
    protected void GrdServiceProviders_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdServiceProviders.PageIndex = e.NewPageIndex;
        this.SelectData();
    }


    protected void LnkDelete_Click(object sender, EventArgs e)
    {
        if (this.con.State == ConnectionState.Closed) con.Open();
        foreach (GridViewRow row in this.GrdServiceProviders.Rows)
        {
            bool flag = Convert.ToBoolean(((CheckBox)row.FindControl("ChkPaidStatus")).Checked);
            TestimonialKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("delete from testimonials where TestimonialKey='" + TestimonialKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();


            }
        }

        if (con.State == ConnectionState.Open) con.Close(); ;

        this.SelectData();

    }

    protected void LnkPublished_Click(object sender, EventArgs e)
    {
        if (this.con.State == ConnectionState.Closed) con.Open();
        foreach (GridViewRow row in this.GrdServiceProviders.Rows)
        {
            bool flag = Convert.ToBoolean(((CheckBox)row.FindControl("ChkPaidStatus")).Checked);
            TestimonialKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("Update testimonials set  Status='Published' where TestimonialKey='" + TestimonialKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
            }
        }

        if (con.State == ConnectionState.Open) con.Close();

        this.SelectData();

    }
    protected void LnkUnpublished_Click(object sender, EventArgs e)
    {
        if (this.con.State == ConnectionState.Closed) con.Open();
        foreach (GridViewRow row in this.GrdServiceProviders.Rows)
        {
            bool flag = Convert.ToBoolean(((CheckBox)row.FindControl("ChkPaidStatus")).Checked);
            TestimonialKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("Update testimonials set status='Unpublished' where TestimonialKey='" + TestimonialKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
            }
        }
        if (con.State == ConnectionState.Open) con.Close();
        this.SelectData();

    }
}