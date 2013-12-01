using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class user
{
    public user()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    MySqlCommand cmd;
    MySqlConnection con;
    string sessionurl="", sessionUserKey="";
    public string loadurl()
    {


        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string path = HttpContext.Current.Request.Url.AbsolutePath;
        string host = HttpContext.Current.Request.Url.Host;

        string myString = path;

        char[] separator = new char[] { '/' };
        string[] colorList = myString.Split(separator);
        if (colorList.Length > 3)
        {
            sessionurl = colorList[3];
        }
        else
        {
            sessionurl = "";
        }
        return sessionurl;
    }

    public string loaduser()
    {

        sessionurl = loadurl();
        //sessionurl = url;
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connectionstrings1"].ConnectionString);

         if (con .State == ConnectionState.Closed) con.Open();

        cmd = new MySqlCommand("select * from Registrations where url ='" + sessionurl + "' ", con);
        MySqlDataReader drregistrations = cmd.ExecuteReader();
        if (drregistrations.HasRows)
        {
            if (drregistrations.Read())
            {
                sessionUserKey = drregistrations.GetString("UserKey").ToString();
            }
        }

        drregistrations.Close();
        if (con.State == ConnectionState.Open) con.Close(); ;
        return sessionUserKey;

    }
}
