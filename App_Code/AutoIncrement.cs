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
using MySql.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for AutoIncrement
/// </summary>
public class AutoIncrement
{
    MySqlConnection con;
    MySqlCommand cmd;
    Int64 large;
    public Int64 Increment(string table, string column)
    {
        large = 0;
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        cmd = new MySqlCommand("select " + column + " from " + table + " order by " + column, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            large = Convert.ToInt32(dr[column]);
        }
        dr.Close();
        if (con.State == ConnectionState.Open) con.Close();
        return (large + 1);
    }

}
