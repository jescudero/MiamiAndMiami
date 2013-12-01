using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;
using System.IO;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Class1
/// </summary>
public class PasswordEncription
{
    
     //Random random=new Random();
    

	public PasswordEncription()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //code generating random data
    public string GetPassword()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(RandomString(2, true));
        builder.Append(RandomNumber(1000, 9999));
        builder.Append(RandomString(2, false));

        return builder.ToString();
    }
    private string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }

        if (lowerCase)       
         return builder.ToString().ToLower();
        
       
        return builder.ToString();

        

    }

    private int RandomNumber(int min, int max)
    {
        
        Random random = new Random();
        return random.Next(min, max);

        
    }

    //code for encryption of password
    public string PasswordEncryption(ref string Data)
    {
        string sValue, sHex = "";
        while (Data.Length > 0)
        {

            sValue =Conversion.Hex(Strings.Asc(Data.Substring(0, 1).ToString()));
            Data = Data.Substring(1, Data.Length - 1);
            sHex = sHex + sValue;

        }

        return sHex;


    }

    //code for Decryption of password
    public string PasswordDecryption(ref string Data)
    {
        string Data1 = "", sData = "";
        while (Data.Length > 0)
        {
            Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Data.Substring(0, 2), 16)).ToString();
            sData = sData + Data1;
            Data = Data.Substring(2, Data.Length - 2);

        }

        return sData;

    }

  
}
