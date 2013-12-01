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
public partial class Admin_Hotels : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;

    private static string HotelKey;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((string)this.Session["sessionUserType"]) != "Admin") || (((string)this.Session["sessionUserType"]) == null))
        {
            base.Response.Redirect("../Login.aspx");
        }
        this.con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        if (!base.IsPostBack)
        {
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
   

        if (ddlGuestType.Text == "De-Activate")
        {
           
            LnkDeactivate.Visible = false;
            LnkActivate.Visible = true;
            Label2.Visible = false;
            this.cmd = new MySqlCommand("SELECT * From Hotels Where Status='De-Activate'  ", this.con);
        }
        else if (ddlGuestType.Text == "Activate")
        {
           
            LnkActivate.Visible = false;
            LnkDeactivate.Visible = true;
            Label2.Visible = false;
            this.cmd = new MySqlCommand("SELECT * From Hotels Where Status='Activate'  ", this.con);
        }
        else
        {
           
            LnkDeactivate.Visible = true;
            LnkActivate.Visible = true;
            Label2.Visible = true;
            this.cmd = new MySqlCommand("SELECT * From Hotels", this.con);
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
            HotelKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
                this.cmd = new MySqlCommand("Select * from hotelphotos where HotelKey='" + HotelKey + "'  ", this.con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string ImageName = dt.Rows[i]["ImageName"].ToString();

                        if (File.Exists(Server.MapPath("../Hotel/" + ImageName)) == true)
                        {

                            File.Delete(Server.MapPath("../Hotel/" + ImageName));
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }
                string HotelImage = Convert.ToString(((Label)row.FindControl("lblHotelImage")).Text);
                if (HotelImage != "NoImage.jpg")
                {
                    try
                    {

                        if (File.Exists(Server.MapPath("../Hotel/" + HotelImage)) == true)
                        {

                            File.Delete(Server.MapPath("../Hotel/" + HotelImage));
                        }

                    }
                    catch
                    {
                    }
                }
                this.cmd = new MySqlCommand("delete from Hotelphotos where HotelKey='" + HotelKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
                this.cmd = new MySqlCommand("delete from Hotels where HotelKey='" + HotelKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
                this.cmd = new MySqlCommand("delete from HotelReviews where HotelKey='" + HotelKey + "' ", this.con);
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
            HotelKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
               
                this.cmd = new MySqlCommand("Update Hotels set  Status='Activate' where HotelKey='" + HotelKey + "' ", this.con);
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
            HotelKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
                
                this.cmd = new MySqlCommand("Update Hotels set status='De-Activate' where HotelKey='" + HotelKey + "' ", this.con);
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

        if (ddlGuestType.Text == "De-Activate")
        {

            cmd = new MySqlCommand("SELECT HotelKey as HotelID,HotelName,ListingType,ShortDescription,HotelImage,HotelOverview,VideoLink,PricePerDay,GoogleMapLocation,EmailID,PhoneNumber,Address,City,State,Country,Website " +
                       " FROM  Hotels Where Status='De-Activate' ", con);
        }
        else if (ddlGuestType.Text == "Activate")
        {

            cmd = new MySqlCommand("SELECT HotelKey as HotelID,HotelName,ListingType,ShortDescription,HotelImage,HotelOverview,VideoLink,PricePerDay,GoogleMapLocation,EmailID,PhoneNumber,Address,City,State,Country,Website " +
                       " FROM  Hotels Where Status='Activate' ", con);
           
        }
        else
        {

            cmd = new MySqlCommand("SELECT HotelKey as HotelID,HotelName,ListingType,ShortDescription,HotelImage,HotelOverview,VideoLink,PricePerDay,GoogleMapLocation,EmailID,PhoneNumber,Address,City,State,Country,Website " +
                     " FROM  Hotels ", con);
           
        }
   
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);

        da.Fill(dt);

        ExportToExcel(dt, "Hotels", ddlGuestType.Text + " Hotel" );
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
}
