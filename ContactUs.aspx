<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" Title="Contact Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type ="text/javascript" language ="javascript" >
        //Account Page

  
       function  fnProspectValidation()
{
    var StringEmail= document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').value;
        if(document.getElementById('ctl00_ContentPlaceHolder1_Txtsubject').value=="")
       {
            alert("Enter Subject");
            document.getElementById('ctl00_ContentPlaceHolder1_Txtsubject').focus();   
             return false;
       }
       
        else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtFirstName').value=="")
       {
            alert("Enter First Name");
            document.getElementById('ctl00_ContentPlaceHolder1_TxtFirstName').focus();
             return false;
       } 
        else if(document.getElementById('ctl00_ContentPlaceHolder1_txtLastName').value=="")
       {
        alert("Enter Last Name");

            document.getElementById('ctl00_ContentPlaceHolder1_txtLastName').focus();
             return false;
       } 
        else if(document.getElementById('ctl00_ContentPlaceHolder1_txtAddress').value=="")
       {
      alert("Enter Address");
            document.getElementById('ctl00_ContentPlaceHolder1_txtAddress').focus();
             return false;
       } 
        else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtContactNo').value=="")
       {
      alert("Enter Contact No.");
            document.getElementById('ctl00_ContentPlaceHolder1_TxtContactNo').focus();
             return false;
       } 
       
   else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').value=="")
       {
            alert("Enter Email");
            document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').focus();
             return false;
       } 
      else if(!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(StringEmail)))
       {
            alert("Enter Valid Email");
            document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').focus();
             return false;
       } 
       else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtMessage').value=="")
       {
            alert("Enter Message");
            document.getElementById('ctl00_ContentPlaceHolder1_TxtMessage').focus();
             return false;
       } 
      
       else
       {
       
             return true;
             
       }
   
}

   

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
			
 <div style="height:15px;"></div>
 <div class="page-title1" ><h2>
 
 <asp:Label ID="LblHeader" runat="server" Text="Contact Us / Enquiry Form"></asp:Label>
 </h2></div>
 <div style ="padding:15px 15px 15px 10px;" id="ContactDetail" runat="server">

</div>
         <div style ="padding:15px 15px 15px 10px;" >
          <table style ="width:100%">
          <tr><td colspan="2"  style="padding-left:30px; height:30px; padding-right:30px;">&nbsp;</td></tr>
            <tr><td colspan="2"  style=" height:30px;"><hr style="border:#ccc dashed 1px; width:100%;" />
            </td></tr>
            <tr><td colspan="2"  style="padding-left:30px; height:10px; padding-right:30px;">&nbsp;</td></tr>
              <tr>
                <td width="150">Subject: *</td>
                <td height="30">
                    <asp:TextBox ID="Txtsubject" TabIndex ="1" MaxLength ="50" Width ="250px" runat="server"></asp:TextBox>                                 </td>
              </tr>
              <tr>
                <td>First Name: *</td>
                               
                <td height="30"> <asp:TextBox ID="TxtFirstName" TabIndex ="2" MaxLength ="40" Width ="200px" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Last Name: *</td>
                <td height="30"> <asp:TextBox ID="txtLastName" TabIndex ="3" MaxLength ="30" Width ="180px" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Address: *</td>
                <td height="30"> <asp:TextBox ID="txtAddress" TabIndex ="4" MaxLength ="100" Width ="250px" runat="server"></asp:TextBox></td>
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
                <td>&nbsp;</td>
                <td>
                                       <asp:Button ID="Button1" runat="server" Text="Submit Enquiry" CssClass="button"  TabIndex ="12"
                                                          onclick="Button1_Click" OnClientClick="return fnProspectValidation();" />                               
                                       <asp:Label ID="LblError" runat="server"></asp:Label>                                 </td>
              </tr>
          </table>

   
 
</div>

</asp:Content>