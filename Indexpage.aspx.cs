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

public partial class Indexpage : System.Web.UI.Page
{
    private MySqlCommand cmd;
    private MySqlConnection con;
       user obj = new user();
    String ModuleName="";
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (!IsPostBack)
        {
            loaddata();
        }
    }
    protected void loaddata()
    {

       
            string DivContant = "";
            if (con.State == ConnectionState.Closed) con.Open();
            this.cmd = new MySqlCommand("Select * from  modules where ModuleName='" + Convert.ToString(Request.QueryString["page"]) + "'", this.con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                LblHeader.Text = dr["Title"].ToString();
                this.Title = dr["Title"].ToString();
                HtmlMeta meta = new HtmlMeta();
                meta.Name = "Hotel";
                meta.Content = dr["Metatag"].ToString();
                this.Header.Controls.Add(meta);
                PageContaint.InnerHtml = dr["ModuleContent"].ToString();
                ArrayList Desh = new ArrayList();
                string Des = dr["ModuleContent"].ToString();
                char[] cc = Des.ToCharArray();

                int nn1 = cc.Length;
                string ss1 = "";
                for (int g = 0; g < nn1; g++)
                {
                    if (cc[g] == '\n')
                    {
                        if (ss1 != "")
                        {
                            Desh.Add(ss1);
                        }
                        ss1 = "";
                    }
                    else
                    {
                        ss1 = ss1 + cc[g];
                    }

                }
                if (ss1 != "")
                {
                    Desh.Add(ss1);
                }

                for (int s = 0; s < Desh.Count; s++)
                {

                    DivContant = DivContant + Convert.ToString(Desh[s]) + "<br/>";

                }

            }
            else
            {
                LblHeader.Text = "Sorry Page not found";

                PageContaint.InnerHtml = "<div align=\"center\"><div id=\"outline\">	<div id=\"errorboxoutline\"><div id=\"errorboxheader\">404 - Component not found</div> " +
                                "<div id=\"errorboxbody\"><p><strong>You may not be able to visit this page because of:</strong></p>" +
                                "<ol><li>an <strong>out-of-date bookmark/favourite</strong></li><li>a search engine that has an <strong>out-of-date listing for this site</strong></li><li>a <strong>mistyped address</strong></li>	<li>you have <strong>no access</strong> to this page</li><li>The requested resource was not found.</li>	<li>An error has occurred while processing your request.</li></ol><p><strong>Please try one of the following pages:</strong></p><p>	</p><ul>" +
                                "<li><a href=\"Default.aspx\" title=\"Go to the Home Page\">Home Page</a></li></ul><p></p><p>If difficulties persist, please contact the System Administrator of this site.</p><div id=\"techinfo\"><p>Component not found</p><p></p></div></div></div></div></div>";

            }
            dr.Close();

            if (con.State == ConnectionState.Open) con.Close(); ;
       

    }
   
}