<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Package.aspx.cs" Inherits="Package" Title="Package" %>

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



 <link rel="stylesheet" type="text/css" media="screen" href="calendar/tcal.css" />

	<script type="text/javascript" src="calendar/tcal.js"></script>
	

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="height:15px;"></div>
 <div class="page-title1" ><h2>
     <asp:Label ID="LblHotel" runat="server" Text="Package"></asp:Label></h2></div>
  
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
 <%-- <div class="HotelTopLeft" >
  <img src="" alt="" id="ImgHotel" runat="server" style="width:500px;height:240px; margin :5px;border:2px solid #224467;padding:2px"/>
  </div>--%>
   <div class="HotelTopRight">
   <div class="hotelrent" id="hotelrent" runat="server" >
       
   </div>
   <div class="hoteldesc" id="hoteldesc" runat="server" >
       
   </div>
<div style="float:right;text-align:right;">
<!--<a id="BookNow" runat="server"   class="button2" onclick="return hs.htmlExpand( this, { objectType: 'iframe', outlineType: 'glossy-dark', wrapperClassName: 'highslide-wrapper drag-header', outlineWhileAnimating: true, preserveContent: false, width: 480 } )">Book Now</a>-->
<a id="Enquiry" runat="server"   class="button2" onclick="return hs.htmlExpand( this, { objectType: 'iframe', outlineType: 'glossy-dark', wrapperClassName: 'highslide-wrapper drag-header', outlineWhileAnimating: true, preserveContent: false, width: 630 } )">Enquiry</a>

</div>
  </div>
  </div>
 
     <div class="hoteloverview">
     <p id="overview" runat ="server">
		
	</p>
  
    </div>
 
    <%--<div class="HotelGallery" id="Gallery" runat="server" >
     <div class="subtitle" style="padding-left:10px;"><h2>Gallery</h2></div>
  
     <div id="UserImages" runat ="server" class="highslide-gallery">
		   
	</div>
  
    </div>--%>
    
    <div class="HotelGoogleMap" id="GoogleMap" runat="server" >
       
    </div>
    
    <div class="HotelVideo" id="Video" runat="server" >
  
  
    </div>
   

  </div>
     	
</asp:Content>

