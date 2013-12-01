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
using System.Text;
public partial class Admin_Members : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;

    private static string UserKey;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!base.IsPostBack)
        {
            //Date1.Text = "01-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
            //Date2.Text = DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
            //HiddenField1.Value = "01-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
            //HiddenField2.Value = DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
            
            
            this.SelectData();
        }
    }

    protected void ddlGuestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectData();
    }
    protected void SelectData()
    {
        if (con.State == ConnectionState.Closed) con.Open();
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
   
        if (ddlGuestType.Text == "De-Activated")
        {
           
            LnkDeactivate.Visible = false;
            LnkActivate.Visible = true;
            Label2.Visible = false;
            //this.cmd = new MySqlCommand("SELECT Users.*,registrations.*,registrations.Status as SS,CONCAT(Users.Title,' ', Users.FirstName, ' ',Users.LastName) as UName  from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And registrations.Status='De-Activate' and registrations.RegistrationKey<>'1'  And (registrations.RegistrationDate Between '" + ArrivalDate + "' And '" + DepartureDate + "')  order by registrations.RegistrationDate desc ", this.con);
            this.cmd = new MySqlCommand("SELECT Users.*,registrations.*,registrations.Status as SS,CONCAT(Users.Title,' ', Users.FirstName, ' ',Users.LastName) as UName  from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And registrations.Status='De-Activate' and registrations.RegistrationKey<>'1'   order by registrations.RegistrationDate desc ", this.con);
        }
        else if (ddlGuestType.Text == "Activated")
        {
           
            LnkActivate.Visible = false;
            LnkDeactivate.Visible = true;
            Label2.Visible = false;
            this.cmd = new MySqlCommand("SELECT Users.*,registrations.*,registrations.Status as SS,CONCAT(Users.Title,' ', Users.FirstName, ' ',Users.LastName) as UName  from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And  registrations.Status='Activate' and registrations.RegistrationKey<>'1' order by registrations.RegistrationDate desc ", this.con);
        }
        else if (ddlGuestType.Text == "Block")
        {
           
            LnkDeactivate.Visible = true;
            LnkActivate.Visible = true;
            Label2.Visible = true;
            this.cmd = new MySqlCommand("SELECT Users.*,registrations.*,registrations.Status as SS,CONCAT(Users.Title,' ', Users.FirstName, ' ',Users.LastName) as UName  from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And  registrations.Status='Block' and registrations.RegistrationKey<>'1' order by registrations.RegistrationDate desc ", this.con);
        }
        else
        {
           
            LnkDeactivate.Visible = true;
            LnkActivate.Visible = true;
            Label2.Visible = true;
            this.cmd = new MySqlCommand("SELECT Users.*,registrations.*,registrations.Status as SS,CONCAT(Users.Title,' ', Users.FirstName, ' ',Users.LastName) as UName from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And  registrations.RegistrationKey<>'1'   order by registrations.RegistrationDate desc ", this.con);
        }
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
            UserKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
                this.cmd = new MySqlCommand("delete from Registrations where UserKey='" + UserKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
                this.cmd = new MySqlCommand("delete from Users where UserKey='" + UserKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
                
              
            }
        }

        if (con.State == ConnectionState.Open) con.Close(); ;

        this.SelectData();

    }

    protected void LnkActivate_Click(object sender, EventArgs e)
    {
        if (this.con.State == ConnectionState.Closed) con.Open();
        foreach (GridViewRow row in this.GrdServiceProviders.Rows)
        { 
            bool flag = Convert.ToBoolean(((CheckBox)row.FindControl("ChkPaidStatus")).Checked);
            UserKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
                //this.cmd = new MySqlCommand("Update Users set  Status='Activate' where UserKey='" + UserKey + "' ", this.con);
                //this.cmd.ExecuteNonQuery();
                this.cmd = new MySqlCommand("Update Registrations set  Status='Activate' where UserKey='" + UserKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
            }
        }
      
        if (con.State == ConnectionState.Open) con.Close(); 
        
        this.SelectData();

    }
    protected void LnkDeactivate_Click(object sender, EventArgs e)
    {
        if (this.con.State == ConnectionState.Closed) con.Open();
        foreach (GridViewRow row in this.GrdServiceProviders.Rows)
        {
            bool flag = Convert.ToBoolean(((CheckBox)row.FindControl("ChkPaidStatus")).Checked);
            UserKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
                //this.cmd = new MySqlCommand("Update Users set status='De-Activate' where UserKey='" + UserKey + "' ", this.con);
                //this.cmd.ExecuteNonQuery();
                this.cmd = new MySqlCommand("Update Registrations set status='De-Activate' where UserKey='" + UserKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
            }
        }
        if (con.State == ConnectionState.Open) con.Close(); 
        this.SelectData();

    }


    protected void LnkBlock_Click(object sender, EventArgs e)
    {
        if (this.con.State == ConnectionState.Closed) con.Open();
        foreach (GridViewRow row in this.GrdServiceProviders.Rows)
        { 
            bool flag = Convert.ToBoolean(((CheckBox)row.FindControl("ChkPaidStatus")).Checked);
            UserKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
                //this.cmd = new MySqlCommand("Update Users set  Status='Block' where UserKey='" + UserKey + "' ", this.con);
                //this.cmd.ExecuteNonQuery();
                this.cmd = new MySqlCommand("Update Registrations set  Status='Block' where UserKey='" + UserKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
            }
        }
        if (con.State == ConnectionState.Open) con.Close(); 
        this.SelectData();

    }

    protected void lnkUnBlock_Click(object sender, EventArgs e)
    {
        if (this.con.State == ConnectionState.Closed) con.Open();
        foreach (GridViewRow row in this.GrdServiceProviders.Rows)
        {
            bool flag = Convert.ToBoolean(((CheckBox)row.FindControl("ChkPaidStatus")).Checked);
            UserKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                //this.cmd = new MySqlCommand("Update Users set  Status='Activate' where UserKey='" + UserKey + "' ", this.con);
                //this.cmd.ExecuteNonQuery();
                this.cmd = new MySqlCommand("Update Registrations set  Status='Activate' where UserKey='" + UserKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
            }
        }
        if (con.State == ConnectionState.Open) con.Close(); 
        this.SelectData();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (con.State == ConnectionState.Closed) con.Open();
        DataTable dt = new DataTable();
        string ArrivalDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
        string DepartureDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
        //if (HiddenField1.Value != "")
        //{
        //    ArrivalDate = HiddenField1.Value.Substring(6, 4) + "-" + HiddenField1.Value.Substring(3, 2) + "-" + HiddenField1.Value.Substring(0, 2);
        //}
        //if (HiddenField2.Value != "")
        //{
        //    DepartureDate = HiddenField2.Value.Substring(6, 4) + "-" + HiddenField2.Value.Substring(3, 2) + "-" + HiddenField2.Value.Substring(0, 2);
        //}

        if (ddlGuestType.Text == "De-Activated")
        {


            this.cmd = new MySqlCommand("SELECT registrations.RegistrationId,registrations.RegistrationDate ,CONCAT(Users.Title,' ', Users.FirstName, '',Users.LastName) as UserName,Users.	Gender,Users.UserName as Email,registrations.Phone as MobileNumber  from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And registrations.Status='De-Activate' and registrations.RegistrationKey<>'1'   order by registrations.RegistrationDate desc ", this.con);
        }
        else if (ddlGuestType.Text == "Activated")
        {


            this.cmd = new MySqlCommand("SELECT registrations.RegistrationId,registrations.RegistrationDate ,CONCAT(Users.Title,' ', Users.FirstName, '',Users.LastName) as UserName,Users.	Gender,Users.UserName as Email,registrations.Phone as MobileNumber   from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And  registrations.Status='Activate' and registrations.RegistrationKey<>'1' order by registrations.RegistrationDate desc ", this.con);
        }
        else if (ddlGuestType.Text == "Block")
        {


            this.cmd = new MySqlCommand("SELECT registrations.RegistrationId,registrations.RegistrationDate ,CONCAT(Users.Title,' ', Users.FirstName, '',Users.LastName) as UserName,Users.	Gender,Users.UserName as Email ,registrations.Phone as MobileNumber   from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And  registrations.Status='Block' and registrations.RegistrationKey<>'1'  order by registrations.RegistrationDate desc ", this.con);
        }
        else
        {


            this.cmd = new MySqlCommand("SELECT registrations.RegistrationId,registrations.RegistrationDate ,CONCAT(Users.Title,' ', Users.FirstName, '',Users.LastName) as UserName,Users.	Gender,Users.UserName as Email ,registrations.Phone as MobileNumber  from Users  Inner Join registrations ON Users.UserKey=registrations.UserKey Where Users.Status='Activate' And  registrations.RegistrationKey<>'1'    order by registrations.RegistrationDate desc ", this.con);
        }

        MySqlDataAdapter da = new MySqlDataAdapter(cmd);

        da.Fill(dt);

        ExportToExcel(dt, "Members", ddlGuestType.Text + " Membe");
        if (con.State == ConnectionState.Open) con.Close();



    }
    private void ExportToExcel(DataTable dt, string fileName, string worksheetName)
    {
        Response.Clear();
        //Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".xls");
        //Response.ContentType = "application/vnd.ms-excel";

        Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".xls");
        Response.ContentType = "application/vnd.ms-excel";


        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
        DataGrid dataExportExcel = new DataGrid();
        dataExportExcel.ItemDataBound += new DataGridItemEventHandler(dataExportExcel_ItemDataBound);
        dataExportExcel.DataSource = dt;
        dataExportExcel.DataBind();
        dataExportExcel.RenderControl(htmlWrite);
        StringBuilder sbResponseString = new StringBuilder();
        sbResponseString.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>" + worksheetName + "</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
        sbResponseString.Append(stringWriter + "</body></html>");
        Response.Write(sbResponseString.ToString());
        Response.End();
    }

    void dataExportExcel_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            //Header Text Format can be done as follows
            e.Item.Font.Bold = true;

            //Adding Filter/Sorting functionality for the Excel
            int cellIndex = 0;
            while (cellIndex < e.Item.Cells.Count)
            {
                e.Item.Cells[cellIndex].Attributes.Add("x:autofilter", "all");
                e.Item.Cells[cellIndex].Width = 200;
                e.Item.Cells[cellIndex].HorizontalAlign = HorizontalAlign.Center;
                cellIndex++;
            }
        }


        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int cellIndex = 0;
            while (cellIndex < e.Item.Cells.Count)
            {
                //Any Cell specific formatting should be done here
                e.Item.Cells[cellIndex].HorizontalAlign = HorizontalAlign.Left;
                cellIndex++;
            }
        }
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
