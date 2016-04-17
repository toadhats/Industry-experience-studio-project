<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Where2Next.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />
    <br />
       <link href="http://libs.baidu.com/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet">
   <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js"></script>
   <script src="http://libs.baidu.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" 
   aria-labelledby="myModalLabel" aria-hidden="true" style="position:absolute;top:50%;height: 240px;margin-top: -120px;">
   <div class="modal-dialog">
      <div class="modal-content">
         <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal"  aria-hidden="true">
            </button>
         </div>
         <div class="modal-body">
            Thanks for voting.
         </div>
         <div class="modal-footer">
            <button type="button" class="btn btn-default" 
               data-dismiss="modal">
               Close
            </button>
         </div>
      </div>
   </div>
</div>
<div class="row">
   <div class="col-sm-6 col-md-3">
      <div class="thumbnail">
         <img src="/Images/caulfield.jpg" 
         alt="">
         <div class="caption">
            <h3>Caulfield</h3>
            <p>Caulfield is a suburb of Melbourne, Victoria, Australia, 12 kilometres (7.5 mi) south-east of Melbourne's central business district. </p>
            <p>
               <a href="https://en.wikipedia.org/wiki/Caulfield,_Victoria" class="btn btn-primary" role="button">
                  More details
               </a> 
               <a href="#" class="btn btn-default" role="button"  data-toggle="modal" data-target="#myModal" >
                 Like ♡
               </a>
            </p>
         </div>
      </div>
   </div>
   <div class="col-sm-6 col-md-3">
      <div class="thumbnail">
         <img src="/Images/Clayton.jpg" 
         alt="">
         <div class="caption">
            <h3>Clayton</h3>
            <p>Clayton is a suburb in Melbourne, Victoria, Australia, 19 km south-east of Melbourne's central business district.　　　　　　　　　　　　　　　　　<br /></p>

            <p>
               <a href="https://en.wikipedia.org/wiki/Clayton,_Victoria" class="btn btn-primary" role="button">
                   More details
               </a> 
               <a href="#" class="btn btn-default" role="button" data-toggle="modal" data-target="#myModal">
                  Like ♡
               </a>
            </p>
         </div>
      </div>
   </div>
   <div class="col-sm-6 col-md-3">
      <div class="thumbnail">
         <img src="/Images/Carnegie.jpg" 
         alt="">
         <div class="caption">
            <h3>Carnegie</h3>
            <p>Carnegie is a suburb in Melbourne, Victoria, Australia, 12 km south-east from Melbourne's central business district.</p>
            <p>
               <a href="https://en.wikipedia.org/wiki/Carnegie,_Victoria" class="btn btn-primary" role="button">
                  More details
               </a> 
               <a href="#" class="btn btn-default" role="button" data-toggle="modal" data-target="#myModal">
                  Like ♡
               </a>
            </p>
         </div>
      </div>
   </div>
   <div class="col-sm-6 col-md-3">
      <div class="thumbnail">
         <img src="/Images/MalvernEast.jpg" 
         alt="">
         <div class="caption">
            <h3>Malvern East</h3>
            <p>Malvern East is a suburb of Melbourne, Victoria, Australia, 12 km south-east of Melbourne's Central Business District.</p>
            <p>
               <a href="https://en.wikipedia.org/wiki/Malvern_East,_Victoria" class="btn btn-primary" role="button">
                  More details
               </a> 
               <a href="#" class="btn btn-default" role="button" data-toggle="modal" data-target="#myModal">
                  Like ♡
               </a>
            </p>
         </div>
      </div>
   </div>
</div>

    <br />
    <br />

    <div class="row">
   <div class="col-sm-6 col-md-3">
      <div class="thumbnail">
         <img src="/Images/toorak.jpg" 
         alt="">
         <div class="caption">
            <h3>Toorak</h3>
            <p>Toorak is a suburb of Melbourne, Victoria, Australia, 5 km south-east from Melbourne's Central Business District. </p>
            <p>
               <a href="https://en.wikipedia.org/wiki/Toorak,_Victoria" class="btn btn-primary" role="button">
                  More details
               </a> 
               <a href="#" class="btn btn-default" role="button" data-toggle="modal" data-target="#myModal">
                 Like ♡
               </a>
            </p>
         </div>
      </div>
   </div>
   <div class="col-sm-6 col-md-3">
      <div class="thumbnail">
         <img src="/Images/skkilda.jpg" 
         alt="">
         <div class="caption">
            <h3>St Kilda</h3>
            <p>St Kilda is a suburb (neighborhood) of the metropolitan area of Melbourne, Victoria, Australia, 6 km south-east of Melbourne's Central Business District. </p>
            <p>
               <a href="https://en.wikipedia.org/wiki/St_Kilda,_Victoria" class="btn btn-primary" role="button">
                  More details
               </a> 
               <a href="#" class="btn btn-default" role="button" data-toggle="modal" data-target="#myModal">
                 Like ♡
               </a>
            </p>
         </div>
      </div>
   </div>
   <div class="col-sm-6 col-md-3">
      <div class="thumbnail">
         <img src="/Images/Burwood.jpg" 
         alt="">
         <div class="caption">
            <h3>Burwood</h3>
            <p>Burwood is a suburb of Melbourne, Victoria, Australia, 14 km east of Melbourne's Central Business District.　　　　　　　　　　</p>
            <p>
               <a href="https://en.wikipedia.org/wiki/Burwood,_Victoria" class="btn btn-primary" role="button">
                  More details
               </a> 
               <a href="#" class="btn btn-default" role="button" data-toggle="modal" data-target="#myModal">
                  Like ♡
               </a>
            </p>
         </div>
      </div>
   </div>
   <div class="col-sm-6 col-md-3">
      <div class="thumbnail">
         <img src="/Images/Camberwell.jpg" 
         alt="">
         <div class="caption">
            <h3>Camberwell</h3>
            <p>Camberwell is a suburb of Melbourne, Victoria, Australia, 10 km east of Melbourne's Central Business District.　　　　　　</p>
            <p>
               <a href="https://en.wikipedia.org/wiki/Camberwell,_Victoria" class="btn btn-primary" role="button">
                 More details
               </a> 
               <a href="#" class="btn btn-default" role="button" data-toggle="modal" data-target="#myModal">
                  Like ♡
               </a>
            </p>
         </div>
      </div>
   </div>
</div>

</asp:Content>
