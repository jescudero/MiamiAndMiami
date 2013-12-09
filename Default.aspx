<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">

<head>

<title>Miami & Miami</title>


<link rel="stylesheet" type="text/css" href="css/styles.css" media="all" /> 
<link rel="stylesheet" type="text/css" href="css/widgets.css" media="all" /> 
<link rel="stylesheet" type="text/css" href="css/Paging.css" media="all" /> 
<script type="text/javascript" src="js/jquery-1.5.1.js"></script>
<script type="text/javascript" src="js/jquery.infinite-carousel.js"></script>
<script type="text/javascript" src="js/jquery.nivo.slider.js"></script>
<script type="text/javascript" charset="utf-8">

var j = jQuery.noConflict();

</script>
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
</head>



<body class="cms-index-index cms-home">
 <form id="form1" runat="server">
<div class="wrapper">
  <div class="page">

        <div class="header-container">

    <div class="header">

                <h1 class="logo"><strong>Miami & Miami</strong><a href="http://www.miamiandmiami.com/" title="Miami & Miami"><img src="images/logo.png" alt="Miami & Miami" /></a></h1>

                <div class="quick-access">

            <p class="welcome-msg"><span id="welcome" runat="server" >Welcome to our Site!</span></p>

            <!--
              <ul class="links"> 
                        <li class="first" ><asp:LinkButton ID="LinkButton1" runat="server" 
                                onclick="LinkButton1_Click" ToolTip="Miami Home">My Account</asp:LinkButton></li> 

                                 <li ><a ID="LnkPassword" runat="server" Visible="false" href="change-credentials" title="Change your Password here" >Change Password</a></li> 
                        <li id="reg" runat="server" ><a href="Register.aspx" title="Click To Register" >Register</a></li> 
                        <li class="last" ><asp:LinkButton ID="LnkLogin" runat="server" 
                                onclick="LnkLogin_Click">Log In</asp:LinkButton></li> 
            </ul> -->
        </div>

    </div>

</div>

<div class="nav-container">
    <a href="Default.aspx"class="home_link"></a>
    
    <ul id="nav">
      
       <li><a href="ListingHotel" class="level-top"> <span>VACATION RENTALS</span> </a> </li>
          <li><a href="ListingPackage"   class="level-top"> <span>DEALS</span> </a>          </li>
         <li><a href="MiamiBeachRestaurants" class="level-top"> <span>RESTAURANTS</span> </a> </li>
        <!--
        <li> <a href="Events" class="level-top"> <span>Events</span> </a> </li>
           <li> <a href="MiamiShopping" class="level-top"> <span>SHOPPING</span></a> </li>
        <li> <a href="FunandLeisure" class="level-top"> <span>Fun & Leisure </span> </a> </li>
        -->
         <li> <a href="blog/"  class="level-top" target="_blank" > <span>Blog</span> </a> </li>
    </ul>
    <div class="home_linkRight"></div>


    

</div>

        <div class="main-container col2-right-layout">
            <div class="main">                
                <div class="col-main">                    
                    <div class="bgs2"><div class="bgs1"><div class="bgs3">
	                    <div class="std">
    	                    <div class="scroller">
    	                        <div id="slider-wrapper">        
                                      <div id="slider" class="nivoSlider">
                                           <img src="images/main_pic.jpg" width="710" height="351" alt="" />
                                           <img src="images/main_pic2.jpg" width="710" height="351" alt="" />
                                           <img src="images/main_pic3.jpg" width="710" height="351" alt="" />

                                      </div>
                                </div>
                            </div>

            <script type="text/javascript">

            j(window).load(function() {

				            j('#slider').nivoSlider();

            });

            </script>

            <script type="text/javascript">

			            jQuery(document).ready(function(){

				            jQuery('#slider-stage').carousel('#previous', '#next');

				            jQuery('#viewport').carousel('#simplePrevious', '#simpleNext');  

			            });

            			

			            //The auto-scrolling function

			            function slide(){

					            j('#simpleNext').click();

			            }

			            //Launch the scroll every 2 seconds

			            var intervalId = window.setInterval(slide, 3000);			

			            //On user click deactivate auto-scrolling

			            j('#previous, #simpleNext').click(

				            function(event){

					            if(event.originalEvent){

						            window.clearInterval(intervalId);

					            }

				            }

			            );

		            </script>

