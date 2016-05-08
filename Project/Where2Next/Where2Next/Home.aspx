<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Where2Next.Home1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/js/home.js"></script>
    <link href="Content/home.css" rel="stylesheet" type="text/css" />
</head>
<body style="width: 100%; height: 100%; margin: 0; padding: 0" onmouseup="stopMove();" onresize="windowResize();">

        <div id="starsContainer" onmousedown="startMove();" onmouseup="stopMove();">
            <div id="stars" onmousedown="startMove();" onmouseup="stopMove();">
            </div>
        </div>

        <div id="sun" onmousedown="startMove();" onmouseup="stopMove();">
        </div>

        <div id="sunDay" onmousedown="startMove();" onmouseup="stopMove();">
        </div>

        <div id="sunSet" onmousedown="startMove();" onmouseup="stopMove();">
        </div>

        <div id="sky" onmousedown="startMove();" onmouseup="stopMove();">
        </div>

        <div class="star" style="left: 250px; top: 30px;"></div>
        <div class="star" style="left: 300px; top: 25px;"></div>
        <div class="star" style="right: 40px; top: 40px;"></div>
        <div class="star" style="right: 80px; top: 45px;"></div>
        <div class="star" style="right: 120px; top: 20px;"></div>

        <div id="horizon" onmousedown="startMove();" onmouseup="stopMove();"></div>

        <div id="horizonNight" onmousedown="startMove();" onmouseup="stopMove();"></div>

        <div id="moon" onmousedown="startMove();" onmouseup="stopMove();"></div>

        <div id="mountainRange">
            <div id="mountain" onmousedown="startMove();" onmouseup="stopMove();">
            </div>

        </div>

        <div id="division" onmousedown="startDraggingDivision();" onmouseup="stopMove();"> 
           <button id="startbtn" onclick="javascript:window.location.href='Default.aspx';" 
               style="background-color: transparent; position:absolute;left:50%;margin-left:-250px;top:50%; font-family:Courier New, Courier, monospace;
font-size:80px;color:white;width:300px; height:150px; 
border:none; cursor:pointer;">Start!</button>
            <%--<input id="start" type="button"  onclick="location.href = 'Default.aspx'" />--%>
            <%--<a href='Default.aspx' class='button'>ENTER SITE</a>--%>
        </div>
    


        <div id="water" onmousedown="startMove();" onmouseup="stopMove();"></div>

        <div id="waterReflectionContainer" onmousedown="startMove();" onmouseup="stopMove();">
            <div id="waterReflectionMiddle" onmousedown="startMove();" onmouseup="stopMove();">
            </div>
        </div>
        <div id="waterDistance" onmousedown="startMove();" onmouseup="stopMove();"></div>
        <div id="darknessOverlaySky" onmousedown="startMove();" onmouseup="stopMove();"></div>
        <div id="darknessOverlay"></div>
        <div id="oceanRippleContainer">
        </div>
        <div id="oceanRipple"></div>
    </body>
</html>
