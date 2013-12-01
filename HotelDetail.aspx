<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="HotelDetail.aspx.cs" Inherits="HotelDetail" Title="Hotel Detail" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	
	  	<script type="text/javascript" src="lib/jquery-1.8.2.min.js"></script>

	
	<!-- Add fancyBox main JS and CSS files -->
	<script type="text/javascript" src="source/jquery.fancybox.js?v=2.1.3"></script>
	<link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.2" media="screen" />
    <link rel="stylesheet" href="css/image-slideshow.css" type="text/css"/>
	<script type="text/javascript" src="js/image-slideshow.js">
	  
 
	
	</script>
	

	<script type="text/javascript">
		$(document).ready(function() {
			/*
			 *  Simple image gallery. Uses default settings
			 */

			$('.fancybox').fancybox();

			/*
			 *  Different effects
			 */

			

		});
	</script>
	<style type="text/css">
		.fancybox-custom .fancybox-skin {
			box-shadow: 0 0 50px #222;
		}
		
	</style>

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

 <link rel="stylesheet" type="text/css" media="screen" href="calendar/tcal.css" />

	<script type="text/javascript" src="calendar/tcal.js"></script>
	

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="height:15px;"></div>
 <div class="pagelinks" id="toppagelinks">
            
            <a href="#PriceList">Price List</a> |
            <a href="#description">Description</a> |
			<a href="#featurelist">Features</a> |
            <a href="#activitieslist">Activities</a> |
            <a href="#gallery">Gallery</a> |
            <a href="#map">Map</a> |
            <a href="#video">Video</a> |
            <a href="#reviewlist">Reviews</a> |
			<a href="#reservation-enquiry" >Enquire Now</a>
			
		</div>
 <div class="page-title1" ><h2>
     <asp:Label ID="LblHotel" runat="server" Text="Hotel"></asp:Label></h2></div>
  
  <div style="margin-top :10px;text-align:left;padding-left:0px;min-height:350px;" >
  
 <div class="HotelSortDesc" id="gallery">
 <div id="dhtmlgoodies_slideshow" class="HotelTopLeft">
	<div id="previewPane">
    <img src="" alt="" id="ImgHotel" runat="server"/>
		<%--<img src="images/images/image1_big.jpg" height="200px">--%>
		<span id="waitMessage">Loading image. Please wait</span>	
		<div id="largeImageCaption"></div>
	</div>
	<div id="galleryContainer" runat="server">
		<div id="arrow_left" ><img src="images/images/arrow_left.gif" height="70px"></div>
		<div id="arrow_right" ><img src="images/images/arrow_right.gif" height="70px"></div>
			<div id="theImages" runat="server">
				
				
				
				
				<div id="slideEnd"></div>
		</div>
	</div>
</div>

 <%-- <div class="HotelTopLeft">
  <img src="" alt="" id="ImgHotel" runat="server" />
  </div>--%>
   <div class="HotelTopRight">
   <div class="hotelrent" id="rateslist" >
       <p id="hotelrent" runat="server"></p>
   </div>
   <div class="hoteldesc" id="hoteldesc" runat="server" >
       
   </div>
