﻿<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Packages.aspx.cs" Inherits="Admin_Packages" Title="Packages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript" >
 
function fnConfirmDeletion() {

    var ss = fnSelect();

    if (ss == false) {
        return false;
    }
    var r=confirm("Are you sure you want to delete this Packages ?");
    if (r==true)
    {
        return true;
    }
    else
    {
        return false;
    }
    
 }

 </script>
 <script type="text/javascript" language="javascript">
function checkAllBoxes(){

  //get total number of rows in the gridview and do whatever
  //you want with it..just grabbing it just cause
  var totalChkBoxes = parseInt('<%=GrdServiceProviders.Rows.Count %>');   
  var gvControl = document.getElementById('<%=GrdServiceProviders.ClientID %>');
           
  //this is the checkbox in the item template...this has to be the same name as the ID of it
  var gvChkBoxControl = "ChkPaidStatus";  
           
  //this is the checkbox in the header template
  var mainChkBox = document.getElementById("chkBoxAll");
           
  //get an array of input types in the gridview
  var inputTypes = gvControl.getElementsByTagName("input");
           
  for(var i = 0; i < inputTypes.length; i++)
  {  
     //if the input type is a checkbox and the id of it is what we set above
     //then check or uncheck according to the main checkbox in the header template            
     if(inputTypes[i].type == 'checkbox' && inputTypes[i].id.indexOf(gvChkBoxControl,0) >= 0)
          inputTypes[i].checked = mainChkBox.checked;  
  }
} 
    </script>
     <script type="text/javascript" language="javascript">
         function fnSelect() {

             var tt = 0;

             var totalChkBoxes = parseInt('<%=GrdServiceProviders.Rows.Count %>');
             var gvControl = document.getElementById('<%=GrdServiceProviders.ClientID %>');

             //this is the checkbox in the item template...this has to be the same name as the ID of it
             var gvChkBoxControl = "ChkPaidStatus";

             //this is the checkbox in the header template
             var mainChkBox = document.getElementById("chkBoxAll");

             //get an array of input types in the gridview
             var inputTypes = gvControl.getElementsByTagName("input");

             for (var i = 0; i < inputTypes.length; i++) {
                 //if the input type is a checkbox and the id of it is what we set above
                 //then check or uncheck according to the main checkbox in the header template            
                 if (inputTypes[i].type == 'checkbox' && inputTypes[i].id.indexOf(gvChkBoxControl, 0) >= 0) {
                     if (inputTypes[i].checked == true) {
                         tt = tt + 1;
                     }
                 }
             }

             if (tt == 0) {
                 alert("please select the packages");
                 return false;
             }
             else {

                 return true;

             }

         }

   

        </script>
      <link href="../css/TableandGrid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="height:15px;"></div>
 <div class="page-title1" ><h2>Packages</h2></div>
  
   <div style="margin-top :10px;text-align:left;padding-left:0px;min-height:350px;" >
  	
<asp:ScriptManager  runat="server" ID="ScriptManager1" >
</asp:ScriptManager> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate >
<div style="margin-top:20px"><table style="width:100%"><tr><td style="text-align:left;">
<a href ="Package.aspx" title="Add New Package" class="button2" >Add New Packages</a>
</td><td style="text-align:right;">
                 <label style="font-size:14px;font-weight:bold">View by:</label>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlGuestType" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlGuestType_SelectedIndexChanged" >
                     <asp:ListItem>All Packages</asp:ListItem>
                     <asp:ListItem>De-Activate</asp:ListItem>
                     <asp:ListItem>Activate</asp:ListItem>
                </asp:DropDownList></td></tr></table>
            </div>
            
