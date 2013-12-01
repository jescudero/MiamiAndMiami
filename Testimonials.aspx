<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Testimonials.aspx.cs" Inherits="Testimonials" Title="Testimonials" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="css/Paging.css" media="all" /> 
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="height:15px;"></div>
 <div class="page-title1" ><h2>Testimonials</h2></div>
  
    <div style="text-align:left;padding-left:0px;min-height:350px;" >
  

<div style="font-size:14px;padding:10px;" runat="server" id="Message"></div>

 <ul class="testimonial-list" id="HotelList" runat="Server">
           <%-- <li class="item">
              
               <div class="u-image"> <img src="images/pic1.jpg"  alt="Nonummy nibh euismod" /></div>
               <div class="test-right">
                <div class="testimonial">"eBizneeds expertise and experience in the latest technologies has provided us with an intuitive and feature rich website. I greatly appreciate eBizneeds’ professional attitude, efficient communication and excellent coordination that ensured timely completion of the project. All our queries were promptly answered and changes were incorporated immediately. eBizneeds has played an instrumental role in helping us realize our vision.
                        With eBizneeds I am confident that my project is in capable hands and will happily recommend them to anyone looking for high standard solutions."</div>
                <h3 class="u-name">Jitendra Shah</h3>
                <div class="location"> Jaipur,Rajasthan </div>
                </div>
                </li>
        <div class="clear" style="height:5px;border-bottom:1px solid #ccc;" ></div>--%>
                  
        </ul>
 <div id="Paging" runat ="server" style="text-align:right ;float:right;" > </div>
  </div> 
</asp:Content>