<%--    <a style="float:right;" id="Review" runat="server"   class="button" onclick="return hs.htmlExpand(this, { objectType: 'iframe'  })">Write A Review</a>
--%> 
<div class="Favorite" id="Fav" runat="server" ></div> 
    <a style="float:right;" id="Review" runat="server"   class="button2" onclick="return hs.htmlExpand( this, { objectType: 'iframe', outlineType: 'glossy-dark', wrapperClassName: 'highslide-wrapper drag-header', outlineWhileAnimating: true, preserveContent: false, width: 510 } )">Write A Review</a>

  </div>
  </div>
 
     <div id="description" class="hoteloverview">
     <div class="subtitle" style="padding-left:0px;"><h2>Description</h2></div>
     <p id="overview" runat ="server">
		
	</p>
  
    </div>
     <div id="featurelist1" class="hoteloverview" runat="server" >
       <div id="featurelist" class="subtitle" style="padding-left:0px;"><h2>Facilities</h2></div>
     <p id="Facilities" runat ="server">
		
	</p>
  
    </div>
     <div id="Activitieslist1" class="hoteloverview" runat="server" >
       <div id="activitieslist" class="subtitle" style="padding-left:0px;"><h2>Activities</h2></div>
     <p id="Activities" runat ="server">
		
	</p>
  
    </div>
    
  <div id="Pricelist1" class="hoteloverview" runat="server" >
  
     <div id="PriceList" class="subtitle" style="padding-left:0px;"><h2>Price List</h2></div>
  
     <p id="P1" runat ="server"></p>

  </div> 
    </div>
     <div id="map"> 
        <cc1:GMap ID="GMap1" runat="server" Width="100%" /> 
         <br />
    </div>

    <div id="video"></div>
    <div class="HotelVideo" id="HotelVideo" runat="server" >
    
  
    </div>
    <div class="HotelGallery" id="HotelReview" runat="server" >
    <div id="reviewlist" class="subtitle" style="padding-left:0px;"><h2>Reviews</h2></div>
   <ul class="review-list" id="ReviewsList" runat="Server">
   <li class="item">
              <div style="height:27px;">
                <div class="y-name">Miami shopping</div>
                <div class="review"> Date : 10-March-2012</div>
                </div>
                <div class="desc">df
                d
                df
                fd</div>
             
            </li>
       
            
   </ul> 
  
    </div>
    <div class="Enquriy" id="Enquriy" runat="server" >
    <div id="reservation-enquiry" class="subtitle" style="padding:10px;font-size:20px;padding-left:0px;">Enquriy</div>
     <div >
		<table width="729" cellspacing="0" cellpadding="4" border="0">
        <tbody>
            <tr>
                <td width="319" >
                    <b>Your Name *</b> 
                   </td>
                 <td width="8" >
                    &nbsp;
                </td>
                <td  colspan="2">
                    <b>Date Required * </b>
                </td>
                <td width="74">
                    &nbsp;
                </td>
                <td width="103">
                </td>
                </tr>
                  <tr>
                <td width="319" >
                       <asp:TextBox ID="TxtName" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                 </td>
                 <td width="8" >
                    &nbsp;
                </td>
               <td width="64" height="28">
                    Arrival -
                </td>
                <td width="113">
                    <asp:TextBox ID="TxtArrival" runat="server" MaxLength="12" class="tcal" ReadOnly="true" ></asp:TextBox>
                 
                  
                </td>
                <td width="74">
                    Departure -
                </td>
                <td width="103">
                <asp:TextBox ID="TxtDeparture" runat="server" MaxLength="12" class="tcal"  ReadOnly="true"></asp:TextBox>
                  
                   
                </td>
             
                </tr>
                <tr><td colspan="6">&nbsp;</td></tr>
                <tr>
                <td>
                    <b>Email *</b>
                                     
                </td>
                <td width="8" >
                    &nbsp;
                </td>
                <td  colspan="2">
                    <b>Party Details: 
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    </b>
                </td>
                <td width="74">
                    &nbsp;
                </td>
                <td width="103">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server"  MaxLength="50" Width="300px"></asp:TextBox>
                   
                </td>
                <td width="8" >
                    &nbsp;
                </td>
                <td>
                    Adults - <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="TxtAdult" runat="server" MaxLength="2" Text="1" Width="50px"></asp:TextBox>
                    
                   
                </td><td>
                    Children -
                </td>
                <td>
                  <asp:TextBox ID="TxtChild" runat="server" MaxLength="2" Text="0" Width="50px"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td colspan="6">&nbsp;</td>
            </tr>
            <tr>
            <td  ><b>Telephone *</b></td>
            <td width="8" >
                    &nbsp;
                </td>
                <td  colspan="2">
                    <b>Additional Message </b> 
                </td>
                <td width="74">
                    &nbsp;
                </td>
                <td width="103">
                </td>
            </tr>
            <tr>
            <td>
             <asp:TextBox ID="TxtTelephone" runat="server" MaxLength="15"></asp:TextBox>
            </td>
            <td width="8" >
                    &nbsp;
                </td>
                 <td  colspan="4" rowspan="1">
                                     <asp:TextBox ID="TxtMessage" runat="server" MaxLength="250" TextMode="MultiLine" Width="400px" Height="80px"></asp:TextBox>

                </td>
            </tr>
            
           <%-- <tr>
                <td>
                    <b>Travelling City *</b>  
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                       
                </td>
                 <td width="8" >
                    &nbsp;
                </td>
                
            </tr>--%>
          <%--  <tr>
                <td>
                     <asp:TextBox ID="TxtCity" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                </td>
                 <td width="8" >
                    &nbsp;
                </td>
                
            </tr>--%>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Button ID="BtnEnquiry" runat="server" Text="Send Enquiry" 
                        CssClass="button" onclick="BtnEnquiry_Click" OnClientClick="return nameemptyP();"  />
                        &nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                
                </td>
            </tr>
        </tbody>
    </table>
	</div>
  
    </div>

  </div>
     	<script type="text/javascript">
      function nameemptyP()
    {
       
        var stringEmail = document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').value;
      
		 if ( document.getElementById('ctl00_ContentPlaceHolder1_TxtName').value == '' )
        {
            alert('Enter your Name!')
			document.getElementById('ctl00_ContentPlaceHolder1_TxtName').focus();
            return false;                
        }
				 
		else if ( document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').value == '' )
        {
            alert('Enter your Email!');
			document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').focus();
            return false;                
        }
      else if(!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(stringEmail)))
        {
            
            alert('Enter Valid Email Id');
            document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').focus();
            return false;
        } 
        else if ( document.getElementById('ctl00_ContentPlaceHolder1_TxtTelephone').value == '' )
        {
            alert('Enter Telephone!')
			document.getElementById('ctl00_ContentPlaceHolder1_TxtTelephone').focus();
            return false;                
        }
//        else if ( document.getElementById('ctl00_ContentPlaceHolder1_TxtCity').value == '' )
//        {
//            alert('Enter Travelling City!')
//			document.getElementById('ctl00_ContentPlaceHolder1_TxtCity').focus();
//            return false;                
//        }
        else if ( document.getElementById('ctl00_ContentPlaceHolder1_TxtArrival').value == '' )
        {
            alert('Select Arrival Date!')
			document.getElementById('ctl00_ContentPlaceHolder1_TxtArrival').focus();
            return false;                
        }
        else if ( document.getElementById('ctl00_ContentPlaceHolder1_TxtDeparture').value == '' )
        {
            alert('Select Departure Date!')
			document.getElementById('ctl00_ContentPlaceHolder1_TxtDeparture').focus();
            return false;                
        }
         else if ( document.getElementById('ctl00_ContentPlaceHolder1_TxtAdult').value == '' )
        {
            alert('Enter Number of Adult!')
			document.getElementById('ctl00_ContentPlaceHolder1_TxtAdult').focus();
            return false;                
        }
         else if ( document.getElementById('ctl00_ContentPlaceHolder1_TxtAdult').value == '0' )
        {
            alert('Enter Number of Adult!')
			document.getElementById('ctl00_ContentPlaceHolder1_TxtAdult').focus();
            return false;                
        }
		 else
        {
       
			  document.getElementById('ctl00_ContentPlaceHolder1_HiddenField1').value=document.getElementById('ctl00_ContentPlaceHolder1_TxtArrival').value;
			  document.getElementById('ctl00_ContentPlaceHolder1_HiddenField2').value=document.getElementById('ctl00_ContentPlaceHolder1_TxtDeparture').value;  
			                   
            return true;
        }
    }
</script>
</asp:Content>