<div class="scroller_bg1">

	<div class="scroller_bg2">

    <a href="javascript:void(0);" class="prev" id="simplePrevious"></a>

  <a href="javascript:void(0);" class="next" id="simpleNext"></a>

  <h2>Hotels</h2>

  <div class="scroller_place">

   <div id="viewport">

    <ul id="HotelList" runat="Server">

        <li><img src="images/slider_pic1.jpg" alt="" /><p><a href="#">Nonummy nibh euismod.</a><br />Dolore magnaorem ipsum dolor</p></li>

        <li><img src="images/slider_pic2.jpg" alt="" /><p><a href="#">Lorem nibh euismod.</a><br />Dolore magnaorem ipsum dolor</p></li>

        <li><img src="images/slider_pic3.jpg" alt="" /><p><a href="#">Euismod</a><br />Dolore magnaorem ipsum dolor</p></li>

        <li><img src="images/slider_pic4.jpg" alt="" /><p><a href="#">Nonummy nibh euismod.</a><br />Dolore magnaorem ipsum dolor</p></li>

        <li><img src="images/slider_pic5.jpg" alt="" /><p><a href="#">Lorem nibh euismod.</a><br />Dolore magnaorem ipsum dolor</p></li>

        <li><img src="images/slider_pic6.jpg" alt="" /><p><a href="#">Euismod</a><br />Dolore magnaorem ipsum dolor</p></li>

    </ul>

   </div>

  </div>

 </div>

</div>

<div><%--<div class="page-title"><h2></h2></div>--%>

       <ul class="products-grid" >
  <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="MiamiBeachRestaurants"  title="Miami Beach Restaurants" class="product-image"><img src="images/pic4.jpg" width="210" height="130" alt="Miami Beach Restaurants" /></a>
                        <h3 class="product-name"><a href="MiamiBeachRestaurants"title="Miami Beach Restaurants">Miami Beach Restaurants</a></h3>
                        <div class="desc" id="MiamiBeachRestaurants" runat="server" >Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <a type="button" title="View Details" class="button btn-cart" onclick="setLocation('')" href="MiamiBeachRestaurants"><span><span>View Details</span></span></a>
                        </div>
                    </div>
                </div>
            </li>
            <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="VacationRentals" title="Vacation Rentals" class="product-image"><img src="images/pic5.jpg" width="210" height="130" alt="Vacation Rentals" /></a>
                        <h3 class="product-name"><a href="VacationRentals" title="Vacation Rentals">Vacation Rentals</a></h3>
                        <div class="desc" id="VacationRentals" runat="server" >Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                                <a type="button" title="View Details" class="button btn-cart" onclick="setLocation('')" href="VacationRentals"><span><span>View Details</span></span></a>
                        </div>
                    </div>
                </div>
            </li>
            <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="HotelsPartner"  title="Hotels Partner" class="product-image"><img src="images/pic6.jpg" width="210" height="130" alt="Hotels Partner" /></a>
                        <h3 class="product-name"><a href="HotelsPartner" title="Hotels Partner">Hotels Partner in Italy</a></h3>
                        <div class="desc" id="HotelsPartner" runat="server"  >Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <a type="button" title="View Details" class="button btn-cart" onclick="setLocation('')" href="Index/HotelsPartner"><span><span>View Details</span></span></a>
                        </div>
                    </div>
                </div>
            </li>
           <!--
			 <div class="clear" style="height:10px"></div>
			   <li class="item first">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="MiamiShopping" title="Miami shopping" class="product-image"><img src="images/pic1.jpg" width="210" height="130" alt="Miami shopping" /></a>
                        <h3 class="product-name"><a href="MiamiShopping" title="Miami shopping">Miami shopping</a></h3>
                        <div class="desc" id="MiamiShopping" runat="server" >Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <a type="button" title="View Details" class="button btn-cart" href="MiamiShopping"><span><span>View Details</span></span></a>
                        </div>
                    </div>
                </div>
            </li>
           
            <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="Events" title="Miami Events" class="product-image"><img src="images/pic2.jpg" width="210" height="130" alt="Miami Events" /></a>
                        <h3 class="product-name"><a href="Events"  title="Miami Events">Miami Events</a></h3>
                        <div class="desc" id="Events" runat="server" >Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                            <a type="button" title="View Details" class="button btn-cart" onclick="setLocation('')" href="Events"><span><span>View Details</span></span></a>
                        </div>
                    </div>
                </div>
            </li>
            <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="FunandLeisure" title="Miami Fun & Leisure" class="product-image"><img src="images/pic3.jpg" width="210" height="130" alt="Miami Fun & Leisure" /></a>
                        <h3 class="product-name"><a href="FunandLeisure" title="Miami Fun & Leisure">Miami Fun & Leisure</a></h3>
                        <div class="desc" id="FunandLeisure" runat="server" >Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <a type="button" title="View Details" class="button btn-cart" onclick="setLocation('')" href="FunandLeisure"><span><span>View Details</span></span></a>
                        </div>
                    </div>
                </div>
           </li>-->
            </ul>

            </div></div>                    </div></div></div>

                </div>

                <div class="col-right sidebar">
