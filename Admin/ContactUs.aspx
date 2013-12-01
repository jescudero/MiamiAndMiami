<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master"  ValidateRequest="false" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Admin_ContactUs" Title="Contact Us" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%--<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" >
    function fnvalidate() {
        if (document.getElementById('ctl00_ContentPlaceHolder1_FCKeditor1').value == "") {
            alert("Please enter Contact Us");
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


<div style="height:15px;"></div>
 <div class="page-title1" ><h2>Contact Us</h2></div>
  <div style="margin-top :10px;text-align:left;padding-left:0px" >
 <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKEditor/" Height="500px">
        </FCKeditorV2:FCKeditor>
<%--
<CKEditor:CKEditorControl ID="FCKeditor1" runat="server" Height="400" BasePath="~/ckeditor">
		
		</CKEditor:CKEditorControl>--%>

    <asp:Button class="button" ID="BtnUpdate" runat="server" Text="Update" onclick="BtnUpdate_Click" OnClientClick="return fnvalidate();" /> 

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" ></asp:Label>
</div> 
</asp:Content>