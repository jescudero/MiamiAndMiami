<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Enquiry.aspx.cs" Inherits="Enquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Enquiry</title>
    <link rel="stylesheet" type="text/css" href="css/styles.css" media="all" /> 
    <link rel="stylesheet" type="text/css" href="css/widgets.css" media="all" /> 

    <style type="text/css" >
    .fonttext
    {
    	text-align:right;padding-right:10px;font-weight:bold;
    }
    </style>
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
            alert('Enter Telephone!')
			document.getElementById('TxtTelephone').focus();
            return false;                
        }
//        else if ( document.getElementById('TxtCity').value == '' )
//        {
//            alert('Enter Travelling City!')
//			document.getElementById('TxtCity').focus();
//            return false;                
//        }
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
         else if ( document.getElementById('TxtAdult').value == '' )
        {
            alert('Enter Number of Adult!')
			document.getElementById('TxtAdult').focus();
            return false;                
        }
         else if ( document.getElementById('TxtAdult').value == '0' )
        {
            alert('Enter Number of Adult!')
			document.getElementById('TxtAdult').focus();
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
    <form id="form1" runat="server" >
    <div class="popupform">
    <div style="padding:10px;font-size:16px;font-weight:bold;text-align:center">  
        <asp:Label ID="LblHotel" runat="server" Text="Hotel Name"></asp:Label>
    
    
    </div>
    <hr />
   
        <table id="ss" runat="server"  cellspacing="0" cellpadding="4">
        <tbody>
            <tr>
                <td  class="contactusback"><strong> Fill in Your Enquiry</strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td  class="contactusback">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>Your Name *</b>
                       </td>
                <td>
                       <asp:TextBox ID="TxtName" runat="server" MaxLength="50" Width="220px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                       &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>Email *</b>
                                       
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server"  MaxLength="50" Width="230px"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>Telephone *</b></td>
                <td>
             <asp:TextBox ID="TxtTelephone" runat="server" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>Date Required * </b>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Arrival -
                </td>
                <td>
                    <asp:TextBox ID="TxtArrival" runat="server" MaxLength="12" class="tcal" ReadOnly="true" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Departure - 
                </td>
                <td>
                    <asp:TextBox ID="TxtDeparture" runat="server" MaxLength="12" class="tcal"  ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>Party Details: 
                    </b></td>
                <td>
                    <b> 
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    </b>
                </td>
            </tr>
            <tr>
                <td >Adults
                    <asp:TextBox ID="TxtAdult" runat="server" MaxLength="2" Text="1" Width="50px"></asp:TextBox>
                    
                   
                    Children -
                  <asp:TextBox ID="TxtChild" runat="server" MaxLength="2" Text="0" Width="50px"></asp:TextBox>
                   
                   
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>Additional Message </b>   <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
                <td>
                                     <asp:TextBox ID="TxtMessage" runat="server" MaxLength="250" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                
                </td>
                <td>
                    <asp:Button ID="BtnEnquiry" runat="server" Text="Send Enquiry" 
                        CssClass="button" onclick="BtnEnquiry_Click" OnClientClick="return nameemptyP();"  />
                        </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
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
