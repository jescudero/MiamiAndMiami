<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteHotelPhoto.aspx.cs" Inherits="Admin_DeleteHotelPhoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Gallery</title>
     <link rel="icon" href="images/favicon.ico" type="image/x-icon"/>
<link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon"/>
</head>
<body>
    <form id="form1" runat="server">
      <div >
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
    </form>
</body>
</html>
