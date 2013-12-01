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
public partial class Admin_Packages : System.Web.UI.Page
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
            this.cmd = new MySqlCommand("SELECT * From Packages Where Status='De-Activate'  ", this.con);
        }
        else if (ddlGuestType.Text == "Activate")
        {
            
            LnkActivate.Visible = false;
            LnkDeactivate.Visible = true;
            Label2.Visible = false;
            this.cmd = new MySqlCommand("SELECT * From Packages Where Status='Activate'  ", this.con);
        }
        else
        {
           
            LnkDeactivate.Visible = true;
            LnkActivate.Visible = true;
            Label2.Visible = true;
            this.cmd = new MySqlCommand("SELECT * From Packages", this.con);
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
            PackageKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {
                this.cmd = new MySqlCommand("Select * from Packagephotos where PackageKey='" + PackageKey + "'  ", this.con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string ImageName = dt.Rows[i]["ImageName"].ToString();

                        if (File.Exists(Server.MapPath("../Packages/" + ImageName)) == true)
                        {

                            File.Delete(Server.MapPath("../Packages/" + ImageName));
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }

                string HotelImage = Convert.ToString(((Label)row.FindControl("lblPackageImage")).Text);
                if (HotelImage != "NoImage.jpg")
                {
                    try
                    {

                        if (File.Exists(Server.MapPath("../Packages/" + HotelImage)) == true)
                        {

                            File.Delete(Server.MapPath("../Packages/" + HotelImage));
                        }

                    }
                    catch
                    {
                    }
                }
                this.cmd = new MySqlCommand("delete from Packagephotos where PackageKey='" + PackageKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
                this.cmd = new MySqlCommand("delete from Packages where PackageKey='" + PackageKey + "' ", this.con);
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
            PackageKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("Update Packages set  Status='Activate' where PackageKey='" + PackageKey + "' ", this.con);
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
            PackageKey = Convert.ToString(((LinkButton)row.FindControl("lnkUserKey")).Text);
            if (flag)
            {

                this.cmd = new MySqlCommand("Update Packages set status='De-Activate' where PackageKey='" + PackageKey + "' ", this.con);
                this.cmd.ExecuteNonQuery();
            }
        }
        if (con.State == ConnectionState.Open) con.Close();
        this.SelectData();

    }


}
