<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="NewsletterSubsribers.aspx.cs" Inherits="Admin_NewsletterSubsribers" Title="Newsletter Subsribers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script type="text/javascript" >
 
function fnConfirmDeletion()
{
    var r=confirm("Are you sure you want to delete this Newsletter subscriber?");
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
   

    <script type = "text/javascript">
    var GridId = "<%=GrdServiceProviders.ClientID %>";
    var ScrollHeight = 350;
    window.onload = function () {
        var grid = document.getElementById(GridId);
        var gridWidth = 500; //grid.offsetWidth;
        var gridHeight = 350; // grid.offsetHeight;
        var headerCellWidths = new Array();
        for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
            headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
        }
        grid.parentNode.appendChild(document.createElement("div"));
        var parentDiv = grid.parentNode;

        var table = document.createElement("table");
        for (i = 0; i < grid.attributes.length; i++) {
            if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
            }
        }
        table.style.cssText = grid.style.cssText;
        table.style.width = gridWidth + "px";
        table.appendChild(document.createElement("tbody"));
        table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
        var cells = table.getElementsByTagName("TH");

        var gridRow = grid.getElementsByTagName("TR")[0];
        for (var i = 0; i < cells.length; i++) {
            var width;
            if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                width = headerCellWidths[i];
            }
            else {
                width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                
            }
            cells[i].style.width = parseInt(width - 3) + "px";
            gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
        }
        parentDiv.removeChild(grid);

        var dummyHeader = document.createElement("div");
        dummyHeader.appendChild(table);
        parentDiv.appendChild(dummyHeader);
        var scrollableDiv = document.createElement("div");
        if (parseInt(gridHeight) > ScrollHeight) {
            gridWidth = parseInt(gridWidth) + 17;
        }
        scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px;";
        scrollableDiv.appendChild(grid);
        parentDiv.appendChild(scrollableDiv);
    }
</script>
   <script type ="text/javascript" language ="javascript" >
        //Account Page
  
       function  fnProspectValidation()
{
    
    var tt=0;
    
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
         {
            if (inputTypes[i].checked ==true)
            {
            tt=tt+1;
            } 
         } 
      }
    
        if(document.getElementById('ctl00_ContentPlaceHolder1_Txtsubject').value=="")
       {
            alert("Enter Subject");
            document.getElementById('ctl00_ContentPlaceHolder1_Txtsubject').focus();   
             return false;
       }
       else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtMessage').value=="")
       {
            alert("Enter Message");
            document.getElementById('ctl00_ContentPlaceHolder1_TxtMessage').focus();
             return false;
       } 
       else if(tt==0)
       {
            alert("Select Subscriber Email Id");
            return false;
       } 
       else
       {
       
             return true;
             
       }
   
}

   

        </script>
      <link href="../css/TableandGrid.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
<div style="height:15px;"></div>
 <div class="page-title1" ><h2>Newsletter Subscribers</h2></div>
  <div style="margin-top :10px;text-align:left;padding-left:0px" >
         

            
<div id="Planning-tools"  style="margin-top:10px;padding-left:225px; " >
    <table style ="width:500px">
          <tr><td colspan="2"  style="padding-left:30px;font-weight:bold; height:30px; padding-right:30px;">
              Send Email To Selected Newsletter Subscribers</td></tr>
            <tr><td colspan="2"  style=" height:10px;"><hr style="border:#ccc dashed 1px; width:100%;" />
            </td></tr>
               <tr>
                <td width="100px"><b>Subject:</b> *</td>
                <td height="30">
                    <asp:TextBox ID="Txtsubject" TabIndex ="1"  Width ="350px" runat="server"></asp:TextBox> </td>
              </tr>
                     
     
              <tr>
                
                <td height="30" colspan="2">
               <b> Message *</b><br/>
                <asp:TextBox ID="TxtMessage" runat="server" TabIndex="11" Width="480px" Height="150px"  TextMode="MultiLine"></asp:TextBox> </td>
              </tr>
              <tr>
                <td width="100">Email Format</td>
                <td height="30">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Plain Text</asp:ListItem>
                        <asp:ListItem>Html Format</asp:ListItem>
                    </asp:DropDownList>
                                                 </td>
              </tr>  
              
              <tr>
                <td>&nbsp;</td>
                <td>
                                       <asp:Button ID="Button1" runat="server" Text="Send Email" CssClass="button"  TabIndex ="12"
                                                          onclick="Button1_Click" OnClientClick="return fnProspectValidation();" />                               
                                       <asp:Label ID="LblError" runat="server"></asp:Label>                                 </td>
              </tr>
          </table>
          <br />
             <asp:ScriptManager  runat="server" ID="ScriptManager1" >
</asp:ScriptManager> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate >
     <asp:GridView ID="GrdServiceProviders" runat="server"   AutoGenerateColumns="False" CssClass="GridStyle"
              AllowPaging="True" OnPageIndexChanging="GrdServiceProviders_PageIndexChanging" 
          Width="500px"   CellPadding="4" PageSize="25"     >
             <FooterStyle CssClass="GridFooterStyle" />
              <HeaderStyle CssClass="GridHeaderStyle" />
              <PagerStyle CssClass="GridPagerStyle" />
              <RowStyle CssClass="GridRowStyle" /> 
              <SelectedRowStyle CssClass="GridSelectedRowStyle"/> 
   
    <Columns>
    
     <asp:TemplateField HeaderText="HotelReviewKey" Visible="False"  >
      <ItemTemplate>       
      <asp:LinkButton ID="lnkUserKey" Visible="true" runat="server" Text='<%#Eval("NewsletterKey")%>' CommandName="Select"></asp:LinkButton>
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
 
        <asp:TemplateField HeaderText="Email" >
      <ItemTemplate>              
              <asp:Label ID="lblEmail" Visible="true" runat="server" Text='<%#Eval("SubscribeEmailID")%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
            
       <asp:TemplateField HeaderText="Subscribe Date"  HeaderStyle-Width="150px" >
      <ItemTemplate>              
              <asp:Label ID="lblUploadedDate" Visible="true" runat="server" Text='<%#Eval("SubscribeDate","{0:dd-MMM-yyyy hh:mm tt}" )%>'></asp:Label>              
      </ItemTemplate>     
      </asp:TemplateField>
     
                 
      </Columns>         
      </asp:GridView>
       <div style="float:left ">
              Action [ <asp:LinkButton ID="LnkDelete" runat="server" OnClientClick ="return fnConfirmDeletion();" onclick="LnkDelete_Click">Delete</asp:LinkButton> ]
                      </div> 
    
        </div> 
                  
                  
                   </ContentTemplate >    
                       </asp:UpdatePanel>
                       </div>      
  

</asp:Content>


