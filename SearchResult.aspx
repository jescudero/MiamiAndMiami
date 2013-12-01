<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" Title="Search Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link rel="stylesheet" type="text/css" media="screen" href="calendar/tcal.css" />

	<script type="text/javascript" src="calendar/tcal.js"></script>
	<script type="text/javascript"> 
	
	function ValidateSearchBox(){

		if(document.getElementById('ctl00_ContentPlaceHolder1_TxtDestinationCity').value=="City,State,Country"){
			document.getElementById('ctl00_ContentPlaceHolder1_TxtDestinationCity').value="";
		}
		if(document.getElementById('ctl00_ContentPlaceHolder1_TxtDestinationCity').value==""){
			alert("Please enter the keyword");
			document.getElementById('ctl00_ContentPlaceHolder1_TxtDestinationCity').focus();
			return false;
		}
		else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtArrival').value==""){
			alert("Select From Date");
			document.getElementById('ctl00_ContentPlaceHolder1_TxtArrival').focus();
			return false;
		}
		else if(document.getElementById('ctl00_ContentPlaceHolder1_TxtDeparture').value==""){
			alert("Select To Date");
			document.getElementById('ctl00_ContentPlaceHolder1_TxtDeparture').focus();
			return false;
		}
		 document.getElementById('ctl00_ContentPlaceHolder1_HiddenField1').value=document.getElementById('ctl00_ContentPlaceHolder1_TxtArrival').value;
		document.getElementById('ctl00_ContentPlaceHolder1_HiddenField2').value=document.getElementById('ctl00_ContentPlaceHolder1_TxtDeparture').value;  
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

		if(document.getElementById('ctl00_ContentPlaceHolder1_TxtSearchMiami').value=="Enter Keyword"){
			document.getElementById('ctl00_ContentPlaceHolder1_TxtSearchMiami').value="";
		}
		if(document.getElementById('ctl00_ContentPlaceHolder1_TxtSearchMiami').value==""){
			alert("Please enter the keyword");
			document.getElementById('ctl00_ContentPlaceHolder1_TxtSearchMiami').focus();
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	                    
	                <div style="height:15px;"></div>
 <div class="page-title1" ><h2>Search Result</h2></div>
  
   <div id="UserImages" runat ="server"  style="margin-top :10px;text-align:left;padding-left:10px;min-height:350px;" >
  <div class="search">
  <h3 calss="searchHead"><a href="" >Jitendra Shah</a></h3>
  <div class="desc">vccccccccccccccccccccccccccccc
  <br />vccccccccccccccccccccccccccccc<br />vccccccccccccccccccccccccccccc<br />vccccccccccccccccccccccccccccc</div>
  </div>

  </div>     
	               
	                             


</asp:Content>

