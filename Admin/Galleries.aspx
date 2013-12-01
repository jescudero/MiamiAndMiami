<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Galleries.aspx.cs" Inherits="Admin_Galleries" Title="Hotel : Image Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript"> 
 function fnvalidate1()
 {

     if(document.getElementById('ctl00_ContentPlaceHolder1_FileUpload1').value=="")
       {
         alert("Select an image to upload");
         document.getElementById('ctl00_ContentPlaceHolder1_FileUpload1').focus();
         return false;
        }               
       else
        {
        return true;
        }
   }
 </script>
 
 <script type="text/javascript" >
 function fnconfirm(abc,HotelID)
{
var abcd=abc;

if (window.XMLHttpRequest)
  {
  xmlhttp=new XMLHttpRequest();
  }
else
  {
  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  }
xmlhttp.onreadystatechange=function()
  {
  if (xmlhttp.readyState===4 && xmlhttp.status===200)
    {   
    document.getElementById("txtLoad").innerHTML=xmlhttp.responseText;	
    }
  }
  
url="DeleteHotelPhoto.aspx?id1="+abcd+"&HotelID="+ HotelID;
var varconfirm = confirm("Are you sure you want to Remove this photo ?");
  if(varconfirm== true )
  {
  xmlhttp.open("GET",url,true);
xmlhttp.send();
  }
  else 
  {
  return false;
  }
//document.getElementById("loading").style.display='block';
}
</script>
 <style type="text/css">


.imges{
float:left;
padding:0px;
margin:0px;
width:928px;
}
.numbers{
float:left;
margin:0px;
padding:0px;
margin-left:30px;
font-weight:bold; 
}
.ProductList Li
{
display :inline;
float:left;
margin:10px;
}

</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="height:15px;"></div>
 <div class="page-title1" ><h2>
     <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h2></div>
  
  <div style="margin-top :10px;text-align:left;padding-left:0px; min-height:350px;" >

 
      <asp:HiddenField ID="HiddenField1" runat="server" />

<div  style=" border-radius: 5px 5px 5px 5px;  padding:10px;   border:solid 1px #000; margin-top :10px;">
<table style="width:100%;">
<tr><td colspan ="2" style="height:30px;"><a style="text-decoration:none; font-size:14px;" class="btnbg" href="javascript: history.go(-1)">Back</a></td></tr>
<tr>
<td style="width:130px; text-align:right;font-weight:bold;">
Upload new image
</td>
<td class="style28">
    &nbsp;</td>
<td>
    <asp:FileUpload ID="FileUpload1" runat="server" Height="25" Width="220" />            
</td>
</tr>
<tr>
<td style ="padding-top:10px;padding-bottom:10px;text-align:right;font-weight:bold;">
Caption
</td>
<td >
    &nbsp;</td>
<td style ="padding-top:10px;padding-bottom:10px; ">
    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="250px" ></asp:TextBox>
                   
</td>
</tr>
<tr>
<td style="width:130px; text-align:right;">

</td>
<td >

    &nbsp;</td>
<td>
    <asp:Button class="button" ID="Button1" runat="server" Text="Upload" OnClientClick="return fnvalidate1();" onclick="Button1_Click" />    
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" ></asp:Label>
</td>
</tr>
</table>
</div>

 <div    id="txtLoad">

<div class="imges" style=" border-radius: 5px 5px 5px 5px; padding:10px; border:solid 1px #000; margin-top :10px;">
<h5>
    <asp:Label ID="Label1" runat="server" Text="Hotel Photos (0)"></asp:Label></h5>
    <br />
<asp:ListView ID="ListView1" runat="server">
<LayoutTemplate>
<ul class="ProductList">

<asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>

</ul>
</LayoutTemplate>
<ItemTemplate>

<li style="text-align:center ;" >
<img style=" padding:1px; margin:1px; cursor:pointer; width:100px; height:100px;  -moz-box-shadow:#999 2px 0px 5px;  -webkit-box-shadow:#999 2px 0px 5px;" src="../Hotel/<%#Eval("ImageName")%>"  alt="" />
<br />  <a id ="A2" href="#" onclick="return fnconfirm(<%#Eval("HotelPhotoKey")%>, <%#Eval("HotelKey")%>)" title="Remove" >Remove </a> </li>
</ItemTemplate>
<EmptyItemTemplate>
<div>
Sorry! No Item found found.

</div>
</EmptyItemTemplate>

</asp:ListView>

</div>

<div class="numbers">
<asp:DataPager ID="DataPager1" PageSize="35" PagedControlID="ListView1"
runat="server" onprerender="DataPager1_PreRender">
<Fields>
<asp:NumericPagerField />
</Fields>
</asp:DataPager>
</div>

</div>
</div>
</asp:Content>
