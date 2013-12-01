<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="HotelReview.aspx.cs" Inherits="Admin_HotelReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Hotel Reviews</title>
    <style type="text/css" >
    .fonttext
    {
    	text-align:right;padding-right:10px;font-weight:bold;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div style="border: 1px solid #224472; border-radius: 5px 5px 5px 5px;width:300px;height:250px;padding:10px;">
    <div style="padding:10px;font-size:16px;font-weight:bold;text-align:center">  <asp:Label ID="LblHotelName" runat="server" Text="Hotel Name"></asp:Label></div>
    <hr />
    <table id="ss" runat="server">
      <tr>
  <td width="100" height="30" valign="middle" class="fonttext"> Review Date </td>
  <td width="164" height="30" valign="middle" id="ReviewDate" runat="Server">
      
  </td>
</tr>
     <tr>
  <td width="100" height="30" valign="middle" class="fonttext"> Name </td>
  <td width="164" height="30" valign="middle" id="Name" runat="Server">
      
  </td>
</tr>
   
    <tr>
      <td height="30" valign="middle" class="fonttext">Email</td>
      <td height="30" valign="middle" id="Email" runat="Server"></td>
    </tr>
    <tr>
      <td height="30" valign="middle" class="fonttext">Rating</td>
      <td height="30" valign="middle"  id="Rating" runat="Server">
               
      </td>
    </tr>
    <tr>
      <td height="30" valign="middle" class="fonttext">Comment</td>
      <td height="30" valign="middle" id="Comment" runat="server" >
                
     </td>
    </tr>
  
</table>

    </div>
    </form>
   
</body>
</html>
