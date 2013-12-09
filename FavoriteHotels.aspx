<%@ Page Title="Favorite Hotels" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FavoriteHotels.aspx.cs" Inherits="FavoriteHotels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<script type="text/javascript" src="highslide/highslide-full.js"></script>
	<link rel="stylesheet" type="text/css" href="highslide/highslide.css" />

<!--
    2) Optionally override the settings defined at the top
    of the highslide.js file. The parameter hs.graphicsDir is important!
-->

<script type="text/javascript">
    hs.graphicsDir = 'highslide/graphics/';
    hs.outlineType = 'glossy-dark';
    hs.align = 'center';
    hs.transitions = ['expand', 'crossfade'];
    hs.wrapperClassName = 'dark';
    hs.fadeInOut = true;

</script>
 <script type="text/javascript" >
     function fnFav(abc, HotelID) {
         var abcd = abc;

         if (window.XMLHttpRequest) {
             xmlhttp = new XMLHttpRequest();
         }
         else {
             xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
         }
         xmlhttp.onreadystatechange = function () {
             if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
                 window.location.reload();
             }
         }

         url = "UserFavorite.aspx?id1=" + abcd + "&HotelID=" + HotelID;
         var varconfirm = confirm("Are you sure you want to " + abcd + " this Hotel in Your Favorite List");
         if (varconfirm == true) {
             xmlhttp.open("GET", url, true);
             xmlhttp.send();
         }
         else {
             return false;
         }
         //document.getElementById("loading").style.display='block';
     }
</script>
<script type="text/javascript">


    function sb_textclear(objs, txtmsg) {
        if (objs.value == txtmsg) {
            objs.value = "";
        }
    }
    function sb_textset(objs, txtmsg) {
        if (objs.value == "") {
            objs.value = txtmsg;

        }
    }
	
	
	
</script>


<link rel="stylesheet" type="text/css" href="css/Paging.css" media="all" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="height:15px;"></div>
 <div class="page-title1" >
 <div style="float:left;width:200px; ">
 <h2>Hotels</h2>
 </div>
  <div style="float:right;text-align:right;width:650px;vertical-align:middle;padding:7px;">

<asp:TextBox ID="Txtsearch" runat="server" style="border:solid 1px #DEE3E4; border-right:0; width:175px; height:27px; line-height:23px; color:#ccc; " ForeColor="LightGray" Text="City,State,Country"   onclick="sb_textclear(this,'City,State,Country');this.style.color = 'black' " 
                        onkeyup="sb_textclear(this,'City,State,Country');this.style.color = 'black' " 
                        onblur="sb_textset(this,'City,State,Country');this.style.color = 'LightGray' "></asp:TextBox>
<asp:Button ID="BtnSer" title="Search" runat="server"  
          style="float:right;background:url(images/btn_search.gif) no-repeat; width:29px; height:29px;border:0px; padding:0; border-radius:0px;" 
          Text="" onclick="BtnSer_Click" />

    

 </div>
 </div>
  
  <div style="margin-top :10px;text-align:left;padding-left:0px;min-height:350px;" >
  
  
  <div style="font-size:14px;padding:10px;" runat="server" id="Message"></div>
 <ul class="hotel-grid" id="HotelList" runat="Server">
            <li class="item">
              
                <a href="#" title="Nonummy nibh euismod" class="hotel-image"><img src="images/pic1.jpg" width="210" height="130" alt="Nonummy nibh euismod" /></a>
                <h3 class="hotel-name"><a href="#" title="Nonummy nibh euismod">Miami shopping</a></h3>
                <div class="review"> Customer reviews 100</div>
                <div class="desc">Dolore magnaorem ipsum dolor</div>
                <div class="price-box"><h3 class="price" >200</h3>
                </div>
                  <div class="Favorite" >vvvvvvvvvv
                  </div>
                <div class="actions">
                     <a type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></a>
                      <!--<a class="button" href=""><span><span>Book now</span></span> </a>-->
                      <a class="button" href=""><span><span>Enquiry</span></span></a>
                </div>
            </li>
           
                  
        </ul>
 <div id="Paging" runat ="server" > </div>
  </div> 
</asp:Content>