<div class="block block-search">

    <div class="block-title">

        <strong><span>Search Miami</span></strong>

    </div>

    <div class="block-content">
      <div class="input-box">
          <asp:TextBox ID="TxtSearchMiami" runat="server"  class="input-text"  ForeColor="LightGray" Text="Enter Keyword"   onclick="sb_textclear(this,'Enter Keyword');this.style.color = 'black' " 
                        onkeyup="sb_textclear(this,'Enter Keyword');this.style.color = 'black' " 
                        onblur="sb_textset(this,'Enter Keyword');this.style.color = 'LightGray' "></asp:TextBox>
      </div>
        <asp:Button ID="Button1" CssClass="button" runat="server" Text="" 
            onclick="Button1_Click" OnClientClick="return ValidateSearch();" />
    
    </div>

</div>



<div class="block block-currency">

    <div class="block-content">

        <div class="block-top">

<div style="text-align:center;" align="center">
        
<script type="text/javascript">
    var dcf = 'GBP';
    var dct = 'EUR';
    var mc = '20426E';
    var mbg = 'ffffff';
    var f = 'arial';
    var fs = '11';
    var fc = '000000';
    var tf = 'arial';
    var ts = '14';
    var tc = 'ffffff';
    var tz = 'userset';

</script>
<script type="text/javascript" src="http://www.currency.me.uk/remote/ER-ERC-1.php"></script>


</div>
        </div>

    </div>

</div>

<script type="text/javascript">

//<![CDATA[

    function validatePollAnswerIsSelected() {

        var options = $$('input.poll_vote');

        for (i in options) {

            if (options[i].checked == true) {

                return true;

            }

        }

        return false;

    }

//]]>

</script>
<div class="block block-subscribe"> 
    <div class="block-title"> 
        <strong><span>Newsletter</span></strong> 
    </div> 
   
        <div class="block-content"> 
            <label for="newsletter">Sign Up for Our Newsletter:</label> 
            <div class="input-box"> 
                <asp:TextBox ID="Txtnewsletter" runat="server" title="Sign up for our newsletter"  CssClass="input-text required-entry validate-email" Text="Enter Email ID"   onclick="sb_textclear(this,'Enter Email ID');this.style.color = 'black' " 
                        onkeyup="sb_textclear(this,'Enter Email ID');this.style.color = 'black' " 
                        onblur="sb_textset(this,'Enter Email ID');this.style.color = 'LightGray' "></asp:TextBox>
       <%--        <input type="text" name="email" id="newsletter" title="Sign up for our newsletter" class="input-text required-entry validate-email" /> --%>
            </div> 
            <div class="actions"> 
            
                <a id ="A2"  title="Subscribe"  class="button" onclick="return fnsubscription(Txtnewsletter);"><span><span>Subscribe</span></span></a> 
            </div>
            <div id="txtLoad" >
            
            </div>
        </div> 

   
    
</div> 
<div class="block block-subscribe"> 
    <div class="block-title"> 
        <strong><span>Miami for Sale</span></strong> 
    </div> 
   
        <div class="block-content"> 
           
                     <div class="desc" id="MiamiSale" runat="server" >Dolore magnaorem ipsum dolor Dolore magnaorem ipsum dolorDolore magnaorem ipsum dolor Dolore magnaorem ipsum dolor</div>
        <a href="MiamiSale" class="btn-blue" style="float:right;padding-right:20px;">read more...</a>
        </div> 
    
</div> 


<div class="block block-subscribe"> 
    <div class="block-title"> 
           

    </div> 
 
        <div class="block-content"> 
         <div align="center" style="width:180px;border:1px solid #20426E; text-align:center; color:#20426E; padding:10px; padding-left:20px; font-weight:bold;margin:0px 0px 0px 0px;"><a style="font-size:14px;text-decoration:none;color:#000;" target="_blank"  href="http://www.weatherforecastmap.com/united_states/miami_beach/">Weather in Miami Beach</a><script src="http://www.weatherforecastmap.com/weather2001.php?zona=united-states_miami-beach"></script><div align="center" style="color:#20426E;font-weight:normal;"></div></div>
        </div> 
   
   
    
</div> 

<div class="block block-listofproperty"> 
    <div class="block-title"> 
         <strong >List Your property</strong>
 </div> 
 <div class="block-content" > 
            
          <a href="ListProperty.aspx?Type=Other" class="btn-blue" style="float:right;padding-right:20px;" onclick="return hs.htmlExpand( this, { objectType: 'iframe', outlineType: 'glossy-dark', wrapperClassName: 'highslide-wrapper drag-header', outlineWhileAnimating: true, preserveContent: false, width: 510 } )">
Submit Request</a>
      
         
        
 </div>
        
     
   
</div> 

