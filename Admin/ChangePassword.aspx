<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master"  ValidateRequest="false" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" Title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type ="text/javascript" language ="javascript" >
    function ChangePasswordValidation()
{ 

 document.getElementById('ctl00_ContentPlaceHolder1_LblError').innerHTML="";
// document.getElementById('ctl00_ContentPlaceHolder1_LblCurrentPassword').innerHTML="*";
// document.getElementById('ctl00_ContentPlaceHolder1_LblNewPassword').innerHTML="*";
// document.getElementById('ctl00_ContentPlaceHolder1_LblConfirmPassword').innerHTML="*";

     
    if(document.getElementById('ctl00_ContentPlaceHolder1_TxtCurrentPassword').value=="")
    {
    document.getElementById('ctl00_ContentPlaceHolder1_TxtCurrentPassword').focus();
    document.getElementById('ctl00_ContentPlaceHolder1_LblError').innerHTML="Enter Current Password ";
     return false;
    
    }
     else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtNewPassword').value=="")
    {
    document.getElementById('ctl00_ContentPlaceHolder1_LblError').innerHTML="Enter New Password";
     document.getElementById('ctl00_ContentPlaceHolder1_TxtNewPassword').focus();
      return false;
    }
   
    else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtConfirmPassword').value=="")
    {
    document.getElementById('ctl00_ContentPlaceHolder1_LblError').innerHTML="Enter Confirm Password";
     document.getElementById('ctl00_ContentPlaceHolder1_TxtConfirmPassword').focus();
      return false;
    }
    else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtNewPassword').value != document.getElementById('ctl00_ContentPlaceHolder1_TxtConfirmPassword').value)
    {
    document.getElementById('ctl00_ContentPlaceHolder1_LblError').innerHTML="Password do not match";
     document.getElementById('ctl00_ContentPlaceHolder1_TxtConfirmPassword').focus();
      return false;
    }
    else
    {
     return true;
    }
   
    }
    
    </script>
       <style type ="text/css">
       
         td
        {
        	height :21px;
        }
    
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div style="height:15px;"></div>
 <div class="page-title1" ><h2>Change Password</h2></div>
  
  <div style="margin-top :10px;text-align:left;padding-left:10px;min-height:350px;border-radius: 5px 5px 5px 5px;border:1px solid #000;" >
  
    
		
<table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
 
  <tr>
    <td height="10" colspan="2"></td>
  </tr>
  <tr>
    <td height="20" colspan="2" ></td>
  </tr>
  <tr>
    <td  align="right"  
          style="padding-left:6px;padding-right:20px;text-align:right;"> Current Password <span>*</span> </td>
    <td width="82%"  >
        <asp:TextBox ID="TxtCurrentPassword" 
            runat="server" TextMode="Password" TabIndex="1" Width="150px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td  align="right"  style="padding-left:6px;padding-right:20px;"> 
        &nbsp;</td>
    <td  >&nbsp;</td>
  </tr>
  <tr>
    <td  align="right"   style="padding-left:6px;padding-right:20px;text-align:right;"> 
        New Password <span>*</span> </td>
    <td >
        <asp:TextBox ID="TxtNewPassword" runat="server" 
            TextMode="Password" TabIndex="2" Width="150px"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right"  style="padding-left:6px;padding-right:20px;text-align:right;"> 
        Confirm Password <span>*</span> </td>
    <td height="28" >
        <asp:TextBox ID="TxtConfirmPassword" 
            runat="server" TextMode="Password" TabIndex="3" Width="150px"></asp:TextBox></td>
  </tr>
   <tr>
    <td  align="right"   style="padding-left:6px;padding-right:20px;"> 
        &nbsp;</td>
    <td  ><asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
        &nbsp;</td>
  </tr>
    <tr>
    <td  align="right"   style="padding-left:6px;padding-right:20px;">
        &nbsp;</td>
    <td  >
        <asp:Button ID="LnkDone" runat="server" Text="Done" Width="65px" TabIndex="4"  CssClass="button" 
            onclick="LnkDone_Click" OnClientClick=" return ChangePasswordValidation(); " />
         &nbsp;
                <asp:Button ID="LnkCancel"   CssClass="button"  runat="server" Text="Cancel" Width="55px" onclick="LnkCancel_Click"  />   
      </td>
  </tr>
  
  <tr>
    <td   >&nbsp;</td>
    <td  >&nbsp;</td>
  </tr>
 
</table>

	
	   
<div class="both"></div>
</div>

</asp:Content>