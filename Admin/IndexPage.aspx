<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" ValidateRequest="false"  AutoEventWireup="true" CodeFile="IndexPage.aspx.cs" Inherits="Admin_IndexPage" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript" >
     function fnvalidate() {
         if (document.getElementById('ctl00_ContentPlaceHolder1_TxtPagetitle').value == "") {
             alert("Please enter page title");
             document.getElementById('ctl00_ContentPlaceHolder1_TxtPagetitle').focus();
             return false;
         }
         else if (document.getElementById('ctl00_ContentPlaceHolder1_TxtDescription').value == "") {
             alert("Please enter Sort Description");
             document.getElementById('ctl00_ContentPlaceHolder1_TxtDescription').focus();
             return false;
         }
         else if (document.getElementById('ctl00_ContentPlaceHolder1_FCKeditor1').value == "") {
             alert("Please enter " + document.getElementById('ctl00_ContentPlaceHolder1_TxtPagetitle').value);
             document.getElementById('ctl00_ContentPlaceHolder1_FCKeditor1').focus();
             return false;
         }
         else {
             return true;
         }
     }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="toolbar-box">
			<div class="m">
				<div id="toolbar" class="toolbar-list">
<ul>
<li id="toolbar-apply"  >
<asp:LinkButton class="toolbar" ID="LnkSave" runat="server" 
        OnClientClick="return fnvalidate();" onclick="LnkSave_Click">
<span class="icon-32-apply">
</span>
Save
</asp:LinkButton>
</li>

<li id="toolbar-save" >
<asp:LinkButton class="toolbar" ID="LnkSaveClose" runat="server" 
        OnClientClick="return fnvalidate();" onclick="LnkSaveClose_Click">
<span class="icon-32-save">
</span>
Save &amp; Close
</asp:LinkButton>
</li>


<li id="toolbar-cancel" >
<asp:LinkButton class="toolbar" ID="LinkButton1" runat="server" PostBackUrl="~/Admin/AdminHome.aspx" >
<span class="icon-32-cancel">
</span>
Close
</asp:LinkButton>

</li>


</ul>
<div class="clr"></div>

</div>
					<div class="pagetitle icon-48-article-add"><h2>
                        <asp:Label ID="LblArticalHeading" runat="server" Text="About Us"></asp:Label> : Edit </h2></div>
			</div>
		</div>
 <asp:Label ID="lblMessage" runat="server" ForeColor="Red" ></asp:Label>
  <div style="margin-top :10px;text-align:left;" >

  <table style="width:100%"><tr>
  <td style="width:130px;padding-left:15px;padding-right:15px;  font-weight:bold; ">Title</td>
  <td style="padding:3px 0 3px 0; "><asp:TextBox ID="TxtPagetitle" runat="server" MaxLength="50" Width="300px"></asp:TextBox></td></tr>
  <tr>
  <td style="width:130px;padding-left:15px;padding-right:15px; font-weight:bold; ">Sort Description</td>
     <td style="padding:3px 0 3px 0; "> <asp:TextBox ID="TxtDescription" runat="server" MaxLength="150" TextMode="MultiLine" Width="350px"></asp:TextBox></td></tr>
  <tr>
  <td style="width:130px;padding-left:15px;padding-right:15px;font-weight:bold; ">Meta Tag Keyword </td>
  <td style="padding:3px 0 3px 0; "><asp:TextBox ID="TxtMatatagKeword" runat="server"  MaxLength="150" TextMode="MultiLine" Width="350px"></asp:TextBox></td></tr>
  
  <tr>
  <td colspan="2" style="padding-left:15px;padding-right:15px;height:25px; ">
  &nbsp;
  </td></tr>
  <tr>
  <td colspan="2">
  <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKEditor/" Height="500px">
        </FCKeditorV2:FCKeditor>
  </td></tr>
  
  </table>
 

	    
</div> 
</asp:Content>

