<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Where2Next._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="myCarousel" class="carousel slide">
   <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
   </ol>   

   <div class="carousel-inner">
      <div class="item active">
         <img src="/images/page1.jpg" style="height: auto; width: 100%">
      </div>
      <div class="item">
         <img src="/images/page2.jpg"style="height: auto; width: 100%">
      </div>
      <div class="item">
         <img src="/images/page3.jpg" style="height: auto; width: 100%">
      </div>
   </div>

   <a class="carousel-control left" href="#myCarousel" 
      data-slide="prev"></a>
   <a class="carousel-control right" href="#myCarousel" 
      data-slide="next"></a>
</div> 
    <br />
    <div class="row">
        <div class="col-md-4">
            <h2>Need a hand?</h2>
            <p>
                If you don't know where to begin, our guided search will help you to decide what's important.
            </p>
            <p>
                <a class="btn btn-default" href="/Quiz">Discover &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>See for yourself</h2>
            <p>
                Take a look at our map and explore Melbourne on your own
            </p>
            <p>
                <a class="btn btn-default" href="/Map">Map &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Advanced Search</h2>
            <p>
                Know exactly what you're looking for? Try the advanced search tool for full access to the data we have available.
            </p>
            <p>
                <a class="btn btn-default" href="/Search">Advanced Search &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
