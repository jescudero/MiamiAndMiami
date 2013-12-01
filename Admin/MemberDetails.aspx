<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberDetails.aspx.cs" ValidateRequest="false" Inherits="Admin_MemberDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
       <title>Member Detail</title>
    <style type="text/css" >
    .fonttext { text-align:right;padding-right:10px;font-weight:bold; }
    td{height:23px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div style="border: 1px solid #224472; border-radius: 5px 5px 5px 5px;width:380px;height:350px;padding:10px;">
    <div style="padding:10px;font-size:16px;font-weight:bold;text-align:center"> Member Detail</div>
    <hr />
   <table >
                            <tr>
                                <td  style="height:25px;padding-left:35px;" colspan="2" >
                                    <strong>Account Details</strong>
                                   
                                </td>
                            
                            </tr>
                            <tr>
                                <td style="width:120px;text-align:right; ">
                                    Email Address &nbsp;:&nbsp;
                                </td>
                            
                                <td align="left" >
                                    <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label>
                                   
                                    
                                </td>
                            </tr>
                          
                           <tr>
                                <td style="width:120px;text-align:right; ">
                                    Registration Date &nbsp;:&nbsp;
                                </td>
                            
                                <td align="left" >
                                    <asp:Label ID="LblRegistrationDate" runat="server" Text=""></asp:Label>
                                   
                                    
                                </td>
                            </tr>
                           
                            <tr>
                                <td  colspan="2" align="left"  >
                                    <hr size="1"  style="background-color: #CCCCCC; width: 350px;" />
                                </td>
                            </tr>
                         
                            <tr>
                                <td style="width:120px;text-align:right; ">
                                    Name &nbsp;:&nbsp;
                                </td>
                              
                                <td align="left" >
                                    <asp:Label ID="LblName" runat="server" Text=""></asp:Label>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="width:120px;text-align:right; ">
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
                                <td style="width:120px;text-align:right; " >
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
                                <td style="width:120px;text-align:right; " >
                                    City/Town &nbsp;:&nbsp;
                                </td>
                              
                                <td align="left" >
                                    <asp:Label ID="LblCity" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none;"  >
                                <td style="width:120px;text-align:right; ">
                                    State/County &nbsp;:&nbsp;
                                </td>
                              
                                <td align="left" >
                                    <asp:Label ID="LblState" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none;" >
                                <td style="width:120px;text-align:right; ">
                                    Country &nbsp;:&nbsp;
                                </td>
                              
                                <td align="left"  >
                                     <asp:Label ID="LblCountry" runat="server" Text=""></asp:Label>
                                
                                </td>
                            </tr>
                            <tr style="display:none;"  >
                                <td style="width:120px;text-align:right; ">
                                    Zipcode/Postcode &nbsp;:&nbsp;
                                </td>
                                
                                <td align="left" >
                                    <asp:Label ID="LblZipcode" runat="server" Text=""></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="width:120px;text-align:right; " >
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
   
    </form>
</body>
</html>
