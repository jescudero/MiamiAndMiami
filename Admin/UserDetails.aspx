<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="Admin_UserDetails" Title="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css"  >td{height:23px;}</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:15px;"></div>
 <div class="page-title1" ><h2>User Detail</h2></div>
  
   <div style="margin-top :10px;text-align:left;padding-left:10px;min-height:350px; border-radius: 5px 5px 5px 5px;border:1px solid #000;" >
  
<table >
                            <tr>
                                <td  style="height:25px;padding-left:35px;" colspan="2" >
                                    <strong>Account Details</strong>
                                   
                                </td>
                            
                            </tr>
                            <tr>
                                <td style="width:150px;text-align:right; ">
                                    Email Address &nbsp;:&nbsp;
                                </td>
                            
                                <td align="left" >
                                    <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label>
                                   
                                    
                                </td>
                            </tr>
                          
                           <tr>
                                <td style="width:150px;text-align:right; ">
                                    Registration Date &nbsp;:&nbsp;
                                </td>
                            
                                <td align="left" >
                                    <asp:Label ID="LblRegistrationDate" runat="server" Text=""></asp:Label>
                                   
                                    
                                </td>
                            </tr>
                           
                            <tr>
                                <td  colspan="2" align="left"  >
                                    <hr size="1"  style="background-color: #CCCCCC; width: 400px;" />
                                </td>
                            </tr>
                         
                            <tr>
                                <td style="width:150px;text-align:right; ">
                                    Name &nbsp;:&nbsp;
                                </td>
                              
                                <td align="left" >
                                    <asp:Label ID="LblName" runat="server" Text=""></asp:Label>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px;text-align:right; ">
                                    Gender &nbsp;:&nbsp;
                                </td>
                                <td align="left" >
                                     <asp:Label ID="LblGender" runat="server" Text=""></asp:Label>
                                    
                                </td>
                            </tr>
                                                     
                          
                           <tr style="display:none;" >
                                <td height="5" colspan="2" align="left"  >
                                    <hr size="1" class="style4" style="background-color: #CCCCCC; width: 400px;" />
                                </td>
                            </tr>
                            <tr style="display:none;" >
                                <td style="height:25px;padding-left:35px;" colspan="2" >
                                    <strong>Address Details</strong>
                                </td>
                              
                               
                            </tr>
                            <tr  style="display:none;" >
                                <td style="width:150px;text-align:right; " >
                                    Address &nbsp;:&nbsp;
                                </td>
                               
                                <td align="left" >
                                  <asp:Label ID="LblAddress" runat="server" Text=""></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr style="display:none;"  >
                                <td height="5" style="width:150px;text-align:right; " >
                                    &nbsp;
                                </td>
                               
                                <td  align="left" >
                                <asp:Label ID="LblAddress2" runat="server" Text=""></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr style="display:none;"  >
                                <td style="width:150px;text-align:right; " >
                                    City/Town &nbsp;:&nbsp;
                                </td>
                              
                                <td align="left" >
                                    <asp:Label ID="LblCity" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none;"  >
                                <td style="width:150px;text-align:right; ">
                                    State/County &nbsp;:&nbsp;
                                </td>
                              
                                <td align="left" >
                                    <asp:Label ID="LblState" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none;" >
                                <td style="width:150px;text-align:right; ">
                                    Country &nbsp;:&nbsp;
                                </td>
                              
                                <td align="left"  >
                                     <asp:Label ID="LblCountry" runat="server" Text=""></asp:Label>
                                
                                </td>
                            </tr>
                            <tr style="display:none;"  >
                                <td style="width:150px;text-align:right; ">
                                    Zipcode/Postcode &nbsp;:&nbsp;
                                </td>
                                
                                <td align="left" >
                                    <asp:Label ID="LblZipcode" runat="server" Text=""></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px;text-align:right; " >
                                    Phone &nbsp;:&nbsp;
                                </td>
                               
                                <td align="left"  >
                                  <asp:Label ID="LblPhone" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                         
                            
                            <tr>
                                <td align="right" >
                                    &nbsp;</td>
                               
                                <td align="left"  >
                                    &nbsp;</td>
                            </tr>
                         
                            
                        </table>
  </div>

 
                    
                 
                  
</asp:Content>

