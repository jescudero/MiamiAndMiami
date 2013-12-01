<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Package.aspx.cs" Inherits="Admin_Package" Title="Package" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script type="text/javascript" language="javascript">
    function validdata()
    {
  

    //var stringEmail = document.getElementById('ctl00_ContentPlaceHolder1_TtxEmail').value;
   
    if(document.getElementById('ctl00_ContentPlaceHolder1_TxtName').value=="")
    {
    alert("Enter Package Name");
    document.getElementById('ctl00_ContentPlaceHolder1_TxtName').focus();
    return false;
    
    }
   else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtShortDescription').value=="")
    {
    alert("Enter Short Description");
    document.getElementById('ctl00_ContentPlaceHolder1_TxtShortDescription').focus();
    return false;
    
    }
//     else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtAddress').value=="")
//    {        
//    
//     alert("Enter Address");
//     document.getElementById('ctl00_ContentPlaceHolder1_TxtAddress').focus();
//    return false;
//    }
//   
//    else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtCity').value=="")
//    {
//     alert("Enter City");
//     document.getElementById('ctl00_ContentPlaceHolder1_TxtCity').focus();
//    return false;
//    }
//     else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtState').value=="")
//    {        
//    
//     alert("Enter State");
//     document.getElementById('ctl00_ContentPlaceHolder1_TxtState').focus();
//    return false;
//    }
//   
//    else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtPhone').value=="")
//    {
//     alert("Enter Phone Number");
//     document.getElementById('ctl00_ContentPlaceHolder1_TxtPhone').focus();
//    return false;
//    }
//   else if(document.getElementById('ctl00_ContentPlaceHolder1_TtxEmail').value=="")
//    {
//    alert("Enter Email Address");
//    document.getElementById('ctl00_ContentPlaceHolder1_TtxEmail').focus();
//    return false;
//    
//    }
//     else if(!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(stringEmail)))
//    {
//       alert("Enter Valid Email ID");
//        document.getElementById('ctl00_ContentPlaceHolder1_TtxEmail').focus();   
//       return false;
//    }  
    else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtPricePerDay').value=="")
    {
     alert("Enter Package Price ");
     document.getElementById('ctl00_ContentPlaceHolder1_TxtPricePerDay').focus();
    return false;
    }
    else if(document.getElementById('ctl00_ContentPlaceHolder1_FCKeditor1').value == "")
    {
        alert("Enter Package Overview");
      
      document.getElementById('ctl00_ContentPlaceHolder1_FCKeditor1').focus();
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
            text-align:right;
            padding-right:10px;
            font-weight:bold;
        }
         .style13
        {
            width: 100px;
            text-align:right;
            padding-right:10px;
            font-weight:bold;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="height:15px;"></div>
 <div class="page-title1" ><h2>Package</h2></div>
  
  <div style="margin-top :10px;text-align:left;padding-left:0px; min-height:350px;" >
  
<div style="height:50px;"><div style="float:left;width:400px;padding:10px;"><asp:Label ID="LblErr" runat="server" ForeColor="#FF3300" Text=""></asp:Label></div> 
<div style="float:right;padding:10px;"><asp:Button ID="Button1" runat="server" 
        Text="Save and Add Another" CssClass="button" 
            OnClientClick=" return validdata();"  TabIndex="9" 
        onclick="BtnAnother_Click"  />&nbsp;<asp:Button ID="btnSave" runat="server" 
        Text="Save and Close" CssClass="button" 
            OnClientClick=" return validdata();"  TabIndex="9" 
        onclick="btnadd_Click"  />&nbsp; <asp:Button ID="BtnCancel" runat="server" 
        Text="Cancel" CssClass="button" 
              TabIndex="9" onclick="BtnCancel_Click"  /></div></div>

<div style="border-radius: 5px 5px 5px 5px;  margin: 0 auto; padding:10px;   border:solid 1px #000;">
<table style="width:900px;">
<tr><td colspan="2" style="padding-left:20px;padding-bottom:15px; font-size:16px;color:#224474; font-weight:bold; "> 
    Package Detail </td></tr>
<tr><td class="style1">Package Name *</td>
                                            <td class="style3" style="width:400px">
   
<asp:TextBox ID="TxtName" runat="server" Width="350px" MaxLength="70" TabIndex="1" ></asp:TextBox>
</td>
    <td rowspan="6"><img src="" id="ImgHotel" runat="server"  alt="" height="150" width="200" /></td>
  </tr>

  <tr><td class="style1">&nbsp;</td><td>
        &nbsp;</td>
    
  </tr>

  <tr><td class="style1">Short Description *</td><td>
        <asp:TextBox ID="TxtShortDescription" runat="server" Width="350px" MaxLength="250" Height="80px"  TabIndex="2" TextMode="MultiLine"  ></asp:TextBox>
        </td>
    
  </tr>
    <tr style="height:10px;"><td class="style1">&nbsp;</td><td>
        &nbsp;</td>
    
  </tr>
  <tr><td class="style13">Price ($) *</td>
  <td class="style3">
      <asp:TextBox ID="TxtPricePerDay" runat="server" Width="70px" TabIndex="3"></asp:TextBox> </td>
    
  </tr>
    <tr><td class="style13">Image </td><td>
       <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="4" /><asp:Button runat="server" ID="btnPhotoPreview" Text="Preview"  Visible="false" 
                                                onclick="btnPhotoPreview_Click" />
             
        </td>
    
  </tr>
   <tr style="height:10px;"><td class="style1" colspan="3">&nbsp;</td>
    
  </tr>
  </table>

<hr />
  
  <p  style="padding-left:20px;padding-bottom:10px;padding-top:10px; font-size:16px;color:#224474; font-weight:bold; "> Overview </p>
  <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKEditor/" Height="500px" EditorAreaCSS="../css/styles.css"  >
        </FCKeditorV2:FCKeditor>
  </div>
  
  </div>
</asp:Content>