<div id="Planning-tools"  style="margin-top:10px;" >
    <div id="txtLoad" class="main-table">
     <asp:GridView ID="GrdServiceProviders" runat="server"  AutoGenerateColumns="False" CssClass="GridStyle"
              AllowPaging="True" OnPageIndexChanging="GrdServiceProviders_PageIndexChanging" 
          Width="100%"  CellPadding="4" PageSize="50"     >
             <FooterStyle CssClass="GridFooterStyle" />
              <HeaderStyle CssClass="GridHeaderStyle" />
              <PagerStyle CssClass="GridPagerStyle" />
              <RowStyle CssClass="GridRowStyle" /> 
              <SelectedRowStyle CssClass="GridSelectedRowStyle"/> 
   
    <Columns>
    
     
       <asp:TemplateField HeaderText="HotelKey" Visible="False"  >
      <ItemTemplate>       
      <asp:LinkButton ID="lnkUserKey" Visible="true" runat="server" Text='<%#Eval("PackageKey")%>' CommandName="Select"></asp:LinkButton>
      </ItemTemplate>     
      </asp:TemplateField>
       <asp:TemplateField HeaderText="Status"  HeaderStyle-Width ="30px" HeaderStyle-CssClass="Space1" ItemStyle-CssClass ="Space1">
       <HeaderTemplate >
                                     <input id="chkBoxAll" type="checkbox" onClick="checkAllBoxes()" class="space1" />
                                </HeaderTemplate>
                                    <ItemTemplate >
                                        <asp:CheckBox ID="ChkPaidStatus" runat="server" CssClass="Space1" Visible="true"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
      <asp:TemplateField HeaderText="Name" Visible="true"  >
      <ItemTemplate>              
              <asp:Label ID="lblEmail" Visible="true" runat="server" Text='<%#Eval("PackageName")%>' ></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
        <asp:TemplateField HeaderText="ShortDescription" Visible="false"  >
      <ItemTemplate>              
              <asp:Label ID="lblGender" Visible="true" runat="server" Text='<%#Eval("ShortDescription")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
            
      <asp:TemplateField HeaderText="Email" Visible="false"  >
      <ItemTemplate>
              <asp:Label ID="lblBride" Visible="true" runat="server" Text='<%#Eval("EmailID")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Phone" Visible="false"  HeaderStyle-Width="100px">
      <ItemTemplate>
              <asp:Label ID="lblPhone" Visible="true" runat="server" Text='<%#Eval("PhoneNumber")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
    
        <asp:TemplateField HeaderText="Price" HeaderStyle-Width="70px">
      <ItemTemplate>
              <asp:Label ID="lblPricePerDay" Visible="true" runat="server" Text='<%#Eval("Price")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Status" HeaderStyle-Width="70px" >
      <ItemTemplate>
              <asp:Label ID="lblStatus" Visible="true" runat="server" Text='<%#Eval("Status")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Gallery" HeaderStyle-Width="70px" >
      <ItemTemplate>
              <a id ="example3" href="PackageGalleries.aspx?PackageID=<%#Eval("PackageKey")%>"  >Edit Gallary</a>            
      </ItemTemplate>     
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Action" Visible="true" HeaderStyle-Width="50px" >
      <ItemTemplate> 
      <a id ="example2" href="Package.aspx?PackageID=<%#Eval("PackageKey")%>"  >Edit</a>
             </ItemTemplate>     
      </asp:TemplateField> 
          <asp:TemplateField HeaderText="PackageImage" Visible="false"  >
      <ItemTemplate>              
              <asp:Label ID="lblPackageImage" Visible="false" runat="server" Text='<%#Eval("PackageImage")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>      
                 
      </Columns>         
      </asp:GridView>
    
        </div>
        </div> 
        <br /> 
              <div style="float:left ">
              Action [ <asp:LinkButton ID="LnkActivate" runat="server" OnClick="LnkActivate_Click" OnClientClick="return fnSelect();">Activate</asp:LinkButton> 
                            <asp:Label ID="Label2" runat="server" Text=" | "></asp:Label> 
                   <asp:LinkButton ID="LnkDeactivate" runat="server" onclick="LnkDeactivate_Click" OnClientClick="return fnSelect();" >De-activate</asp:LinkButton> 
                   &nbsp;|&nbsp; <asp:LinkButton ID="LnkDelete" runat="server"   OnClientClick ="return fnConfirmDeletion();" onclick="LnkDelete_Click">Delete</asp:LinkButton>]
                      </div>  
                  
                   </ContentTemplate >    
                       </asp:UpdatePanel>
                       </div>
</asp:Content>

