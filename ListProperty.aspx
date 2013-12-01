<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListProperty.aspx.cs" Inherits="ListProperty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Your Property</title>
    <link rel="stylesheet" type="text/css" href="css/styles.css" media="all" /> 
    <link rel="stylesheet" type="text/css" href="css/widgets.css" media="all" /> 
    <script type ="text/javascript" language ="javascript" >
        //Account Page


        function fnProspectValidation() {
            var StringEmail = document.getElementById('TxtEmail').value;
          

            if (document.getElementById('TxtFirstName').value == "") {
                alert("Enter First Name");
                document.getElementById('TxtFirstName').focus();
                return false;
            }
            else if (document.getElementById('txtLastName').value == "") {
                alert("Enter Last Name");

                document.getElementById('txtLastName').focus();
                return false;
            }
            else if (document.getElementById('txtHotelname').value == "") {
                alert("Enter Hotel Name");
                document.getElementById('txtHotelname').focus();
                return false;
            }
            else if (document.getElementById('TxtContactNo').value == "") {
                alert("Enter Contact No.");
                document.getElementById('TxtContactNo').focus();
                return false;
            }

            else if (document.getElementById('TxtEmail').value == "") {
                alert("Enter Email");
                document.getElementById('TxtEmail').focus();
                return false;
            }
            else if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(StringEmail))) {
                alert("Enter Valid Email");
                document.getElementById('TxtEmail').focus();
                return false;
            }
            else if (document.getElementById('TxtMessage').value == "") {
                alert("Enter Message");
                document.getElementById('TxtMessage').focus();
                return false;
            }

            else {

                return true;

            }

        }

   

        </script>
         <style type="text/css" >
    .fonttext
    {
    	text-align:right;padding-right:10px;font-weight:bold;
    }
    </style>

</head>
<body>
    <form id="form1" runat="server">
   
    <div class="popupform" >
          <table style ="width:500px;" id="ss" runat="server" >
          <tr><td colspan="2"  style="padding-left:0px; height:30px; padding-right:30px;"><strong>List Property</strong></td></tr>
            <tr><td colspan="2"  style=" height:20px;"><hr style="border:#ccc dashed 1px; width:100%;" />
            </td></tr>
           
             
              <tr>
                <td>First Name: *</td>
                               
                <td height="30"> <asp:TextBox ID="TxtFirstName" TabIndex ="2" MaxLength ="40" Width ="200px" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Last Name: *</td>
                <td height="30"> <asp:TextBox ID="txtLastName" TabIndex ="3" MaxLength ="30" Width ="180px" runat="server"></asp:TextBox></td>
              </tr>
             <tr>
                <td>Hotel Name: *</td>
                <td height="30"> <asp:TextBox ID="txtHotelname" TabIndex ="4" MaxLength ="100" Width ="250px" runat="server"></asp:TextBox></td>
              </tr>

              <tr>
                <td width="150">Hotel Url: </td>
                <td height="30">
                    <asp:TextBox ID="TxtUrl" TabIndex ="1" MaxLength ="50" Width ="250px" runat="server"></asp:TextBox>                                 </td>
              </tr>
              <tr>
                <td> Contact No: *</td>
                <td height="30"> <asp:TextBox ID="TxtContactNo" TabIndex ="5" MaxLength ="15" Width ="130px" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Email ID: *</td>
                <td height="30"> <asp:TextBox ID="TxtEmail" TabIndex ="6" MaxLength ="70" Width ="250px" runat="server"></asp:TextBox></td>
              </tr>
             
     
              <tr>
                <td height="30" style="vertical-align:top">Message: *</td>
                <td height="30">
                                       <asp:TextBox ID="TxtMessage" runat="server" TabIndex="11" Width="250px"  TextMode="MultiLine"></asp:TextBox>                               </td>
              </tr>
             
     
              <tr>
                <td height="30" style="vertical-align:top">&nbsp;</td>
                <td height="30">
                                       &nbsp;</td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td>
                                       <asp:Button ID="Button1" runat="server" Text="Submit Enquiry" CssClass="button"  TabIndex ="12"
                                                          onclick="Button1_Click" OnClientClick="return fnProspectValidation();" />                               
                                       <asp:Label ID="LblError" runat="server"></asp:Label>                                 </td>
              </tr>
          </table>

   
 <div id="Message" runat="server" visible="false"  >
<p style="background-color:Green;color:#ffffff;font-size:16px; text-align:center;">Thank you for sending us a request.</p>

</div>

    </div>


    </form>
</body>
</html>
