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

/// <summary>
/// Summary description for DateSelection
/// </summary>
public class DateSelection
{
    DateTime FromDate;
    DateTime ToDate;
    string DateString;
	public DateSelection()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DateTime  FROMDATE
    {

        get { return FromDate ; }
        set { FromDate = value; }

    }

    public DateTime TODATE
    {

        get { return ToDate; }
        set { ToDate = value; }

    }

    public string  DateSTRING
    {

        get { return DateString; }
        set { DateString = value; }

    }
    public string ConvertToMonthName(int Month)
    {
        string monthNamestr = "";

        if (Month == 1)
        {
            monthNamestr = "January";
        }
        else if (Month == 2)
        {
            monthNamestr = "February";
        }
        else if (Month == 3)
        {
            monthNamestr = "March";
        }
        else if (Month == 4)
        {
            monthNamestr = "April";
        }
        else if (Month == 5)
        {
            monthNamestr = "May";
        }
        else if (Month == 6)
        {
            monthNamestr = "June";
        }
        else if (Month == 7)
        {
            monthNamestr = "July";
        }
        else if (Month == 8)
        {
            monthNamestr = "August";
        }
        else if (Month == 9)
        {
            monthNamestr = "September";
        }
        else if (Month == 10)
        {
            monthNamestr = "October";
        }
        else if (Month == 11)
        {
            monthNamestr = "November";
        }
        else
        {
            monthNamestr = "December";
        }

        return monthNamestr;
    }

    public int ConvertMonthNametoNumber(string MonthName)
    {
        int MonthNumber = 0;
        if (MonthName == "January")
        {
            MonthNumber = 1;
        }

        else if (MonthName == "February")
        {
            MonthNumber = 2;
        }
        else if (MonthName == "March")
        {
            MonthNumber = 3;
        }
        else if (MonthName == "April")
        {
            MonthNumber = 4;
        }
        else if (MonthName == "May")
        {
            MonthNumber = 5;
        }
        else if (MonthName == "June")
        {
            MonthNumber = 6;
        }
        else if (MonthName == "July")
        {
            MonthNumber = 7;
        }
        else if (MonthName == "August")
        {
            MonthNumber = 8;
        }
        else if (MonthName == "September")
        {
            MonthNumber = 9;
        }
        else if (MonthName == "October")
        {
            MonthNumber = 10;
        }
        else if (MonthName == "November")
        {
            MonthNumber = 11;
        }
        else if (MonthName == "December")
        {
            MonthNumber = 12;
        }
        return MonthNumber;
    }
    public int MaximumDayinMonth(int Month,int Year )
    {

        int MaxDay1 = 30;
        if (Month == 2)
        {

            if (Year % 4 == 0)
            {

                MaxDay1 = 29;


            }
            else
            {
                MaxDay1 = 28;

            }
        }
        else if ((Month == 4) || (Month == 6) || (Month == 9) || (Month == 11))
        {


            MaxDay1 = 30;

        }
        else
        {

            MaxDay1 = 31;

        }

        return MaxDay1;

    }

    public void DateSelectionFormat(string SelectionType)
    {
     
        DateTime Todays = DateTime.Now.AddHours(11).AddMinutes(30);
      
        if (SelectionType == "Last Month")
        {
            Todays = Todays.AddMonths(-1);

            FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + "1" + "/" + Todays.Year.ToString());
            TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + MaximumDayinMonth(Todays.Month, Todays.Year) + "/" + Todays.Year.ToString());

            DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year;
           
        }
        else if (SelectionType == "Current Month")
        {
            
            FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + "1" + "/" + Todays.Year.ToString());
            TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + MaximumDayinMonth(Todays.Month, Todays.Year) + "/" + Todays.Year.ToString());

            DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year;

        }
        else if (SelectionType == "Currrent Quarter")
        {
            int mod = Todays.Month % 3;

            
             if (mod==1)
            {
                FROMDATE = Convert.ToDateTime((Todays.Month ).ToString() + "/" + "1" + "/" + Todays.Year.ToString());
                TODATE = Convert.ToDateTime((Todays.Month + 2).ToString() + "/" + MaximumDayinMonth((Todays.Month + 2), Todays.Year) + "/" + Todays.Year.ToString());
            
            }
             else if (mod == 2)
            {
                FROMDATE = Convert.ToDateTime((Todays.Month -1).ToString() + "/" + "1" + "/" + Todays.Year.ToString());
                TODATE = Convert.ToDateTime((Todays.Month + 1).ToString() + "/" + MaximumDayinMonth((Todays.Month + 1), Todays.Year) + "/" + Todays.Year.ToString());

            }
             else{

           
                FROMDATE = Convert.ToDateTime((Todays.Month-2).ToString() + "/" + "1" + "/" + Todays.Year.ToString());
                TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + MaximumDayinMonth(Todays.Month, Todays.Year) + "/" + Todays.Year.ToString());
            
           
            }


             DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year + " - " + ConvertToMonthName(TODATE.Month) + " " + TODATE.Year;
          

        }
        else if (SelectionType == "Last Quarter")
        {

            int mod = Todays.Month % 3;


            if (mod == 1)
            {
                FROMDATE = Convert.ToDateTime((Todays.Month).ToString() + "/" + "1" + "/" + Todays.Year.ToString());
                TODATE = Convert.ToDateTime((Todays.Month + 2).ToString() + "/" + MaximumDayinMonth((Todays.Month + 2), Todays.Year) + "/" + Todays.Year.ToString());

            }
            else if (mod == 2)
            {
                FROMDATE = Convert.ToDateTime((Todays.Month - 1).ToString() + "/" + "1" + "/" + Todays.Year.ToString());
                TODATE = Convert.ToDateTime((Todays.Month + 1).ToString() + "/" + MaximumDayinMonth((Todays.Month + 1), Todays.Year) + "/" + Todays.Year.ToString());

            }
            else
            {


                FROMDATE = Convert.ToDateTime((Todays.Month - 2).ToString() + "/" + "1" + "/" + Todays.Year.ToString());
                TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + MaximumDayinMonth(Todays.Month, Todays.Year) + "/" + Todays.Year.ToString());


            }

            FROMDATE = FROMDATE.AddMonths(-3);
            TODATE = TODATE.AddMonths(-3);

            DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year + " - " + ConvertToMonthName(TODATE.Month) + " " + TODATE.Year;
          


        }
        else if (SelectionType == "Current Year")
        {

            if (Todays.Month > 3)
            {
                FROMDATE = Convert.ToDateTime("4/1/" + Todays.Year.ToString());
                TODATE = Convert.ToDateTime( "3/31/" + (Todays.Year+1).ToString());
            
            }
            else
            {

                FROMDATE = Convert.ToDateTime("4/1/" + (Todays.Year - 1).ToString());
                TODATE = Convert.ToDateTime("3/31/" + (Todays.Year ).ToString());
            
                
            }

            DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year + " - " + ConvertToMonthName(TODATE.Month) + " " + TODATE.Year;
          


        }
        else if (SelectionType == "Last Year")
        {

            if (Todays.Month > 3)
            {
                FROMDATE = Convert.ToDateTime("4/1/" + (Todays.Year - 1).ToString());
                TODATE = Convert.ToDateTime("3/31/" + (Todays.Year).ToString());

            }
            else
            {

                FROMDATE = Convert.ToDateTime("4/1/" + (Todays.Year - 2).ToString());
                TODATE = Convert.ToDateTime("3/31/" + (Todays.Year-1).ToString());


            }

            DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year + " - " + ConvertToMonthName(TODATE.Month) + " " + TODATE.Year;
          


        }
        else if (SelectionType == "Today")
        {
            FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
            TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());

           // DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year + " - " + ConvertToMonthName(TODATE.Month) + " " + TODATE.Year;
            DateSTRING = FROMDATE.Day + " " + ConvertToMonthName(FROMDATE.Month) + " " + TODATE.Year;
        }
        else if (SelectionType == "Tomorrow")
        {
            Todays = Todays.AddDays(+1);
            FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
            TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
           // DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year + " - " + ConvertToMonthName(TODATE.Month) + " " + TODATE.Year;
            DateSTRING = FROMDATE.Day + " " + ConvertToMonthName(FROMDATE.Month) + " " + TODATE.Year;
        }
        else if (SelectionType == "This Week")
        {
            string s = Todays.DayOfWeek.ToString();

            if (s == "Sunday")
            {
              
            }
            else if (s == "Monday")
            {
                FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                Todays = Todays.AddDays(5);
                TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                DateSTRING = FROMDATE.Day + " " + ConvertToMonthName(FROMDATE.Month) + " - " + TODATE.Day + " " + ConvertToMonthName(TODATE.Month);
            }
            else if (s == "Tuesday")
            {
                Todays = Todays.AddDays(-1);
                FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                Todays = DateTime.Now.AddHours(11).AddMinutes(30);
                Todays = Todays.AddDays(4);
                TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                DateSTRING = FROMDATE.Day + " " + ConvertToMonthName(FROMDATE.Month) + " - " + TODATE.Day + " " + ConvertToMonthName(TODATE.Month);
            }
            else if (s == "Wednesday")
            {
                Todays = Todays.AddDays(-2);
                FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                Todays = DateTime.Now.AddHours(11).AddMinutes(30);
                Todays = Todays.AddDays(3);
                TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                DateSTRING = FROMDATE.Day + " " + ConvertToMonthName(FROMDATE.Month) + " - " + TODATE.Day + " " + ConvertToMonthName(TODATE.Month);
            }
            else if (s == "Thursday")
            {
                Todays = Todays.AddDays(-3);
             
                FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                Todays = DateTime.Now.AddHours(11).AddMinutes(30);
                Todays = Todays.AddDays(2);
                
                TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                DateSTRING = FROMDATE.Day + " " + ConvertToMonthName(FROMDATE.Month) + " - " + TODATE.Day + " " + ConvertToMonthName(TODATE.Month);
            }
            else if (s == "Friday")
            {
                Todays = Todays.AddDays(-4);
                FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                Todays = DateTime.Now.AddHours(11).AddMinutes(30);
                Todays = Todays.AddDays(1);
                TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                DateSTRING = FROMDATE.Day + " " + ConvertToMonthName(FROMDATE.Month) + " - " + TODATE.Day + " " + ConvertToMonthName(TODATE.Month);
            }
            else if (s == "Saturday")
            {
                Todays = Todays.AddDays(-5);
                FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                Todays = DateTime.Now.AddHours(11).AddMinutes(30);
                TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + Todays.Day.ToString() + "/" + Todays.Year.ToString());
                DateSTRING = FROMDATE.Day + " " + ConvertToMonthName(FROMDATE.Month) + " - " + TODATE.Day + " " + ConvertToMonthName(TODATE.Month);
            }
        }
        else
        {
            FROMDATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + "1" + "/" + Todays.Year.ToString());
            TODATE = Convert.ToDateTime(Todays.Month.ToString() + "/" + MaximumDayinMonth(Todays.Month, Todays.Year) + "/" + Todays.Year.ToString());
            DateSTRING = ConvertToMonthName(FROMDATE.Month) + " " + FROMDATE.Year;

        }

       
    }
}
