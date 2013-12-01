<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" Title="Forgot Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   <div style="height:15px;"></div>
 <div class="page-title1" ><h2>Forgot Password</h2></div>
  
   <div style="margin-top :10px;text-align:left;padding-left:10px;min-height:350px;" >
  			
  <table style="width :500px;">
       
        
       
       <tr>
        
             <td align ="right" style ="text-align:right;width:150px;padding-right:20px">
                 Email ID
            </td> 
            <td ><asp:TextBox ID="TxtEmailId" runat="Server" MaxLength="70" Width="300px"></asp:TextBox>
               </td>
            <td >
                &nbsp;
            </td>
           </tr>
        <tr><td></td>
            <td class="style3" colspan ="2">
             <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>   &nbsp;</td>
           
        </tr>
        <tr>
        <td>
            
            </td>
            <td style ="width :297px"  >
                             <asp:Button ID="Btnok" runat="server" onclick="Btnok_Click" CssClass="button" Text="Submit"/>
                             &nbsp;
                             <asp:Button ID="BtnCancel" runat="server" onclick="BtnCancel_Click" CssClass="button"  Text="Cancel" />
                        </td>
            <td  >
                             &nbsp;</td>
            
        </tr>
    </table>



</div>
</asp:Content>