<div class="block block-testimonials"> 
    <div class="block-title"> 
           <strong><span>Testimonials</span></strong>

    </div> 

        <div class="block-content"> 
         
          <div class="desc" id="testimonial" runat="server" >Dolore magnaorem ipsum dolor Dolore magnaorem ipsum dolorDolore magnaorem ipsum dolor Dolore magnaorem ipsum dolor</div>
        <a href="Testimonials" class="btn-blue" style="float:right;padding-right:20px;">read more...</a>
        </div> 
 
   
    
</div> 

<div class="block block-visit"> 
    <div class="block-title"> 
           <strong><span>Visit Miami</span></strong>

    </div> 
   
        <div class="block-content"> 
          
          <div> <a href="Miami" title="Visit Miami"></a> <img src="images/visitmiami.jpg" width="210px;" /></div>
        <div class="desc" id="VisitMiami" runat="server" >Dolore magnaorem ipsum dolor Dolore magnaorem ipsum dolorDolore magnaorem ipsum dolor Dolore magnaorem ipsum dolor</div>
        <a href="VisitMiami" class="btn-blue" style="float:right;padding-right:20px;">read more...</a>
        </div> 
    
   
    
</div> 
</div>

            </div>

        </div>

        <div class="footer-container">

    <div class="footer">

                  <ul class="links">

                <li class="first"><a href="Aboutus" title="About Us">About Us</a></li>
                <li><a href="SiteMap" title="Site Map">Site Map</a></li> 
                <li ><a href="FAQ" title="FAQ">FAQ</a></li> 
                <li><a href="TermsAndConditions" title="Terms and Conditions">Terms and Conditions</a></li>
                <li class="last" ><a href="Testimonials" title="Testimonials">Testimonials </a></li>
                <li ><a href="ContactUs" title="Contact Us">Contact Us </a></li> 
                <li ><a href="HotelsPartner" title="Hotels Partner in Italy">Hotels Partner in Italy</a></li> 
                <li ><a href="Birds" title="Bird's Nest vacation apartments">Bird's Nest vacation apartments</a></li> 
               <li><asp:LinkButton ID="LnkLoginBottom" runat="server" onclick="LnkLogin_Click">Log In</asp:LinkButton></li>
            </ul> 
        <div class="clear"></div>

        <address>&copy;Copyright 2012 Miami & Miami All rights reserved
</address>

        <div id="facbooklink"><a href="#"><img src="images/icon-1.png" /></a>&nbsp;<a href="#"><img src="images/icon-2.png" /></a></div>
    </div>

</div>

  </div>

</div>
  </form>
</body>

 <link rel="stylesheet" type="text/css" media="screen" href="calendar/tcal.css" />

	<script type="text/javascript" src="calendar/tcal.js"></script>
	<script type="text/javascript"> 
	
	function ValidateSearchBox(){
		if(document.getElementById('TxtDestinationCity').value=="City,State,Country"){
			document.getElementById('TxtDestinationCity').value="";
		}
		if(document.getElementById('TxtDestinationCity').value==""){
			alert("Please enter the keyword");
			document.getElementById('TxtDestinationCity').focus();
			return false;
		}
		else if(document.getElementById('TxtArrival').value==""){
			alert("Select From Date");
			document.getElementById('TxtArrival').focus();
			return false;
		}
		else if(document.getElementById('TxtDeparture').value==""){
			alert("Select To Date");
			document.getElementById('TxtDeparture').focus();
			return false;
		}
		 document.getElementById('HiddenField1').value=document.getElementById('TxtArrival').value;
		document.getElementById('HiddenField2').value=document.getElementById('TxtDeparture').value;  
		return true;
	}
	function sb_textclear(objs,txtmsg){
		if(objs.value == txtmsg){
			objs.value = "";
		}
	}
	function sb_textset(objs,txtmsg){
		if(objs.value == ""){
			objs.value=txtmsg;
			
		}
	}
	function ValidateSearch(){

		if(document.getElementById('TxtSearchMiami').value=="Enter Keyword"){
			document.getElementById('TxtSearchMiami').value="";
		}
		if(document.getElementById('TxtSearchMiami').value==""){
			alert("Please enter the keyword");
			document.getElementById('TxtSearchMiami').focus();
			return false;
		}
		
		return true;
	}
	</script>
<script type="text/javascript"> 
 function fnsubscription(email)
{
    
    if(email.value=="Enter Email ID")
    {
		email.value="";
	}
    var abcd=email.value;
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
            email.value="Enter Email ID";
        }
    }
    url="NewsletterSubscription.aspx?Email="+abcd ;
    

    if (email.value=="")
    {
        alert("Enter Subscribe Email");
        email.focus();
         return false;
    } 
    else if(!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(abcd)))
    {
        alert("Enter Valid Email");
        email.focus();
         return false;
    } 
    else
    {
       
        xmlhttp.open("GET",url,true);
        xmlhttp.send();
        
    }

}
	
</script>
</html>
