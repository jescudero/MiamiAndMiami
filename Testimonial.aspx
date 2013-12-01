<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Testimonial.aspx.cs" Inherits="Testimonial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link rel="stylesheet" type="text/css" href="css/forms.css" media="all" />
 <script type="text/javascript" language="javascript">
     function fnvalidate() {
         var stringEmail = document.getElementById('ContentPlaceHolder1_TxtEmail').value;
       if (document.getElementById('ContentPlaceHolder1_FileUpload1').value == "")
        {
              alert("Please upload Image.");
              document.getElementById('ContentPlaceHolder1_TxtFullName').focus();
              return false;
          }
         else if (document.getElementById('ContentPlaceHolder1_TxtFullName').value == "")
          {
              alert("Please enter Name.");
              document.getElementById('ContentPlaceHolder1_TxtFullName').focus();
              return false;
          }
          else if (document.getElementById('ContentPlaceHolder1_TxtEmail').value == "") {
              alert("Please enter Email.");
              document.getElementById('ContentPlaceHolder1_TxtEmail').focus();
              return false;

          }
          else if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(stringEmail))) {
              alert("Enter Valid Email ID");
              document.getElementById('ContentPlaceHolder1_TxtEmail').focus();
              return false;
          }
          else if (document.getElementById('ContentPlaceHolder1_TxtLocation').value == "") {
              alert("Please enter Location.");
              document.getElementById('ContentPlaceHolder1_TxtLocation').focus();
              return false;

          }
          else if (document.getElementById('ContentPlaceHolder1_TxtTestimonial').value == "") {
              alert("Text should not be empty.");
              document.getElementById('ContentPlaceHolder1_TxtTestimonial').focus();
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
<div class="main">
<div style="height:15px;"></div>
 <div class="page-title1" ><h2>Testimonial</h2></div>
 <div style="width:100%;padding-left:20px;margin-bottom:40px;padding-right:20px" class="main-container">
<div style="float:left;width:300px">
<table>
<tr>
<td>Image</td></tr>
<tr>


<tr><td  style="padding-left:10px"><asp:FileUpload id="FileUpload1" runat="server" 
        /></td></tr>
<tr><td  style="padding-left:10px">Full Name</td></tr>
<tr><td style="padding-bottom:10px"><asp:TextBox ID="TxtFullName" runat="server"></asp:TextBox></td></tr>
<tr><td style="padding-left:10px">Email</td></tr>
<tr><td style="padding-bottom:10px"><asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox></td></tr>
<tr><td style="padding-left:10px">Location</td></tr>
<tr><td style="padding-bottom:10px"><asp:TextBox ID="TxtLocation" runat="server"></asp:TextBox></td></tr>
</table>
</div>
<div style="float:right;margin-bottom:10px; width:500px;margin-right:20px" class="divstyle">

<table style="" align="center" >

<tr><td><asp:TextBox ID="TxtTestimonial" runat="server" TextMode="MultiLine" Width="480px" Height="180px" ></asp:TextBox></td></tr>
<tr><td style="padding-top:10px" align="right"><asp:Button ID="BtnOk" 
        runat="server"  CssClass="button" Text="Submit" onclick="BtnOk_Click" OnClientClick="return fnvalidate();"  ></asp:Button>    &nbsp;   
    <asp:Button ID="BtnCancel" runat="server"  CssClass="button" Text="Cancel" 
        onclick="BtnCancel_Click" ></asp:Button> <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" ></asp:Label>  </td></tr>
</table>
</div>

</div>

</div>
</asp:Content>

