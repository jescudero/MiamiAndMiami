<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Enquiry.aspx.cs" Inherits="Admin_Enquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enquiry</title>
    <style type="text/css">
        .style1
        {
            width: 140px;
            text-align:right;
            padding-right:10px;
            font-weight:bold ;
            height:25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div style="border: 1px solid #224472; border-radius: 5px 5px 5px 5px;width:450px;height:430px;padding:10px;">
    <div style="padding:10px;font-size:16px;font-weight:bold;text-align:center">  <asp:Label ID="LblHotelName" runat="server" Text="Enquiry"></asp:Label></div>
    <hr />
<table >
    <tr><td class="style1">Enquiry Date-Time </td><td id="EnquiryDate" runat ="server" > 
                            
                                </td>
    
  </tr>
<tr><td class="style1">Contact Person </td><td id="ContactPerson" runat ="server" > 
                            
                                </td>
    
  </tr><tr><td class="style1">Email </td><td id="Email" runat ="server" >
        
        </td>
    
  </tr>
  <tr><td class="style1">Telephone</td><td id="Telephone" runat="server">
        &nbsp;</td>
    
    
  </tr><tr><td class="style1">Travelling From </td><td id="FromCity" runat ="server">
        
        &nbsp;</td>
    
  </tr>
  <tr><td style="height:10px;">&nbsp;</td><td>
        &nbsp;</td>
    
  </tr>
  <tr><td class="style1">Arrival Date</td><td id="ArrivalDate" runat ="server">
        
        &nbsp;</td>
    
  </tr><tr><td class="style1">Departure Date</td><td id="DepartureDate" runat ="server">
        
        &nbsp;</td>
    

    
  </tr><tr><td class="style1">Adult</td><td id="Adult" runat ="server">
        
        &nbsp;</td>
    
  </tr><tr><td class="style1">Child</td><td id="Child" runat ="server">
        
        &nbsp;</td>
    
  </tr> <tr><td style="height:10px;">&nbsp;</td><td>
        &nbsp;</td>
    
  </tr><tr><td class="style1">Requirements</td><td id="Requirement" runat ="server">
        
        &nbsp;</td>
    </tr> <tr><td style="height:10px;">&nbsp;</td><td>
        &nbsp;</td>
  </tr></table>
</div>
    </form>
</body>
</html>
