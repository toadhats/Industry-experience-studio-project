<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Where2Next._Default" %>

<asp:Content ContentPlaceHolderID="extraHeadContent" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,800italic,700italic,600italic,400italic,300italic,800,700,600' rel='stylesheet' type='text/css'>

    <link href="Content/css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="Content/css/style.css" rel="stylesheet" type="text/css">
    <link href="Content/css/font-awesome.css" rel="stylesheet" type="text/css">
    <link href="Content/css/responsive.css" rel="stylesheet" type="text/css">
    <link href="Content/css/animate.css" rel="stylesheet" type="text/css">

    <script type="text/javascript" src="Scripts/js/jquery.1.8.3.min.js"></script>
    <script type="text/javascript" src="Scripts/js/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/js/jquery-scrolltofixed.js"></script>
    <script type="text/javascript" src="Scripts/js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="Scripts/js/jquery.isotope.js"></script>
    <script type="text/javascript" src="Scripts/js/wow.js"></script>
    <script type="text/javascript" src="Scripts/js/classie.js"></script>

    <script type="text/javascript">
        $(document).ready(function (e) {
            $('#test').scrollToFixed();
            $('.res-nav_click').click(function () {
                $('.main-nav').slideToggle();
                return false

            });

        });
    </script>

    <script>
        wow = new WOW(
          {
              animateClass: 'animated',
              offset: 100
          }
        );
        wow.init();
    </script>

    <script type="text/javascript">
        $(window).load(function () {

            $('.main-nav li a').bind('click', function (event) {
                var $anchor = $(this);

                $('html, body').stop().animate({
                    scrollTop: $($anchor.attr('href')).offset().top - 102
                }, 1500, 'easeInOutExpo');
                /*
                if you don't want to use the easing effects:
                $('html, body').stop().animate({
                    scrollTop: $($anchor.attr('href')).offset().top
                }, 1000);
                */
                event.preventDefault();
            });
        })
    </script>

    <script type="text/javascript">

        $(window).load(function () {

            var $container = $('.portfolioContainer'),
                $body = $('body'),
                colW = 375,
                columns = null;

            $container.isotope({
                // disable window resizing
                resizable: true,
                masonry: {
                    columnWidth: colW
                }
            });

            $(window).smartresize(function () {
                // check if columns has changed
                var currentColumns = Math.floor(($body.width() - 30) / colW);
                if (currentColumns !== columns) {
                    // set new column count
                    columns = currentColumns;
                    // apply width to container manually, then trigger relayout
                    $container.width(columns * colW)
                      .isotope('reLayout');
                }

            }).smartresize(); // trigger resize to set container width
            $('.portfolioFilter a').click(function () {
                $('.portfolioFilter .current').removeClass('current');
                $(this).addClass('current');

                var selector = $(this).attr('data-filter');
                $container.isotope({

                    filter: selector,
                });
                return false;
            });

        });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!doctype html>
    <html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, maximum-scale=1">
        <title>Homepage</title>
    </head>
    <body>
        <div style="overflow: hidden;">
            <header class="header" id="header">
                <!--header-start-->
                <div class="container">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <%-- <figure class="logo animated fadeInDown delay-07s">
                        <a href="#">
                            <img src="Images/house250px.png" alt=""></a>
                    </figure>--%>
                    <h1 class="animated fadeInDown delay-07s">Welcome To Where2Next</h1>
                    <ul class="we-create animated fadeInUp delay-1s">
                        <li>Our aim is to help you find the perfect place to live!</li>
                    </ul>
                    <a class="link animated fadeInUp delay-1s" href="QuizCategories.aspx">Get Started</a>
                </div>
        </div>
        </header>
        <!--header-end-->

        <%--<nav class="main-nav-outer" id="test">
            <!--main-nav-start-->
            <div class="container">
                <ul class="main-nav">
                    <li><a href="#header">Top</a></li>
                    <li><a href="#service">Discover</a></li>
                    <li><a href="#Portfolio">Profile</a></li>
                    <li class="small-logo"><a href="#header">
                        <img src="Images/Logos/w2n%20logo%20house%20only%20[100px].png" alt=""></a></li>

                    <li><a href="#client">Map</a></li>
                    <li><a href="#team">About Us</a></li>
                    <li><a href="#contact">Contact Us</a></li>
                </ul>
                <a class="res-nav_click" href="#"><i class="fa-bars"></i></a>
            </div>
        </nav>--%>
        <!--main-nav-end-->

        <section class="main-section" id="service">
            <!--main-section-start-->
            <div class="container">
                <h2><a href="QuizCategories.aspx">Discover</a></h2>
                <h6>The Discover function helps you to discover your perfect suburbs.</h6>
                <div class="row">
                    <div class="col-lg-4 col-sm-6 wow fadeInLeft delay-05s">
                        <%--<div class="service-list">
                            <div class="service-list-col1">
                                <i class="fa-paw"></i>
                            </div>
                            <div class="service-list-col2">
                                <h3>Quiz Function 1</h3>
                                <p>...</p>
                            </div>
                        </div>--%>
                        <div class="service-list">
                            <div class="service-list-col1">
                                <i class="fa-gear"></i>
                            </div>
                            <div class="service-list-col2">
                                <h3>Discover Step  1</h3>
                                <p>Choose your favourite categories</p>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="service-list">
                            <div class="service-list-col1">
                                <i class="fa-gear"></i>
                            </div>
                            <div class="service-list-col2">
                                <h3>Discover Step 2</h3>
                                <p>Have a look on the results</p>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="service-list">
                            <div class="service-list-col1">
                                <i class="fa-gear"></i>
                            </div>
                            <div class="service-list-col2">
                                <h3>Discover Step 3</h3>
                                <p>Search Again?</p>
                            </div>
                        </div>
                    </div>
                    <figure class="col-lg-8 col-sm-6  text-right wow fadeInUp delay-02s">

                        <iframe width="560" height="315" src="https://www.youtube.com/embed/z4JWujzg9uU" frameborder="0" allowfullscreen></iframe>
                    </figure>
                </div>
            </div>
        </section>
        <!--main-section-end-->

        <section class="main-section paddind" id="Portfolio">
            <!--main-section-start-->
            <div class="container clearfix">
                <h2><a href="SuburbProfile">Profile</a></h2>
                <h6>Profile helps you to get to know Victoria.</h6>
            </div>
            <div class="portfolioContainer wow fadeInUp delay-04s clearfix">
                <div class=" Portfolio-box printdesign">
                    <a href="SuburbProfile?query=caulfield">
                        <img src="Images/Caulfield.jpg" alt=""></a>
                    <h3>Caulfield</h3>
                    <%--<p>Print Design</p>--%>
                </div>
                <div class="Portfolio-box webdesign clearfix">
                    <a href="SuburbProfile?query=clayton">
                        <img src="Images/Clayton.jpg" alt=""></a>
                    <h3>Clayton</h3>
                    <%--<p>Web Design</p>--%>
                </div>
                <div class=" Portfolio-box branding clearfix">
                    <a href="SuburbProfile?query=carnegie">
                        <img src="Images/Carnegie.jpg" alt=""></a>
                    <h3>Carnegie</h3>
                    <%--<p>Branding</p>--%>
                </div>
                <div class=" Portfolio-box photography clearfix">
                    <a href="SuburbProfile?query=malvern east">
                        <img src="Images/MalvernEast.jpg" alt=""></a>
                    <h3>Malvern East</h3>
                    <%--<p>Photography</p>--%>
                </div>
                <div class=" Portfolio-box branding clearfix">
                    <a href="SuburbProfile?query=st kilda">
                        <img src="Images/StKilda.jpg" alt=""></a>
                    <h3>St Kilda</h3>
                    <%--<p>Branding</p>--%>
                </div>
                <div class=" Portfolio-box photography clearfix">
                    <a href="SuburbProfile?query=toorak">
                        <img src="Images/Toorak.jpg" alt=""></a>
                    <h3>Toorak</h3>
                    <%--<p>Photography</p>--%>
                </div>
            </div>
        </section>
        <!--main-section-end-->

        <section class="main-section client-part clearfix" id="client">
            <!--main-section client-part-start-->
            <div class="container clearfix">
                <%--<b class="quote-right wow fadeInDown delay-03"><i class="fa-quote-right"></i></b>
                <div class="row">
                    <div class="col-lg-12">
                        <p class="client-part-haead wow fadeInDown delay-05">Search on Our Maps!</p>
                    </div>
                </div>--%>
                <h2><a href="Map.aspx">Map</a></h2>
                <h6>Search on Our Map!</h6>
                <ul class="client wow fadeIn delay-05s">
                    <li><a href="Map.aspx">
                        <img src="Images/letsmoveto.png" alt="">
                        <%--  <h3>James Bond</h3>
                <span>License To Drink Inc.</span>--%>
                    </a></li>
                </ul>
            </div>
        </section>
        <!--main-section client-part-end-->
        <%--<div class="c-logo-part"><!--c-logo-part-start-->
	<div class="container">
    	<ul>
        	<li><a href="#"><img src="Images/img/c-liogo1.png" alt=""></a></li>
            <li><a href="#"><img src="Images/img/c-liogo2.png" alt=""></a></li>
            <li><a href="#"><img src="Images/img/c-liogo3.png" alt=""></a></li>
            <li><a href="#"><img src="Images/img/c-liogo4.png" alt=""></a></li>
            <li><a href="#"><img src="Images/img/c-liogo5.png" alt=""></a></li>
    	</ul>
	</div>
