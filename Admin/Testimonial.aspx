<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testimonial.aspx.cs" ValidateRequest="false" Inherits="Admin_Testimonial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Testimonial</title>
     <style type="text/css" >
    .fonttext
    {
    	text-align:left;padding-left:10px;font-weight:bold;
    	width:150px;
    }
    </style>
    <script type="text/javascript" language="javascript">
     function fnvalidate() {
         var stringEmail = document.getElementById('TxtEmail').value;
        if (document.getElementById('TxtFullName').value == "")
          {
              alert("Please enter Name.");
              document.getElementById('TxtFullName').focus();
              return false;
          }
          else if (document.getElementById('TxtEmail').value == "") {
              alert("Please enter Email.");
              document.getElementById('TxtEmail').focus();
              return false;

          }
          else if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(stringEmail))) {
              alert("Enter Valid Email ID");
              document.getElementById('TxtEmail').focus();
              return false;
          }
          else if (document.getElementById('TxtLocation').value == "") {
              alert("Please enter Location.");
              document.getElementById('TxtLocation').focus();
              return false;

          }
          else if (document.getElementById('TxtTestimonial').value == "") {
              alert("Text should not be empty.");
              document.getElementById('TxtTestimonial').focus();
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
    <div style="width:580px;height:320px;border: 1px solid #224472; border-radius: 5px 5px 5px 5px;">
 <div style="padding:2px;font-size:16px;font-weight:bold;text-align:center" ><h2>Testimonial</h2></div>
<hr style="width:560px;"/>
<table>
<tr><td  class="fonttext">Full Name<br /><asp:TextBox ID="TxtFullName" runat="server"></asp:TextBox></td>

<td  rowspan="3">
Testimonial<br />
<asp:TextBox ID="TxtTestimonial" runat="server" TextMode="MultiLine" Width="400px" Height="120px" ></asp:TextBox></td>


</tr>
<tr><td class="fonttext">Email<br /><asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox></td></tr>
<tr><td class="fonttext">Location<br /><asp:TextBox ID="TxtLocation" runat="server"></asp:TextBox></td></tr>
<tr><td class="fonttext" colspan="2">Image :
<asp:FileUpload id="FileUpload1" runat="server"   /></td></tr>
<tr><td style="padding-top:10px" colspan="2"><asp:Button ID="BtnOk" 
        runat="server"  CssClass="button" Text="Submit" onclick="BtnOk_Click" OnClientClick="return fnvalidate();"  ></asp:Button>    &nbsp;   
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" ></asp:Label>  </td></tr>
</table>
</div>

    </form>
</body>
</html>
