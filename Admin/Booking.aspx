<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Admin_Booking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Reservation</title>
 

</head>
<body>
    <form id="form1" runat="server">
    <div style="border: 1px solid #224472; border-radius: 5px 5px 5px 5px;width:440px;height:480px;padding:10px;">
    <div style="padding:10px;font-size:16px;font-weight:bold;text-align:center"><asp:Label ID="LblHotelName" runat="server" Text="Online Booking"></asp:Label></div>
    <hr />
                              <table id="ss" runat="server"  cellspacing="0" cellpadding="5" width="430">
                                  <tbody>
                                 <tr><td class="style1">Booking Date-Time </td><td id="BookingDate" runat ="server" > 
                            
                                </td>
    
  </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Name </td>
                                      <td valign="top" id="Name" runat="server" > </td>
                                 
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Email Id </td>
                                      <td valign="top" id="Email" runat="server"> </td>
                                    
                                    </tr>
                                    
                                    <tr valign="bottom">
                                      <td valign="top" >Travaling City</td>
                                      <td valign="top" id="TravalingCity" runat="server"></td>
                                  
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Phone</td>
                                      <td valign="top"  id="Phone" runat="server"></td>
                                      
                                    </tr>
                                    
                                    <tr valign="bottom">
                                      <td valign="top" >Payment Type </td>
                                      <td width="312" valign="top" id="PaymentType" runat="server"></td>
                                      
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Check in Date </td>
                                     <td valign="top"  id="CheckinDate" runat="server"> </td>
                                      
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Check Out Date </td>
                                      <td valign="top" id="CheckOutDate" runat="server"> </td>
                                     
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Adults</td>
                                                                            
                                      <td valign="top"  id="Adults" runat="server">  </td>
                                      
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Children</td>
                                      <td align="left" valign="top"  id="Children" runat="server"></td>
                                    
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top">No. of Rooms</td>
                                      <td valign="top"  id="NoofRooms" runat="server"></td>
                                 
                                    </tr>
                                    <tr valign="bottom">
                                      <td width="124" valign="top" >Requirements</td>
                                      <td valign="top" id="Requirements" runat="server"></td>
                                     
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td valign="top">
                                          
                                      </td>
                                  
                                    </tr>
                                  </tbody>
  </table>
  
  
    </div>
    </form>
</body>
</html>