</div><!--c-logo-part-end-->--%>

        <section class="main-section team" id="team">
            <!--main-section team-start-->
            <div class="container">
                <h2>About Us</h2>
                <h6>Truss is a student team which provide reliable products.</h6>
                <div class="team-leader-block clearfix">
                    <div class="team-leader-box">
                        <div class="team-leader wow fadeInDown delay-03s">
                            <div class="team-leader-shadow"><a href="#"></a></div>
                            <img src="Images/Jonathan.jpg" alt="">
                            <ul>
                                <li><a href="#" class="fa-twitter"></a></li>
                                <li><a href="#" class="fa-facebook"></a></li>
                                <%--<li><a href="#" class="fa-pinterest"></a></li>
                                <li><a href="#" class="fa-google-plus"></a></li>--%>
                            </ul>
                        </div>
                        <h3 class="wow fadeInDown delay-03s">Jonathan Warner</h3>
                        <span class="wow fadeInDown delay-03s">Programmer</span>
                             <p class="wow fadeInDown delay-03s">limule@icloud.com</p>
                    </div>
                    <div class="team-leader-box clearfix">
                        <div class="team-leader  wow fadeInDown delay-06s">
                            <div class="team-leader-shadow"><a href="#"></a></div>
                            <img src="Images/Rongda.jpg" alt="">
                            <ul>
                                <li><a href="#" class="fa-twitter"></a></li>
                                <li><a href="#" class="fa-facebook"></a></li>
                                <%--<li><a href="#" class="fa-pinterest"></a></li>
                                <li><a href="#" class="fa-google-plus"></a></li>--%>
                            </ul>
                        </div>
                        <h3 class="wow fadeInDown delay-06s">Rongda Xu</h3>
                        <span class="wow fadeInDown delay-06s">Programmer</span>
                        <p class="wow fadeInDown delay-06s">xurongda6@gamil.com</p>
                    </div>
                    <div class="team-leader-box clearfix">
                        <div class="team-leader wow fadeInDown delay-09s">
                            <div class="team-leader-shadow"><a href="#"></a></div>
                            <img src="Images/Chen.jpg" alt="">
                            <ul>
                                <li><a href="#" class="fa-twitter"></a></li>
                                <li><a href="#" class="fa-facebook"></a></li>
                                <%--<li><a href="#" class="fa-pinterest"></a></li>
                                <li><a href="#" class="fa-google-plus"></a></li>--%>
                            </ul>
                        </div>
                        <h3 class="wow fadeInDown delay-09s">Chen Zhou</h3>
                        <span class="wow fadeInDown delay-09s">UI & Database</span>
                         <p class="wow fadeInDown delay-09s">zhouc0528@163.com</p>
                    </div>
                    <div class="team-leader-box clearfix">
                        <div class="team-leader wow fadeInDown delay-09s">
                            <div class="team-leader-shadow"><a href="#"></a></div>
                            <img src="Images/Sheng.jpg" alt="">
                            <ul>
                                <li><a href="#" class="fa-twitter"></a></li>
                                <li><a href="#" class="fa-facebook"></a></li>
                                <%--<li><a href="#" class="fa-pinterest"></a></li>
                                <li><a href="#" class="fa-google-plus"></a></li>--%>
                            </ul>
                        </div>
                        <h3 class="wow fadeInDown delay-09s">Sheng Mao</h3>
                        <span class="wow fadeInDown delay-09s">Design</span>
                        <p class="wow fadeInDown delay-09s">maosheng421@gmail.com</p>
                    </div>
                    <div class="team-leader-box clearfix">
                        <div class="team-leader wow fadeInDown delay-09s">
                            <div class="team-leader-shadow"><a href="#"></a></div>
                            <img src="Images/Ulupi.jpg" alt="">
                            <ul>
                                <li><a href="#" class="fa-twitter"></a></li>
                                <li><a href="#" class="fa-facebook"></a></li>
                                <%--<li><a href="#" class="fa-pinterest"></a></li>
                                <li><a href="#" class="fa-google-plus"></a></li>--%>
                            </ul>
                        </div>
                        <h3 class="wow fadeInDown delay-09s">Ulupi Udaya</h3>
                        <span class="wow fadeInDown delay-09s">Documentation</span>
                        <p class="wow fadeInDown delay-09s">ulupiuday@gmail.com</p>
                    </div>
                </div>
            </div>
        </section>
        <!--main-section team-end-->

        <section class="business-talking">
            <!--business-talking-start-->
            <div class="container">
                <h2>Contact Us</h2>
                <%--<h6>Tell us if you have any feedbacks!</h6>--%>
            </div>
        </section>
        <!--business-talking-end-->
        <div class="container">
            <section class="main-section contact" id="contact">

                <div class="row">
                    <div class="col-lg-6 col-sm-7 wow fadeInLeft">
                        <div class="contact-info-box address clearfix">
                            <h3><i class=" icon-map-marker"></i>Address:</h3>
                            <span>900 Dandenong Rd, Caulfield East VIC 3145</span>
                        </div>
                        <div class="contact-info-box phone clearfix">
                            <h3><i class="fa-phone"></i>Phone:</h3>
                            <span>(03) 9903 2000</span>
                        </div>
                        <div class="contact-info-box email clearfix">
                            <h3><i class="fa-pencil"></i>Website:</h3>
                            <span>monash.edu.au</span>
                        </div>
                        <%--<div class="contact-info-box hours clearfix">
                	<h3><i class="fa-clock-o"></i>Hours:</h3>
                	<span><strong>Monday - Thursday:</strong> 10am - 6pm<br><strong>Friday:</strong> People work on Fridays now?<br><strong>Saturday - Sunday:</strong> Best not to ask.</span>
                </div>--%>
                        <ul class="social-link">
                            <li class="twitter"><a href="https://twitter.com/Where2nextTruss"><i class="fa-twitter"></i></a></li>
                            <li class="facebook"><a href="https://www.facebook.com/where2next.truss"><i class="fa-facebook"></i></a></li>
                            <%--<li class="pinterest"><a href="#"><i class="fa-pinterest"></i></a></li>--%>
                            <li class="gplus"><a href="https://plus.google.com/u/0/106262326426235513979"><i class="fa-google-plus"></i></a></li>
                            <%--<li class="dribbble"><a href="#"><i class="fa-dribbble"></i></a></li>--%>
                        </ul>
                    </div>
                    <div class="col-lg-6 col-sm-5 wow fadeInUp delay-05s">
                        <div class="form">
                            <img src="Images/Monash.jpg" />
                            <%--<input class="input-text" id="e-name" type="text" name="" value="Your Name *" onfocus="if(this.value==this.defaultValue)this.value='';" onblur="if(this.value=='')this.value=this.defaultValue;">
                            <input class="input-text" id="e-email" type="text" name="" value="Your E-mail *" onfocus="if(this.value==this.defaultValue)this.value='';" onblur="if(this.value=='')this.value=this.defaultValue;">
                            <textarea class="input-text text-area" id="e-message" cols="0" rows="0" onfocus="if(this.value==this.defaultValue)this.value='';" onblur="if(this.value=='')this.value=this.defaultValue;">Your Message *</textarea>
                            <input class="input-btn" type="submit" value="send message">--%>
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <footer class="footer">
            <div class="container">

                <span class="copyright">Copyright © 2015 | <a href="http://bootstraptaste.com/">Bootstrap Themes</a> by BootstrapTaste</span>
            </div>
            <!--
        All links in the footer should remain intact.
        Licenseing information is available at: http://bootstraptaste.com/license/
        You can buy this theme without footer links online at: http://bootstraptaste.com/buy/?theme=Knight
    -->
        </footer>
    </body>
    </html>
</asp:Content>
