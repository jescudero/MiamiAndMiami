<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" Title="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" language="javascript">
    function validdata()
    {
  

    var stringEmail = document.getElementById('ctl00_ContentPlaceHolder1_TtxEmail').value;
   
    if(document.getElementById('ctl00_ContentPlaceHolder1_TxtFName').value=="")
    {
    alert("Enter First Name");
    document.getElementById('ctl00_ContentPlaceHolder1_TxtFName').focus();
    return false;
    
    }
   else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtLastName').value=="")
    {
    alert("Enter Last Name");
    document.getElementById('ctl00_ContentPlaceHolder1_TxtLastName').focus();
    return false;
    
    }
   else if(document.getElementById('ctl00_ContentPlaceHolder1_TtxEmail').value=="")
    {
    alert("Enter Email Address");
    document.getElementById('ctl00_ContentPlaceHolder1_TtxEmail').focus();
    return false;
    
    }
     else if(!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(stringEmail)))
    {
       alert("Enter Valid Email ID");
        document.getElementById('ctl00_ContentPlaceHolder1_TtxEmail').focus();   
       return false;
    }  
    else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtPassword').value=="")
    {        
    
     alert("Enter Password");
     document.getElementById('ctl00_ContentPlaceHolder1_TxtPassword').focus();
    return false;
    }
   
    else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtConfirmPassword').value=="")
    {
     alert("Enter Confirm Password");
     document.getElementById('ctl00_ContentPlaceHolder1_TxtConfirmPassword').focus();
    return false;
    }
     else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtPassword').value != document.getElementById('ctl00_ContentPlaceHolder1_TxtConfirmPassword').value)
    {
        alert("Password Does not Match With Confirm Password");
      
      document.getElementById('ctl00_ContentPlaceHolder1_TxtConfirmPassword').focus();
      return false ;
    }
     else
    {
    return true;
    }
}
    
    </script>
    <style type="text/css">
        tr
        {
        	height:25px;
        }
        .style1
        {
            width: 120px;
        }
        .style2
        {
            width: 120px;
            height: 26px;
        }
        .style3
        {
            height: 26px;
        }
        .style4
        {
            width: 120px;
            height: 4px;
        }
        .style5
        {
            height: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="height:15px;"></div>
 <div class="page-title1" ><h2>Registration</h2></div>
  <div style="margin-top :10px;text-align:left;min-height:350px;" >

<div style="border-radius: 5px 5px 5px 5px;  margin: 0 auto;   padding: 20px; border:solid 2px #224472;">
<table ><tr><td class="style2">Name <%--<span class="star">*</span>--%>*</td>
                                            <td class="style3">
    <asp:DropDownList ID="DdlTitle" runat="server" Width="50px" TabIndex="1" >
        <asp:ListItem>Mr.</asp:ListItem>
        <asp:ListItem>Mrs.</asp:ListItem>
    </asp:DropDownList>
&nbsp;<asp:TextBox ID="TxtFName" runat="server" Width="150px" MaxLength="40" TabIndex="2" ></asp:TextBox>
<asp:TextBox ID="TxtLastName" runat="server" Width="125px" MaxLength="30" TabIndex="3" ></asp:TextBox>
&nbsp;</td>
    
  </tr>
  <tr style="height:10px;"><td class="style1">&nbsp;</td><td>
        &nbsp;</td>
    
  </tr>
  <tr><td class="style1">Gender <%--<span class="star">*</span>--%></td><td>
        <asp:DropDownList ID="DdlGender" runat="server" Width="100px" TabIndex="4" >
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
        </td>
    
  </tr>
  
   <tr><td class="style1">Mobile Number</td><td>
        <asp:TextBox ID="TxtMobileNumber" runat="server" MaxLength="15" 
            Width="150px"  TabIndex="5" ></asp:TextBox>
        </td>
    
  </tr>
  <tr style="height:10px;"><td class="style1">&nbsp;</td><td>
        &nbsp;</td>
    
  </tr>
  <tr><td class="style1">Email *</td><td>
        <asp:TextBox ID="TtxEmail" runat="server" MaxLength="70" Width="350px" TabIndex="6" ></asp:TextBox>
        </td>
    
  </tr>
  <tr style="height:10px;"><td class="style1">&nbsp;</td><td>
        &nbsp;</td>
    
  </tr>
  <tr><td class="style1">Password *</td><td>
        <asp:TextBox ID="TxtPassword" runat="server" MaxLength="30" Width="150px" 
            TextMode="Password" TabIndex="7" ></asp:TextBox>
        </td>
    
  </tr>
  <tr><td class="style1">Confirm Password *</td><td>
        <asp:TextBox ID="TxtConfirmPassword" runat="server" MaxLength="30" 
            Width="150px" TextMode="Password" TabIndex="8" ></asp:TextBox>
        </td>
    
  </tr>
  
  <tr style="height:10px;"><td class="style1">&nbsp;</td><td>
        &nbsp;</td>
    
  </tr>
    <tr><td class="style1">&nbsp;</td><td>
        <asp:Button 
            ID="btnnext" runat="server" Text="Submit" CssClass="button" 
            OnClientClick=" return validdata();" onclick="btnnext_Click" TabIndex="9"  />
        <br />
        <asp:Label ID="LblErr" runat="server" ForeColor="#FF3300" Text=""></asp:Label>
        </td>
    
  </tr>
  </table>
  </div>
</div>



</asp:Content>

