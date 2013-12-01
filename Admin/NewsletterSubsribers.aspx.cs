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
public partial class Admin_NewsletterSubsribers : System.Web.UI.Page
{

    MySqlConnection con;
    MySqlCommand cmd;
    private static string NewsletterKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }

        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        if (!IsPostBack)
        {
            SelectData();
        }

    }
  
  
    protected void SelectData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
        string ss = "";


        this.cmd = new MySqlCommand("SELECT * From newsletters  Order By SubscribeDate DESC", this.con);
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
            NewsletterKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("delete from newsletters where NewsletterKey='" + NewsletterKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();


            }
        }

        if (con.State == ConnectionState.Open) con.Close(); ;

        this.SelectData();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed) con.Open();

        cmd = new MySqlCommand("SELECT  *  FROM Options Where OptionKey=1", con);
        MySqlDataAdapter objOptionAdapter = new MySqlDataAdapter(cmd);
        DataTable OptionDataTable = new DataTable();

        objOptionAdapter.Fill(OptionDataTable);

        int Portnumber = 0;
        if (OptionDataTable.Rows[0]["PortNumber"].ToString() != "")
        {
            Portnumber = Convert.ToInt32(OptionDataTable.Rows[0]["PortNumber"].ToString());
        }
        SMSAndEmail objSmsEmail = new SMSAndEmail();
        string[] StrAttachment=new string[0];
        Int32 Total = 0;
        foreach (GridViewRow row in this.GrdServiceProviders.Rows)
        {
            bool flag = Convert.ToBoolean(((CheckBox)row.FindControl("ChkPaidStatus")).Checked);
            NewsletterKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
                Total = Total + 1;
                string Email = Convert.ToString(((Label)row.FindControl("lblEmail")).Text);
                if (DropDownList1.Text == "Plain Text")
               {
                   objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), Email, Txtsubject.Text, TxtMessage.Text,false ,StrAttachment );
               }
               else
               {

                   objSmsEmail.SendMail(OptionDataTable.Rows[0]["SMTPServerName"].ToString(), Portnumber, OptionDataTable.Rows[0]["SMTPServerEmailId"].ToString(), OptionDataTable.Rows[0]["SMTPServerEmailPassword"].ToString(), Email, Txtsubject.Text, TxtMessage.Text, true, StrAttachment);
               }
        

            }
        }
        LblError.Text = Total + " email successfully sent";
        
    }
}
