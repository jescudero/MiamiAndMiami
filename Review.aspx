<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Review.aspx.cs" Inherits="Review" %>

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
      else if ( document.getElementById('TxtComment').value == '' )
        {
            alert('Enter Comment!')
			document.getElementById('TxtComment').focus();
            return false;                
        }
		 else
        {
			                   
            return true;
        }
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="border: 1px solid #224472; border-radius: 5px 5px 5px 5px;width:440px;height:330px;padding:10px;">
    <div style="padding:10px;font-size:16px;font-weight:bold;text-align:center">  <asp:Label ID="LblHotelName" runat="server" Text="Hotel Name"></asp:Label></div>
    <hr />
    <table id="ss" runat="server">
     <tr>
    <td colspan="2" class="contactusback"><strong> Fill in Your Review</strong></td>
    </tr>
  <tr>
  <td width="100" height="30" valign="middle" class="fonttext">Your Name<span class="start">*</span> </td>
  <td width="164" height="30" valign="middle">
      <asp:TextBox ID="TxtName" runat="server" TabIndex="1" MaxLength="50" Width="300px"></asp:TextBox>
  </td>
</tr>
   
    <tr>
      <td height="30" valign="middle" class="fonttext">Email<span class="start">*</span></td>
      <td height="30" valign="middle"><asp:TextBox ID="TxtEmail" runat="server" TabIndex="2" MaxLength="70" Width="300px"></asp:TextBox></td>
    </tr>
    <tr>
      <td height="30" valign="middle" class="fonttext">Rating</td>
      <td height="30" valign="middle">
          <asp:DropDownList ID="DropDownList1" runat="server" Width="50px" TabIndex="3">
              <asp:ListItem Selected="True">5</asp:ListItem>
              <asp:ListItem>4</asp:ListItem>
              <asp:ListItem>3</asp:ListItem>
              <asp:ListItem>2</asp:ListItem>
              <asp:ListItem>1</asp:ListItem>
          </asp:DropDownList>
      
      </td>
    </tr>
    <tr>
      <td height="30" valign="middle" class="fonttext">Comment<span class="start">*</span></td>
      <td height="30" valign="middle">
          <asp:TextBox ID="TxtComment" runat="server" TabIndex="4" TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
        
     </td>
    </tr>
    <tr>
      <td height="30" valign="middle">&nbsp; </td>
      <td height="30" valign="middle">
          <asp:Button ID="BtnSubmit" runat="server" Text="Submit"  TabIndex="5" 
              CssClass="button" OnClientClick="return nameemptyP();" 
              onclick="BtnSubmit_Click" />
      
     </td>
    </tr>
</table>
<div id="Message" runat="server" visible="false"  >
<p style="background-color:Green;color:#ffffff;font-size:16px; text-align:center;">Thank you for sending us a comment.</p>

</div>
    </div>
    </form>
</body>
</html>
