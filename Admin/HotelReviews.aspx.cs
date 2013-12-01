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


public partial class Admin_HotelReviews : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    private static string HotelReviewKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
       
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        if (!IsPostBack)
        {
            //Date1.Text = "01-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
            //Date2.Text = DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
            //HiddenField1.Value = "01-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
            //HiddenField2.Value = DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
            
            FillItemCategories();
            DDLHotel.SelectedValue = (String)Session["HotelID"];
            DDLHotel_SelectedIndexChanged(null, null); 
        }
        
    }
    private void FillItemCategories()
    {
        if (con.State == ConnectionState.Closed) con.Open();

        cmd = new MySqlCommand("SELECT * FROM Hotels", con);
        MySqlDataAdapter SqlAdp = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        SqlAdp.Fill(dt);
        DDLHotel.DataValueField = "HotelKey";
        DDLHotel.DataTextField  = "HotelName"; 
        DDLHotel .DataSource = dt;
        DDLHotel.DataBind();

        if (con.State == ConnectionState.Open) con.Close();

    }
    protected void ddlGuestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectData();
    }
    protected void DDLHotel_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectData();
    }
    protected void SelectData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string ss = "";
        if (ddlGuestType.Text != "All")
        {
            ss = " And Status='" + ddlGuestType.Text + "' ";
        }

        string ArrivalDate = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-01";
        string DepartureDate = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00");
        //if (HiddenField1.Value != "")
        //{
        //    ArrivalDate = HiddenField1.Value.Substring(6, 4) + "-" + HiddenField1.Value.Substring(3, 2) + "-" + HiddenField1.Value.Substring(0, 2);
        //}
        //if (HiddenField2.Value != "")
        //{
        //    DepartureDate = HiddenField2.Value.Substring(6, 4) + "-" + HiddenField2.Value.Substring(3, 2) + "-" + HiddenField2.Value.Substring(0, 2);
        //}

        //LblBookingDate.Text = HiddenField1.Value + " To " + HiddenField2.Value;

        //this.cmd = new MySqlCommand("SELECT * From HotelReviews Where HotelKey='" + Convert.ToString(DDLHotel.SelectedValue) + "'  " + ss + "   And (ReviewDate Between '" + ArrivalDate + "' And '" + DepartureDate + "')   Order By ReviewDate DESC", this.con);
        this.cmd = new MySqlCommand("SELECT * From HotelReviews Where HotelKey='" + Convert.ToString(DDLHotel.SelectedValue) + "'  " + ss + "    Order By ReviewDate DESC", this.con);
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
            HotelReviewKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("delete from HotelReviews where HotelReviewKey='" + HotelReviewKey + "' ", this.con);
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
            HotelReviewKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("Update HotelReviews set  Status='Published' where HotelReviewKey='" + HotelReviewKey + "' ", this.con);
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
            HotelReviewKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("Update HotelReviews set status='Unpublished' where HotelReviewKey='" + HotelReviewKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
            }
        }
        if (con.State == ConnectionState.Open) con.Close();
        this.SelectData();

    }

    //protected void showModalPopupServerOperatorButton_Click(object sender, EventArgs e)
    //{
    //    Date1.Text = HiddenField1.Value;
    //    Date2.Text = HiddenField2.Value;

    //    this.programmaticModalPopup.Show();
    //}
    //protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    //{
    //    this.programmaticModalPopup.Hide();
    //    SelectData();
    //}
    //protected void hideModalPopupViaServer1_Click(object sender, EventArgs e)
    //{
    //    this.programmaticModalPopup.Hide();
    //}
}
