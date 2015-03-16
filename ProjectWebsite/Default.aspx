<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectWebsite.Default" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mathos Parser</title>
    <style type="text/css">
        body
        {
            font-family:Arial;
        }

        #parserInput
        {
            margin:auto;
            padding:auto;
            display:block;
            border:1px black solid;
            width:450px;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Calc_onclick() {
            window.location.href = "?expression=" + encodeURIComponent(text.value);
        }

// ]]>
    </script>
</head>
<body>

    
    <div id="parserInput">
    <p style="font-family:Arial; text-align:center; font-size:20px;padding-top:5px;color:Blue;">
    Mathos Parser
    </p>
    <input type="text" 
            style="display:block;width:395px; margin-left:5px; float:left; font-family:Consolas; font-size:16px;" 
            runat="server" id="text" onkeydown="if (event.keyCode == 13) { Calc_onclick();}" />
    <input type="button" value="Go!" style="float:right;" id="Calc" runat="server" onclick="return Calc_onclick()" />
    <div style="clear:both;"></div>
   <br />
    <div style=" margin:5px; font-family:Consolas; font-size:16px; display:block;" id="result" runat="server"></div>
    </div>

    <div style="text-align: center; font-family: Arial;" ><h6>Copyright &copy; 2012-2013 <a href="http://artemlos.net/">Artem Los</a></h6></div>

    <div style="position:absolute; top:0; left:0;"><ul><li><a href="http://parser.mathosproject.com/?expression=table(3x%2C%200%2C%2010)">table(3x, 0, 10)</a></li>
    <li><a href="http://parser.mathosproject.com/?expression=sum(3x%2C%200%2C%2010)">sum(3x, 0, 10)</a></li><li><a href="http://parser.mathosproject.com/?expression=d(3x%5E2%2C%209)">d(3x^2, 9)</a>
    </li><li><a href="http://parser.mathosproject.com/?expression=decbin(991)">decbin(991)</a></li><li><a href="http://parser.mathosproject.com/?expression=bindec(111010)">bindec(111010)</a></li><li><a href="http://mathosproject.com/wiki/mathos-parser/mathos-parser-web-app/">and more!</a></li>
    </ul></div>

</body>

</html>
