<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Hotel.aspx.cs" Inherits="Hotel" Title="Hotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="css/Paging.css" media="all" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="height:15px;"></div>
 <div class="page-title1" ><h2>Hotels</h2></div>
  
  <div style="margin-top :10px;text-align:left;padding-left:0px;min-height:350px;" >
  
 <ul class="products-grid" id="HotelList" runat="Server">
            <li class="item first">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="#" title="Nonummy nibh euismod" class="product-image"><img src="images/pic1.jpg" width="210" height="130" alt="Nonummy nibh euismod" /></a>
                        <h3 class="product-name"><a href="#" title="Nonummy nibh euismod">Miami shopping</a></h3>
                        <div class="desc">Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <button type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></button>
                        </div>
                    </div>
                </div>
            </li>
            <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="#" title="Nibh euismod" class="product-image"><img src="images/pic2.jpg" width="210" height="130" alt="Nibh euismod" /></a>
                        <h3 class="product-name"><a href="#">Miami Events</a></h3>
                        <div class="desc">Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                            <button type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></button>
                        </div>
                    </div>
                </div>
            </li>
            <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="#" title="Nibh euismod" class="product-image"><img src="images/pic3.jpg" width="210" height="130" alt="Nibh euismod" /></a>
                        <h3 class="product-name"><a href="#">Miami Fun & Leisure</a></h3>
                        <div class="desc">Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <button type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></button>
                        </div>
                    </div>
                </div>
           </li>
           <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="#" title="Nibh euismod" class="product-image"><img src="images/pic4.jpg" width="210" height="130" alt="Nibh euismod" /></a>
                        <h3 class="product-name"><a href="#">Miami Beach Restaurants</a></h3>
                        <div class="desc">Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <button type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></button>
                        </div>
                    </div>
                </div>
            </li>
           <div class="clear" style="height:10px"></div>
           <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="#" title="Nibh euismod" class="product-image"><img src="images/pic4.jpg" width="210" height="130" alt="Nibh euismod" /></a>
                        <h3 class="product-name"><a href="#">Miami Beach Restaurants</a></h3>
                        <div class="desc">Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <button type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></button>
                        </div>
                    </div>
                </div>
            </li>
           <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="#" title="Nibh euismod" class="product-image"><img src="images/pic4.jpg" width="210" height="130" alt="Nibh euismod" /></a>
                        <h3 class="product-name"><a href="#">Miami Beach Restaurants</a></h3>
                        <div class="desc">Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <button type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></button>
                        </div>
                    </div>
                </div>
            </li>
            <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="#" title="Nibh euismod" class="product-image"><img src="images/pic5.jpg" width="210" height="130" alt="Nibh euismod" /></a>
                        <h3 class="product-name"><a href="#">Vacation Rentals</a></h3>
                        <div class="desc">Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                                <button type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></button>
                        </div>
                    </div>
                </div>
            </li>
            <li class="item">
                <div class="grid_bg1">
                    <div class="grid_bg2">
                        <a href="#" title="Set nibh euismod" class="product-image"><img src="images/pic6.jpg" width="210" height="130" alt="Set nibh euismod" /></a>
                        <h3 class="product-name"><a href="#" title="Set nibh euismod">Hotels Partner in Italy</a></h3>
                        <div class="desc">Dolore magnaorem ipsum dolor</div>
                        <div class="actions">
                             <button type="button" title="View Details" class="button btn-cart" onclick="setLocation('')"><span><span>View Details</span></span></button>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
 <div id="Paging" runat ="server" > </div>
  </div> 
</asp:Content>

