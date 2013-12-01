<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Members.aspx.cs" Inherits="Admin_Members" Title="Member List" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" >
 
function fnConfirmDeletion() {

    var ss = fnSelect();

    if (ss == false) {
        return false;
    }
    var r=confirm("Are you sure you want to delete this Member?");
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
                 alert("please select the Members");
                 return false;
             }
             else {

                 return true;

             }

         }

   

        </script>
      <link href="../css/TableandGrid.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="../highslide/highslide-full.js"></script>
	<link rel="stylesheet" type="text/css" href="../highslide/highslide.css" />

<!--
    2) Optionally override the settings defined at the top
    of the highslide.js file. The parameter hs.graphicsDir is important!
-->

<script type="text/javascript">
    hs.graphicsDir = '../highslide/graphics/';
    hs.outlineType = 'glossy-dark';
    hs.align = 'center';
    hs.transitions = ['expand', 'crossfade'];
    hs.wrapperClassName = 'dark';
    hs.fadeInOut = true;

</script>
<script type="text/javascript">
    function nameemptyP() {

        document.getElementById('ctl00_ContentPlaceHolder1_HiddenField1').value = document.getElementById('ctl00_ContentPlaceHolder1_Date1').value;
        document.getElementById('ctl00_ContentPlaceHolder1_HiddenField2').value = document.getElementById('ctl00_ContentPlaceHolder1_Date2').value;

    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:15px;"></div>
 <div class="page-title1" ><h2>Members</h2></div>
  
   <div style="margin-top :10px;text-align:left;padding-left:0px;min-height:350px;" >
  	<asp:Button ID="Button1" runat="server" Text="Export " class="button2" onclick="Button1_Click"/>
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ToolkitScriptManager1" /> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate >  
                <div style="margin-top:-20px"><table style="width:100%"><tr><td style="text-align:left; padding-left:80px;">

               <%--<asp:LinkButton runat="server" ID="showModalPopupServerOperatorButton" Text="Change Date"
            OnClick="showModalPopupServerOperatorButton_Click" /> &nbsp;
    <asp:Label ID="LblBookingDate" runat="server" Text="Booking Date"></asp:Label>
        <br />
        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
            BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none; background-color:#ccc;
            width: 200px; padding: 10px;border: solid 1px #446795;">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #446795;
                border: solid 1px Gray;padding:5px;margin-bottom:10px; color: Black; text-align: center;">
                Select Booking Date 
            </asp:Panel>
          
           <table>
           <tr valign="bottom" style="height:30px;">
                                      <td valign="top" >From Date *</td>
                                     <td valign="top">
                   <asp:TextBox runat="server" ID="Date1" autocomplete="off" ReadOnly="true" Width="100px" /><br />
        <ajaxToolkit:CalendarExtender ID="defaultCalendarExtender" runat="server"  TargetControlID="Date1" Format="dd-MM-yyyy"/>
                   <asp:HiddenField ID="HiddenField1" runat="server" />    
                </td>
                                      
                                    </tr>
                                    <tr valign="bottom">
                                      <td valign="top" >To Date *</td>
                                      <td valign="top">
                   <asp:TextBox runat="server" ID="Date2" autocomplete="off" ReadOnly="true" Width="100px" /><br />
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="Date2" Format="dd-MM-yyyy"  />   
         <asp:HiddenField ID="HiddenField2" runat="server" />                 
                </td>
                                     
                                    </tr>
           </table>
            <asp:LinkButton runat="server" ID="hideModalPopupViaServer" Text="Ok"
                OnClick="hideModalPopupViaServer_Click" OnClientClick="nameemptyP();"  />&nbsp;
            <asp:LinkButton runat="server" ID="LinkButton1" Text="Cancel"
                OnClick="hideModalPopupViaServer1_Click" />
          
        </asp:Panel>--%>
</td><td style="text-align:right;">

       
               <label style="font-size:14px;font-weight:bold">View by:</label>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlGuestType" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlGuestType_SelectedIndexChanged" >
                     <asp:ListItem>All Members</asp:ListItem>
                     <asp:ListItem>De-Activated</asp:ListItem>
                     <asp:ListItem>Activated</asp:ListItem>
                   
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
    
     
       <asp:TemplateField HeaderText="UserKey" Visible="False"  >
      <ItemTemplate>       
      <asp:LinkButton ID="lnkUserKey" Visible="true" runat="server" Text='<%#Eval("UserKey")%>' CommandName="Select"></asp:LinkButton>
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
              <asp:Label ID="lblEmail" Visible="true" runat="server" Text='<%#Eval("UName")%>' ></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
        <asp:TemplateField HeaderText="Gender" Visible="true"  >
      <ItemTemplate>              
              <asp:Label ID="lblGender" Visible="true" runat="server" Text='<%#Eval("Gender")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
            
      <asp:TemplateField HeaderText="User Name/Email" Visible="true"  >
      <ItemTemplate>
              <asp:Label ID="lblBride" Visible="true" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>

      
  <asp:TemplateField HeaderText="City" Visible="true"  >
      <ItemTemplate>
              <asp:Label ID="lblCity" Visible="true" runat="server" Text='<%#Eval("City")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Phone" Visible="true"  HeaderStyle-Width="100px">
      <ItemTemplate>
              <asp:Label ID="lblPhone" Visible="true" runat="server" Text='<%#Eval("Phone")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
       <asp:TemplateField HeaderText="Registration Date" Visible="false"   >
      <ItemTemplate>
              <asp:Label ID="lblRegistrationDate" Visible="true" runat="server" Text='<%#Eval("RegistrationDate","{0:dd-MMM-yyyy}" )%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" >
      <ItemTemplate>
              <asp:Label ID="lblStatus" Visible="true" runat="server" Text='<%#Eval("SS")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Action" Visible="true" HeaderStyle-Width="50px" >
      <ItemTemplate> 
      <a id ="A1" href="MemberDetails.aspx?ID=<%#Eval("UserKey")%>" onclick="return hs.htmlExpand( this, { objectType: 'iframe', outlineType: 'glossy-dark', wrapperClassName: 'highslide-wrapper drag-header', outlineWhileAnimating: true, preserveContent: false, width: 450 } )" >View</a>
  
             </ItemTemplate>     
      </asp:TemplateField> 
            
                 
      </Columns>         
      </asp:GridView>
    
        </div>
        </div> 
        <br /> 
              <div style="float:left ">
              Change Status [ <asp:LinkButton ID="LnkActivate" runat="server" OnClick="LnkActivate_Click" OnClientClick="return fnSelect();">Activate</asp:LinkButton> 
                            <asp:Label ID="Label2" runat="server" Text=" | "></asp:Label> 
                   <asp:LinkButton ID="LnkDeactivate" runat="server" onclick="LnkDeactivate_Click" OnClientClick="return fnSelect();">De-activate</asp:LinkButton> 
                   &nbsp;|&nbsp;
                  <asp:LinkButton ID="LnkDelete" runat="server" 
                      OnClientClick ="return fnConfirmDeletion();" onclick="LnkDelete_Click">Delete</asp:LinkButton> ]     
                      </div>  
                  
                   </ContentTemplate >    
                       </asp:UpdatePanel>
                       </div>
</asp:Content>

