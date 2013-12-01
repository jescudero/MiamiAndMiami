<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlineReservation.aspx.cs" Inherits="OnlineReservation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Reservation</title>
    <link rel="stylesheet" type="text/css" href="css/styles.css" media="all" /> 
    <link rel="stylesheet" type="text/css" href="css/widgets.css" media="all" /> 
 <script type="text/javascript">
      function nameemptyP()
    {
       
        var stringEmail = document.getElementById('TxtEmail').value;
      
		 if ( document.getElementById('TxtName').value == '' )
        {
            alert('Enter your Name!')
			document.getElementById('TxtName').focus();
            return false;                
        }
				 
		else if ( document.getElementById('TxtEmail').value == '' )
        {
            alert('Enter your Email!');
			document.getElementById('TxtEmail').focus();
            return false;                
        }
      else if(!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(stringEmail)))
        {
            
            alert('Enter Valid Email Id');
            document.getElementById('TxtEmail').focus();
            return false;
        } 
        else if ( document.getElementById('TxtTelephone').value == '' )
        {
            alert('Enter phone!')
			document.getElementById('TxtTelephone').focus();
            return false;                
        }
        else if ( document.getElementById('TxtCity').value == '' )
        {
            alert('Enter Travelling City!')
			document.getElementById('TxtCity').focus();
            return false;                
        }
        else if ( document.getElementById('TxtArrival').value == '' )
        {
            alert('Select Arrival Date!')
			document.getElementById('TxtArrival').focus();
            return false;                
        }
        else if ( document.getElementById('TxtDeparture').value == '' )
        {
            alert('Select Departure Date!')
			document.getElementById('TxtDeparture').focus();
            return false;                
        }
         else if ( document.getElementById('TxtMessage').value == '' )
        {
            alert('Enter Requirements')
			document.getElementById('TxtMessage').focus();
            return false;                
        }
         else
        {
       
			  document.getElementById('HiddenField1').value=document.getElementById('TxtArrival').value;
			  document.getElementById('HiddenField2').value=document.getElementById('TxtDeparture').value;  
			                   
            return true;
        }
    }
</script>
 <link rel="stylesheet" type="text/css" media="screen" href="calendar/tcal.css" />

	<script type="text/javascript" src="calendar/tcal.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="popupform">
    <div style="padding:10px;font-size:16px;font-weight:bold;text-align:center"><asp:Label ID="LblHotelName" runat="server" Text="Online Reservation"></asp:Label></div>
    <hr />
                              <table id="ss" runat="server"  cellspacing="0" cellpadding="5" width="450">
                                  <tbody>
                                
                                    <tr valign="bottom">
                                      <td valign="top" >Name *</td>
                                      <td valign="top"> <asp:TextBox ID="TxtName" runat="server" MaxLength="50" Width="220px"></asp:TextBox></td>
                                 
                                    </tr>
                                
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td valign="top"> &nbsp;</td>
                                 
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Email Id *</td>
                                      <td valign="top"> <asp:TextBox ID="TxtEmail" runat="server"  MaxLength="50" Width="230px"></asp:TextBox></td>
                                    
                                    </tr>
                                    
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td valign="top"> &nbsp;</td>
                                    
                                    </tr>
                                    
                                    <tr valign="bottom">
                                      <td valign="top" >Travaling City</td>
                                      <td valign="top">
                                          <asp:TextBox ID="TxtCity" runat="server" MaxLength="15" Width="200px"></asp:TextBox></td>
                                  
                                    </tr>
                                    
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td valign="top">
                                          &nbsp;</td>
                                  
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Phone*</td>
                                      <td valign="top"><asp:TextBox ID="TxtTelephone" runat="server" MaxLength="15"></asp:TextBox></td>
                                      
                                    </tr>
                                    
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td valign="top">&nbsp;</td>
                                      
                                    </tr>
                                    
                                    <tr valign="bottom">
                                      <td valign="top" >Payment Type </td>
                                      <td width="312" valign="top"><label>
                                          <asp:DropDownList ID="TxtRoomType" runat="server" Width="120px">
                                              <asp:ListItem Selected="True">Cash</asp:ListItem>
                                              <asp:ListItem>Credit Card</asp:ListItem>
                                              <asp:ListItem>Debit Card</asp:ListItem>
                                              <asp:ListItem>Cheque</asp:ListItem>
                                          </asp:DropDownList>
                                      
                                      </label></td>
                                      
                                    </tr>
                                    
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td width="312" valign="top">&nbsp;</td>
                                      
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Check in Date *</td>
                                     <td valign="top">
                    <asp:TextBox ID="TxtArrival" runat="server" MaxLength="12" class="tcal" ReadOnly="true" ></asp:TextBox>
                   <asp:HiddenField ID="HiddenField1" runat="server" />
                  
                </td>
                                      
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Check Out Date *</td>
                                      <td valign="top">
                    <asp:TextBox ID="TxtDeparture" runat="server" MaxLength="12" class="tcal" ReadOnly="true" ></asp:TextBox>
                   <asp:HiddenField ID="HiddenField2" runat="server" />                  
                </td>
                                     
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td valign="top">
                                          &nbsp;</td>
                                     
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Adults</td>
                                                                            
                                      <td valign="top">
                                          <asp:TextBox ID="TxtAdult" runat="server" MaxLength="2" Width="50px"></asp:TextBox>
                                      
                                    </td>
                                      
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                                                            
                                      <td valign="top">
                                          &nbsp;</td>
                                      
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >Children</td>
                                      <td align="left" valign="top"><asp:TextBox ID="txtChildren" runat="server" 
                                              MaxLength="2" Width="51px"></asp:TextBox></td>
                                    
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td align="left" valign="top">&nbsp;</td>
                                    
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top">No. of Rooms</td>
                                      <td valign="top"><asp:TextBox ID="TextBox1" runat="server" Width="48px"></asp:TextBox></td>
                                 
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top">&nbsp;</td>
                                      <td valign="top">&nbsp;</td>
                                 
                                    </tr>
                                    <tr valign="bottom">
                                      <td width="124" valign="top" >Requirements*</td>
                                      <td valign="top"> <asp:TextBox ID="TxtMessage" runat="server" MaxLength="250" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox></td>
                                     
                                    </tr>
                                    <tr valign="bottom">
                                      <td width="124" valign="top" >&nbsp;</td>
                                      <td valign="top"> &nbsp;</td>
                                     
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td valign="top">
                                          <asp:Button ID="Button1" runat="server" Text="Book Now" CssClass="button"
                                              OnClientClick="return nameemptyP();" onclick="BtnEnquiry_Click"/>
                                      </td>
                                  
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >&nbsp;</td>
                                      <td valign="top">
                                          &nbsp;</td>
                                  
                                    </tr>
                                  </tbody>
  </table>
  
  <div id="Message" runat="server" visible="false"  >
<p style="background-color:Green;color:#ffffff;font-size:16px; text-align:center;">Thank you for sending us a request.</p>

</div>
    </div>
    </form>
</body>
</html>
